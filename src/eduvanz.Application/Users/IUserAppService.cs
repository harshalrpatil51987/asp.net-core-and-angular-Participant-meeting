using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using eduvanz.Roles.Dto;
using eduvanz.Users.Dto;

namespace eduvanz.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);

        Task<bool> ChangePassword(ChangePasswordDto input);
    }
}
