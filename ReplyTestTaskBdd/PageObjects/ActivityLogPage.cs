using OpenQA.Selenium;

namespace ReplyTestTaskBdd.PageObjects;

public class ActivityLogPage : BasePageObject
{
    public ActivityLogPage(IWebDriver webDriver) : base(webDriver)
    {
    }

    public int GetNumberOfAllItems()
    {
        WaitForElementIsDisplayed(By.XPath("//span[contains(@id,'SelectCountHead')]//parent::div//span[last()]"));
        var textNumber = _webDriver
            .FindElement(By.XPath("//span[contains(@id,'SelectCountHead')]//parent::div//span[last()]")).Text;
        var number = int.Parse(textNumber.Replace(",", ""));
        return number;
    }

    public void SelectLogItems(int numberOfItems)
    {
        var elements = _webDriver.FindElements(By.XPath("//td//div[@class='input-check']"));
        for (var i = 0; i < numberOfItems; i++)
        {
            ClickOnElement(elements[i]);
        }
    }

    public void ExecuteDelete()
    {
        ClickOnElement(_webDriver.FindElement(By.XPath("//button[contains(@id,'ActionButtonHead')]")));
        ClickOnElement(
            _webDriver.FindElement(By.XPath("//div[contains(text(),'Delete') and contains(@class,'input-label')]")), 10);
        var alert = _webDriver.SwitchTo().Alert();
        alert.Accept();
    }
}