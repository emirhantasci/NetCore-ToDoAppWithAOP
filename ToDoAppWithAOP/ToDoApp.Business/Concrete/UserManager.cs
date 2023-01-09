using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Core.Aspects.Exception;
using TodoApp.Core.Aspects.Logging;
using TodoApp.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using TodoApp.Core.Entities.Concrete;
using TodoApp.Entities.Concrete;
using ToDoApp.Business.Abstract;
using ToDoApp.DataAccess.Abstract;

namespace ToDoApp.Business.Concrete
{
    [LogAspect(typeof(FileLogger))]
    [ExceptionLogAspect(typeof(FileLogger))]
    public class UserManager:IUserService
    {
        private IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public bool AddNewUser(User user)
        {
            bool newUser =_userDal.AddNewUser(user);
            if (newUser == null)
            {
                return newUser;
            }
            return newUser;

        }

        public User GetByMail(string email)
        {
            User user = _userDal.GetByMail(email);
            if (user is null)
            {
                return null;
            }
            return user;
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }
    }
}
