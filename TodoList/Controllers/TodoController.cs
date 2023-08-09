using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoList.Business.Abstract;
using TodoList.Entities.Models;
using TodoList.validators;

namespace TodoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private ITodoService _todoService;

        public TodoController(ITodoService service)
        {
            _todoService = service;
        }

        [HttpGet]
        public IEnumerable<TodoModel> GetAllTodos(int UserId)
        {
            return _todoService.GetAllTodos(UserId);
        }


        [HttpGet("{id}")]
        public TodoModel Get(int id)
        {
            return _todoService.GetTodoByID(id);
        }

        [HttpGet("favtodo/{id}")]
        public IEnumerable<TodoModel> GetFav(int id)
        {
            return _todoService.GetFavTodo(id);
        }

        [HttpGet("finishedtodo/{id}")]
        public IEnumerable<TodoModel> GetFinished(int id)
        {
            return _todoService.GetFinishedTodo(id);
        }

        [HttpPut]
        public void Put(TodoModel Todo)
        {
            _todoService.UpdateTodo(Todo);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
           _todoService.RemoveTodo(id);
        }

        [HttpPut("finished")]
        public void FinishedTodo(TodoIdModel IdModel)
        {
            _todoService.FinishedTodo(IdModel);
        }

        [HttpPut("favorited")]
        public void FavTodo(TodoIdModel IdModel)
        {
            _todoService.FavTodo(IdModel);
        }

        [HttpPost("addTodo")]
        public void Post(TodoModel Todo)
        {
            var todoValidator = new TodoValidator();
            var validationResult = todoValidator.Validate(Todo);

            if (!validationResult.IsValid)
            {
                return;
            }

            _todoService.AddTodo(Todo);
        }

    }
}
