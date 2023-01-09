using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Core.Utilities.Interceptors;
using TodoApp.Core.Utilities.Security.JWT;
using ToDoApp.Business.Abstract;
using ToDoApp.Business.Concrete;
using ToDoApp.DataAccess.Abstract;
using ToDoApp.DataAccess.Concrete.Dapper;
using ToDoApp.DataAccess.Concrete.EntityFrw;

namespace ToDoApp.Business.DependencyResolvers
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<OperationClaimManager>().As<IOperationClaimService>();
            builder.RegisterType<DapperOperationClaimDal>().As<IOperationClaimDal>();
            builder.RegisterType<ToDoGroupElementsManager>().As<IToDoGroupElementsService>();
            builder.RegisterType<DapperToDoGroupElementsDal>().As<IToDoGroupElementsDal>();
            builder.RegisterType<ToDoGroupManager>().As<IToDoGroupService>();
            builder.RegisterType<DapperToDoGroupDal>().As<IToDoGroupDal>();
            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<DapperUserDal>().As<IUserDal>();
            builder.RegisterType<ToDoManager>().As<IToDoService>();
            builder.RegisterType<DapperToDoDal>().As<IToDoDal>();
            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
