using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumInitialize_Builder;

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
            var driver = _builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(20)).Build();
            try
            {
                var element = driver.FindElement(By.XPath("//mat-select[@role='combobox' and @data-testid='calc-input-mortgageCreditType']"));
                
                Assert.NotNull(element);
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Элемент не найден на странице.");
            }
        }

        [Test(Description = "Проверка наличия Кнопки 'Заполнить через госуслуги'")]
        public void HasFillThroughGosusligiButton()
        {
            var driver = _builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(20)).Build();
            try
            {
                var element = driver.FindElement(By.XPath("//button[@appearance='primary' and @icon='gosuslugi']"));
                Assert.NotNull(element);
            }
            catch (NoSuchElementException) 
            { 
                Assert.Fail("Элемент не найден на странице.");
            }
        }

        [Test(Description = "Проверка наличия Карточки с брендом 'Семейная ипотека'")]
        public void HasFamilyMortgageCard()
        {
            var driver = _builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(20)).Build();
            try
            {
                var element = driver.FindElement(By.XPath("//div[@class='brands-cards__item ng-star-inserted']"));
                Assert.NotNull(element);
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Элемент не найден на странице.");
            }
        }

        [Test(Description = "Проверка наличия Свитчера 'Страхование жизни'")]
        public void HasLifeInsuranceSwitcher()
        {
            var driver = _builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(20)).Build();
            try
            {
                var element = driver.FindElement(By.XPath("//input[@name = 'switcher-2']"));
                Assert.NotNull(element);
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Элемент не найден на странице.");
            }
        }

        [Test(Description = "Проверка наличия Поля 'Срок кредита'")]
        public void HasLoanTermField()
        {          
            var driver = _builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(20)).Build();
            try
            {
                var element = driver.FindElement(By.XPath("//rtl-mortgage-calculator-field[contains(@class, 'ng-star-inserted')]"));
                Assert.NotNull(element);
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Элемент не найден на странице.");
            }
        }

        [Test(Description = "Проверка состояние активности Выпадающего списка 'Объект ипотеки'")]
        public void IsDropDownListEnabled()
        {
            var driver = _builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(20)).Build();
            var element = driver.FindElement(By.XPath("//mat-select[@role='combobox' and @data-testid='calc-input-mortgageCreditType']"));

            Assert.IsTrue(element.Enabled);
        }

        [Test(Description = "Проверка отображения Выпадающего списка 'Объект ипотеки'")]
        public void IsDropDownListDisplayed()
        {
            var driver = _builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(20)).Build();
            var element = driver.FindElement(By.XPath("//mat-select[@role='combobox' and @data-testid='calc-input-mortgageCreditType']"));

            Assert.IsTrue(element.Displayed);
        }

        [Test(Description = "Проверка состояние активности Кнопки 'Заполнить через госуслуги'")]
        public void IsFillThroughGosusligiButtonEnabled()
        {
            var driver = _builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(20)).Build();
            var element = driver.FindElement(By.XPath("//button[@appearance='primary' and @icon='gosuslugi']"));

            Assert.IsTrue(element.Enabled);
        }

        [Test(Description = "Проверка отображения Кнопки 'Заполнить через госуслуги'")]
        public void IsFillThroughGosusligiButtonDisplayed()
        {
            var driver = _builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(20)).Build();
            var element = driver.FindElement(By.XPath("//button[@appearance='primary' and @icon='gosuslugi']"));

            Assert.IsTrue(element.Displayed);
        }

        [Test(Description = "Проверка значения 'Квартира в строящемся домe' у Выпадающего списка 'Объект ипотеки'")]
        public void DropDownListHasRightValue()
        {
            var driver = _builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(20)).Build();
            try
            {
                var elementValue = driver.FindElement(By.XPath("//mat-select[@role='combobox' and @data-testid='calc-input-mortgageCreditType']"))
                    .FindElement(By.TagName("span")).Text;
                Assert.AreEqual(elementValue, "Квартира в строящемся доме");
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Элемент не найден на странице.");
            }
        }

        //[Test]
        //public void LoanTermFieldHasRightValue()
        //{
        //    var driver = _builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(20)).Build();
        //    try
        //    {
        //        var elementValue = driver.FindElement(By.XPath("//rtl-mortgage-calculator-field[contains(@class, 'ng-star-inserted')]"))
        //            .FindElement(By.ClassName("form-field-infix")).FindElement(By.TagName("input")).Text;
        //        Assert.AreEqual(elementValue, "30");
        //    }
        //    catch (NoSuchElementException)
        //    {
        //        Assert.Fail("Элемент не найден на странице.");
        //    }
        //}

        //[Test]
        //public void CheckStylesFillThroughGosusligiButton()
        //{
        //    var driver = _builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").WithTimeout(TimeSpan.FromSeconds(20))
        //        .SetArgument("--headless").Build();

        //    var element = driver.FindElement(By.XPath("//button[@appearance='primary' and @icon='gosuslugi']"));

        //    var color = element.GetCssValue("color");
        //    var height = element.GetCssValue("height");
        //    var prevPageTitle = driver.Title;

        //    bool clickable = false;
        //    try
        //    {
        //        // Попытка выполнения клика на элементе
        //        element.Click();
        //        clickable = true;
        //    }
        //    catch (ElementClickInterceptedException)
        //    {
        //        Assert.Fail("Ошибка нажатия");
        //    }

        //    Assert.AreEqual(color, "#f26126");
        //    Assert.AreEqual(height, "48px");
        //}
    }
}