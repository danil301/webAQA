using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Pages.Helpers;
using SeleniumExtras.WaitHelpers;

namespace Pages
{
    public class CreditPage : DebitCardYourCashBack
    {
        public CustomWebElement _oficcialEmploymentInput;
        public CustomWebElement _creditStoryCheckBox;

        public CreditPage(IWebDriver driver, WebDriverWait webDriverWait) : base(driver, webDriverWait)
        {
            FindScecialElements();
        }

        /// <summary>
        /// Находит поля, которые не инициализировала базовая страница.
        /// </summary>
        protected override void FindScecialElements()
        {
            _oficcialEmploymentInput = new CustomWebElement("//mat-select[@name='RussianEmployment']", _driverWait);
            _creditStoryCheckBox = new CustomWebElement("//a[@href='/res/i/td/ConsentBKI.pdf']/../../../span[@class='rui-checkbox__frame']", _driverWait);
        }

        
    }
}
