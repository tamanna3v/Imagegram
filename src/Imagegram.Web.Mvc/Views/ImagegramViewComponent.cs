using Abp.AspNetCore.Mvc.ViewComponents;

namespace Imagegram.Web.Views
{
    public abstract class ImagegramViewComponent : AbpViewComponent
    {
        protected ImagegramViewComponent()
        {
            LocalizationSourceName = ImagegramConsts.LocalizationSourceName;
        }
    }
}
