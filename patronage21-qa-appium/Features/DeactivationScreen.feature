Feature: DeactivationScreen
	User wants to be able to 
	deactivate his profile
	to sign out from Patronage
#Task in QA Team: https://tracker.intive.com/jira/browse/IP2-264
#Task in Android Team: https://tracker.intive.com/jira/browse/IP2-155

Background: 
	Given User is not logged in

# https://tracker.intive.com/jira/browse/IP2-758
Scenario Outline: USERS_SCREEN_1_IP2-152_deactivation_screen_displayed_correctly
	When User registers as "jankwalski" with surname "Kowalski"
	And User navigates to "Dezaktywacja" screen through "<way>"
	Then User sees "Dezaktywacja" screen

	Examples: 
	| way         |
	| Użytkownicy |
	| Moje konto  |
	
# https://tracker.intive.com/jira/browse/IP2-759
Scenario: USERS_SCREEN_2_IP2-152_account_deactivated_correctly
	When User registers as "jankwalski" with surname "Kowalski"
	And User navigates to "Dezaktywacja" screen through "Moje konto" 
	And User writes "Kowalski" to "Nazwisko" field
	And User clicks "Dezaktywuj profil"
	Then User with username "jankowalski" profile is deactivated
	And User is not logged in

# https://tracker.intive.com/jira/browse/IP2-760
Scenario: USERS_SCREEN_3_IP2-152_wrong_surname_provided
	When User registers as "jankwalski" with surname "Kowalski"
	And User navigates to "Dezaktywacja" screen through "Moje konto" 
	And User writes "notKowalski" to "Nazwisko" field
	And User clicks "Dezaktywuj profil"
	Then User sees "Dezaktywacja" screen
	
# https://tracker.intive.com/jira/browse/IP2-761
Scenario: USERS_SCREEN_4_IP2-152_too_long_surname_provided
	When User registers as "jankwalski" with surname "Kowalski"
	And User navigates to "Dezaktywacja" screen through "Moje konto" 
	And User writes "31" characters to "Nazwisko" field
	Then User sees "30" characters in "Nazwisko" field
