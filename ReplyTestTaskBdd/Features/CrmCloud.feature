Feature: CrmCloud
Crm Cloud Portal

    Scenario: Create User
        Given Admin Login to Crm with login "admin" and password "admin"
        When User navigates to "Sales & Marketing" and "Contacts"
        And Create new contact with name "Alan" surname "Delon" role "CEO" categories "Customers, Suppliers"
        Then User open created contact and check data "Alan" surname "Delon" role "CEO" categories "Customers, Suppliers"

    Scenario: Run Report
        Given Admin Login to Crm with login "admin" and password "admin"
        When User navigates to "Reports & Settings" and "Reports"
        And Find "Project Profitability" report
        And Run report
        Then Verify results were returned

    Scenario: Remove Events From Actitity Log
        Given Admin Login to Crm with login "admin" and password "admin"
        When User navigates to "Reports & Settings" and "Activity Log"
        And Select 3 first items in the table
        And Click Actions and Delete
        Then Verify 3 items were deleted