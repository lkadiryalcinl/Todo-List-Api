using System;
using System.Collections.Generic;
using System.Text;
using TodoList.Entities.Models;

namespace TodoList.Business.Abstract
{
    public interface ITodoService
    {
        List<TodoModel> GetAllTodos(int UserID);
        TodoModel GetTodoByID(int TodoID);
        List<TodoModel> GetFavTodo(int id);
        List<TodoModel> GetFinishedTodo(int id);
        void UpdateTodo(TodoModel Todo);
        void RemoveTodo(int TodoID);
        TodoModel AddTodo(TodoModel Todo);
        void FinishedTodo(TodoIdModel IdModel);
        void FavTodo(TodoIdModel IdModel);
    }
}
