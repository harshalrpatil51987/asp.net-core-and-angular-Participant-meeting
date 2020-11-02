using Abp.Authorization;
using eduvanz.Authorization.Roles;
using eduvanz.Authorization.Users;

namespace eduvanz.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
