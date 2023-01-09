using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Core.Entities.Concrete;
using TodoApp.Entities.Concrete;

namespace ToDoApp.Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
        bool AddNewUser(User user);
        User GetByMail(string email);
    }
}
