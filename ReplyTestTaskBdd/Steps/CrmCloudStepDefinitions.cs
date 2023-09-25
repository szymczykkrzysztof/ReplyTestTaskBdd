using ReplyTestTaskBdd.Drivers;
using ReplyTestTaskBdd.PageObjects;

namespace ReplyTestTaskBdd.Steps;

[Binding]
public class CrmCloudStepDefinitions
{
    private readonly LoginPage _loginPage;
    private readonly DashboardPage _dashboard;
    private readonly ContactsPage _contactsPage;
    private readonly ReportsPage _reportsPage;

    public CrmCloudStepDefinitions(BrowserDriver browserDriver)
    {
        _contactsPage = new ContactsPage(browserDriver.Current);
        _loginPage = new LoginPage(browserDriver.Current);
        _dashboard = new DashboardPage(browserDriver.Current);
        _reportsPage = new ReportsPage(browserDriver.Current);
    }

    [Given(@"Admin Login to Crm with login ""(.*)"" and password ""(.*)""")]
    public void GivenAdminLoginToCrmWithLoginAndPassword(string username, string password)
    {
        _loginPage.Login(username, password);
    }

    [When(@"User navigates to Sales and Marketing to contacts")]
    public void WhenUserNavigatesToSalesAndMarketingToContacts()
    {
        _dashboard.NavigateTo("Sales & Marketing", "Contacts");
    }

    [When(@"Create new contact")]
    public void WhenCreateNewContact()
    {
    }


    [When(@"User navigates to ""(.*)"" and ""(.*)""")]
    public void WhenUserNavigatesToAnd(string tabMenu, string item)
    {
        _dashboard.NavigateTo(tabMenu, item);
    }

    [When(@"Create new contact with name ""(.*)"" surname ""(.*)"" role ""(.*)"" categories ""(.*)""")]
    public void WhenCreateNewContactWithNameSurnameRoleCategories(string name, string surname, string role,
        string categories)
    {
        _contactsPage.CreateNewContact(name, surname, role, categories);
    }

    [Then(@"User open created contact and check data ""(.*)"" surname ""(.*)"" role ""(.*)"" categories ""(.*)""")]
    public void ThenUserOpenCreatedContactAndCheckDataSurnameRoleCategories(string name, string surname, string role,
        string categories)
    {
        _contactsPage.CheckContact(name, surname, role, categories);
    }

    [When(@"Find ""(.*)"" report")]
    public void WhenFindReport(string reportName)
    {
        _reportsPage.FindReport(reportName);
    }

    [When(@"Run report")]
    public void WhenRunReport()
    {
        _reportsPage.RunReport();
    }


    [Then(@"Verify results were returned")]
    public void ThenVerifyResultsWereReturned()
    {
        _reportsPage.CheckResults();
    }
}