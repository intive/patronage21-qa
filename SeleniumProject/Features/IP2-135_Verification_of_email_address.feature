Feature: Verification of email address
User should be able to confirm his/hers email address with received code.
	

Scenario: User inserts correct code
	Given User is on registration site
	And is in possession of code 
	When User is entering the code
	Then Button "Zatwierdź kod" becomes active, can be clicked
	And redirects User on another page


Scenario: User should be able to retrive code
	Given User is on registration site
	And doesn't have code
	When User clicks "Nie otrzymałem/am kodu"
	Then User should receive code one more time
	

Scenario: User shouldn't be able to register with invalid code
	Given User is on registration site
	When User enters false code
	Then User should be moved on the site, where "Wystąpił błąd" is visible.

Scenario: User shouldn't be able to click the button, which has less than 8 characters
	Given User is on registration site
	When User enters incorrect code
	Then Button "Zatwierdz kod" should remain inactive

Scenario: User shouldn't be able to click the button, which has more than 8 characters
	Given User is on registration site
	When User enters incorrect code
	Then Button "Zatwierdz kod" should remain inactive