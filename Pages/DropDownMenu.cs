using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pages
{
    public class DropDownMenu : CustomWebElement
    {
        public DropDownMenu(string xPath, WebDriverWait driverWait) : base(xPath, driverWait)
        {
        }
    }
}
