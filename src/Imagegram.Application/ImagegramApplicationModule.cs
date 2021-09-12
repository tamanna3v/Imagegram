using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Imagegram.Authorization;

namespace Imagegram
{
    [DependsOn(
        typeof(ImagegramCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class ImagegramApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<ImagegramAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(ImagegramApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
