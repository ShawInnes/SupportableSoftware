using System.Configuration;
using NUnit.Framework;
using Shouldly;

namespace AutomationTestsDemo
{
    public class HomePageTests : WebTestBase
    {
        [Test]
        public void TestLink()
        {
            var homepage = this.WebContext.NavigateTo<HomePage>(ConfigurationManager.AppSettings["BaseUrl"]);

            homepage.AboutButton.Exists.ShouldBe(true);
        }
    }
}