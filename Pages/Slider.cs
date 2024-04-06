using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pages
{
    public class Slider : CustomWebElement
    {
        private IWebDriver _driver;
        private Actions _actions;
        private int _width;
        private int _max;
        private int _currentValue;

        public Slider(string xPath, IWebDriver driver, WebDriverWait driverWait) : base(xPath, driverWait)
        {
            _driver = driver;
            _width = element.Size.Width;
            int.TryParse(element.GetAttribute("max"), out _max);
            _actions = new Actions(_driver);
        }

        public void SetValue(int target)
        {
            _width = element.Size.Width;      
            var amountPerPixel = _max / _width;
            
            _actions.ClickAndHold(element).Release().Perform();
            int.TryParse(element.GetAttribute("value"), out _currentValue);

            if (_currentValue != null)
            {
                _actions.ClickAndHold(element).MoveByOffset((target - _currentValue) / amountPerPixel, 0).Release().Perform();
                int.TryParse(element.GetAttribute("value"), out _currentValue);
                if (_currentValue > target) _actions.SendKeys(string.Join("", Enumerable.Repeat(Keys.Left, _currentValue - target).ToArray())).Release().Perform();
                else if(_currentValue < target) _actions.SendKeys(string.Join("", Enumerable.Repeat(Keys.Right, target - _currentValue).ToArray())).Release().Perform();
            }
        }
    }
}
