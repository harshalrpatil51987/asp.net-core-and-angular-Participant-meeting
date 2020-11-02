using System.Threading.Tasks;
using eduvanz.Models.TokenAuth;
using eduvanz.Web.Controllers;
using Shouldly;
using Xunit;

namespace eduvanz.Web.Tests.Controllers
{
    public class HomeController_Tests: eduvanzWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}