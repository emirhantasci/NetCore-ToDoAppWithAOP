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
    public class DapperOperationClaimDal : DapperEntityRepositoryBase<OperationClaim>, IOperationClaimDal
    {
        public bool AddNewOperationClaim(OperationClaim operationClaim)
        {
            using (IDbConnection dapperConn = DapperConnection.DapperDbConnection())
            {
                try
                {
                    dapperConn.Execute("insert into OperationClaims(Name) values (@Name)",
                       new OperationClaim
                       {
                           Name = operationClaim.Name
                       });
                    return true;

                }
                catch (Exception ex)
                {
                    return false;
                }
                
            }
        }

        

        public bool AddNewUserOperationClaim(UserOperationClaim userOperationClaim)
        {
            using (IDbConnection dapperConn = DapperConnection.DapperDbConnection())
            {
                try
                {
                    dapperConn.Execute("insert into UserOperationClaims(UserId, OperationClaimId) values (@UserId, @OperationClaimId)",
                       new UserOperationClaim
                       {
                           UserId=userOperationClaim.UserId,
                           OperationClaimId=userOperationClaim.OperationClaimId
                       });
                    return true;

                }
                catch (Exception ex)
                {
                    return false;
                }

            }
        }

        public List<OperationClaim> GetListOperationClaim()
        {
            using (IDbConnection dapperConn = DapperConnection.DapperDbConnection())
            {
                try
                {
                    List<OperationClaim> todoGroups = dapperConn.Query<OperationClaim>("select * from OperationClaims").ToList();
                    return todoGroups;

                }
                catch (Exception ex)
                {
                    return null;
                }

            }
        }

        public List<OperationClaim> GetListOperationClaimByUserId(int userId)
        {
            using (IDbConnection dapperConn = DapperConnection.DapperDbConnection())
            {
                try
                {
                    var parameter = new DynamicParameters();
                    parameter.Add("@userId", userId, dbType: DbType.Int32);
                    List<OperationClaim> todoGroups = dapperConn.Query<OperationClaim>("SELECT [o].[Id], [o].[Name] FROM[OperationClaims] AS[o] INNER JOIN[UserOperationClaims] AS[u] ON[o].[Id] = [u].[OperationClaimId] INNER JOIN[Users] AS[u0] ON[u].[UserId] = [u0].[Id] WHERE[u0].[Id] = @UserId", parameter).ToList();
                    return todoGroups;

                }
                catch (Exception ex)
                {
                    return null;
                }

            }
        }
    }
}
