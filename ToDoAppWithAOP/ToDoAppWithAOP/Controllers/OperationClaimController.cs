using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Core.Entities.Concrete;
using ToDoApp.Business.Abstract;

namespace ToDoAppWithAOP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationClaimController : ControllerBase
    {
        private IOperationClaimService _operationClaimService;
        public OperationClaimController(IOperationClaimService operationClaimService)
        {
            _operationClaimService = operationClaimService;
        }

        [HttpGet("getListOperationClaim")]
        //[Authorize(Roles ="OperationClaim.GetListOperationClaim")]
        public ActionResult GetListOperationClaim()
        {
            var operationClaims = _operationClaimService.GetListOperationClaim();
            if (operationClaims.Success)
            {
                return Ok(operationClaims);
            }
            return BadRequest(operationClaims);
        }

        [HttpGet("getListOperationClaimByUserId")]
        //[Authorize(Roles ="OperationClaim.GetListOperationClaimByUserId")]
        public ActionResult GetListOperationClaimByUserId(int userId)
        {
            var operationClaims = _operationClaimService.GetListOperationClaimByUserId(userId);
            if (operationClaims.Success)
            {
                return Ok(operationClaims);
            }
            return BadRequest(operationClaims);
        }

        [HttpPost("addNewOperationClaim")]
        //[Authorize(Roles ="OperationClaim.AddNewOperationClaim")]
        public ActionResult AddNewOperationClaim(OperationClaim operationClaim)
        {
            var operationClaims = _operationClaimService.AddNewOperationClaim(operationClaim);
            if (operationClaims.Success)
            {
                return Ok(operationClaims);
            }
            return BadRequest(operationClaims);
        }

        [HttpPost("addNewUserOperationClaim")]
        //[Authorize(Roles ="OperationClaim.AddNewUserOperationClaim")]
        public ActionResult AddNewUserOperationClaim(UserOperationClaim userOperationClaim)
        {
            var operationClaims = _operationClaimService.AddNewUserOperationClaim(userOperationClaim);
            if (operationClaims.Success)
            {
                return Ok(operationClaims);
            }
            return BadRequest(operationClaims);
        }
    }
}
