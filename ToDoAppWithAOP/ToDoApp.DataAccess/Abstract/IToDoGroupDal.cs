using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Core.DataAccess;
using TodoApp.Entities.Concrete;

namespace ToDoApp.DataAccess.Abstract
{
    public interface IToDoGroupDal : IEntityRepository<ToDoGroups>
    {
        List<ToDoGroups> GetListToDoGroupByUserID(int userId);
        bool AddNewToDoGroup(ToDoGroups toDoGroups);
        ToDoGroups GetToDoGroupById(int Id);
        ToDoGroups GetToDoGroupByUserIDAndGroupId(int userId, int groupId);
    }
}
