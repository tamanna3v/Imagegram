using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using Imagegram.Controllers;

namespace Imagegram.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : ImagegramControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
