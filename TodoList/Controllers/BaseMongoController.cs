using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TodoList.DataAccess.Concrete;
using TodoList.Entities.Models;

namespace TodoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseMongoController<TModel> : ControllerBase
        where TModel : MongoBaseModel
    {
        public BaseMongoRepository<TModel> BaseMongoRepository { get; set; }

        public BaseMongoController(BaseMongoRepository<TModel> baseMongoRepository)
        {
            BaseMongoRepository = baseMongoRepository;
        }

        [HttpGet("elements/{id}")]
        public IEnumerable<TModel> Get(int id)
        {
            return BaseMongoRepository.GetAllTodos(id);
        }


        [HttpGet("element/{id}")]
        public TModel GetByID(int id)
        {
            return BaseMongoRepository.GetTodoByID(id);
        }


        [HttpPost]
        public TModel Post(TModel Todo)
        {
            return BaseMongoRepository.AddTodo(Todo);
        }


        [HttpPut]
        public TModel Put(TModel Todo)
        {
            return BaseMongoRepository.UpdateTodo(Todo);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            BaseMongoRepository.RemoveTodo(id);
        }

        [HttpPut("finished")]
        public TModel Finished(TodoIdModel IdModel)
        {
            return BaseMongoRepository.Finished(IdModel.TodoID);
        }

        [HttpPut("favorited")]
        public TModel Favorited(TodoIdModel IdModel)
        {
            return BaseMongoRepository.Fav(IdModel.TodoID);
        }

    }
}
