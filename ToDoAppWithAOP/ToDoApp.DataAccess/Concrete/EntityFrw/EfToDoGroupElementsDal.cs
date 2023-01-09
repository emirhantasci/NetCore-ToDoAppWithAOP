using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Core.DataAccess.EntityFramework;
using TodoApp.Entities.Concrete;
using ToDoApp.DataAccess.Abstract;

namespace ToDoApp.DataAccess.Concrete.EntityFrw
{
    public class EfToDoGroupElementsDal : EfEntityRepositoryBase<ToDoGroupElement, ToDoContext>, IToDoGroupElementsDal
    {
        public bool AddNewToDoGroupElement(ToDoGroupElement toDoGroupElement)
        {
            bool _efresult = false;
            using (var context = new ToDoContext())
            {
                context.ToDoGroupElement.Add(toDoGroupElement);
                int result = context.SaveChanges();
                if (result == 1)
                    _efresult = true;

            }
            return _efresult;
        }
    }
}
