using System;
using System.Collections.Generic;
using System.Text;
using TodoList.Entities.Models;
using TodoList.Entities.Models.ReqModels;
using TodoList.Entities.Models.ResModels;

namespace TodoList.DataAccess.Abstract
{
    public interface IUserAuthRepository
    {
        LoginResponseModel CreateUser(UserAuthModel User);
        LoginResponseModel LoginUser(LoginRequestModel ReqModel);
        UserAuthModel GetUserById(int id);
        void RemoveUser(int id);
        UserAuthModel UpdateUser(int id,UserAuthModel User);
        LoginResponseModel ActivateUser(int id);
        EditUserResModel EditUser(EditUserReqModel User);
        ChangePasswordResModel ChangePassword(ChangePasswordReqModel User);

    }
}
