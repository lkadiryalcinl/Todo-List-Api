using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TodoList.DataAccess.Abstract;
using TodoList.Entities.Models;

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
                && u.Password == ReqModel.Password
                && u.IsActive == true
                );
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

        public UserAuthModel ActivateUser(int id)
        {
            UserAuthModel User = Dbset.FirstOrDefault(user => user.UserID == id);
            User.IsActive = true;
            Dbset.Update(User);
            authDbContext.SaveChanges();
            return User;
        }
    }
}
