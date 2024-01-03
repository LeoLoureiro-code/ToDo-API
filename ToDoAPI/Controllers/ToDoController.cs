using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using Todo.DataAccess.EF.Context;
using Todo.DataAccess.EF.Models;
using Todo.DataAccess.EF.Repositories;

namespace ToDoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private ToDoRespository toDoRespository;

        [HttpGet]
        [Route("GetToDos")]
        public IActionResult GetTodos()
        {
            List<ToDo> list = new List<ToDo>();
            try
            {
                list = toDoRespository.GetAllAccounts();
                return StatusCode(StatusCodes.Status200OK, new { messaje = "ok", response = list });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { messaje = ex.Message, response = list });
            }
        }

        [HttpGet]
        [Route("GetToDoById")]

        public IActionResult GetToDoById(int toDoId)
        {
            ToDo todo = toDoRespository.GetToDoByID(toDoId);
            try
            {
                return StatusCode(StatusCodes.Status200OK, new { messaje = "ok", response = todo });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { messaje = ex.Message, response = todo });
            }
        }

        [HttpPost]
        [Route("CreateToDo")]
        public IActionResult AddTask([FromBody] string toDoName)
        {
            ToDo todo = new ToDo();
            todo.TaskName = toDoName;
            try
            {
                
                toDoRespository.Create(todo);
                return StatusCode(StatusCodes.Status200OK, new { messaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { messaje = ex.Message });
            }
        }

        /*
         * 
         * Fix this
        [HttpPut]
        [Route("UpdateToDo")]
        public IActionResult EditTask([FromBody] int taskId, string toDoName)
        {

            try
            {
                toDoRespository.Update();
                return StatusCode(StatusCodes.Status200OK, new { messaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { messaje = ex.Message });
            }
        }
        */

        [HttpDelete]
        [Route("DeleteToDo")]
        public IActionResult RemoveTask(int taskId)
        {

            try
            {
                toDoRespository.Delete(taskId);
                return StatusCode(StatusCodes.Status200OK, new { messaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { messaje = ex.Message });
            }
        }
    }
}
