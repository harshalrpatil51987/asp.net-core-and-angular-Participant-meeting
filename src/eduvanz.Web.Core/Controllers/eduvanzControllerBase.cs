using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace eduvanz.Controllers
{
    public abstract class eduvanzControllerBase: AbpController
    {
        protected eduvanzControllerBase()
        {
            LocalizationSourceName = eduvanzConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
