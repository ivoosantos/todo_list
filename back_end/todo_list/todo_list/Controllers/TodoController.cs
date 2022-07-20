using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todo_list.Model;
using todo_list.Repositories;

namespace todo_list.Controllers
{
    [ApiController]
    [Route("api")]
    public class TodoController : Controller
    {
        private ITodoRepository _todoRepository;
        public TodoController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        [HttpPost]
        public ActionResult Cadastrar([FromBody]Todo todo)
        {
            if (ModelState.IsValid)
                _todoRepository.Add(todo);

            return Ok();
        }

        [HttpGet("getall")]
        public ActionResult GetTodos()
        {
            List<Todo> lista = _todoRepository.GetTodos();

            return Ok(lista);
        }

        [Route("id", Name = "getTodoId")]
        [HttpGet]
        public ActionResult GetTodoId(int id)
        {
            var todo = _todoRepository.Get(id);
            if (todo == null)
                return NotFound();

            return Ok(todo);
        }

        [Route("{id}", Name = "deletar")]
        [HttpDelete]
        public ActionResult Apagar(int id)
        {
            var todo = _todoRepository.Get(id);
            if (todo == null)
                return NotFound();

            _todoRepository.Del(todo.id);

            return Ok();
        }

        [Route("finalizar/{id}", Name = "finalizar")]
        [HttpPut]
        public ActionResult Finalizar(int id)
        {
            var todo = _todoRepository.Get(id);

            //if (todo.finalizado)
            //    return Ok();

            if (todo == null)
                return NotFound();

            _todoRepository.Finalizado(todo.id);

            return Ok();
        }

        [Route("refazer/{id}", Name = "refazer")]
        [HttpPut]
        public ActionResult Refazer(int id)
        {
            var todo = _todoRepository.Get(id);

            //if (todo.finalizado)
            //    return Ok();

            if (todo == null)
                return NotFound();

            _todoRepository.Refazer(todo.id);

            return Ok();
        }
    }
}
