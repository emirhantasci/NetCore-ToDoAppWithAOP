using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Core.DataAccess.Dapper;
using TodoApp.Entities.Concrete;
using ToDoApp.DataAccess.Abstract;
using ToDoApp.DataAccess.Concrete.Dapper.Connection;

namespace ToDoApp.DataAccess.Concrete.Dapper
{
    public class DapperToDoGroupElementsDal : DapperEntityRepositoryBase<ToDoGroupElement>, IToDoGroupElementsDal
    {
        public bool AddNewToDoGroupElement(ToDoGroupElement toDoGroupElement)
        {
            using (IDbConnection dapperConn = DapperConnection.DapperDbConnection())
            {
                try
                {
                    dapperConn.Execute("insert into ToDoGroupElement(ToDoGroupId, ToDoId) values (@ToDoGroupId, @ToDoId)",
                       new ToDoGroupElement
                       {
                           ToDoGroupId = toDoGroupElement.ToDoGroupId,
                           ToDoId = toDoGroupElement.ToDoId,
                       });
                    return true;

                }
                catch (Exception ex)
                {
                    return false;
                }

            }
        }
    }
}
