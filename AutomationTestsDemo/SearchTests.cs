using System.Configuration;
using NUnit.Framework;
using Shouldly;

namespace AutomationTestsDemo
{
    public class SearchTests : WebTestBase
    {
        [Test]
        public void CanSearch()
        {
            var homepage = this.WebContext.NavigateTo<HomePage>(ConfigurationManager.AppSettings["BaseUrl"]);
            var searchpage = this.WebContext.As<SearchPage>();
            var resultpage = this.WebContext.As<ResultPage>();

            homepage.SearchButton.Click();
            searchpage.SearchText.SendKeys("search text");            
            searchpage.SearchButton.Click();

            resultpage.SearchResults.Exists.ShouldBe(true);
        }
    }
}