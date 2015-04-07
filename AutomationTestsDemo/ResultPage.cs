using AFrame.Web;
using AFrame.Web.Controls;

namespace AutomationTestsDemo
{
    public class ResultPage : WebControl
    {
        public ResultPage(WebContext context) : base(context)
        {
        }

        public WebControl SearchResults
        {
            get { return this.CreateControl("dl"); }
        }

    }
}