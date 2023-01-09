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
    public class ToDoGroupController : ControllerBase
    {
        private IToDoGroupService _toDoGroupService;
        private IToDoGroupElementsService _toDoGroupElementsService;
        public ToDoGroupController(IToDoGroupService toDoGroupService, IToDoGroupElementsService toDoGroupElementsService)
        {
            _toDoGroupService = toDoGroupService;
            _toDoGroupElementsService = toDoGroupElementsService;
        }

        [HttpPost("addNewToDoGroupElement")]
        //[Authorize(Roles ="ToDoGroup.AddNewToDoGroupElement")]
        public ActionResult AddNewToDoGroupElement(ToDoGroupElement toDoGroupElement)
        {
            var newToDoGroupElement = _toDoGroupElementsService.AddNewToDoGroupElement(toDoGroupElement);
            if (newToDoGroupElement.Success)
            {
                return Ok(newToDoGroupElement);
            }
            return BadRequest(newToDoGroupElement);
        }

        [HttpPost("addNewToDoGroup")]
        //[Authorize(Roles ="ToDoGroup.AddNewToDoGroup")]
        public ActionResult AddNewToDoGroup(ToDoGroups toDoGroup)
        {
            var newToDoGroup = _toDoGroupService.AddNewToDoGroup(toDoGroup);
            if (newToDoGroup.Success)
            {
                return Ok(newToDoGroup);
            }
            return BadRequest(newToDoGroup);
        }

        [HttpGet("getToDoGroupById")]
        //[Authorize(Roles = "ToDoGroup.GetToDoGroupById")]
        public ActionResult GetToDoGroupById(int Id)
        {
            var toDoGroup = _toDoGroupService.GetToDoGroupById(Id);
            if (toDoGroup.Success)
            {
                return Ok(toDoGroup);
            }
            return BadRequest(toDoGroup);
        }

        [HttpGet("getListToDoGroupByUserID")]
        //[Authorize(Roles = "ToDoGroup.GetListToDoGroupByUserID")]
        public ActionResult GetListToDoGroupByUserID(int userId)
        {
            var toDoGroups = _toDoGroupService.GetListToDoGroupByUserID(userId);
            if (toDoGroups.Success)
            {
                return Ok(toDoGroups);
            }
            return BadRequest(toDoGroups);
        }

        [HttpGet("getToDoGroupByUserIDAndGroupId")]
        //[Authorize(Roles = "ToDoGroup.GetToDoGroupByUserIDAndGroupId")]
        public ActionResult GetToDoGroupByUserIDAndGroupId(int userId, int groupId)
        {
            var toDoGroup = _toDoGroupService.GetToDoGroupByUserIDAndGroupId(userId, groupId);
            if (toDoGroup.Success)
            {
                return Ok(toDoGroup);
            }
            return BadRequest(toDoGroup);
        }
    }
}
