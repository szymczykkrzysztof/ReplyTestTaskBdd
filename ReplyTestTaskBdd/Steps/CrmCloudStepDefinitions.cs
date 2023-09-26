using NUnit.Framework;
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
    private readonly ActivityLogPage _activityLogPage;
    private int _numberOfItemsInLog = 0;

    public CrmCloudStepDefinitions(BrowserDriver browserDriver)
    {
        _contactsPage = new ContactsPage(browserDriver.Current);
        _loginPage = new LoginPage(browserDriver.Current);
        _dashboard = new DashboardPage(browserDriver.Current);
        _reportsPage = new ReportsPage(browserDriver.Current);
        _activityLogPage = new ActivityLogPage(browserDriver.Current);
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

    [When(@"Select (.*) first items in the table")]
    public void WhenSelectFirstItemsInTheTable(int numberOfItems)
    {
        _numberOfItemsInLog = _activityLogPage.GetNumberOfAllItems();
        _activityLogPage.SelectLogItems(numberOfItems);
    }

    [When(@"Click Actions and Delete")]
    public void WhenClickActionsAndDelete()
    {
        _activityLogPage.ExecuteDelete();
    }
    
    [Then(@"Verify (.*) items were deleted")]
    public void ThenVerifyItemsWereDeleted(int deletedItems)
    {
        Thread.Sleep(2000);
        var currentNumberOfItemsInLog = _activityLogPage.GetNumberOfAllItems();
        Assert.AreEqual(_numberOfItemsInLog-deletedItems,currentNumberOfItemsInLog);
    }
}