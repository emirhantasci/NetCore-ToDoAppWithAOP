using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Core.DataAccess;
using TodoApp.Core.Entities.Concrete;

namespace ToDoApp.DataAccess.Abstract
{
    public interface IOperationClaimDal : IEntityRepository<OperationClaim>
    {
        List<OperationClaim> GetListOperationClaimByUserId(int userId);
        bool AddNewOperationClaim(OperationClaim operationClaim);
        bool AddNewUserOperationClaim(UserOperationClaim userOperationClaim);
        List<OperationClaim> GetListOperationClaim();
    }
}
