using System.Threading.Tasks;
using Abp.Application.Services;
using eduvanz.Authorization.Accounts.Dto;

namespace eduvanz.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
