using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using Todo.DataAccess.EF.Context;
using Todo.DataAccess.EF.Models;

namespace ToDoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly ToDoContext _context;
        public ToDoController(ToDoContext context)
        { 
             _context = context;
        }

        [HttpGet]
        [Route("GetToDos")]
        public IActionResult GetTodos()
        {
            List<ToDo> list = new List<ToDo>();
            try
            {
                list = _context.ToDos.ToList();
                return StatusCode(StatusCodes.Status200OK, new { messaje = "ok", response = list });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { messaje = ex.Message, response = list });
            }
        }

        [HttpPost]
        [Route("AddTask")]
        public IActionResult AddTask([FromBody] ToDo toDoTask, string toDoName)
        {
            try
            {
                toDoTask.TaskName = toDoName;
                _context.ToDos.Add(toDoTask);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { messaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { messaje = ex.Message });
            }
        }

        [HttpPut]
        [Route("EditTask")]
        public IActionResult EditTask([FromBody] ToDo toDoTask, int taskId, string toDoName)
        {
            ToDo toDo = _context.ToDos.Find(toDoTask.TaskId = taskId);

            if (toDo == null)
            {
                return BadRequest("Non-existed task");
            }

            try
            {
                toDo.TaskName = toDoName;
                _context.ToDos.Update(toDo);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { messaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { messaje = ex.Message });
            }
        }

        [HttpDelete]
        [Route("RemoveTask")]
        public IActionResult RemoveTask(int taskId)
        {
            ToDo toDo = _context.ToDos.Find(taskId);

            if (toDo == null)
            {
                return BadRequest("Non-existed task");
            }

            try
            {
                _context.ToDos.Remove(toDo);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { messaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { messaje = ex.Message });
            }
        }
    }
}
