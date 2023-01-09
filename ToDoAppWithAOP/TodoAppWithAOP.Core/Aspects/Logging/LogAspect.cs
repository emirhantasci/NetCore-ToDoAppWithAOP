using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Core.CrossCuttingConcerns.Logging.Log4Net;
using TodoApp.Core.Utilities.Interceptors;

namespace TodoApp.Core.Aspects.Logging
{
    public class LogAspect : MethodInterception
    {
        private LoggerServiceBase _loggerServiceBase;

        public LogAspect(Type loggerService)
        {
            if (loggerService.BaseType != typeof(LoggerServiceBase))
            {
                throw new System.Exception("Exception");
            }

            _loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(loggerService);
        }

        protected override void OnBefore(IInvocation invocation)
        {
            _loggerServiceBase.Debug(GetLogBefore(invocation));
        }

        protected override void OnAfter(IInvocation invocation)
        {
            _loggerServiceBase.Debug(GetLogAfter(invocation));
        }

        protected override void OnException(IInvocation invocation, System.Exception e)
        {
            string exception = e.ToString();
            _loggerServiceBase.Error(exception);
        }

        private string GetLogAfter(IInvocation invocation)
        {
            string service = ActiveService(invocation);
            string logAfter = service + "." + invocation.Method.Name + " metodundan çıkıldı.";

            return logAfter;
        }

        private string GetLogBefore(IInvocation invocation)
        {
            string service = ActiveService(invocation);
            string logBefore = service + "." + invocation.Method.Name + " metodu çalıştırıldı.";
            return logBefore;
        }

        private string ActiveService(IInvocation invocation)
        {
            string activeService = invocation.Proxy.ToString();
            string[] activeServiceSplit = activeService.Split("Proxies.");
            string activeServiceSplitted = activeServiceSplit[1].ToString();
            return activeServiceSplitted;
        }

        //private LogDetail GetLogDetail(IInvocation invocation)
        //{
        //    var logParameters = new List<LogParameter>();
        //    for (int i = 0; i < invocation.Arguments.Length; i++)
        //    {
        //     logParameters.Add(new LogParameter
        //     { 
        //         Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
        //         Value = invocation.Arguments[i],
        //         Type = invocation.Arguments[i].GetType().Name                
        //     });   
        //    }

        //    var logDetail = new LogDetail
        //    {
        //        MethodName = invocation.Method.Name,
        //        LogParameters = logParameters,
        //        Date = DateTime.UtcNow,
        //        UserName = ActiveDirectoryHelpers.GetCurrentActiveDirectoryUserName()
        //};

        //    return logDetail;
        //}
    }
}
