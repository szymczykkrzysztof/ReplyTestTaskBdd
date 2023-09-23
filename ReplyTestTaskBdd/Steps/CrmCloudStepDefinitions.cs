using ReplyTestTaskBdd.Drivers;
using ReplyTestTaskBdd.PageObjects;

namespace ReplyTestTaskBdd.Steps;

[Binding]
public class CrmCloudStepDefinitions
{
    private readonly LoginPage _loginPage;
    private readonly DashboardPage _dashboard;

    public CrmCloudStepDefinitions(BrowserDriver browserDriver)
    {
        _loginPage = new LoginPage(browserDriver.Current);
        _dashboard = new DashboardPage(browserDriver.Current);
    }
    
    [Given(@"Admin Login to Crm with login ""(.*)"" and password ""(.*)""")]
    public void GivenAdminLoginToCrmWithLoginAndPassword(string username, string password)
    {
        _loginPage.Login(username,password);
    }

    [When(@"User navigates to Sales and Marketing to contacts")]
    public void WhenUserNavigatesToSalesAndMarketingToContacts()
    {
        _dashboard.NavigateTo("Sales & Marketing", "Contacts");
    }

    [When(@"Create new contact")]
    public void WhenCreateNewContact()
    {
        ScenarioContext.StepIsPending();
    }

    [Then(@"User open created contact and check data")]
    public void ThenUserOpenCreatedContactAndCheckData()
    {
        ScenarioContext.StepIsPending();
    }

    [When(@"User navigates to ""(.*)"" and ""(.*)""")]
    public void WhenUserNavigatesToAnd(string tabMenu, string item)
    {
        _dashboard.NavigateTo(tabMenu, item);
    }
}