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
    public class EfToDoDal : EfEntityRepositoryBase<ToDo, ToDoContext>, IToDoDal
    {
        public List<ToDo> GetListToDoByToDoGroupId(int Id)
        {
            var result = new List<ToDo>();
            using (var toDoContext = new ToDoContext())
            {
                var query = (from t in toDoContext.Set<ToDoGroupElement>()
                             join u in toDoContext.Set<ToDoGroups>()
                                on t.ToDoGroupId equals u.Id
                             join p in toDoContext.Set<ToDo>()
                                on t.ToDoId equals p.Id
                             where (u.Id==Id)
                             select new
                             {
                                 p.Id,
                                 p.IsCompleted,
                                 p.ToDoDescription,
                                 p.ToDoName,
                                 p.UserId,
                                 p.LastDatetime
                                 
                             }).ToList();

                foreach (var queryTodo in query)
                {

                    ToDo toDo = new ToDo();
                    toDo.Id = queryTodo.Id;
                    toDo.IsCompleted = queryTodo.IsCompleted;
                    toDo.ToDoDescription = queryTodo.ToDoDescription;
                    toDo.ToDoName = queryTodo.ToDoName;
                    toDo.UserId = queryTodo.UserId;
                    toDo.LastDatetime = queryTodo.LastDatetime;
                    result.Add(toDo);
                }
            }
            return result.OrderBy(t => t.Id).ToList();
        }

        public bool AddNewToDo(ToDo toDo)
        {
            bool _efresult = false;
            using (var context = new ToDoContext())
            {
                context.ToDo.Add(toDo);
                int result = context.SaveChanges();
                if (result == 1)
                    _efresult = true;

            }
            return _efresult;
        }

        public bool UpdateIsCompletedByToDoId(int id, bool isCompleted)
        {
            bool _efresult = false;
            using (var context = new ToDoContext())
            {
                ToDo results = (from p in context.ToDo
                                where p.Id==id
                                select p).FirstOrDefault();

                
                results.IsCompleted = isCompleted;
                

                int _result = context.SaveChanges();
                if (_result == 0)
                    _efresult = true;

            }
            return _efresult;
        }

        public ToDo GetToDoById(int toDoId)
        {
            ToDo toDo = new ToDo();
            using (var toDoContext = new ToDoContext())
            {
                var query = (from t in toDoContext.Set<ToDo>()
                             where (t.Id==toDoId)
                             select new
                             {
                                 t.Id,
                                 t.IsCompleted,
                                 t.ToDoDescription,
                                 t.ToDoName,
                                 t.UserId,
                                 t.LastDatetime

                             }).FirstOrDefault();

                if (query==null)
                {
                    return null;
                }
                toDo.Id = query.Id;
                toDo.IsCompleted = query.IsCompleted;
                toDo.ToDoDescription = query.ToDoDescription;
                toDo.ToDoName = query.ToDoName;
                toDo.UserId = query.UserId;
                toDo.LastDatetime = query.LastDatetime;

            }
            return toDo;
        }

        public List<ToDo> GetListTodoByUserId(int userId)
        {
            List<ToDo> todos = new List<ToDo>();
            using (var toDoContext = new ToDoContext())
            {
                var query = (from t in toDoContext.Set<ToDo>()
                             where (t.UserId == userId)
                             select new
                             {
                                 t.Id,
                                 t.IsCompleted,
                                 t.ToDoDescription,
                                 t.ToDoName,
                                 t.UserId,
                                 t.LastDatetime
                             }).ToList();

                foreach (var queryTodos in query)
                {
                    ToDo toDo = new ToDo();
                    toDo.Id = queryTodos.Id;
                    toDo.IsCompleted = queryTodos.IsCompleted;
                    toDo.ToDoDescription = queryTodos.ToDoDescription;
                    toDo.ToDoName = queryTodos.ToDoName;
                    toDo.UserId = queryTodos.UserId;
                    toDo.LastDatetime = queryTodos.LastDatetime;
                    todos.Add(toDo);
                }
                
            }
            return todos;
        }
    }
}
