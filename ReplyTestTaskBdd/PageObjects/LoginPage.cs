using OpenQA.Selenium;

namespace ReplyTestTaskBdd.PageObjects;

/// <summary>
/// Login Page Object class
/// </summary>
public class LoginPage : BasePageObject
{
    public LoginPage(IWebDriver webDriver) : base(webDriver)
    {
    }

    private IWebElement UserName => _webDriver.FindElement(By.Id("login_user"));
    private IWebElement Password => _webDriver.FindElement(By.Id("login_pass"));
    private IWebElement LoginBtn => _webDriver.FindElement(By.Id("login_button"));

    public void Login(string username, string password)
    {
        _webDriver.Navigate().GoToUrl(Hooks.Hooks.Configuration?["url"]);
        UserName.SendKeys(username);
        Password.SendKeys(password);
        LoginBtn.Click();
    }
}