Feature: SuccessSide

#link to Zephyr_1 test
Scenario: SUCCESS_SIDE_1_IP2-175_The_user_makes_a_successful_registration_request
	Given the user sees the registration success message
	When the user clicks on button <zamknij>
	Then the user should be redirected to their page <Witaj w Patron-a-tive!>