using Mango.Entities.Domain;
using Microsoft.AspNet.Identity;

namespace Mango.BLL.Identity
{
    public class AppUserManager : UserManager<User>
    {
        public AppUserManager(IUserStore<User> store) : base(store)
        {
            //Configure validation logic for passwords
            PasswordValidator = new PasswordValidator
            {
                RequiredLength = 1,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };
        }
    }
}
