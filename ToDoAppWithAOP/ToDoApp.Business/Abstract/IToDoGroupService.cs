using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Core.Utilities.Results;
using TodoApp.Entities.Concrete;

namespace ToDoApp.Business.Abstract
{
    public interface IToDoGroupService
    {
        IDataResult<ToDoGroups> GetToDoGroupById(int Id);
        IDataResult<List<ToDoGroups>> GetListToDoGroupByUserID(int userId);
        IDataResult<ToDoGroups> GetToDoGroupByUserIDAndGroupId(int userId, int groupId);
        IDataResult<bool> AddNewToDoGroup(ToDoGroups toDoGroups);
    }
}
