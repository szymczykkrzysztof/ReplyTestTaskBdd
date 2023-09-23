Feature: CrmCloud
Crm Cloud Portal

    Scenario: Create User
    #Given Admin Login to Crm with login "Admin" and password "Admin"
        When User navigates to "Sales & Marketing" and "Contacts"
    #	And Create new contact
    #	Then User open created contact and check data

    Scenario: Run Report
    #Given Login to Crm with login "Admin" and password "Admin"
        When User navigates to "Reports & Settings" and "Reports"

    Scenario: Remove Events From Actitity Log
        When User navigates to "Reports & Settings" and "Activity Log"