using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    public class ToDoGroupManager : IToDoGroupService
    {
        private IToDoGroupDal _toDoGroupDal;

        public ToDoGroupManager(IToDoGroupDal toDoGroupDal)
        {
            _toDoGroupDal = toDoGroupDal;
        }

        public IDataResult<bool> AddNewToDoGroup(ToDoGroups toDoGroups)
        {
            bool newtoDoGroup = _toDoGroupDal.AddNewToDoGroup(toDoGroups);
            if (newtoDoGroup == true)
            {
                return new SuccessDataResult<bool>(newtoDoGroup);
            }
            return new ErrorDataResult<bool>(Messages.ErrorAddNewToDoGroup);
        }

        public IDataResult<List<ToDoGroups>> GetListToDoGroupByUserID(int userId)
        {
            var toDoGroups = _toDoGroupDal.GetListToDoGroupByUserID(userId);
            if (toDoGroups.Count<1)
            {
                return new ErrorDataResult<List<ToDoGroups>>(Messages.ErrorGetToDoGroupByUserIDAndGroupId);
            }
            return new SuccessDataResult<List<ToDoGroups>>(toDoGroups);
        }

        public IDataResult<ToDoGroups> GetToDoGroupById(int Id)
        {
            var toDoGroup = _toDoGroupDal.GetToDoGroupById(Id);
            if (toDoGroup is null)
            {
                return new ErrorDataResult<ToDoGroups>(Messages.ErrorGetToDoGroupById);
            }
            return new SuccessDataResult<ToDoGroups>(toDoGroup);
        }

        public IDataResult<ToDoGroups> GetToDoGroupByUserIDAndGroupId(int userId, int groupId)
        {
            var toDoGroup = _toDoGroupDal.GetToDoGroupByUserIDAndGroupId(userId, groupId);
            if (toDoGroup is null)
            {
                return new ErrorDataResult<ToDoGroups>(Messages.ErrorGetToDoGroupById);
            }
            return new SuccessDataResult<ToDoGroups>(toDoGroup);
        }
    }
}
