using OpenQA.Selenium;
using SeleniumInitialize_Builder;

SeleniumBuilder _builder = new SeleniumBuilder();
var driver = _builder.WithURL("https://ib.psbank.ru/store/products/classic-mortgage-program").Build();

var element = driver.FindElement(By.XPath("//mat-select[@role='combobox' and @data-testid='calc-input-mortgageCreditType']"));


driver.Dispose();