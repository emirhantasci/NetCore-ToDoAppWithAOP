using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Core.Entities.Concrete;
using TodoApp.Core.Utilities.Results;

namespace ToDoApp.Business.Abstract
{
    public interface IOperationClaimService
    {
        IDataResult<List<OperationClaim>> GetListOperationClaim();
        IDataResult<List<OperationClaim>> GetListOperationClaimByUserId(int userId);
        IDataResult<bool> AddNewOperationClaim(OperationClaim operationClaim);
        IDataResult<bool> AddNewUserOperationClaim(UserOperationClaim userOperationClaim);
    }
}
