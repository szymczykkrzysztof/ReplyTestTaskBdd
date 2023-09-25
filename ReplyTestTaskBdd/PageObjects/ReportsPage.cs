using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace ReplyTestTaskBdd.PageObjects;

public class ReportsPage : BasePageObject
{
    public ReportsPage(IWebDriver webDriver) : base(webDriver)
    {
    }

    public void FindReport(string report)
    {
        SelectReport(report);
        ChooseReport(report);
        
       
    }

    public void RunReport()
    {
        WaitForElementIsDisplayed(By.XPath("//span[text()='Run Report']/parent::button"));
        Thread.Sleep(1000);
        _webDriver.FindElement(By.XPath("//span[text()='Run Report']/parent::button")).Click();
    }

    public void CheckResults()
    {
        WaitForElementIsDisplayed(By.XPath("//div[contains(text(),'Selected')]//span[@class='text-number']"));
        var elements = _webDriver.FindElements(By.XPath("//div[contains(text(),'Selected')]//span[@class='text-number']"));
        Assert.AreEqual(elements[0].Text, "0");
        Assert.AreEqual(elements[1].Text, "608");
    }
    private void ChooseReport(string report)
    {
        WaitForElementIsDisplayed(
            By.XPath($"//div[contains(@id,'text-input-select')]//*[contains(text(),'{report}')]"));
        _webDriver.FindElement(By.XPath($"//div[contains(@id,'text-input-select')]//*[contains(text(),'{report}')]"))
            .Click();
        WaitForElementIsDisplayed(By.XPath("//span[text()='Run Report']/parent::button"));
    }

    private void SelectReport(string report)
    {
        WaitForElementIsDisplayed(By.XPath("//span[text()='Quick Filter']"));
        _webDriver.FindElement(By.XPath("//span[text()='Quick Filter']")).Click();
         Thread.Sleep(2000);
        var element = _webDriver.FindElement(By.XPath("//span[text()='Quick Filter']"));
        new Actions(_webDriver)
            .MoveToElement(element)
            .Click()
            .Perform();
        WaitForElementIsDisplayed(By.XPath("//input[@id='filter_text']"));
        _webDriver.FindElement(By.XPath("//input[@id='filter_text']")).SendKeys(report);
        Thread.Sleep(1500);
        
    }
}