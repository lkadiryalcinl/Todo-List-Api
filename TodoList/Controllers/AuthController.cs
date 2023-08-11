using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TodoList.Business.Abstract;
using TodoList.Entities.Models;
using TodoList.Entities.Models.ReqModels;
using TodoList.Entities.Models.ResModels;
using TodoList.validators;

namespace TodoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public string Get()
        {
            return "";
        }

        [HttpGet("{id}")]
        public UserAuthModel Get(int id)
        {
            return _authService.GetUserById(id);
        }

        [HttpPost("CreateAccount")]
        public LoginResponseModel CreateAccount(UserAuthModel User)
        {
            var signUpValidator = new SignUpValidator();
            var validationResult = signUpValidator.Validate(User);

            if (!validationResult.IsValid)
            {
                return null;
            }

            return _authService.CreateUser(User);
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginRequestModel ReqModel)
        {
            var loginValidator = new LoginValidator();
            var validationResult = loginValidator.Validate(ReqModel);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            return Ok(_authService.LoginUser(ReqModel));
        }

        [HttpPost("Activate")]
        public LoginResponseModel ActivateUser(UserIdModel User)
        {
            return _authService.ActivateUser(User.UserID);
        }

        [HttpPut("{id}")]
        public UserAuthModel Put(int id, UserAuthModel User)
        {
            return _authService.UpdateUser(id, User);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _authService.RemoveUser(id);
        }

        [HttpPatch("{id}")]
        public UserAuthModel Patch(int id, UserAuthModel User)
        {
            return _authService.UpdateUser(id, User);
        }

        [HttpPut("EditUser")]
        public EditUserResModel EditUser(EditUserReqModel User)
        {
            return _authService.EditUser(User);
        }

        [HttpPut("ChangePassword")]
        public ChangePasswordResModel ChangePassword(ChangePasswordReqModel User)
        {
            return _authService.ChangePassword(User);
        }

    }
}
