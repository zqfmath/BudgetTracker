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
    public class IncomeController : ControllerBase
    {
        private readonly IIncomeService _incomeService;
        private readonly IUserService _userService;
        public IncomeController(IIncomeService incomeService, IUserService userService)
        {
            _incomeService = incomeService;
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> AddIncome([FromBody] IncomeAddModel requestModel)
        {
            if (!ModelState.IsValid) return BadRequest("Please check data");
            if (requestModel.UserId != null)
            {
                var isExist = await _userService.ExistUser(requestModel.UserId.Value);
                if (!isExist) return BadRequest("User Not Found");
            }
            bool result = await _incomeService.AddIncome(requestModel);
            return Ok(result);
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllIncomes()
        {
            var incomes = await _incomeService.GetAllIncomes();
            return Ok(incomes);

        }

        [HttpGet]
        [Route("user/{userId:int}")]
        public async Task<IActionResult> GetAllIncomesByUserId(int userId)
        {
            var incomes = await _incomeService.GetIncomeByUserId(userId);
            return Ok(incomes);

        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetIncomeById(int id)
        {
            var income = await _incomeService.GetIncomeById(id);
            if (income != null)
            {
                return Ok(income);
            }
            return NotFound("Income Not Found");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateIncome([FromBody] IncomeUpdateModel RequestModel)
        {
            if (!ModelState.IsValid) return BadRequest("Please check data");
            var isExist = await _incomeService.ExistIncome(RequestModel.Id);
            if (!isExist) return NotFound("Income Not Found");
            var result = await _incomeService.UpdateIncome(RequestModel);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteIncomeById(int id)
        {
            var isExist = await _incomeService.ExistIncome(id);
            if (!isExist) return NotFound("Income Not Found");
            var result = await _incomeService.DeleteIncomeById(id);
            return Ok(result);
        }


    }
}
