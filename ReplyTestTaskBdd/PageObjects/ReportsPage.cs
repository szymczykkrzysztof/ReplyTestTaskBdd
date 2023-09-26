using NUnit.Framework;
using OpenQA.Selenium;

namespace ReplyTestTaskBdd.PageObjects;

public class ReportsPage : BasePageObject
{
    public ReportsPage(IWebDriver webDriver) : base(webDriver)
    {
    }
    private By RunReportSelector => By.XPath("//span[text()='Run Report']/parent::button");
    private By ResultsSelector => By.XPath("//div[contains(text(),'Selected')]//span[@class='text-number']");
    private By QuickFilterSelector =>By.XPath("//span[text()='Quick Filter']");
    private By FilterSelector => By.XPath("//input[@id='filter_text']");
    private IWebElement RunReportBtn => _webDriver.FindElement(RunReportSelector);
    private IWebElement QuickFilter => _webDriver.FindElement(QuickFilterSelector);
    private IWebElement Filter => _webDriver.FindElement(FilterSelector);
    private IReadOnlyCollection<IWebElement> Results => _webDriver.FindElements(ResultsSelector);
    public void FindReport(string report)
    {
        SelectReport(report);
        ChooseReport(report);
    }

    public void RunReport()
    {
        WaitForElementIsDisplayed(RunReportSelector);
        Thread.Sleep(1000);
        ClickOnElement(RunReportBtn);
    }

    public void CheckResults()
    {
        WaitForElementIsDisplayed(RunReportSelector);
        var elements = Results.ToList();
            
        Assert.AreEqual(int.Parse(elements[0].Text), 0);
        Assert.Greater(int.Parse(elements[1].Text), 0);
    }

    private void ChooseReport(string report)
    {
        ClickOnElement(_webDriver.FindElement(By.XPath($"//div[contains(@id,'text-input-select')]//*[contains(text(),'{report}')]")));
        WaitForElementIsDisplayed(RunReportSelector);
    }

    private void SelectReport(string report)
    {
        WaitForElementIsDisplayed(QuickFilterSelector);
        ClickOnElement(QuickFilter);
        WaitForElementIsDisplayed(FilterSelector);
        Filter.SendKeys(report);
        Thread.Sleep(1500);
    }
}