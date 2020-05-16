using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Security.Security.Jwt;
using Service.EmailSender;
using Service.EmailSender.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyInjection.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>();
            builder.RegisterType<ProductDal>().As<IProductDal>();

            builder.RegisterType<OrderManager>().As<IOrderService>();
            builder.RegisterType<OrderDal>().As<IOrderDal>();

            builder.RegisterType<OrderedProductsManager>().As<IOrderedProductsService>();
            builder.RegisterType<OrderedProductDal>().As<IOrderedProductDal>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<UserDal>().As<IUserDal>();

            builder.RegisterType<MailManager>().As<IMailService>();
            builder.RegisterType<EmailService>().As<IEmailService>();
            builder.RegisterType<EmailConfiguration>().As<IEmailConfiguration>();

            builder.RegisterType<JwtHelper>().As<ITokenHelper>();
            //builder.RegisterType<AuthManager>().As<IAuthService>();
            //builder.RegisterType<JwtHelper>().As<ITokenHelper>();
        }
    }
}
