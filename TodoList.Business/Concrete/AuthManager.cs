using System;
using System.Collections.Generic;
using System.Text;
using TodoList.Business.Abstract;
using TodoList.DataAccess.Abstract;
using TodoList.Entities.Models;
using TodoList.Business.utils;

namespace TodoList.Business.Concrete
{
    public class AuthManager : IAuthService
    {

        private IUserAuthRepository _userAuthRepository;
        public AuthManager(IUserAuthRepository authRepo)
        {
            _userAuthRepository = authRepo;
        }

        public UserAuthModel ActivateUser(int id)
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
    }
}
