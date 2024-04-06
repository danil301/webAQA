
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Pages;
using Pages.Helpers;
using PdfSharp.Pdf;
using SeleniumExtras.WaitHelpers;
using SeleniumInitialize_Builder;
using System.Net;
using System.Text.RegularExpressions;

namespace tasks2_Tests
{
    public class Tests
    {
        private SeleniumBuilder _builder;

        [SetUp]
        public void Setup()
        {
            _builder = new SeleniumBuilder();
        }

        [TearDown]
        public void Teardown()
        {
            _builder.Dispose();
        }

        [Test(Description = "Проверка наличия Выпадающего списка 'Объект ипотеки'")]
        public void HasDropDownList()
        {
            var driver = _builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").Build();
            var element = driver.FindElement(By.XPath("//label[contains(text(), 'Объект ипотеки')]"));
                
            Assert.NotNull(element, "Элемент не найден на странице.");
        }

        [Test(Description = "Проверка наличия Кнопки 'Заполнить через госуслуги'")]
        public void HasFillThroughGosusligiButton()
        {
            var driver = _builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(20)).Build();
            var element = driver.FindElement(By.XPath("//button[@appearance='primary' and @icon='gosuslugi']"));

            Assert.NotNull(element, "Элемент не найден на странице.");
        }

        [Test(Description = "Проверка наличия Карточки с брендом 'Семейная ипотека'")]
        public void HasFamilyMortgageCard()
        {
            var driver = _builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(20)).Build();
            var familyCard = driver.FindElement(By.XPath("//div[contains(@class, 'brands-cards__header') and (text()='Семейная ипотека — 6%')]"));
            
