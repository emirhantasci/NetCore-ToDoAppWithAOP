using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Core.Utilities.Results;
using TodoApp.Entities.Concrete;

namespace ToDoApp.Business.Abstract
{
    public interface IToDoGroupElementsService
    {
        IDataResult<bool> AddNewToDoGroupElement(ToDoGroupElement toDoGroupElement);
    }
}
