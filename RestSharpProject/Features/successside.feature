Feature: successside
# link to Zephyr 

@mytag
Scenario: The user makes a successful registration request

	Given the user sees the registration success message
	When  the user clicks on <zamknij> button 
	Then the user should be redirected to <Witaj w Patron-a-tive!> page