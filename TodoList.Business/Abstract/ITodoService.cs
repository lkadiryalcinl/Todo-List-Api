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
        TodoModel UpdateTodo(TodoModel Todo);
        void RemoveTodo(int TodoID);
        TodoModel AddTodo(TodoModel Todo);
        TodoModel FinishedTodo(TodoIdModel IdModel);
        TodoModel FavTodo(TodoIdModel IdModel);
    }
}
