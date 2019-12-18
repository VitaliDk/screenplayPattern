Feature: PostDeploymentUISmokeTests
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: User can view an order
   Given the user is logged into the DMI
   When the user navigates to the orders page
   Then the user can see an order

Scenario: user can navigate to the order details page
   Given the user is on the orders page
   When the user can find at least 1 order
   And the user clicks the link to the order details page for an order
   Then the user is taken to the order details page

Scenario: User can view a settlement
   Given the user is logged into the DMI
   When the user navigates to the settlements page
   Then the user can see a settlement

Scenario: User can view basic information on the order details page
   Given the user is on the order details page
   Then the user can see the system name is displayed

Scenario: User can view a balance
   Given the user has the ability to view balances
   And the user is logged into the DMI
   When the user navigates to the balances page
   Then the user can see a balance

Scenario: User can view a holding
   Given the user has the ability to view holdings
   And the user is logged into the DMI
   When the user navigates to the register page
   Then the user can see a holding

Scenario: User can view a tranche within a holding
   Given the user is on the register page
   When the user expands all holdings on the page
   Then the user can see atleast one tranche

 Scenario: User can view an underlying order within a settlement
   Given the user is on the settlements page
   When the user searches for all settlements for the client 
      And  the user expands all settlements on the page
   Then the user can see at least one underlying order on the page



   