            Assert.NotNull(familyCard, "Элемент не найден на странице.");
        }

        [Test(Description = "Проверка наличия Свитчера 'Страхование жизни'")]
        public void HasLifeInsuranceSwitcher()
        {
            var driver = _builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(20)).Build();
            var lifeSwitcher = driver.FindElement(By.XPath("//psb-text[contains(text(), 'Страхование жизни')]"));           

            Assert.NotNull(lifeSwitcher, "Элемент не найден на странице.");            
        }

        [Test(Description = "Проверка наличия Поля 'Срок кредита'")]
        public void HasLoanTermField()
        {     
            var driver = _builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(20)).Build();
            var element = driver.FindElement(By.XPath("//rui-range-slider[@id='loanPeriod']"));

            Assert.NotNull(element, "Элемент не найден на странице.");
        }

        [Test(Description = "Проверка состояние активности Выпадающего списка 'Объект ипотеки'")]
        public void IsDropDownListEnabled()
        {
            var driver = _builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(20)).Build();
            var element = driver.FindElement(By.XPath("//mat-select[@role='combobox' and @data-testid='calc-input-mortgageCreditType']"));

            Assert.IsTrue(element.Enabled, "Выпадающий список 'Объект ипотеки' не активен");
        }

        [Test(Description = "Проверка отображения Выпадающего списка 'Объект ипотеки'")]
        public void IsDropDownListDisplayed()
        {
            var driver = _builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(20)).Build();
            var element = driver.FindElement(By.XPath("//mat-select[@role='combobox' and @data-testid='calc-input-mortgageCreditType']"));

            Assert.IsTrue(element.Displayed, "Выпадающий список 'Объект ипотеки' не отображается");
        }

        [Test(Description = "Проверка состояние активности Кнопки 'Заполнить через госуслуги'")]
        public void IsFillThroughGosusligiButtonEnabled()
        {
            var driver = _builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(20)).Build();
            var element = driver.FindElement(By.XPath("//button[@appearance='primary' and @icon='gosuslugi']"));

            Assert.IsTrue(element.Enabled, "Кнопка 'Заполнить через госуслуги' не активна");
        }

        [Test(Description = "Проверка отображения Кнопки 'Заполнить через госуслуги'")]
        public void IsFillThroughGosusligiButtonDisplayed()
        {
            var driver = _builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(20)).Build();
            var element = driver.FindElement(By.XPath("//button[@appearance='primary' and @icon='gosuslugi']"));

            Assert.IsTrue(element.Displayed, "Кнопка 'Заполнить через госуслуги' не отображается");
        }

        [Test(Description = "Проверка состояние активности Карточки с брендом 'Семейная ипотека'")]
        public void IsFamilyMortgageCardEnabled()
        {
            var driver = _builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(20)).Build();
            var element = driver.FindElement(By.XPath("//div[@class='brands-cards__item ng-star-inserted']"));

            Assert.IsTrue(element.Enabled, "Карточка с брендом 'Семейная ипотека' не активна");
        }

        [Test(Description = "Проверка отображения Карточки с брендом 'Семейная ипотека'")]
        public void IsFamilyMortgageCardDisplayed()
        {
            var driver = _builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(20)).Build();
            var element = driver.FindElement(By.XPath("//div[@class='brands-cards__item ng-star-inserted']"));

            Assert.IsTrue(element.Displayed, "Карточка с брендом 'Семейная ипотека' не отображается");
        }

        [Test(Description = "Проверка состояние активности Свитчера 'Страхование жизни'")]
        public void IsLifeInsuranceSwitcherEnabled()
        {
            var driver = _builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(20)).Build();
            var element = driver.FindElement(By.XPath("//psb-switcher[@class = 'deltas__switcher _checked ng-untouched ng-pristine ng-valid']"));

            Assert.IsTrue(element.Enabled, "Свитчер 'Страхование жизни' не активен");
        }

        [Test(Description = "Проверка отображения Свитчера 'Страхование жизни'")]
        public void IsLifeInsuranceSwitcherDisplayed()
        {
            var driver = _builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(20)).Build();
            var element = driver.FindElement(By.XPath("//psb-switcher[@class = 'deltas__switcher _checked ng-untouched ng-pristine ng-valid']"));

            Assert.IsTrue(element.Displayed, "Свитчер 'Страхование жизни' не отображается");
        }

        [Test(Description = "Проверка состояние активности поля 'Срок кредита'")]
        public void IsLoanTermFieldEnabled()
        {
            var driver = _builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(20)).Build();
            var element = driver.FindElement(By.XPath("//rtl-mortgage-calculator-field[contains(@class, 'ng-star-inserted')]"));

            Assert.IsTrue(element.Enabled, "Поле 'Срок кредита' не активно");
        }

        [Test(Description = "Проверка состояние активности поля 'Срок кредита'")]
        public void IsLoanTermFieldDisplayed()
        {
            var driver = _builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(20)).Build();
            var element = driver.FindElement(By.XPath("//rtl-mortgage-calculator-field[contains(@class, 'ng-star-inserted')]"));

            Assert.IsTrue(element.Displayed, "Поле 'Срок кредита' не отображается");
        }


        [Test(Description = "Проверка значения 'Квартира в строящемся домe' у Выпадающего списка 'Объект ипотеки'")]
        public void DropDownListHasRightValue()
        {
            var driver = _builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(20)).Build();
            var elementValue = driver.FindElement(By.XPath("//mat-select[@role='combobox' and @data-testid='calc-input-mortgageCreditType']//span")).Text;

            Assert.AreEqual(elementValue, "Квартира в строящемся доме", "Значение не 'Квартира в строящемся доме'");          
        }

        [Test(Description = "Проверка изначального значения '30' поля 'Срок кредита'")]
        public void LoanTermFieldHasRightValue()
        {
            var driver = _builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(20)).Build();
            var elementValue = driver.FindElement(By.XPath("//rui-range-slider[@id='loanPeriod']//input")).GetAttribute("value").ToString();

            Assert.AreEqual(elementValue, "30", "Изначальное значение не '30'");
        }

        [Test(Description = "Проверка активности свитчера 'Страхование жизни'")]
        public void CheckLifeInsuranceSwitcherState()
        {
            var driver = _builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(20)).Build();
            var elementState = driver.FindElement(By.XPath("//input[@name='switcher-2']")).Selected;

            Assert.True(elementState, "Свитчера 'Страхование жизни' не выбран");
        }

        [Test(Description = "Проверка активности свитчера Карточки 'Семейная ипотека'. Должна быть не выбрана.")]
        public void CheckFamilyMortgageCardState()
        {
            var driver = _builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(20)).Build();
            var familyCard = driver.FindElement(By.XPath("//div[text()='Семейная ипотека — 6%']"));
            bool isActive = familyCard.GetAttribute("class").Contains("_active");

            Assert.False(isActive, "Карточка 'Семейная ипотека' выбрана");
        }

        [Test(Description = "Проверка стилей Кнопки 'Заполнить через госуслуги'")]
        public void CheckStylesFillThroughGosusligiButton()
        {
            var driver = _builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(20))
                .SetArgument("--headless").Build();

            var element = driver.FindElement(By.XPath("//rui-wrapper[@data-appearance='primary']"));
            var buttonElement = driver.FindElement(By.XPath("//button[@appearance='primary' and @icon='gosuslugi']"));
            var clickable = buttonElement.Enabled && buttonElement.Displayed ? true : false;           

            var color = element.GetCssValue("background-color");
            var height = buttonElement.GetCssValue("height");

            Assert.True(clickable);
            Assert.AreEqual(color, "rgba(242, 97, 38, 1)", "Цвет Кнопки 'Заполнить через госуслуги' не верный");
            Assert.AreEqual(height, "48px", "Высота Кнопки 'Заполнить через госуслуги' неверная");
        }

        [Test(Description = "Проверка видимости сообщения об ошибке при нажатии Кнопки 'Заполнить через госуслуги' с незаполненными полями")]
        public void CheckErronMessageWhenClickFillWithoutGosusligiButtonWithEmptyFields()
        {
            var driver = _builder.Build();
            driver.Navigate().GoToUrl("https://ib.psbank.ru/store/products/military-family-mortgage-program");
            WebDriverWait driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
            {
                PollingInterval = TimeSpan.FromMilliseconds(200),
            };
            driverWait.IgnoreExceptionTypes(typeof(ElementClickInterceptedException));

            var button = driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//button[contains(@class, 'mortgage-calculator-output-submit__button') and @data-appearance = 'secondary']")));         

            driverWait.Until(d =>
            {
                button.Click();
                return true;
            });
                                  
            var errorMessage = driverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(@class, 'mortgage-calculator-output__alert_show')]")));

            Assert.AreEqual(errorMessage.Text, "Оформление заявки станет доступным после заполнения обязательных полей", "Ошибка отображается неверно на Кнопке 'Заполнить через госуслуги' с незаполненными полями");
        }

        [Test(Description = "Проверка наличия Кнопки 'Заполнить без госуслуг'")]
        public void DoesNotHaveFillWithoutGosusligiButtonWhenErrorMessage()
        {
            var driver = _builder.Build();
            driver.Navigate().GoToUrl("https://ib.psbank.ru/store/products/military-family-mortgage-program");
            WebDriverWait driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(5))
            {
                PollingInterval = TimeSpan.FromMilliseconds(200),
            };
            driverWait.IgnoreExceptionTypes(typeof(ElementClickInterceptedException));

            var button = driverWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(@class, 'mortgage-calculator-output-submit__button') " +
                "and @data-appearance = 'secondary']")));

            bool IsButtonVisible;
            bool IsButtonAppeared;
            bool IsErrorGone;

            driverWait.Until(d =>
            {
                button.Click();
                return true;
            });


            try
            {
                button = driver.FindElement(By.XPath("//button[contains(@class, 'mortgage-calculator-output-submit__button') " +
                "and @data-appearance = 'secondary' and contains(@class, '_hovered')]"));
                IsButtonVisible = true;
            }
            catch (Exception)
            {
                IsButtonVisible = false;
            }

            try
            {
                button = driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//button[contains(@class, 'mortgage-calculator-output-submit__button') " +
                "and @data-appearance = 'secondary']")));
                IsButtonAppeared = true;
            }
            catch (Exception)
            {
                IsButtonAppeared = false;
            }
            
            try
            {
                var errorMessage = driverWait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[contains(@class, 'mortgage-calculator-output__alert_show')]")));
                IsErrorGone = true;
            }
            catch (Exception)
            {
                IsErrorGone = false;
            }

            Assert.Multiple(() =>
            {
                Assert.True(IsButtonAppeared, "Кнопка 'Заполнить без госуслуг' не появилась");
                Assert.True(IsErrorGone, "Сообщение об ошибке не ушло");
                Assert.False(IsButtonVisible, "Кнопка 'Заполнить без госуслуг' видна");
                Assert.NotNull(button, "Кнопки 'Заполнить без госуслуг' не существует");
            });
            
        }


        //todo
        [Test(Description = "Проверка работы свитчеров")]
        public void SwitchersCheck()
        {
            var driver = _builder.Build();
            driver.Navigate().GoToUrl("https://ib.psbank.ru/store/products/classic-mortgage-program");
            WebDriverWait driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
            {
                PollingInterval = TimeSpan.FromMilliseconds(200),
            };
            driverWait.IgnoreExceptionTypes(typeof(ElementClickInterceptedException), typeof(ElementNotInteractableException));

            TurnOffSwitcher(driverWait, driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//input[@name='switcher-2']"))));  
            TurnOffSwitcher(driverWait, driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//input[@name='switcher-3']"))));  
            TurnOffSwitcher(driverWait, driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//input[@name='switcher-4']"))));  
            TurnOffSwitcher(driverWait, driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//input[@name='switcher-5']"))));

            var switchers = (driver.FindElements(By.XPath("//span[contains(@class, 'psb-status')]")));

            bool IsAllSwitchersMain = true;
            foreach (var item in switchers)
            {
                if (item.GetAttribute("class").Split().Contains("psb-status_main")) continue;
                IsAllSwitchersMain = false;
            }

            bool IsAllSwitchersSuccess = true;
            for (int i = 2; i < 6; i++)
            {
                TurnOnSwitcher(driverWait, driverWait.Until(ExpectedConditions.ElementExists(By.XPath($"//input[@name='switcher-{i}']"))));
                if(CheckSpanStatus(driver, "psb-status_success", i - 2)) continue;
                IsAllSwitchersSuccess = false;
            }

            Assert.True(IsAllSwitchersMain, "Не все свитчеры в состоянии 'main'");
            Assert.True(IsAllSwitchersSuccess, "Не все свитчеры в состоянии 'success'");
        }

        private void TurnOffSwitcher(WebDriverWait driverWait, IWebElement switcher)
        {
            if (switcher.Selected)
            {
                driverWait.Until(d =>
                {
                    switcher.FindElement(By.XPath("./..//span")).Click();
                    return true;
                });
            }
        }

        private void TurnOnSwitcher(WebDriverWait driverWait, IWebElement switcher)
        {
            if (!switcher.Selected)
            {
                driverWait.Until(d =>
                {
                    switcher.FindElement(By.XPath("./..//span")).Click();
                    return true;
                });
            }
        }

        
        private bool CheckSpanStatus(IWebDriver driver, string className, int num)
        {
            var switchers = (driver.FindElements(By.XPath("//span[contains(@class, 'psb-status')]")));
            var span = switchers[num];
            if (span.GetAttribute("class").Split().Contains(className)) return true;
            return false;
        }



        [Test(Description = "Проверка страницы с формой заполнения ипотеки без госуслуг")]
        public void FillWithoutGosusligiFormCheck()
        {
            var driver = _builder.Build();
            driver.Navigate().GoToUrl("https://ib.psbank.ru/store/products/classic-mortgage-program");
            WebDriverWait driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
            {
                PollingInterval = TimeSpan.FromMilliseconds(200),
            };
            driverWait.IgnoreExceptionTypes(typeof(ElementClickInterceptedException), typeof(ElementNotInteractableException), typeof(StaleElementReferenceException));

            var button = driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//button[contains(@class, 'mortgage-calculator-output-submit__button') " +
                "and @data-appearance = 'secondary']")));
            driverWait.Until(d =>
            {
                button.Click();
                return true;
            });


            try
            {
                var cookieButton = driver.FindElements(By.XPath("//button[@class='button']"))[1];
                cookieButton.Click();
            }
            catch (Exception) { }
            

            var notClickable = driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//button[@rtl-automark='REGISTRATION_NEXT']")))
                .GetAttribute("class").Contains("_disabled");
            Assert.True(notClickable, "Кнопка кликабельна при незаполненных полях");

            var lastNameInput = driver.FindElement(By.XPath("//input[@name='CardHolderLastName']"));
            lastNameInput.SendKeys("абв");

            var firstNameInput = driver.FindElement(By.XPath("//input[@name='CardHolderFirstName']"));
            firstNameInput.SendKeys("абв");

            var middleNameInput = driver.FindElement(By.XPath("//input[@name='CardHolderMiddleName']"));
            middleNameInput.SendKeys("абв");

            var maleRadioButton = driverWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@name='formly_19_radio_Sex_0']")))
                .FindElement(By.XPath(".."));
            driverWait.Until(d =>
            {
                maleRadioButton.Click();
                return true;
            });

            var birthDate = driver.FindElement(By.XPath("//input[@data-mat-calendar='mat-datepicker-1']"));
            driverWait.Until(d =>
            {
                birthDate.Click();
                return true;
            });
            Actions actions = new Actions(driver);
            actions.SendKeys("30122000").Perform();

            var phoneNumber = driver.FindElement(By.XPath("//input[@name='Phone']"));
            phoneNumber.Click();
            actions.SendKeys("9002221212").Perform();
         
            var emailInput = driver.FindElement(By.XPath("//input[@name='Email']"));
            emailInput.SendKeys("test@mail.ru");

            var selectResidence = driver.FindElement(By.XPath("//mat-select[@name='RussianFederationResident']"));
            selectResidence.Click();
            var RFResidence = driverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[contains(text(),'РФ')]")));
            RFResidence.Click();

            var officialEmployment = driverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//mat-select[@name='RussianEmployment']")));            
            officialEmployment.Click();
            var hasOfficialEmployment = driverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Есть']")));
            hasOfficialEmployment.Click();

            var mortgageCentreAdress = driver.FindElement(By.Id("formly_28_select-with-double-item_OfficeId_0"));
            mortgageCentreAdress.Click();
            var adress = driverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='г. Москва, пл. Славянская, д. 2/5 ']")));
            adress.Click();


            var personalDataCheckBox = driver.FindElement(By.XPath("//a[@href='/res/i/td/ConsentPDProcessing.pdf']/../../../span[@class='rui-checkbox__frame']"));
            personalDataCheckBox.Click();

            var creditStoryCheckBox = driver.FindElement(By.XPath("//a[@href='/res/i/td/ConsentBKI.pdf']/../../../span[@class='rui-checkbox__frame']"));
            creditStoryCheckBox.Click();

            var promotionCheckBox = driver.FindElement(By.XPath("//a[@href='/res/i/td/ConsentPromotion.pdf']/../../../span[@class='rui-checkbox__frame']"));
            promotionCheckBox.Click();

            var clickable = driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//button[@rtl-automark='REGISTRATION_NEXT']")))
                .GetAttribute("class").Contains("_disabled") ? false : true;
            
            Assert.True(clickable, "Кнопка кликабельна при заполненных полях");
        }

        [Test(Description = "Проверка цвета для кнопки 'Заполнить через Госуслуги' в обычном и наведённом состоянии")]
        public void FillThroughGosusligiButtonColorsCheck()
        {
            var driver = _builder.Build();
            driver.Navigate().GoToUrl("https://ib.psbank.ru/store/products/classic-mortgage-program");
            WebDriverWait driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
            {
                PollingInterval = TimeSpan.FromMilliseconds(200),
            };
            driverWait.IgnoreExceptionTypes(typeof(ElementClickInterceptedException), typeof(ElementNotInteractableException));

            var button = driverWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//rui-wrapper[@data-appearance='primary']")));

            var color = button.GetCssValue("background-color");

            Actions actions = new Actions(driver);
            actions.MoveToElement(button).Perform();

            var hoverButton = driverWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//rui-wrapper[@data-appearance='primary']")));
            var hoverColor = hoverButton.GetCssValue("background-color");

            Assert.AreEqual(color, "rgba(242, 97, 38, 1)", "Цвет кнопки в обычном состоянии не верный");
            Assert.AreEqual(hoverColor, "rgba(212, 73, 33, 1)", "Цвет кнопки в наведенном состоянии не верный");
        }

        [Test(Description = "Проверка изменения значения слайдера при его прокрутке")]
        public void SliderValueCheckWhenSlide()
        {
            var driver = _builder.Build();
            driver.Navigate().GoToUrl("https://ib.psbank.ru/store/products/classic-mortgage-program");
            WebDriverWait driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
            {
                PollingInterval = TimeSpan.FromMilliseconds(200),
            };
            driverWait.IgnoreExceptionTypes(typeof(ElementClickInterceptedException), typeof(ElementNotInteractableException));

            var slider = driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//rui-range-slider[@data-testid='calc-input-amountPledge']")))
                .FindElement(By.TagName("rui-slider"));
            var inputField = driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//input[@forminput]")));

            var prevValue = inputField.GetAttribute("value");


            Actions actions = new Actions(driver);
            actions.MoveToElement(slider).Perform();           
            actions.ClickAndHold(slider).MoveByOffset(500, 0).Release().Perform();

        
            string updatedValue = driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//input[@forminput]"))).GetAttribute("value");
            Console.WriteLine("Updated value: " + updatedValue);

            Assert.AreNotEqual(prevValue, updatedValue, "Значение слайдера не изменилось");
        }

        [Test]
        public void POM()
        {
            var driver = _builder.Build();
            driver.Navigate().GoToUrl("https://ib.psbank.ru/store/products/your-cashback-new");
            WebDriverWait driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
            {
                PollingInterval = TimeSpan.FromMilliseconds(200),
            };



            //using (var client = new WebClient())
            //{
            //    byte[] data = client.DownloadData("");
            //    using (var pdf = new PdfDocument(data))
            //    {
            //        pdf.
            //        string text = pdf.GetText();
                  
    
            //}



            var calendar = new Calendar("//mat-calendar", driverWait);
            calendar.SetDate("33.12.2003");

            var input = driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//input[contains(@class,'slider') and @type='range']")));

            var debitSlider = new Slider("//input[contains(@class,'slider') and @type='range']", driver, driverWait);
            debitSlider.SetValue(13432);


            Actions actions = new Actions(driver);
            actions.MoveToElement(input).ClickAndHold().SendKeys(Keys.End).SendKeys(string.Join("", Enumerable.Repeat(Keys.Left, 10000).ToArray())).Release().Perform();

            DebitCardYourCashBack debitCardYourCashBack = new DebitCardYourCashBack(driver, driverWait);
            debitCardYourCashBack._categoriesButton.UncheckAllCategories().SelectCategories(new string[] { "Кафе и", "Дом", "Ж/д", "Одежда" });

            Interactions interactions = new Interactions(driver, driverWait);
            interactions.ClickElement(debitCardYourCashBack._categoriesButton._confirmButton);



            Console.WriteLine();


            //DebitCardYourCashBack debitCardYourCashBack = new DebitCardYourCashBack(driver, driverWait);
            //interactions = new Interactions(driver, driverWait);
            //interactions.AcceptCookieIfExists()
            //    .FillCheckBox(true, debitCardYourCashBack._promotionCheckBox.element, debitCardYourCashBack._promotionCheckBox._xPath)
            //    .FillCheckBox(true, debitCardYourCashBack._personalDataCheckBox.element, debitCardYourCashBack._personalDataCheckBox._xPath)
            //    .FillTextFields(debitCardYourCashBack._firstNameInput.element, Fields._firstName)
            //    .FillTextFields(debitCardYourCashBack._lastNameInput.element, Fields._lastName)
            //    .FillTextFields(debitCardYourCashBack._middleNameInput.element, Fields._middleName)
            //    .FillActionFields(debitCardYourCashBack._birthDateInput.element, Fields._birthDate)
            //    .FillActionFields(debitCardYourCashBack._phoneNumberInput.element, Fields._phoneNumber)
            //    .FillListBox(debitCardYourCashBack._citizenShipInput.element, "РФ")
            //    .ClickElement(debitCardYourCashBack._maleRadioButton.element)
            //    .ClickElement(debitCardYourCashBack._continueButton.element);

            //CheckDataPage checkDataPageDebit = new CheckDataPage(driver, driverWait);
            //var checkDebitFields = checkDataPageDebit.CheckFields();


            driver.Navigate().GoToUrl("https://ib.psbank.ru/store/products/consumer-loan");
            CreditPage creditPage = new CreditPage(driver, driverWait);
            interactions = new Interactions(driver, driverWait);
            interactions.AcceptCookieIfExists()
                .FillCheckBox(true, creditPage._promotionCheckBox.element, creditPage._promotionCheckBox._xPath)
                .FillCheckBox(true, creditPage._personalDataCheckBox.element, creditPage._personalDataCheckBox._xPath)
                .FillCheckBox(true, creditPage._creditStoryCheckBox.element, creditPage._creditStoryCheckBox._xPath)
                .FillTextFields(creditPage._firstNameInput.element, Fields._firstName)
                .FillTextFields(creditPage._lastNameInput.element, Fields._lastName)
                .FillTextFields(creditPage._middleNameInput.element, Fields._middleName)
                .FillActionFields(creditPage._birthDateInput.element, Fields._birthDate)
                .FillActionFields(creditPage._phoneNumberInput.element, Fields._phoneNumber.Substring(1))
                .FillListBox(creditPage._citizenShipInput.element, "РФ")
                .FillListBox(creditPage._oficcialEmploymentInput.element, "Есть")
                .ClickElement(creditPage._maleRadioButton.element)
                .ClickElement(creditPage._continueButton.element);

            CheckDataPage checkDataPageCredit = new CheckDataPage(driver, driverWait);
            var checkCreditFields = checkDataPageCredit.CheckFields();

           // Assert.IsTrue(checkDebitFields);
            Assert.IsTrue(checkCreditFields);
        }



        //3 block

        //Task1
        //Страница https://ib.psbank.ru/, тип локатора xPath, значение локатора "//span[contains(text(), "Стать клиентом")]"
        //Страница https://ib.psbank.ru/store/products/consumer-loan, тип локатора xPath, значение локатора "//div[contains(@class, "card-benefits-banner__text")]"
        //Страница https://ib.psbank.ru/store/products/investmentsbrokerage, тип локатора xPath, значение локатора "//span[contains(text(), "Аналитическая поддержка")]"


        [Test(Description = "Проверка отображения текста в блоке переводов с карты на карту")]
        public void TransferFromCardToCardHasRightText()
        {
            var driver = _builder.Build();
            driver.Navigate().GoToUrl("https://ib.psbank.ru/");
            WebDriverWait driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
            {
                PollingInterval = TimeSpan.FromMilliseconds(200),
            };

            driver.SwitchTo().Frame(driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//iframe[@class='card-to-card__iframe']"))));

            var elementWithTetxVisible = driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//h2[@class='transfers__title']")));
            var elementText = elementWithTetxVisible.Text;

            Assert.Multiple(() =>
            {
                Assert.NotNull(elementWithTetxVisible, "Текст не отображается");
                Assert.AreEqual(elementText, "Перевод с карты на карту", "Элемент не содержит правильный текст");
            });          
        }

        [Test(Description = "Проверка url у брокерского договора")]
        public void InvestmentLinksLoadCheck()
        {
            var driver = _builder.Build();
            driver.Navigate().GoToUrl("https://ib.psbank.ru/");
            
            WebDriverWait driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
            {
                PollingInterval = TimeSpan.FromMilliseconds(200),
            };

            var investmentsDropMenu = driverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[contains(text(), 'Инвестиции')]")));
            investmentsDropMenu.Click();
                       
            var option = driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//a[contains(text(), 'Брокерский договор')]")));
            var optionLink = option.GetAttribute("href");
            Assert.AreEqual("https://ib.psbank.ru/store/products/investmentsbrokerage", optionLink, "Неверный url у тега с Брокерским договором.");

            option.Click();
            driverWait.Until(ExpectedConditions.UrlToBe(optionLink));
            
            Assert.AreEqual("https://ib.psbank.ru/store/products/investmentsbrokerage", driver.Url, "Переход на неправильный url.");
        }

        [Test(Description = "Проверка текста на странице кредита при смене вкладок")]
        public void SwitchTabsCheck()
        {
            var driver = _builder.Build();
            driver.Navigate().GoToUrl("https://ib.psbank.ru/store/products/consumer-loan");

            WebDriverWait driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
            {
                PollingInterval = TimeSpan.FromMilliseconds(200),
            };

            ((IJavaScriptExecutor)driver).ExecuteScript("window.open();");

            var tabs = driver.WindowHandles;
          
            driver.SwitchTo().Window(tabs[1]);

            driver.Navigate().GoToUrl("https://ib.psbank.ru/store/products/investmentsbrokerage");

            string pattern = @"Генеральная лицензия на осуществление банковских операций № \d{4} от \d{2} \w{3,8} \d{4}";

            var text = driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//font[contains(text(), 'Генеральная лицензия на')]"))).Text;
            var isInvestTextMatch = Regex.IsMatch(text, pattern);
            Assert.IsTrue(isInvestTextMatch, "Текст на странице инвестиций не соответсвует паттерну.");

            driver.Close();
            driver.SwitchTo().Window(tabs[0]);

            text = driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//rtl-copyrights"))).Text;
            var isCreditTextMatch = Regex.IsMatch(text, pattern);

            Assert.IsTrue(isCreditTextMatch, "Текст на странице кредита не соответсвует паттерну.");
            
        }

        [Test(Description = "Проверка работы вкладок ипотеки")]
        public void MortgageTabsCheck()
        {
            var driver = _builder.Build();
            driver.Navigate().GoToUrl("https://ib.psbank.ru/");

            WebDriverWait driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
            {
                PollingInterval = TimeSpan.FromMilliseconds(200),
            };

            var mortgageDropMenu = driverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[contains(text(), 'Ипотека')]")));
            mortgageDropMenu.Click();

            var option = driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//a[contains(text(), 'Приобретение квартиры')]")));
            option.Click();

            var button = driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//span[contains(text(), 'Приобретение')]")));
            button.Click();

            //проверить цвет как зафиксят
            
            var familyMortgage = driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//div[contains(text(), 'Семейная ипотека — ')]")));
            familyMortgage.Click();

            var familyMortgageProgramText = driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@data-testid='program-header']"))).Text;
            var familyMortgageMonthlyPayment = driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//span[@data-testid='monthly-payment']"))).Text
                .Replace(" ", "").Replace("₽", "");
            int payment;
            var isFamilyMortgageMonthlyPaymentNumber = int.TryParse(familyMortgageMonthlyPayment, out payment);

            var familyMortgageInterestRate = driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@data-testid='interest-rate']"))).Text;
            var pattern = @"\d*%";
            var isFamilyMortgageInterestRateMatch = Regex.IsMatch(familyMortgageInterestRate, pattern);


            ////////////////////////////////////multple
            Assert.Multiple(() =>
            {
                Assert.AreEqual(familyMortgageProgramText, "Семейная ипотека", "Неверное отображение типа ипотеки семейной ипотеке.");
                Assert.True(isFamilyMortgageMonthlyPaymentNumber, "Месячный платеж не число в семейной ипотеке.");
                Assert.True(isFamilyMortgageInterestRateMatch, "Процент не соответствует маске в семейной ипотеке.");
            });
            

          
            button = driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//span[contains(text(), 'Рефинансирование')]")));                        
            button.Click();
            Actions action = new Actions(driver);
            action.MoveToElement(familyMortgage).Perform();
            button = driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//span[contains(text(), 'Рефинансирование')]/..")));
            var bgColor = button.GetCssValue("background-color");

            var refinancingProgramText = driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@data-testid='program-header']"))).Text;
            var refinancingMonthlyPayment = driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//span[@data-testid='monthly-payment']"))).Text
                .Replace(" ", "").Replace("₽", "");
            var isRefinancingMonthlyPaymentNumber = int.TryParse(refinancingMonthlyPayment, out payment);

            var refinancingProgramRate = driverWait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@data-testid='interest-rate']"))).Text;
            var isRefinancingProgramInterestRateMatch = Regex.IsMatch(familyMortgageInterestRate, pattern);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(bgColor, "rgba(33, 33, 33, 1)", "Цвет кнопки 'Рефинансирование' неправильный в выбранном состоянии.");
                Assert.AreEqual(refinancingProgramText, "Рефинансирование. Семейная ипотека", "Неверное отображение типа ипотеки в рефинансировании.");
                Assert.True(isRefinancingMonthlyPaymentNumber, "Месячный платеж не число в рефинансировании.");
                Assert.True(isRefinancingProgramInterestRateMatch, "Процент не соответствует маске в рефинансировании.");
            });            
        }
    }
}