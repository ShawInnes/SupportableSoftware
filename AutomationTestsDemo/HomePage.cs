using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AFrame.Web;
using AFrame.Web.Controls;

namespace AutomationTestsDemo
{
    public class HomePage : WebControl
    {
        public HomePage(WebContext context)
            : base(context)
        {
        }

        public WebControl HomeButton
        {
            get { return this.CreateControl("a:contains('Home')"); }
        }
        
        public WebControl AboutButton
        {
            get { return this.CreateControl("a:contains('About')"); }
        }

        public WebControl ContactButton
        {
            get { return this.CreateControl("a:contains('Contact')"); }
        }

        public WebControl SearchButton
        {
            get { return this.CreateControl("a:contains('Search')"); }
        }
    }
}
