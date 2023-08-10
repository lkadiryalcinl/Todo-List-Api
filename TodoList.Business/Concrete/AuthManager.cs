using System;
using System.Collections.Generic;
using System.Text;
using TodoList.Business.Abstract;
using TodoList.DataAccess.Abstract;
using TodoList.Entities.Models;
using TodoList.Business.utils;
using TodoList.Entities.Models.ReqModels;
using TodoList.Entities.Models.ResModels;

namespace TodoList.Business.Concrete
{
    public class AuthManager : IAuthService
    {

        private IUserAuthRepository _userAuthRepository;
        public AuthManager(IUserAuthRepository authRepo)
        {
            _userAuthRepository = authRepo;
        }

        public LoginResponseModel ActivateUser(int id)
        {
            return _userAuthRepository.ActivateUser(id);
        }

        public LoginResponseModel CreateUser(UserAuthModel User)
        {
            User.Password = Utils.EncryptPassword(User.Password);
            return _userAuthRepository.CreateUser(User);
        }

        public UserAuthModel GetUserById(int id)
        {
            return _userAuthRepository.GetUserById(id);
        }

        public LoginResponseModel LoginUser(LoginRequestModel ReqModel)
        {
            ReqModel.Password = Utils.EncryptPassword(ReqModel.Password);
            return _userAuthRepository.LoginUser(ReqModel);
        }

        public void RemoveUser(int id)
        {
            _userAuthRepository.RemoveUser(id);
        }

        public UserAuthModel UpdateUser(int id, UserAuthModel User)
        {
            User.UserID = id;
            User.Password = Utils.EncryptPassword(User.Password);
            return _userAuthRepository.UpdateUser(id, User);
        }

        public string EditUser(EditUserReqModel User)
        {
            UserAuthModel _user = _userAuthRepository.GetUserById(User.UserID);

            if (_user.Password == Utils.EncryptPassword(User.ConfirmPassword))
                return _userAuthRepository.EditUser(User);
            return "PasswordWrong";
        }

        public string ChangePassword(ChangePasswordReqModel User)
        {
            UserAuthModel _user = _userAuthRepository.GetUserById(User.UserID);

            if (_user.Password == Utils.EncryptPassword(User.oldPassword))
            {
                User.NewPassword = Utils.EncryptPassword(User.NewPassword);
                return _userAuthRepository.ChangePassword(User);
            }
            return "PasswordWrong";
        }
    }
}
