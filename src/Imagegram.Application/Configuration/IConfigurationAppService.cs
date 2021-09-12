using System.Threading.Tasks;
using Imagegram.Configuration.Dto;

namespace Imagegram.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
