using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Pages.Data;
using Pages.Helpers;
using SeleniumExtras.WaitHelpers;
using System.Reflection;

namespace Pages
{
    public class DebitCardYourCashBack
    {
        public IWebDriver _driver;
        public WebDriverWait _driverWait;
        public Actions _actions;

        public CustomWebElement _firstNameInput;
        public CustomWebElement _lastNameInput;
        public CustomWebElement _middleNameInput;
        public CustomWebElement _maleRadioButton;
        public CustomWebElement _femaleRadioButton;
        public CustomWebElement _birthDateInput;
        public CustomWebElement _phoneNumberInput;
        public CustomWebElement _citizenShipInput;
        public CustomWebElement _personalDataCheckBox;
        public CustomWebElement _promotionCheckBox;

        public CustomWebElement _continueButton;

        public DebitCardYourCashBack(IWebDriver driver, WebDriverWait webDriverWait, DebitXPaths paths)
        {
            _driver = driver;
            _driverWait = webDriverWait;
            _actions = new Actions(_driver);
          
            FindElements(paths);
            Fields.GenerateFields();                    
        }

        /// <summary>
        /// Находит все веб-элементы на странице.
        /// </summary>
        private void FindElements(DebitXPaths paths)
        {
            _lastNameInput = new CustomWebElement(paths.LastName, _driverWait);
            _firstNameInput = new CustomWebElement(paths.FirstName, _driverWait);
            _middleNameInput = new CustomWebElement(paths.MiddleName, _driverWait);
            _maleRadioButton = new CustomWebElement(paths.Male, _driverWait);
            _femaleRadioButton = new CustomWebElement(paths.Female, _driverWait);
            _birthDateInput = new CustomWebElement(paths.BirthDate, _driverWait);
            _phoneNumberInput = new CustomWebElement(paths.PhoneNumber, _driverWait);
            _citizenShipInput = new CustomWebElement(paths.CitizenShip, _driverWait);
            _personalDataCheckBox = new CustomWebElement(paths.PersonalData, _driverWait);
            _promotionCheckBox = new CustomWebElement(paths.Promotion, _driverWait);
            _continueButton = new CustomWebElement(paths.Continue, _driverWait);
        }
    }
}
