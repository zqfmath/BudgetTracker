using BudgetTracker.Core.Models.Request;
using BudgetTracker.Core.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenditureController : ControllerBase
    {
        private readonly IExpenditureService _expenditureService;
        private readonly IUserService _userService;
        public ExpenditureController(IExpenditureService expenditureService, IUserService userService)
        {
            _expenditureService = expenditureService;
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> AddExpenditure([FromBody] ExpenditureAddModel requestModel)
        {
            if (!ModelState.IsValid) return BadRequest("Please check data");

            if (requestModel.UserId != null)
            {
                var isExist = await _userService.ExistUser(requestModel.UserId.Value);
                if (!isExist) return BadRequest("User Not Found");
            }
            bool result = await _expenditureService.AddExpenditure(requestModel);
            return Ok(result);
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllExpenditures()
        {
            var expenditures = await _expenditureService.GetAllExpenditure();
            return Ok(expenditures);

        }

        [HttpGet]
        [Route("user/{userId:int}")]
        public async Task<IActionResult> GetAllExpendituresByUserId(int userId)
        {
            var expenditures = await _expenditureService.GetExpenditureByUserId(userId);
            return Ok(expenditures);

        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var expenditure = await _expenditureService.GetExpenditureById(id);
            if (expenditure != null)
            {
                return Ok(expenditure);
            }
            return NotFound("Expenditure Not Found");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateExpenditure([FromBody] ExpenditureUpdateModel RequestModel)
        {
            if (!ModelState.IsValid) return BadRequest("Please check data");
            var isExist = await _expenditureService.ExistExpenditure(RequestModel.Id);
            if (!isExist) return NotFound("Expenditure Not Found");
            var result = await _expenditureService.UpdateExpenditure(RequestModel);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteExpenditureById(int id)
        {
            var isExist = await _expenditureService.ExistExpenditure(id);
            if (!isExist) return NotFound("Expenditure Not Found");
            var result = await _expenditureService.DeleteExpenditureById(id);
            return Ok(result);
        }

       

    }
}
