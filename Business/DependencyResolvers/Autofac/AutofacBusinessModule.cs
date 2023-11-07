using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EmployeeManager>().As<IEmployeeService>().SingleInstance();
            builder.RegisterType<EmployeeDal>().As<IEmployeeDal>().SingleInstance();

            builder.RegisterType<DepartmentManager>().As<IDepartmenService>().SingleInstance();
            builder.RegisterType<DepartmentDal>().As<IDepartmentDal>().SingleInstance();

            builder.RegisterType<PositionManager>().As<IPositionService>().SingleInstance();
            builder.RegisterType<PositionDal>().As<IPositionDal>().SingleInstance();

            builder.RegisterType<AnnouncementManager>().As<IAnnouncementService>().SingleInstance();
            builder.RegisterType<AnnouncementDal>().As<IAnnouncementDal>().SingleInstance();

            builder.RegisterType<AnswerManager>().As<IAnswerService>().SingleInstance();
            builder.RegisterType<AnswerDal>().As<IAnswerDal>().SingleInstance();

            builder.RegisterType<QuestionManager>().As<IQuestionService>().SingleInstance();
            builder.RegisterType<QuestionDal>().As<IQuestionDal>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
                


            
            
        }
    }
}
