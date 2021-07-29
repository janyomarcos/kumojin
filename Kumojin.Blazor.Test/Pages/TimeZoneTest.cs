using Bunit;
using Kumojin.Blazor.Data;
using Kumojin.Blazor.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TestContext = Bunit.TestContext;

namespace Kumojin.Blazor.Test.Pages
{
    [TestClass]
    public class TimeZoneTest
    {
        [TestMethod]
        public void RefreshShouldCallMethodWhenClicked()
        {
            // Arrange
            var dateTimeDTO = new DateTimeDTO();
            var mockService = new Mock<ITimeZoneService>();
            var viewModel = new TimeZoneViewModel();

            mockService.Setup(x => x.GetTimeZone(viewModel.Id)).ReturnsAsync(dateTimeDTO);
            mockService.Setup(x => x.GetViewModel()).Returns(viewModel);

            using var ctx = new TestContext();
            ctx.Services.AddSingleton(mockService.Object);

            var cut = ctx.RenderComponent<Blazor.Pages.TimeZone>();
            var elementsP = cut.FindAll("p");

            // Act
            cut.Find("button").Click();
            var textTimeZoneLocal = elementsP[0].TextContent;
            var textTimeZoneServer = elementsP[1].TextContent;

            // Assert
            var result = $"{dateTimeDTO.CurrentTime} [{viewModel.Id}]";
            textTimeZoneServer.MarkupMatches(result);
        }
    }
}