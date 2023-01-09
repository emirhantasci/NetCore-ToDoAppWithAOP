using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Core.DataAccess.EntityFramework;
using TodoApp.Core.Entities.Concrete;
using ToDoApp.DataAccess.Abstract;

namespace ToDoApp.DataAccess.Concrete.EntityFrw
{
    public class EfOperationClaimDal : EfEntityRepositoryBase<OperationClaim, ToDoContext>, IOperationClaimDal
    {
        public List<OperationClaim> GetListOperationClaimByUserId(int userId)
        {
            var result = new List<OperationClaim>();
            using (var toDoContext = new ToDoContext())
            {
                var query = (from o in toDoContext.Set<OperationClaim>()
                             join uoc in toDoContext.Set<UserOperationClaim>()
                                on o.Id equals uoc.OperationClaimId
                             join u in toDoContext.Set<User>()
                             on uoc.UserId equals u.Id
                             where (u.Id == userId)
                             select new
                             {
                                 o.Id,
                                 o.Name

                             }).ToList();

                foreach (var queryOperationClaim in query)
                {

                    OperationClaim operationClaim = new OperationClaim();
                    operationClaim.Id = queryOperationClaim.Id;
                    operationClaim.Name = queryOperationClaim.Name;
                    result.Add(operationClaim);
                }
            }
            return result.OrderBy(t => t.Id).ToList();
        }

        public bool AddNewOperationClaim(OperationClaim operationClaim)
        {
            bool _efresult = false;
            using (var context = new ToDoContext())
            {
                context.OperationClaims.Add(operationClaim);
                int result = context.SaveChanges();
                if (result == 1)
                    _efresult = true;

            }
            return _efresult;
        }

        public bool AddNewUserOperationClaim(UserOperationClaim userOperationClaim)
        {
            bool _efresult = false;
            using (var context = new ToDoContext())
            {
                context.UserOperationClaims.Add(userOperationClaim);
                int result = context.SaveChanges();
                if (result == 1)
                    _efresult = true;

            }
            return _efresult;
        }

        public List<OperationClaim> GetListOperationClaim()
        {
            var result = new List<OperationClaim>();
            using (var toDoContext = new ToDoContext())
            {
                var query = (from o in toDoContext.Set<OperationClaim>()
                             select new
                             {
                                 o.Id,
                                 o.Name

                             }).ToList();

                foreach (var queryOperationClaim in query)
                {

                    OperationClaim operationClaim = new OperationClaim();
                    operationClaim.Id = queryOperationClaim.Id;
                    operationClaim.Name = queryOperationClaim.Name;
                    result.Add(operationClaim);
                }
            }
            return result.OrderBy(t => t.Id).ToList();
        }
    }
}
