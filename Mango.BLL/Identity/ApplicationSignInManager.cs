using System.Security.Claims;
using System.Threading.Tasks;
using Mango.Entities.Domain;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace Mango.BLL.Identity
{
    public class ApplicationSignInManager : SignInManager<User, string>
    {
        public ApplicationSignInManager(AppUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(User user)
        {
            return user.GenerateUserIdentityAsync((AppUserManager)UserManager);
        }

    }
}
