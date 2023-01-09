using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Core.Aspects.Exception;
using TodoApp.Core.Aspects.Logging;
using TodoApp.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using TodoApp.Core.Utilities.Results;
using TodoApp.Entities.Concrete;
using ToDoApp.Business.Abstract;
using ToDoApp.Business.Constants;
using ToDoApp.DataAccess.Abstract;

namespace ToDoApp.Business.Concrete
{
    [LogAspect(typeof(FileLogger))]
    [ExceptionLogAspect(typeof(FileLogger))]
    public class ToDoGroupElementsManager : IToDoGroupElementsService
    {
        private IToDoGroupElementsDal _todoGroupElementsDal;
        public ToDoGroupElementsManager(IToDoGroupElementsDal toDoGroupElementsDal)
        {
            _todoGroupElementsDal = toDoGroupElementsDal;
        }
        public IDataResult<bool> AddNewToDoGroupElement(ToDoGroupElement toDoGroupElement)
        {
            bool newtoDoGroupElement = _todoGroupElementsDal.AddNewToDoGroupElement(toDoGroupElement);
            if (newtoDoGroupElement == true)
            {
                return new SuccessDataResult<bool>(newtoDoGroupElement);
            }
            return new ErrorDataResult<bool>(Messages.ErrorAddNewToDoGroupElement);
        }
    }
}
