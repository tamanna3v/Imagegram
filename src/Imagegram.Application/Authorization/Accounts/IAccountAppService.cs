using System.Threading.Tasks;
using Abp.Application.Services;
using Imagegram.Authorization.Accounts.Dto;

namespace Imagegram.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
