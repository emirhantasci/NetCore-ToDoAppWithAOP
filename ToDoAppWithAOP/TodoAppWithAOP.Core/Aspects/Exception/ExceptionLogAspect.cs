using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Core.CrossCuttingConcerns.Logging.Log4Net;
using TodoApp.Core.Utilities.Interceptors;

namespace TodoApp.Core.Aspects.Exception
{
    public class ExceptionLogAspect : MethodInterception
    {
        private LoggerServiceBase _loggerServiceBase;

        public ExceptionLogAspect(Type loggerService)
        {
            if (loggerService.BaseType != typeof(LoggerServiceBase))
            {
                throw new System.Exception("Exception");
            }

            _loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(loggerService);
        }
        //protected override void OnException(IInvocation invocation, System.Exception e)
        //{
        //    LogDetailWithException logDetailWithException = GetLogDetail(invocation);
        //    logDetailWithException.ExceptionMessage = e.ToString();
        //    _loggerServiceBase.Error(logDetailWithException);
        //}

        //private LogDetailWithException GetLogDetail(IInvocation invocation)
        //{
        //    var logParameters = new List<LogParameter>();

        //    for (int i = 0; i < invocation.Arguments.Length; i++)
        //    {
        //        logParameters.Add(new LogParameter
        //        {
        //            Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
        //            Value = invocation.Arguments[i],
        //            Type = invocation.Arguments[i].GetType().Name,
        //        });
        //    }

        //    var logDetailWithException = new LogDetailWithException
        //    {
        //        MethodName = invocation.Method.Name,
        //        LogParameters = logParameters,
        //        Date = DateTime.UtcNow,
        //        UserName = WindowsIdentity.GetCurrent().Name
        //    };

        //    return logDetailWithException;
        //}
    }
}
