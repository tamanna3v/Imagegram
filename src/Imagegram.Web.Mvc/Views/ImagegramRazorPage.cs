using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace Imagegram.Web.Views
{
    public abstract class ImagegramRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected ImagegramRazorPage()
        {
            LocalizationSourceName = ImagegramConsts.LocalizationSourceName;
        }
    }
}
