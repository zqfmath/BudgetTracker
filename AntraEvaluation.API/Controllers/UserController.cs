using AutoMapper;
using BudgetTracker.Core.Models.Request;
using BudgetTracker.Core.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BudgetTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;
        private readonly IIncomeService _incomeService;
        private readonly IExpenditureService _expenditureService;
        public UserController(IUserService userService,IIncomeService incomeService,IExpenditureService expenditureService)
        {
            _userService = userService;
            _incomeService = incomeService;
            _expenditureService = expenditureService;
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] UserAddModel requestModel)
        {
            if (!ModelState.IsValid) return BadRequest("Please check data");
            var isExist = await _userService.ExistUser(requestModel.Email);
            if (isExist) return BadRequest("User Already Exists"); 
            bool result = await _userService .AddUser(requestModel);
            return Ok(result);
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);

        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound("User Not Found");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UserUpdateModel RequestModel)
        {
            if (!ModelState.IsValid) return BadRequest("Please check data");
            var isExist = await _userService.ExistUser(RequestModel.Id);
            if (!isExist) return NotFound("User Not Found");
            var isEmailExist= await _userService.ExistUser(RequestModel.Email);
            if (isEmailExist) return BadRequest("Email Already Occupied");
            var result = await _userService.UpdateUser(RequestModel);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteUserById(int id)
        {
  
            var isExist = await _userService.ExistUser(id);
            if (!isExist) return NotFound("User Not Found");
            await _expenditureService.DeleteExpenditureByUserId(id);
            await _incomeService.DeleteIncomeByUserId(id);
            var result = await _userService.DeleteUserById(id);
            return Ok(result);
        }

    }
}
