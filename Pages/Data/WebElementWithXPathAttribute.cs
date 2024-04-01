using OpenQA.Selenium;

public class WebElementWithXPathAttribute : System.Attribute
{
    public IWebElement WebElement { get; }
    public string XPath { get; }

    public WebElementWithXPathAttribute(IWebElement webElement, string xPath)
    {
        WebElement = webElement;
        XPath = xPath;
    }
}