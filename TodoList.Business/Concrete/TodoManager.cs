using System;
using System.Collections.Generic;
using System.Text;
using TodoList.Business.Abstract;
using TodoList.DataAccess.Abstract;
using TodoList.Entities.Models;

namespace TodoList.Business.Concrete
{
    public class TodoManager : ITodoService
    {
        private ITodoRepository _todoRepository;

        public TodoManager(ITodoRepository repo)
        {
            _todoRepository = repo;
        }

        public TodoModel AddTodo(TodoModel Todo)
        {
            return _todoRepository.AddTodo(Todo);
        }

        public TodoModel FavTodo(TodoIdModel IdModel)
        {
            return _todoRepository.FavTodo(IdModel);
        }

        public TodoModel FinishedTodo(TodoIdModel IdModel)
        {
            return _todoRepository.FinishedTodo(IdModel);
        }

        public List<TodoModel> GetAllTodos(int UserID)
        {
            return _todoRepository.GetAllTodos(UserID);
        }

        public TodoModel GetTodoByID(int TodoID)
        {
            return _todoRepository.GetTodoByID(TodoID);
        }

        public void RemoveTodo(int TodoID)
        {
           _todoRepository.RemoveTodo(TodoID);
        }

        public TodoModel UpdateTodo(TodoModel Todo)
        {
            return _todoRepository.UpdateTodo(Todo);
        }
    }
}
