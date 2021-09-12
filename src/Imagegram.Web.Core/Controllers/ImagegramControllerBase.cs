using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Imagegram.Controllers
{
    public abstract class ImagegramControllerBase: AbpController
    {
        protected ImagegramControllerBase()
        {
            LocalizationSourceName = ImagegramConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
