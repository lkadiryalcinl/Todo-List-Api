using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using TodoList.DataAccess.Abstract;
using TodoList.Entities.Models;

namespace TodoList.DataAccess.Concrete
{
    public class BaseMongoRepository<TModel> where TModel : MongoBaseModel
    {
        private readonly IMongoCollection<TModel> mongoCollection;

        public BaseMongoRepository(string mongoDBConnectionString, string dbName, string collectionName)
        {
            var client = new MongoClient(mongoDBConnectionString);
            var database = client.GetDatabase(dbName);
            mongoCollection = database.GetCollection<TModel>(collectionName);
        }

        public TModel AddTodo(TModel Todo)
        {
            mongoCollection.InsertOne(Todo);
            return Todo;
        }

        public List<TModel> GetAllTodos(int userID)
        {
            return mongoCollection.Find(todo => todo.UserID == userID).ToList();
        }

        public TModel GetTodoByID(int TodoID)
        {
            return mongoCollection.Find(todo => todo.TodoID == TodoID).FirstOrDefault();
        }

        public void RemoveTodo(int TodoID)
        {
            TModel Todo = GetTodoByID(TodoID);
            if (Todo != null)
            {
                Todo.IsActive = false;
            }

            UpdateTodo(Todo);
        }

        public TModel UpdateTodo(TModel Todo)
        {
            mongoCollection.ReplaceOne(todo => todo.TodoID == Todo.TodoID, Todo);
            return Todo;
        }

        public TModel Finished(int TodoID)
        {
            TModel Todo = GetTodoByID(TodoID);
            if (Todo != null)
            {
                Todo.IsFinished = Todo.IsFinished ? false : true;
            }

            return UpdateTodo(Todo);
        }

        public TModel Fav(int TodoID)
        {
            TModel Todo = GetTodoByID(TodoID);
            if (Todo != null)
            {
                Todo.IsFav = Todo.IsFav ? false : true;
            }
            return UpdateTodo(Todo);
        }


    }

}
