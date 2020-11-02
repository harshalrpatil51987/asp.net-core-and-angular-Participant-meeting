using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using eduvanz.Configuration.Dto;

namespace eduvanz.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : eduvanzAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
