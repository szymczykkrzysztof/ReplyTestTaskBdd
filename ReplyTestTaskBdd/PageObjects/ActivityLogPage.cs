using OpenQA.Selenium;

namespace ReplyTestTaskBdd.PageObjects;

public class ActivityLogPage : BasePageObject
{
    public ActivityLogPage(IWebDriver webDriver) : base(webDriver)
    {
    }

    private By CounterOfOperationsSelector =>
        By.XPath("//span[contains(@id,'SelectCountHead')]//parent::div//span[last()]");

    private IWebElement Actions => _webDriver.FindElement(By.XPath("//button[contains(@id,'ActionButtonHead')]"));

    private IWebElement Delete => _webDriver.FindElement(By.XPath("//div[contains(text(),'Delete') and contains(@class,'input-label')]"));

    private IWebElement CounterOfOperations => _webDriver.FindElement(CounterOfOperationsSelector);

    public int GetNumberOfAllItems()
    {
        WaitForElementIsDisplayed(CounterOfOperationsSelector);
        var textNumber = CounterOfOperations.Text;
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
        ClickOnElement(Actions);
        ClickOnElement(Delete, 10);
        var alert = _webDriver.SwitchTo().Alert();
        alert.Accept();
    }
}