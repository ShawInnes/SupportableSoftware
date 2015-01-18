using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConventionTestsDemo.ViewModels
{
    public class DemoViewModel
    {
        public string Name { get; set; }

        public DemoViewModel(string name)
        {
            Name = name;
        }

        DateTime badField = new DateTime();

        public void IUseIllegalThings()
        {
            DateTime test = DateTime.Now;
        }
    }
}
