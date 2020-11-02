using System.Threading.Tasks;
using Abp.Application.Services;
using eduvanz.Sessions.Dto;

namespace eduvanz.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
