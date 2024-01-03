using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.DataAccess.EF.Context;
using Todo.DataAccess.EF.Models;

namespace Todo.DataAccess.EF.Repositories
{
    public class ToDoRespository
    {
        private readonly ToDoContext _toDoContext;

        public ToDoRespository(ToDoContext toDoContext)
        {
            _toDoContext = toDoContext;
        }

        public int Create(ToDo todo)
        {

            _toDoContext.Add(todo);
            _toDoContext.SaveChanges();

            return todo.TaskId;
        }

        public int Update(ToDo todo)
        {
            ToDo existingTodo = _toDoContext.ToDos.Find(todo.TaskId);

            existingTodo.TaskName = todo.TaskName;

           _toDoContext.SaveChanges();
            return existingTodo.TaskId;
        }

        public bool Delete(int taskId)
        {
            ToDo todo = _toDoContext.ToDos.Find(taskId);
            _toDoContext.Remove(todo);
            _toDoContext.SaveChanges();
            return true;
        }

        public List<ToDo> GetAllAccounts()
        {
            List<ToDo> toDoList = _toDoContext.ToDos.ToList();
            return toDoList;
        }

        public ToDo GetToDoByID(int toDoId)
        {
            ToDo todo = _toDoContext.ToDos.Find(toDoId);

            return todo;
        }

    }
}
