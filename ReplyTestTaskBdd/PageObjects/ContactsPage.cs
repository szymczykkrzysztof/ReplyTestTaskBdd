using FluentAssertions;
using OpenQA.Selenium;

namespace ReplyTestTaskBdd.PageObjects;

public class ContactsPage : BasePageObject
{
    public ContactsPage(IWebDriver webDriver) : base(webDriver)
    {
    }

    private IWebElement CreateContact => _webDriver.FindElement(By.XPath("//span[text()='Create Contact']/.."));
    private By FirstNameSelector => By.Name("first_name");
    private By LastNameSelector => By.Name("last_name");
    private By BusinessRoleSelector => By.Id("DetailFormbusiness_role-input-label");
    private By CategorySelector => By.Id("DetailFormcategories-input");
    private By SaveSelector => By.Id("DetailForm_save2");
    private By HeaderSelector => By.XPath("//div[@id='_form_header']/h3");
    private IWebElement FirstName => _webDriver.FindElement(FirstNameSelector);
    private IWebElement LastName => _webDriver.FindElement(LastNameSelector);
    private IWebElement BusinessRole => _webDriver.FindElement(BusinessRoleSelector);
    private IWebElement Category => _webDriver.FindElement(CategorySelector);
    private IWebElement SaveBtn => _webDriver.FindElement(SaveSelector);
    private IWebElement Header => _webDriver.FindElement(HeaderSelector);
    private IWebElement Categories => _webDriver.FindElement(By.XPath("//p[text()='Category']/parent::li"));
    private IWebElement BusinessRoleIndicator => _webDriver.FindElement(By.XPath("//p[text()='Business Role']/../div[@class='form-value']"));
    private IWebElement CategoriesDropDown =>
        _webDriver.FindElement(By.XPath("//div[@id='DetailFormcategories-input-search-text']/input"));

    public void CreateNewContact(string name, string surname, string role, string categories)
    {
        var givenCategories = string.Concat(categories.Where(c => !char.IsWhiteSpace(c))).Split(',');
        CreateContact.Click();
        WaitForElementIsDisplayed(FirstNameSelector);
        FirstName.SendKeys(name);
        WaitForElementIsDisplayed(LastNameSelector);
        LastName.SendKeys(surname);
        SelectRole(role);
        foreach (var item in givenCategories)
        {
            SelectCategory(item);
        }

        SaveBtn.Click();
    }

    public void CheckContact(string name, string surname, string role, string categories)
    {
        var givenCategories = string.Concat(categories.Where(c => !Char.IsWhiteSpace(c))).Split(',');
        Thread.Sleep(1000);
        WaitForElementIsDisplayed(By.XPath($"//span[@class='detailLink']//a[text()='{name} {surname}']"));
        _webDriver.FindElement(By.XPath($"//span[@class='detailLink']//a[text()='{name} {surname}']")).Click();
        WaitForElementIsDisplayed(HeaderSelector);
        Header.Text.Should().Contain($"{name} {surname}");
        Categories.Text.Should().ContainAll(givenCategories);
        BusinessRoleIndicator.Text.Should().Contain(role);
    }

    private void SelectRole(string role)
    {
        Thread.Sleep(1000);
        WaitForElementIsDisplayed(BusinessRoleSelector);
        BusinessRole.Click();
        _webDriver.FindElement(By.XPath($"//div[contains(@class,'option-cell') and text()='{role}']")).Click();
    }

    private void SelectCategory(string category)
    {
        Category.Click();
        CategoriesDropDown.SendKeys(category);
        var selector = By.XPath($"//div[contains(@class,'option-cell') and text()='{category}']");
        var element = _webDriver.FindElement(selector);
        ClickOnElement(element);
    }
}