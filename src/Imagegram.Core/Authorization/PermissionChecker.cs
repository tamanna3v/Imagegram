using Abp.Authorization;
using Imagegram.Authorization.Roles;
using Imagegram.Authorization.Users;

namespace Imagegram.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
