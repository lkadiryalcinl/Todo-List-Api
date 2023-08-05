using System;
using System.Collections.Generic;
using System.Text;
using TodoList.Entities.Models;

namespace TodoList.DataAccess.Concrete
{
    public class FinTodoMongoRepository : BaseMongoRepository<FinTodoMongoModel>
    {
        public FinTodoMongoRepository(string mongoDBConnectionString, string dbName, string collectionName) : base(mongoDBConnectionString, dbName, collectionName)
        {
        }
    }
}
