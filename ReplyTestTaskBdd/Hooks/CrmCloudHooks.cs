using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using ReplyTestTaskBdd.Drivers;
using ReplyTestTaskBdd.PageObjects;

namespace ReplyTestTaskBdd.Hooks;
[Binding]
public class CrmCloudHooks
{
    //TODO: ask how to login via api - as following code is not that approach
    // [BeforeScenario]
    // public static void BeforeScenario(BrowserDriver browserDriver)
    // {
    //     var loginPage = new LoginPage(browserDriver.Current);
    //     loginPage.Login("admin", "admin");
    //
    // }
}