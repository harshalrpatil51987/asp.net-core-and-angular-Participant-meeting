using Abp.Application.Services;
using eduvanz.MultiTenancy.Dto;

namespace eduvanz.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

