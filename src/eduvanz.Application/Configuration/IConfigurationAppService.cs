using System.Threading.Tasks;
using eduvanz.Configuration.Dto;

namespace eduvanz.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
