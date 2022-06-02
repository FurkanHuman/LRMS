using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CityManager>().As<ICityService>().SingleInstance();
            builder.RegisterType<EfCityDal>().As<ICityDal>().SingleInstance();


            builder.RegisterType<WriterManager>().As<IWriterService>();
            builder.RegisterType<EfWriterDal>().As<IWriterDal>();





            // Todo daha sonra yapılacak  builder.RegisterType<AuthManager>().As<IAuthService>(); Not.
            // builder.RegisterType<JwtHelper>().As<ITokenHelper>()"

            /*
             * 
             *  Bunu en son aç, istemeyen autofac modülerini çalıştıruyor.
             *
             *  Last to open it, running autofac modules that don't want it.
             *
             * "var assembly = System.Reflection.Assembly.GetExecutingAssembly();"
             *  
             * builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
             *    .EnableInterfaceInterceptors(new ProxyGenerationOptions()
             *  {"
             *     Selector = new AspectInterceptorSelector()
             *   }).SingleInstance();"
             * "
             */
        }
    }
}
