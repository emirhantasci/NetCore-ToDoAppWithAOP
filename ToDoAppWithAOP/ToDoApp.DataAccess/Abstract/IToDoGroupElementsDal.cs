using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Core.DataAccess;
using TodoApp.Entities.Concrete;

namespace ToDoApp.DataAccess.Abstract
{
    public interface IToDoGroupElementsDal : IEntityRepository<ToDoGroupElement>
    {
        bool AddNewToDoGroupElement(ToDoGroupElement toDoGroupElement);
    }
}
