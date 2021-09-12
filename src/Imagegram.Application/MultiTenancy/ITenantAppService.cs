using Abp.Application.Services;
using Imagegram.MultiTenancy.Dto;

namespace Imagegram.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

