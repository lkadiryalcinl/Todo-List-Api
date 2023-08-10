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

        public void FavTodo(TodoIdModel IdModel)
        {
            _todoRepository.FavTodo(IdModel);
        }

        public void FinishedTodo(TodoIdModel IdModel)
        {
            _todoRepository.FinishedTodo(IdModel);
        }

        public List<TodoModel> GetAllTodos(int UserID)
        {
            var result = _todoRepository.GetAllTodos(UserID).FindAll(todo => todo.IsFinished == false);
            return result;
        }

        public List<TodoModel> GetFavTodo(int id)
        {
            var result = _todoRepository.GetAllTodos(id).FindAll(todo => todo.IsFav == true && todo.IsFinished == false);
            return result;
        }

        public List<TodoModel> GetFinishedTodo(int id)
        {
            var result = _todoRepository.GetAllTodos(id).FindAll(todo => todo.IsFinished == true);
            return result;
        }

        public TodoModel GetTodoByID(int TodoID)
        {
            return _todoRepository.GetTodoByID(TodoID);
        }

        public void RemoveTodo(int TodoID)
        {
            _todoRepository.RemoveTodo(TodoID);
        }

        public void UpdateTodo(TodoModel Todo)
        {
            _todoRepository.UpdateTodo(Todo);
        }
    }
}
