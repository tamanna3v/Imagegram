using System.Threading.Tasks;
using Imagegram.Models.TokenAuth;
using Imagegram.Web.Controllers;
using Shouldly;
using Xunit;

namespace Imagegram.Web.Tests.Controllers
{
    public class HomeController_Tests: ImagegramWebTestBase
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