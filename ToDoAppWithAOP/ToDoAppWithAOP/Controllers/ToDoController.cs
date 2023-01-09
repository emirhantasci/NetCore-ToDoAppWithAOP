using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Entities.Concrete;
using ToDoApp.Business.Abstract;

namespace ToDoAppWithAOP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private IToDoService _toDoService;
        public ToDoController(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        [HttpPut("updateIsCompletedByToDoId")]
        //[Authorize(Roles = "ToDo.UpdateIsCompletedByToDoId")]
        public ActionResult UpdateIsCompletedByToDoId(int id, bool isCompleted)
        {
            var updateToDoCompleted = _toDoService.UpdateIsCompletedByToDoId(id, isCompleted);
            if (updateToDoCompleted.Success)
            {
                return Ok(updateToDoCompleted);
            }
            return BadRequest(updateToDoCompleted);
        }

        [HttpPost("addNewToDo")]
        //[Authorize(Roles ="ToDo.AddNewToDo")]
        public ActionResult AddNewToDo(ToDo toDo)
        {
            var newToDo = _toDoService.AddNewToDo(toDo);
            if (newToDo.Success)
            {
                return Ok(newToDo);
            }
            return BadRequest(newToDo);
        }

        [HttpGet("getToDoById")]
        //[Authorize(Roles ="ToDo.GetToDoById")]
        public ActionResult GetToDoById(int toDoId)
        {
            var toDo = _toDoService.GetToDoById(toDoId);
            if (toDo.Success)
            {
                return Ok(toDo);
            }
            return BadRequest(toDo);
        }

        [HttpGet("getListTodoByUserId")]
        //[Authorize(Roles = "ToDo.GetListTodoByUserId")]
        public ActionResult GetListTodoByUserId(int userId)
        {
            var toDo = _toDoService.GetListTodoByUserId(userId);
            if (toDo.Success)
            {
                return Ok(toDo);
            }
            return BadRequest(toDo);
        }

        [HttpGet("getListToDoByToDoGroupId")]
        //[Authorize(Roles = "ToDo.GetListToDoByToDoGroupId")]
        public ActionResult GetListToDoByToDoGroupId(int groupId)
        {
            var toDo = _toDoService.GetListToDoByToDoGroupId(groupId);
            if (toDo.Success)
            {
                return Ok(toDo);
            }
            return BadRequest(toDo);
        }
    }
}
