using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using ReplyTestTaskBdd.Drivers;
using ReplyTestTaskBdd.PageObjects;

namespace ReplyTestTaskBdd.Hooks;
[Binding]
public class CrmCloudHooks
{
    /// <summary>
    /// Login to application with admin credentials
    /// </summary>
    /// <param name="browserDriver"></param>
    [BeforeScenario]
    public static void BeforeScenario(BrowserDriver browserDriver)
    {
        var loginPage = new LoginPage(browserDriver.Current);
        loginPage.Login("admin", "admin");

    }
}