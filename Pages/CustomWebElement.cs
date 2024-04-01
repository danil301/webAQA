using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pages
{
    public class CustomWebElement
    {
        public string _xPath;
        public IWebElement element;

        public CustomWebElement(string xPath, WebDriverWait driverWait)
        {
            _xPath = xPath;
            element = driverWait.Until(ExpectedConditions.ElementExists(By.XPath(xPath)));
        }
    }
}
