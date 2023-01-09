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
    public class DapperToDoDal : DapperEntityRepositoryBase<ToDo>, IToDoDal
    {
        public bool AddNewToDo(ToDo toDo)
        {
            using (IDbConnection dapperConn = DapperConnection.DapperDbConnection())
            {
                try
                {
                    dapperConn.Execute("insert into ToDo(ToDoName, ToDoDescription, IsCompleted, UserId, LastDatetime) values (@ToDoName, @ToDoDescription, @IsCompleted, @UserId, @LastDatetime)",
                       new ToDo
                       {
                           ToDoName = toDo.ToDoName,
                           ToDoDescription=toDo.ToDoDescription,
                           IsCompleted=toDo.IsCompleted,
                           UserId=toDo.UserId,
                           LastDatetime=toDo.LastDatetime
                       });
                    return true;

                }
                catch (Exception ex)
                {
                    return false;
                }

            }
        }

        public List<ToDo> GetListToDoByToDoGroupId(int Id)
        {
            using (IDbConnection dapperConn = DapperConnection.DapperDbConnection())
            {
                try
                {
                    var parameter = new DynamicParameters();
                    parameter.Add("@ToDoGroupId", Id, dbType: DbType.Int32);
                    List<ToDo> todoList = dapperConn.Query<ToDo>("SELECT [t1].[Id], [t1].[IsCompleted], [t1].[ToDoDescription], [t1].[ToDoName], [t1].[UserId], [t1].[LastDatetime] FROM[ToDoGroupElement] AS[t] INNER JOIN[ToDoGroups] AS[t0] ON[t].[ToDoGroupId] = [t0].[Id] INNER JOIN[ToDo] AS[t1] ON[t].[ToDoId] = [t1].[Id] WHERE[t0].[Id] = @ToDoGroupId", parameter).ToList();
                    return todoList;

                }
                catch (Exception ex)
                {
                    return null;
                }

            }
        }

        public List<ToDo> GetListTodoByUserId(int userId)
        {
            using (IDbConnection dapperConn = DapperConnection.DapperDbConnection())
            {
                try
                {
                    var parameter = new DynamicParameters();
                    parameter.Add("@UserId", userId, dbType: DbType.Int32);
                    List<ToDo> todoList = dapperConn.Query<ToDo>("SELECT [t].[Id], [t].[IsCompleted], [t].[ToDoDescription], [t].[ToDoName], [t].[UserId], [t].[LastDatetime] FROM[ToDo] AS[t] WHERE[t].[UserId] = @UserId", parameter).ToList();
                    return todoList;

                }
                catch (Exception ex)
                {
                    return null;
                }

            }
        }

        public ToDo GetToDoById(int toDoId)
        {
            using (IDbConnection dapperConn = DapperConnection.DapperDbConnection())
            {
                try
                {
                    var parameter = new DynamicParameters();
                    parameter.Add("@Id", toDoId, dbType: DbType.Int32);
                    ToDo todo = dapperConn.Query<ToDo>("SELECT TOP(1) [t].[Id], [t].[IsCompleted], [t].[ToDoDescription], [t].[ToDoName], [t].[UserId], [t].[LastDatetime] FROM[ToDo] AS[t] WHERE[t].[Id] = @Id", parameter).FirstOrDefault();
                    return todo;

                }
                catch (Exception ex)
                {
                    return null;
                }

            }
        }

        public bool UpdateIsCompletedByToDoId(int id, bool isCompleted)
        {
            using (IDbConnection dapperConn = DapperConnection.DapperDbConnection())
            {
                try
                {
                    var parameter = new DynamicParameters();
                    parameter.Add("@Id", id, dbType: DbType.Int32);
                    parameter.Add("@IsCompleted", isCompleted, dbType: DbType.Boolean);
                    dapperConn.Execute("UPDATE [dbo].[ToDo] SET [IsCompleted] = @IsCompleted WHERE Id = @Id", parameter);
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
