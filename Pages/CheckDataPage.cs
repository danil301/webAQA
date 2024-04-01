using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Pages.Helpers;
using SeleniumExtras.WaitHelpers;

namespace Pages
{
    public class CheckDataPage
    {
        private IWebDriver _driver;
        private WebDriverWait _driverWait;

        protected IWebElement _firstNameInput;
        protected IWebElement _lastNameInput;
        protected IWebElement _middleNameInput;
        protected IWebElement _maleRadioButton;
        protected IWebElement _femaleRadioButton;
        protected IWebElement _birthDateInput;
        protected IWebElement _phoneNumberInput;
        protected IWebElement _citizenShipInput;

        public CheckDataPage(IWebDriver driver, WebDriverWait webDriverWait)
        {
            _driver = driver;
            _driverWait = webDriverWait;
            FindElements();
        }

        /// <summary>
        /// Находит элементы страницы.
        /// </summary>
        private void FindElements()
        {
            var elements = _driver.FindElements(By.XPath("//div[contains(@class, 'confirm-section__name')]"));
            _lastNameInput = elements[0].FindElement(By.ClassName("confirm-section__value"));
            _firstNameInput = elements[1].FindElement(By.ClassName("confirm-section__value"));
            _middleNameInput = elements[2].FindElement(By.ClassName("confirm-section__value"));
            _birthDateInput = _driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@class='confirm-section__birthdate']")))
                .FindElement(By.ClassName("confirm-section__value"));
            _phoneNumberInput = _driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@class='confirm-section__mobile-phone']")))
                .FindElement(By.ClassName("confirm-section__value"));
        }


        ///assert mult
        /// <summary>
        /// Проверяет правильность отображения введённых на предыдущей странице данных.
        /// </summary>
        /// <returns>bool</returns>
        public bool CheckFields() 
        {
            return _lastNameInput.Text == Fields._lastName && _firstNameInput.Text == Fields._firstName && _middleNameInput.Text == Fields._middleName
                && _birthDateInput.Text == Fields._birthDate && _phoneNumberInput.Text.Replace(" ", "").Replace("+", "").Replace("-", " ").Replace("(", "")
                .Replace(")", "").Replace(" ", "").Substring(1) == Fields._phoneNumber;
        }

    }
}
