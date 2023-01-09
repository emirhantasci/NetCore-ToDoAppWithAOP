using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Core.Utilities.Results;
using TodoApp.Entities.Concrete;

namespace ToDoApp.Business.Abstract
{
    public interface IToDoService
    {
        public IDataResult<ToDo> GetToDoById(int toDoId);
        public IDataResult<List<ToDo>> GetListTodoByUserId(int userId);
        public IDataResult<List<ToDo>> GetListToDoByToDoGroupId(int Id);
        public IDataResult<bool> AddNewToDo(ToDo toDo);
        public IDataResult<bool> UpdateIsCompletedByToDoId(int id, bool isCompleted);
    }
}
