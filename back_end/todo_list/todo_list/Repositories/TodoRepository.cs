using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todo_list.DataAccess;
using todo_list.Model;
using Npgsql;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace todo_list.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private IConfiguration _conf;
        DataContext _data;
        private NpgsqlConnection _npgsql;
        public TodoRepository(DataContext data, IConfiguration config)
        {
            _conf = config;
            _data = data;
            _npgsql = new NpgsqlConnection(_conf.GetConnectionString("DBIEQSYSTEMPOSTGRE"));
        }

        public void Add(Todo todo)
        {
            _data.Add(todo);
            _data.SaveChanges();
        }

        public void Del(int id)
        {
            var todo = _data.Todos.Find(id);

            _data.Remove(todo);
            _data.SaveChanges();
        }

        public Todo Get(int id)
        {
            return _data.Todos.Find(id);
        }

        public List<Todo> GetTodos()
        {
            string query = $"select * from \"Todos\"";
            return _npgsql.Query<Todo>(query).ToList();
        }
    }
}
