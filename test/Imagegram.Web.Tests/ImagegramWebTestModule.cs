using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Imagegram.EntityFrameworkCore;
using Imagegram.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace Imagegram.Web.Tests
{
    [DependsOn(
        typeof(ImagegramWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class ImagegramWebTestModule : AbpModule
    {
        public ImagegramWebTestModule(ImagegramEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ImagegramWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(ImagegramWebMvcModule).Assembly);
        }
    }
}