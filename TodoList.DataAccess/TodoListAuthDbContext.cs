using Microsoft.EntityFrameworkCore;
using TodoList.Entities.Models;
using MongoDB.Driver;
using MongoDB.Bson;

namespace TodoList.DataAccess
{
    public class TodoListAuthDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=GVY397; Database=TodoListDbV2; Integrated Security=SSPI; persist security info=True;");
        }

        public DbSet<UserAuthModel> Users { get; set; }

        public DbSet<TodoModel> Todos { get; set; }

        public DbSet<TodoUserModel> TodoUser { get; set; }
    }
}
