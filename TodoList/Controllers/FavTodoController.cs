using Microsoft.AspNetCore.Mvc;
using TodoList.DataAccess.Concrete;
using TodoList.Entities.Models;

namespace TodoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavTodoController : BaseMongoController<FavTodoMongoModel>
    {
        public FavTodoController(BaseMongoRepository<FavTodoMongoModel> baseMongoRepository) : base(baseMongoRepository)
        {
        }
    }
}