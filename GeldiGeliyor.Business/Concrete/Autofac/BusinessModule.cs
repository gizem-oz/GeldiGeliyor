using Autofac;
using Autofac.Core;
using GeldiGeliyor.Business.Abstract;
using GeldiGeliyor.DataAccess.Abstract;
using GeldiGeliyor.DataAccess.Concrete.EFCore;
using GeldiGeliyor.Entities.Concrete;

namespace GeldiGeliyor.Business.Concrete.Autofac
{
    public class BusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<PictureManager>().As<IPictureService>();
            builder.RegisterType<ProductManager>().As<IProductService>();
            builder.RegisterType<CityManager>().As<ICityService>();
            builder.RegisterType<OrderDetailManager>().As<IOrderDetailService>();
            builder.RegisterType<OrderManager>().As<IOrderService>();
           
          
           



            builder.RegisterType<CategoryDal>().As<ICategoryDal>();
            builder.RegisterType<CityDal>().As<ICityDal>();
            builder.RegisterType<CustomerDal>().As<ICustomerDal>();
            builder.RegisterType<OrderDal>().As<IOrderDal>();
            builder.RegisterType<OrderDetailDal>().As<IOrderDetailDal>();
            builder.RegisterType<PictureDal>().As<IPictureDal>();
            builder.RegisterType<ProductDal>().As<IProductDal>();
            builder.RegisterType<SellerDal>().As<ISellerDal>();
        }
    }
}
