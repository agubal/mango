using System.Data.Entity;
using AutoMapper;
using Mango.BLL;
using Mango.BLL.Identity;
using Mango.BLL.Mails;
using Mango.Common;
using Mango.DAL.Core;
using Mango.DAL.Repo;
using Mango.Dependencies.Mapping;
using Mango.Entities.Domain;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using StructureMap;
using static System.Configuration.ConfigurationManager;

namespace Mango.Dependencies.StructureMap
{
    public class IocRegistry : Registry
    {
        public IocRegistry()
        {
            Register();
        }

        public static void RegisterMappings(IContainer container)
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DomainProfile>();
                x.ConstructServicesUsing(container.GetInstance);
            });
        }
        
        private void Register()
        {
            //Core:
            For<DAL.Core.IContext>().Add<AppDbContext>().Ctor<string>("connectionString").Is(ConnectionStrings["AppDbContext"].ConnectionString);
            Forward<DAL.Core.IContext, DbContext>();
            For<IUnitOfWork>().Add<UnitOfWork>().Ctor<DAL.Core.IContext>("context").Is(i => i.GetInstance<DAL.Core.IContext>());
            For<IUser>().Use<User>();
            For<IUserStore<User>>().Use<UserStore<User>>();
            For<AppUserManager>().Add<AppUserManager>().Ctor<IUserStore<User>>("store").Is(i => i.GetInstance<IUserStore<User>>());
            Forward<AppUserManager, UserManager<User>>();

            //Generics:
            For(typeof(IRepository<>)).Use(typeof(GenericRepository<>));
            For(typeof(IService<>)).Use(typeof(GenericService<>));

            //Services:
            For(typeof(IMailService)).Use(typeof(MailService));

        }
    }
}
