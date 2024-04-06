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
    public class Calendar : CustomWebElement
    {
        private IWebElement _yearButton;
        private IWebElement _prev;
        private IWebElement _next;

        public Calendar(string xPath, WebDriverWait driverWait) : base(xPath, driverWait)
        {
            _yearButton = driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//button[contains(@aria-label, 'Choose date')]")));
            _prev = driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//button[contains(@aria-label, 'Previous 24 years')]")));
            _next = driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//button[contains(@aria-label, 'Next 24 years')]")));
        }

        public void SetDate(string date)
        {
            DateTime parsedDate;
            if(!DateTime.TryParse(date, out parsedDate)) return;

            var years = element.FindElements(By.XPath("//td/div[string-length(text()) > 0]"));
            while (true)
            {
                var low = int.Parse(years[0].Text.Trim());
                var high = int.Parse(years[years.Count - 1].Text.Trim());
                if (low <= parsedDate.Year && high >= parsedDate.Year) break;
                else
                {
                    if (low > parsedDate.Year) _prev.Click();
                    else _next.Click();                   
                }
                years = element.FindElements(By.XPath("//td"));
            }

            element.FindElement(By.XPath($"//div[contains(text(), '{parsedDate.Year}')]")).Click();
            var months = element.FindElements(By.XPath("//td/div[string-length(text()) > 0]"));
            months[parsedDate.Month - 1].Click();
            var days = element.FindElements(By.XPath("//td/div[string-length(text()) > 0]"));
            days[parsedDate.Day - 1].Click();
        }

    }
}
