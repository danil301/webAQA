using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Pages.Data;
using Pages.Helpers;
using SeleniumExtras.WaitHelpers;

namespace Pages
{
    public class CreditPage : DebitCardYourCashBack
    {
        public CustomWebElement _oficcialEmploymentInput;
        public CustomWebElement _creditStoryCheckBox;

        public CreditPage(IWebDriver driver, WebDriverWait webDriverWait, DebitXPaths paths) : base(driver, webDriverWait, paths)
        {
            FindScecialFields((CreditXPaths)paths);
        }

        /// <summary>
        /// Находит поля, которые не инициализировала базовая страница.
        /// </summary>
        private void FindScecialFields(CreditXPaths paths)
        {
            _oficcialEmploymentInput = new CustomWebElement(paths.OfficialEmploymnet, _driverWait);
            _creditStoryCheckBox = new CustomWebElement(paths.CreditStory, _driverWait);
        }

        
    }
}
