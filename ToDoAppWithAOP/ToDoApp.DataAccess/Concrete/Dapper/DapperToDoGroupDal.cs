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
    public class DapperToDoGroupDal : DapperEntityRepositoryBase<ToDoGroups>, IToDoGroupDal
    {
        public bool AddNewToDoGroup(ToDoGroups toDoGroups)
        {
            using (IDbConnection dapperConn = DapperConnection.DapperDbConnection())
            {
                try
                {
                    dapperConn.Execute("insert into ToDoGroups(ToDoGroupName, ToDoGroupDescription) values (@ToDoGroupName, @ToDoGroupDescription)",
                       new ToDoGroups
                       {
                           ToDoGroupName = toDoGroups.ToDoGroupName,
                           ToDoGroupDescription = toDoGroups.ToDoGroupDescription,
                       });
                    return true;

                }
                catch (Exception ex)
                {
                    return false;
                }

            }
        }

        public List<ToDoGroups> GetListToDoGroupByUserID(int userId)
        {
            using (IDbConnection dapperConn = DapperConnection.DapperDbConnection())
            {
                try
                {
                    var parameter = new DynamicParameters();
                    parameter.Add("@UserId", userId, dbType: DbType.Int32);
                    List<ToDoGroups> todoList = dapperConn.Query<ToDoGroups>("SELECT [t].[Id], [t].[ToDoGroupName], [t].[ToDoGroupDescription], [t].[UserId] FROM[ToDoGroups] AS[t] INNER JOIN[Users] AS[u] ON[t].[UserId] = [u].[Id] WHERE[t].[UserId] = @UserId", parameter).ToList();
                    return todoList;

                }
                catch (Exception ex)
                {
                    return null;
                }

            }
        }

        public ToDoGroups GetToDoGroupById(int Id)
        {
            using (IDbConnection dapperConn = DapperConnection.DapperDbConnection())
            {
                try
                {
                    var parameter = new DynamicParameters();
                    parameter.Add("@GroupId", Id, dbType: DbType.Int32);
                    ToDoGroups todoGroup = dapperConn.Query<ToDoGroups>("SELECT TOP(1) [t].[Id], [t].[ToDoGroupName], [t].[ToDoGroupDescription], [t].[UserId] FROM[ToDoGroups] AS[t] WHERE[t].[Id] = @GroupId", parameter).FirstOrDefault();
                    return todoGroup;

                }
                catch (Exception ex)
                {
                    return null;
                }

            }
        }

        public ToDoGroups GetToDoGroupByUserIDAndGroupId(int userId, int groupId)
        {
            using (IDbConnection dapperConn = DapperConnection.DapperDbConnection())
            {
                try
                {
                    var parameter = new DynamicParameters();
                    parameter.Add("@GroupId", groupId, dbType: DbType.Int32);
                    parameter.Add("@UserId", userId, dbType: DbType.Int32);
                    ToDoGroups todoGroup = dapperConn.Query<ToDoGroups>("SELECT TOP(1) [t].[Id], [t].[ToDoGroupName], [t].[ToDoGroupDescription], [t].[UserId] FROM[ToDoGroups] AS[t] WHERE([t].[UserId] = @UserId) AND([t].[Id] = @GroupId)", parameter).FirstOrDefault();
                    return todoGroup;

                }
                catch (Exception ex)
                {
                    return null;
                }

            }
        }
    }
}
