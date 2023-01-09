using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Core.DataAccess;
using TodoApp.Entities.Concrete;

namespace ToDoApp.DataAccess.Abstract
{
    public interface IToDoDal : IEntityRepository<ToDo>
    {
        List<ToDo> GetListToDoByToDoGroupId(int Id);
        bool AddNewToDo(ToDo toDo);
        bool UpdateIsCompletedByToDoId(int id, bool isCompleted);
        ToDo GetToDoById(int toDoId);
        List<ToDo> GetListTodoByUserId(int userId);
    }
}
