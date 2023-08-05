using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoList.Business.Abstract;
using TodoList.Entities.Models;

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


        [HttpPost("addTodo")]
        public TodoModel Post(TodoModel Todo)
        {
            return _todoService.AddTodo(Todo);
        }

        [HttpPut]
        public TodoModel Put(TodoModel Todo)
        {
            return _todoService.UpdateTodo(Todo);
        }

        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
           _todoService.RemoveTodo(id);
        }

        [HttpPut("finished")]
        public TodoModel FinishedTodo(TodoIdModel IdModel)
        {
            return _todoService.FinishedTodo(IdModel);
        }

        [HttpPut("favorited")]
        public TodoModel FavTodo(TodoIdModel IdModel)
        {
            return _todoService.FavTodo(IdModel);
        }
    }
}
