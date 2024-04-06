using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
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

        public Categories _categoriesButton;



        public DebitCardYourCashBack(IWebDriver driver, WebDriverWait webDriverWait)
        {
            _driver = driver;
            _driverWait = webDriverWait;
            _actions = new Actions(_driver);
          
            FindElements();
            FindScecialElements();
            Fields.GenerateFields();                    
        }

        /// <summary>
        /// Находит все веб-элементы на странице.
        /// </summary>
        private void FindElements()
        {
            _lastNameInput = new CustomWebElement("//input[@name='CardHolderLastName']", _driverWait);
            _firstNameInput = new CustomWebElement("//input[@name='CardHolderFirstName']", _driverWait);
            _middleNameInput = new CustomWebElement("//input[@name='CardHolderMiddleName']", _driverWait);
            _maleRadioButton = new CustomWebElement("//div[@class='rui-radio__label'][normalize-space()='Мужской']/..", _driverWait);
            _femaleRadioButton = new CustomWebElement("//div[@class='rui-radio__label'][normalize-space()='Женский']/..", _driverWait);
            _birthDateInput = new CustomWebElement("//input[@data-mat-calendar='mat-datepicker-1']", _driverWait);
            _phoneNumberInput = new CustomWebElement("//input[@rtl-automark='Phone']", _driverWait);
            _citizenShipInput = new CustomWebElement("//mat-select[@name='RussianFederationResident']", _driverWait);
            _personalDataCheckBox = new CustomWebElement("//a[@href='/res/i/td/ConsentPDProcessing.pdf']/../../../span[@class='rui-checkbox__frame']", _driverWait);
            _promotionCheckBox = new CustomWebElement("//a[@href='/res/i/td/ConsentPromotion.pdf']/../../../span[@class='rui-checkbox__frame']", _driverWait);
            _continueButton = new CustomWebElement("//button[@rtl-automark='REGISTRATION_NEXT']", _driverWait);
        }

        protected virtual void FindScecialElements()
        {
            _categoriesButton = new Categories("//span[contains(text(), 'Выбрать другие категории')]/../..", _driver, _driverWait);
        }
    }
}
