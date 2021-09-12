using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Imagegram.Configuration.Dto;

namespace Imagegram.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : ImagegramAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
