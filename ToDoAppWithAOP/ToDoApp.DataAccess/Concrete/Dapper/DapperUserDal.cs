using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Core.DataAccess.Dapper;
using TodoApp.Core.Entities.Concrete;
using ToDoApp.DataAccess.Abstract;
using ToDoApp.DataAccess.Concrete.Dapper.Connection;

namespace ToDoApp.DataAccess.Concrete.Dapper
{
    public class DapperUserDal : DapperEntityRepositoryBase<User>, IUserDal
    {
        public bool AddNewUser(User user)
        {
            using (IDbConnection dapperConn = DapperConnection.DapperDbConnection())
            {
                try
                {
                    dapperConn.Execute("insert into Users(FirstName, Email, Status, PasswordSalt, PasswordHash, LastName) values (@FirstName, @Email, @Status, @PasswordSalt, @PasswordHash, @LastName)",
                       user);
                    return true;

                }
                catch (Exception ex)
                {
                    return false;
                }

            }
        }

        public User GetByMail(string email)
        {
            using (IDbConnection dapperConn = DapperConnection.DapperDbConnection())
            {
                try
                {
                    var parameter = new DynamicParameters();
                    parameter.Add("@Email", email, dbType: DbType.String);
                    User user = dapperConn.Query<User>("SELECT TOP(1) [u].[Email], [u].[FirstName], [u].[Id], [u].[LastName], [u].[PasswordHash], [u].[PasswordSalt], [u].[Status] FROM[Users] AS[u] WHERE[u].[Email] = @Email", parameter).FirstOrDefault();
                    return user;

                }
                catch (Exception ex)
                {
                    return null;
                }

            }
        }

        public List<OperationClaim> GetClaims(User user)
        {
            using (IDbConnection dapperConn = DapperConnection.DapperDbConnection())
            {
                try
                {
                    var parameter = new DynamicParameters();
                    parameter.Add("@UserId", user.Id, dbType: DbType.String);
                    List<OperationClaim> operationClaims = dapperConn.Query<OperationClaim>("SELECT [o].[Id], [o].[Name] FROM[OperationClaims] AS[o] INNER JOIN[UserOperationClaims] AS[u] ON[o].[Id] = [u].[OperationClaimId] WHERE[u].[UserId] = @UserId", parameter).ToList();
                    return operationClaims;

                }
                catch (Exception ex)
                {
                    return null;
                }

            }
        }
    }
}
