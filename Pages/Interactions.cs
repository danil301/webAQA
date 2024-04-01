using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Pages.Data;
using Pages.Helpers;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pages
{
    public class Interactions
    {
        private IWebDriver _driver;
        private WebDriverWait _driverWait;

        public Interactions(IWebDriver driver, WebDriverWait driverWait)
        {
            _driver = driver;
            _driverWait = driverWait;
        }


        /// <summary>
        /// Нажимает на кнопку принятия куки, если есть сообщение.
        /// </summary>
        /// <returns>DebitCardYourCashBack</returns>
        public Interactions AcceptCookieIfExists()       
        {
            try
            {
                var cookieButton = _driver.FindElements(By.XPath("//button[@class='button']"))[1];
                cookieButton.Click();
            }
            catch (Exception)
            {

            }
            return this;
        }

        ///// <summary>
        ///// Выбирает гражданство
        ///// </summary>
        ///// <param name="citizenship">string(РФ или Не РФ)</param>
        ///// <returns>DebitCardYourCashBack</returns>
        ///// <exception cref="Exception"></exception>
        //public Interactions<T> FillCitizenShip(string citizenship)
        //{
        //    return FillListBox(_page._citizenShipInput.element, citizenship);
        //}

        

        public Interactions FillCheckBox(bool check, IWebElement element, string xPath)
        {
            if (check && ! _driver.FindElement(By.XPath(xPath)).Selected)
            {
                element.Click();
            }
            else if (!check && _driver.FindElement(By.XPath(xPath)).Selected)
            {
                element.Click();
            }

            return this;
        }

        public Interactions FillActionFields(IWebElement element, string data)
        {
            element.Click();
            Actions actions = new Actions(_driver);
            actions.SendKeys(data).Perform();

            return this;
        }

        public Interactions FillTextFields(IWebElement element, string data)
        {
            element.SendKeys(data);
            return this;
        }

        public Interactions FillListBox(IWebElement element, string option)
        {
            element.Click();
            _driverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"//span[text()='{option}']"))).Click();

            return this;
        }

        /// <summary>
        /// Нажимает на элемент
        /// </summary>
        public Interactions ClickElement(IWebElement element)
        {
            element.Click();

            return this;
        }
    }
}
