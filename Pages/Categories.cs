using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pages
{
    public class Categories : CustomWebElement
    {
        private IWebElement _list;
        public IWebElement _confirmButton;

        public Categories(string xPath, IWebDriver driver, WebDriverWait driverWait) : base(xPath, driverWait)
        {
            try
            {
                var cookieButton = driver.FindElements(By.XPath("//button[@class='button']"))[1];
                cookieButton.Click();
            }
            catch (Exception) { }
            element.Click();
            _list = driverWait.Until(ExpectedConditions.ElementExists(By.TagName("ul")));
            _confirmButton = driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//button[contains(@class, 'confirm-button')]")));



        }

        public Categories UncheckAllCategories()
        {
            foreach (var category in _list.FindElements(By.XPath("//li/rui-checkbox/label[contains(@class, 'rui-checkbox_checked')]"))) category.Click();

            return this;
        }

        public Categories SelectCategories(string[] categories)
        {
            foreach (var category in categories)
            {
                _list.FindElement(By.XPath($"//span[contains(text(), '{category}')]/../rui-checkbox/label")).Click();
            }

            return this;
        }

    }
}
