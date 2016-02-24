using Mango.BLL.Identity;
using Mango.Dependencies;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace Mango.Site
{
    public class IdentityFactory
    {
        public static ApplicationSignInManager CreatSignInManager(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<AppUserManager>(), context.Authentication);
        }

        public static AppUserManager CreateUserManager(IdentityFactoryOptions<AppUserManager> options, IOwinContext context)
        {
            return IoC.Container.GetInstance<AppUserManager>();
        }
    }
}