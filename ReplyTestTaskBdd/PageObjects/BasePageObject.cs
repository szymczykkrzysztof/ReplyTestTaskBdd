using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace ReplyTestTaskBdd.PageObjects;
/// <summary>
/// Base Page Object Class
/// </summary>
public abstract class BasePageObject
{
    protected readonly IWebDriver _webDriver;

    protected BasePageObject(IWebDriver webDriver)
    {
        _webDriver = webDriver;
        _webDriver.Manage().Window.Maximize();
    }
    protected bool WaitForElementIsDisplayed(By locator)
    {
        new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10)).Until(condition: ExpectedConditions.PresenceOfAllElementsLocatedBy(locator));
        return _webDriver.FindElement(locator).Displayed ;
    }
    
    
}