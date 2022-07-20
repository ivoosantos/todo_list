using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todo_list.Model
{
    public class Todo
    {
        public int id { get; set; }
        public string todo { get; set; }
        public bool finalizado { get; set; }
    }
}
