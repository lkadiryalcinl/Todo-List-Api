using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TodoList.DataAccess.Abstract;
using TodoList.Entities.Models;

namespace TodoList.DataAccess.Concrete
{
    public class TodoRepository : ITodoRepository
    {
        private DbContext Dbcontext;
        private DbSet<TodoModel> Dbset;

        public TodoRepository(DbContext context)
        {
            Dbcontext = context;
            Dbset = Dbcontext.Set<TodoModel>();
        }

        public TodoModel AddTodo(TodoModel Todo)
        {
            Dbset.Add(Todo);
            Dbcontext.SaveChanges();
            return Todo;
        }

        public TodoModel FavTodo(TodoIdModel IdModel)
        {
            TodoModel Todo = new TodoModel();
            Todo = GetTodoByID(IdModel.TodoID);

            if (Todo != null)
            {
                Todo.IsFav = Todo.IsFav ? false : true;
                Dbset.Update(Todo);
                Dbcontext.SaveChanges();
            }

            return Todo;
        }

        public TodoModel FinishedTodo(TodoIdModel IdModel)
        {
            TodoModel Todo = GetTodoByID(IdModel.TodoID);

            if (Todo != null)
            {
                Todo.IsFinished = Todo.IsFinished ? false : true;
                Dbset.Update(Todo);
                Dbcontext.SaveChanges();
            }

            return Todo;
        }

        public List<TodoModel> GetAllTodos(int UserID)
        {
            var Todos = Dbset.Where(todo => todo.UserID == UserID && todo.IsActive == true).OrderByDescending(x => x.IsFav);
            return Todos.ToList();
        }

        public TodoModel GetTodoByID(int TodoID)
        {
            return Dbset.Find(TodoID);
        }

        public void RemoveTodo(int TodoID)
        {
            TodoModel Todo = GetTodoByID(TodoID);
            Todo.IsActive = false;
            Dbset.Update(Todo);
            Dbcontext.SaveChanges();
        }

        public TodoModel UpdateTodo(TodoModel Todo)
        {
            Dbset.Update(Todo);
            Dbcontext.SaveChanges();
            return Todo;
        }

    }
}
