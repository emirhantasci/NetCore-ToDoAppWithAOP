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
    public class ToDoManager : IToDoService
    {
        private IToDoDal _toDoDal;
        public ToDoManager(IToDoDal toDoDal)
        {
            _toDoDal = toDoDal;
        }

        public IDataResult<bool> AddNewToDo(ToDo toDo)
        {
            bool newtoDo = _toDoDal.AddNewToDo(toDo);
            if (newtoDo == true)
            {
                return new SuccessDataResult<bool>(newtoDo);
            }
            return new ErrorDataResult<bool>(Messages.ErrorAddNewToDo);
        }

        public IDataResult<List<ToDo>> GetListToDoByToDoGroupId(int todoGroupId)
        {
            List<ToDo> toDos = _toDoDal.GetListToDoByToDoGroupId(todoGroupId);
            if (toDos.Count>0)
            {
                return new SuccessDataResult<List<ToDo>>(toDos);
            }
            return new ErrorDataResult<List<ToDo>>(Messages.ErrorGetListTodoByTodoGroupId);
        }

        public IDataResult<List<ToDo>> GetListTodoByUserId(int userId)
        {
            List<ToDo> toDos = (List<ToDo>)_toDoDal.GetListTodoByUserId(userId);
            if (toDos.Count>0)
            {
                return new SuccessDataResult<List<ToDo>>(toDos);
            }
            return new ErrorDataResult<List<ToDo>>(Messages.ErrorGetListTodoByUserId);
        }

        public IDataResult<ToDo> GetToDoById(int toDoId)
        {
            ToDo toDo = _toDoDal.GetToDoById(toDoId);
            if (toDo is null)
            {
                return new ErrorDataResult<ToDo>(Messages.ErrorGetToDoById);
            }
            return new SuccessDataResult<ToDo>(toDo);
        }

        public IDataResult<bool> UpdateIsCompletedByToDoId(int id, bool isCompleted)
        {
            bool updatetoDoCompleted = _toDoDal.UpdateIsCompletedByToDoId(id, isCompleted);
            if (updatetoDoCompleted == true)
            {
                return new SuccessDataResult<bool>(updatetoDoCompleted);
            }
            return new ErrorDataResult<bool>(Messages.ErrorUpdateIsCompletedByToDoId);
        }
    }
}
