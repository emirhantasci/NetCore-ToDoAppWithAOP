using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Core.DataAccess;
using TodoApp.Core.Entities.Concrete;
using TodoApp.Entities.Concrete;

namespace ToDoApp.DataAccess.Abstract
{
    public interface IUserDal:IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
        User GetByMail(string email);
        bool AddNewUser(User user);

    }
}
