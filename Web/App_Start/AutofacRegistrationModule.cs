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
            builder.RegisterType<MerchantService>().As<IMerchantService>().InstancePerRequest();
            builder.RegisterType<OrderGoodService>().As<IOrderGoodService>().InstancePerRequest();
            builder.RegisterType<OrderService>().As<IOrderService>().InstancePerRequest();
            builder.RegisterType<ShopService>().As<IShopService>().InstancePerRequest();
            builder.RegisterType<StudioHostService>().As<IStudioHostService>().InstancePerRequest();
            builder.RegisterType<WithdrawalService>().As<IWithdrawalService>().InstancePerRequest();

            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerRequest();
            builder.RegisterType<GoodRepository>().As<IGoodRepository>().InstancePerRequest();
            builder.RegisterType<MerchantRepository>().As<IMerchantRepository>().InstancePerRequest();
            builder.RegisterType<OrderGoodRepository>().As<IOrderGoodRepository>().InstancePerRequest();
            builder.RegisterType<OrderRepository>().As<IOrderRepository>().InstancePerRequest();
            builder.RegisterType<ShopRepository>().As<IShopRepository>().InstancePerRequest();
            builder.RegisterType<StudioHostRepository>().As<IStudioHostRepository>().InstancePerRequest();
            builder.RegisterType<WithdrawalRepository>().As<IWithdrawalRepository>().InstancePerRequest();
        }
    }
}