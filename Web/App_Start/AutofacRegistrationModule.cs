using Autofac;
using Infrastructure.Repository;
using YYP.ComLib.Services;
using YYP.Repository;
using YYP.Services;
using Module = Autofac.Module;

namespace YYP.Web
{
    public class AutofacRegistrationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DefaultWorkContext>().As<IWorkContext>().InstancePerRequest();
            builder.RegisterType<DefaultDatabaseFactory>().As<IDatabaseFactory>().InstancePerRequest();

            builder.RegisterType<AliyunSendSmsService>().As<ISendSmsService>().InstancePerRequest();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerRequest();
            builder.RegisterType<GoodService>().As<IGoodService>().InstancePerRequest();

            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerRequest();
            builder.RegisterType<GoodRepository>().As<IGoodRepository>().InstancePerRequest();
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerRequest();
        }
    }
}