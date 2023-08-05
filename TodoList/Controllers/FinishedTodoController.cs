using Microsoft.AspNetCore.Mvc;
using TodoList.DataAccess.Concrete;
using TodoList.Entities.Models;

namespace TodoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinishedTodoController : BaseMongoController<FinTodoMongoModel>
    {
        public FinishedTodoController(BaseMongoRepository<FinTodoMongoModel> baseMongoRepository) : base(baseMongoRepository)
        {
        }
    }
}