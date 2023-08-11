using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TodoList.DataAccess.Abstract;
using TodoList.Entities.Models;
using TodoList.Entities.Models.ReqModels;
using TodoList.Entities.Models.ResModels;

namespace TodoList.DataAccess.Concrete
{
    public class UserAuthRepository : IUserAuthRepository
    {
        private DbContext authDbContext;
        private DbSet<UserAuthModel> Dbset;
        public UserAuthRepository(DbContext context)
        {
            authDbContext = context;
            Dbset = context.Set<UserAuthModel>();
        }

        public LoginResponseModel CreateUser(UserAuthModel User)
        {
            LoginResponseModel ResModel = new LoginResponseModel();
            Dbset.Add(User);
            authDbContext.SaveChanges();

            ResModel.UserId = User.UserID;
            ResModel.HasAccess = true;
            return ResModel;
        }

        public LoginResponseModel LoginUser(LoginRequestModel ReqModel)
        {
            LoginResponseModel ResModel = new LoginResponseModel();
            UserAuthModel user = Dbset.FirstOrDefault(
                u => u.Username == ReqModel.Username
                && u.Password == ReqModel.Password);
            if (user != null)
            {
                ResModel.UserId = user.UserID;
                ResModel.HasAccess = true;
                return ResModel;
            }
            return ResModel;
        }

        public UserAuthModel GetUserById(int id)
        {
            UserAuthModel User = Dbset.Find(id);
            if (User.IsActive)
                return User;
            return null;
        }

        public void RemoveUser(int id)
        {
            UserAuthModel User = GetUserById(id);
            User.IsActive = false;
            Dbset.Update(User);
            authDbContext.SaveChanges();
        }

        public UserAuthModel UpdateUser(int id, UserAuthModel User)
        {
            Dbset.Update(User);
            authDbContext.SaveChanges();
            return User;
        }

        public LoginResponseModel ActivateUser(int id)
        {
            LoginResponseModel Res = new LoginResponseModel();
            UserAuthModel User = Dbset.FirstOrDefault(user => user.UserID == id);
            User.IsActive = true;
            Res.HasAccess = true;
            Res.UserId = id;

            Dbset.Update(User);
            authDbContext.SaveChanges();
            return Res;
        }

        public EditUserResModel EditUser(EditUserReqModel User)
        {
            EditUserResModel Res = new EditUserResModel();
            UserAuthModel _user = GetUserById(User.UserID);

            var searchedUser = Dbset.FirstOrDefault(x => x.Username == User.Username);

            if (searchedUser == null)
            {
                _user.Username = User.Username;
                _user.Email = User.Email;

                Dbset.Update(_user);
                authDbContext.SaveChanges();
                Res.EditUserResponse = "Success";
                return Res;
            }
            else
            {
                Res.EditUserResponse = "Usernameoremailtaken";
                return Res;
            }
        }

        public ChangePasswordResModel ChangePassword(ChangePasswordReqModel User)
        {
            ChangePasswordResModel Res = new ChangePasswordResModel();
            UserAuthModel _user = GetUserById(User.UserID);

            if (_user.Password != User.NewPassword)
            {
                _user.Password = User.NewPassword;
                Dbset.Update(_user);
                authDbContext.SaveChanges();

                Res.ChangePasswordResponse = "Success";
            }
            else
            {
                Res.ChangePasswordResponse = "PasswordSame";
            }
            return Res;
        }
    }
}
