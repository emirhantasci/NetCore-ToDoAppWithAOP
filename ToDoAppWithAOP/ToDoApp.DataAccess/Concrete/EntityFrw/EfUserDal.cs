using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Core.DataAccess.EntityFramework;
using TodoApp.Core.Entities.Concrete;
using TodoApp.Entities.Concrete;
using ToDoApp.DataAccess.Abstract;

namespace ToDoApp.DataAccess.Concrete.EntityFrw
{
    public class EfUserDal : EfEntityRepositoryBase<User, ToDoContext>, IUserDal
    {
        public User GetByMail(string email)
        {
            User user = new User();
            using (var toDoContext = new ToDoContext())
            {
                var query = (from u in toDoContext.Set<User>()
                             where (u.Email == email)
                             select new
                             {
                                 u.Email,
                                 u.FirstName,
                                 u.Id,
                                 u.LastName,
                                 u.PasswordHash,
                                 u.PasswordSalt,
                                 u.Status

                             }).FirstOrDefault();

                if (query == null)
                {
                    return null;
                }
                user.Id = query.Id;
                user.Email = query.Email;
                user.FirstName = query.FirstName;
                user.LastName = query.LastName;
                user.PasswordHash = query.PasswordHash;
                user.PasswordSalt = query.PasswordSalt;
                user.Status = query.Status;
            }
            return user;
        }

        public List<OperationClaim> GetClaims(User user)
        {
            using(var context=new ToDoContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }

        public bool AddNewUser(User user)
        {
            bool _efresult = false;
            using (var context = new ToDoContext())
            {
                context.Users.Add(user);
                int result = context.SaveChanges();
                if (result == 1)
                    _efresult = true;

            }
            return _efresult;
        }
    }
}
