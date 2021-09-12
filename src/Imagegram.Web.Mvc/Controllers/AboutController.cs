using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using Imagegram.Controllers;

namespace Imagegram.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : ImagegramControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
