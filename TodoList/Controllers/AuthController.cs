using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TodoList.Business.Abstract;
using TodoList.Entities.Models;

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
            return _authService.CreateUser(User);
        }

        [HttpPost("Login")]
        public LoginResponseModel Login(LoginRequestModel ReqModel)
        {
            return _authService.LoginUser(ReqModel);
        }

        [HttpPost("Activate")]
        public UserAuthModel ActivateUser(UserIdModel User)
        {
            return _authService.ActivateUser(User.UserID);
        }

        [HttpPut("{id}")]
        public UserAuthModel Put(int id,UserAuthModel User)
        {
            return _authService.UpdateUser(id,User);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _authService.RemoveUser(id);
        }

        [HttpPatch("{id}")]
        public UserAuthModel Patch(int id,UserAuthModel User)
        {
            return _authService.UpdateUser(id, User);
        }

    }
}
