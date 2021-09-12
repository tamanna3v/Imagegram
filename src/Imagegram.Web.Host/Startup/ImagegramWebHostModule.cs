using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Imagegram.Configuration;

namespace Imagegram.Web.Host.Startup
{
    [DependsOn(
       typeof(ImagegramWebCoreModule))]
    public class ImagegramWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public ImagegramWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ImagegramWebHostModule).GetAssembly());
        }
    }
}
