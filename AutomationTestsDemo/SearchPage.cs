using AFrame.Web;
using AFrame.Web.Controls;

namespace AutomationTestsDemo
{
    public class SearchPage : WebControl
    {
        public SearchPage(WebContext context) : base(context)
        {
        }

        public WebControl SearchButton
        {
            get { return this.CreateControl("#searchButton"); }
        }

        public WebControl SearchText
        {
            get { return this.CreateControl("#searchString"); }
        }
    }
}