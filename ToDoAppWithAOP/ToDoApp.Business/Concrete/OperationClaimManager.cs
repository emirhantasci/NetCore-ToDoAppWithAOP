using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Core.Aspects.Exception;
using TodoApp.Core.Aspects.Logging;
using TodoApp.Core.CrossCuttingConcerns.Logging.Log4Net;
using TodoApp.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using TodoApp.Core.Entities.Concrete;
using TodoApp.Core.Utilities.Results;
using ToDoApp.Business.Abstract;
using ToDoApp.Business.Constants;
using ToDoApp.DataAccess.Abstract;

namespace ToDoApp.Business.Concrete
{
    [LogAspect(typeof(FileLogger))]
    [ExceptionLogAspect(typeof(FileLogger))]
    public class OperationClaimManager : IOperationClaimService
    {
        private IOperationClaimDal _operationClaimDal;
        private LoggerServiceBase _logger;
        public OperationClaimManager(IOperationClaimDal operationClaimDal)
        {
            _operationClaimDal = operationClaimDal;
            _logger = (LoggerServiceBase)Activator.CreateInstance(typeof(FileLogger));
        }
        public IDataResult<List<OperationClaim>> GetListOperationClaim()
        {
            List<OperationClaim> operationClaims = (List<OperationClaim>)_operationClaimDal.GetListOperationClaim();
            if (operationClaims.Count>0)
            {
                return new SuccessDataResult<List<OperationClaim>>(operationClaims);
            }
            return new ErrorDataResult<List<OperationClaim>>(Messages.ErrorGetListOperationClaim);
        }

        public IDataResult<List<OperationClaim>> GetListOperationClaimByUserId(int userId)
        {
            List<OperationClaim> operationClaims = (List<OperationClaim>)_operationClaimDal.GetListOperationClaimByUserId(userId);
            if (operationClaims.Count > 0)
            {
                return new SuccessDataResult<List<OperationClaim>>(operationClaims);
            }
            return new ErrorDataResult<List<OperationClaim>>(Messages.ErrorGetListOperationClaimByUserId);
        }

        public IDataResult<bool> AddNewOperationClaim(OperationClaim operationClaim)
        {
            bool operationClaims = _operationClaimDal.AddNewOperationClaim(operationClaim);
            if (operationClaims == true)
            {
                return new SuccessDataResult<bool>(operationClaims);
            }
            return new ErrorDataResult<bool>(Messages.ErrorAddNewOperationClaim);
        }

        public IDataResult<bool> AddNewUserOperationClaim(UserOperationClaim userOperationClaim)
        {
            bool userOperationClaims = _operationClaimDal.AddNewUserOperationClaim(userOperationClaim);
            if (userOperationClaims == true)
            {
                return new SuccessDataResult<bool>(userOperationClaims);
            }
            return new ErrorDataResult<bool>(Messages.ErrorAddNewUserOperationClaim);
        }
    }
}
