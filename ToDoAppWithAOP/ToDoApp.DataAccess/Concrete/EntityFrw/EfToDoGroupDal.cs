using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Core.DataAccess.EntityFramework;
using TodoApp.Core.Entities.Concrete;
using TodoApp.Entities.Concrete;
using ToDoApp.DataAccess.Abstract;

namespace ToDoApp.DataAccess.Concrete.EntityFrw
{
    public class EfToDoGroupDal : EfEntityRepositoryBase<ToDoGroups, ToDoContext>, IToDoGroupDal
    {
        public bool AddNewToDoGroup(ToDoGroups toDoGroups)
        {
            bool _efresult = false;
            using (var context = new ToDoContext())
            {
                context.ToDoGroups.Add(toDoGroups);
                int result = context.SaveChanges();
                if (result == 1)
                    _efresult = true;

            }
            return _efresult;
        }

        public List<ToDoGroups> GetListToDoGroupByUserID(int userId)
        {

            var result = new List<ToDoGroups>();
            using (var toDoContext = new ToDoContext())
            {
                var query = (from t in toDoContext.Set<ToDoGroups>()
                             join p in toDoContext.Set<User>()
                             on t.UserId equals p.Id
                             where (t.UserId == userId)
                             select new
                             {
                                 t.Id,
                                 t.ToDoGroupName,
                                 t.ToDoGroupDescription,
                                 t.UserId

                             }).ToList();

                foreach (var queryToDoGroup in query)
                {

                    ToDoGroups toDoGroup = new ToDoGroups();
                    toDoGroup.Id = queryToDoGroup.Id;
                    toDoGroup.ToDoGroupName = queryToDoGroup.ToDoGroupName;
                    toDoGroup.ToDoGroupDescription = queryToDoGroup.ToDoGroupDescription;
                    toDoGroup.UserId = queryToDoGroup.UserId;
                    result.Add(toDoGroup);
                }
            }
            return result.OrderBy(t => t.Id).ToList();

        }

        public ToDoGroups GetToDoGroupById(int Id)
        {
            ToDoGroups toDoGroup = new ToDoGroups();
            using (var toDoContext = new ToDoContext())
            {
                var query = (from t in toDoContext.Set<ToDoGroups>()
                             where (t.Id == Id)
                             select new
                             {
                                 t.Id,
                                 t.ToDoGroupName,
                                 t.ToDoGroupDescription,
                                 t.UserId

                             }).FirstOrDefault();

                if (query == null)
                {
                    return null;
                }
                toDoGroup.Id = query.Id;
                toDoGroup.ToDoGroupName = query.ToDoGroupName;
                toDoGroup.ToDoGroupDescription = query.ToDoGroupDescription;
                toDoGroup.UserId = query.UserId;

            }
            return toDoGroup;
        }

        public ToDoGroups GetToDoGroupByUserIDAndGroupId(int userId, int groupId)
        {
            ToDoGroups toDoGroup = new ToDoGroups();
            using (var toDoContext = new ToDoContext())
            {
                var query = (from t in toDoContext.Set<ToDoGroups>()
                             where (t.UserId == userId && t.Id==groupId)
                             select new
                             {
                                 t.Id,
                                 t.ToDoGroupName,
                                 t.ToDoGroupDescription,
                                 t.UserId,
                             }).FirstOrDefault();

                if (query == null)
                {
                    return null;
                }
                
                toDoGroup.Id = query.Id;
                toDoGroup.ToDoGroupName = query.ToDoGroupName;
                toDoGroup.ToDoGroupDescription = query.ToDoGroupDescription;
                toDoGroup.UserId = query.UserId;
                
            }
            return toDoGroup;
        }
    }
}
