Feature: IdentityProvider
     Testing the identity provider

@Browser: Firefox
Scenario: A user is able to log into the DMI
	Given the user is on the login page
	When the user attempts to log in
	Then the user is redirected to the DMI

Scenario: A user is able to log out of the DMI
    Given the user is logged into the DMI
	When the user attempts to log out
    Then the user is redirected to the DMI login page

Scenario: User is shown a validation message when attempting to log in with an invalid username
    Given the user is on the login page
	When the user attempts to log in with an invalid username
	Then the user is shown a validation message explaining that their login attempt was unsuccessful
	
Scenario: User is shown a validation message when attempting to log in with an invalid password
    Given the user is on the login page
	When the user attempts to log in with an invalid password
	Then the user is shown a validation message explaining that their login attempt was unsuccessful

Scenario: A disabled user cannot log in
    Given the user is on the login page
	   And the user is disabled and attempts to log in
    Then the user is shown a validation message explaining that their login attempt was unsuccessful

Scenario: A deleted user cannot log in
    Given the user is on the login page
	   And the user is deleted and attempts to log in
    Then the user is shown a validation message explaining that their login attempt was unsuccessful

Scenario: A user is redirected to the change password page when their password is 1825 days old
   Given the user is on the login page
      And the user's password is 1825 days old
   When the user attempts to log in
   Then the user is redirected to the change password page

Scenario: A user with a 1824 day old password can log in without being forced to change their password
   Given the user is on the login page
      And the user's password is 1824 days old
   When the user attempts to log in
   Then the user is redirected to the DMI

 Scenario: User can log in successfully after specifying an incorrect password twice
   Given the user is on the login page
   When the user attempts to log in 2 times with an incorrect password
     And the user attempts to log in
   Then the user is redirected to the DMI

 Scenario: User is locked out after specifying an incorrect password 3 times
   Given the user is on the login page
   When the user attempts to log in 3 times with an incorrect password
     And the user attempts to log in
   Then the user is shown a validation message explaining that their login attempt was unsuccessful

 Scenario: test email functions
   Given I can read emails