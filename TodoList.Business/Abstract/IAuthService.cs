using System;
using System.Collections.Generic;
using System.Text;
using TodoList.Entities.Models;

namespace TodoList.Business.Abstract
{
    public interface IAuthService
    {
        LoginResponseModel CreateUser(UserAuthModel User);
        LoginResponseModel LoginUser(LoginRequestModel ReqModel);
        UserAuthModel GetUserById(int id);
        void RemoveUser(int id);
        UserAuthModel UpdateUser(int id, UserAuthModel User);
        LoginResponseModel ActivateUser(int id);
    }
}
