Feature: DeactivationScreen
	User wants to be able to 
	deactivate his profile
	to sign out from Patronage
#Task in QA Team: https://tracker.intive.com/jira/browse/IP2-264
#Task in Android Team: https://tracker.intive.com/jira/browse/IP2-155

Background: 
	Given User is not logged in

# zephyr link
Scenario: USERS_SCREEN_1_IP2-152_deactivation_screen_displayed_correctly
	Given Existing user with username "jankowalski" password "Deactivate1!!" and surname "Kowalski"
	When User log in with username "jankowalski" and password "Deactivate1!!"
	And User navigates to "Dezaktywacja" screen
	Then User sees "Dezaktywacja" screen
	
# zephyr link
Scenario: USERS_SCREEN_2_IP2-152_account_deactivated_correctly
	Given Existing user with username "jankowalski" password "Deactivate1!!" and surname "Kowalski"
	When User log in with username "jankowalski" and password "Deactivate1!!"
	And User navigates to "Deactivation" screen
	And User writes "Kowalski" to "Nazwisko" field
	And User clicks "Dezaktywuj profil"
	Then User with username "jankowalski" and password "Deactivate1!!" profile is deactivated
	And User is not logged in

# zephyr link
Scenario Outline: USERS_SCREEN_3_IP2-152_wrong_surname_provided
	Given Existing user with username "jankowalski" password "Deactivate1!!" and surname "Kowalski"
	When User log in with username "jankowalski" and password "Deactivate1!!"
	And User navigates to "Deactivation" screen
	And User writes "notKowalski" to "Nazwisko" field
	And User clicks "Dezaktywuj profil"
	Then User sees "Dezaktywacja" screen
	
# zephyr link
Scenario: USERS_SCREEN_4_IP2-152_too_long_surname_provided
	Given Existing user with username "jankowalski" password "Deactivate1!!" and surname "Kowalski"
	When User log in with username "jankowalski" and password "Deactivate1!!"
	And User navigates to "Dezaktywacja" screen
	And User writes "21" characters to "Nazwisko" field
	Then User sees "20" characters in "Nazwisko" field
