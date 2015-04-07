using AFrame.Web;
using NUnit.Framework;

namespace AutomationTestsDemo
{
    [TestFixture]
    public class WebTestBase
    {
        private WebContext _webContext;
        public WebContext WebContext
        {
            get
            {
                if (this._webContext == null)
                {
                    var driver = new OpenQA.Selenium.Chrome.ChromeDriver();

                    this._webContext = new WebContext(driver);
                }
                return this._webContext;
            }
        }

        [TearDown]
        public void TestCleanup()
        {
            if (this.WebContext != null)
            {
                this.WebContext.Dispose();
            }
        }
    }
}