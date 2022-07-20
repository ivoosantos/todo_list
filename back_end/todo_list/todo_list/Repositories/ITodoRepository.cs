using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todo_list.Model;

namespace todo_list.Repositories
{
    public interface ITodoRepository
    {
        List<Todo> GetTodos();
        void Add(Todo todo);
        void Del(int id);
        Todo Get(int id);
    }
}
