using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace ReplyTestTaskBdd.PageObjects;

/// <summary>
/// Dashboard Page Object
/// </summary>
public class DashboardPage : BasePageObject
{
    public DashboardPage(IWebDriver webDriver) : base(webDriver)
    {
    }

    private By NavBarSelector => By.ClassName("nav-wrap");

    public void NavigateTo(string menu, string item)
    {
        WaitForElementIsDisplayed(NavBarSelector);
        var tabMenu = _webDriver.FindElement(By.XPath($"//div[(@class='menu-tab-label') and contains(text(),'{menu}')]"));
        new Actions(_webDriver).MoveToElement(tabMenu).Perform();
        WaitForElementIsDisplayed(By.PartialLinkText(item));
        _webDriver.FindElement(By.PartialLinkText(item)).Click();
 
    }
}