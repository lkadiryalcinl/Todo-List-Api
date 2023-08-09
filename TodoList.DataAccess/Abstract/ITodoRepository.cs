using System;
using System.Collections.Generic;
using System.Text;
using TodoList.Entities.Models;

namespace TodoList.DataAccess.Abstract
{
    public interface ITodoRepository
    {
        List<TodoModel> GetAllTodos(int UserID);
        TodoModel GetTodoByID(int TodoID);
        void UpdateTodo(TodoModel Todo);
        void RemoveTodo(int TodoID);
        void AddTodo(TodoModel Todo);
        void FinishedTodo(TodoIdModel IdModel);
        void FavTodo(TodoIdModel IdModel);
        
    }
}
