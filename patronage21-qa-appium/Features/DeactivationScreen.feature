Feature: DeactivationScreen
	User wants to be able to 
	deactivate his profile
	to sign out from Patronage
#Task in QA Team: https://tracker.intive.com/jira/browse/IP2-264
#Task in Android Team: https://tracker.intive.com/jira/browse/IP2-155

Background: 
	Given User is not logged in

# zephyr link
Scenario outline: USERS_SCREEN_1_IP2-152_deactivation_screen_displayed_correctly
	When User registers as "jankwalski" with surname "Kowalski"
	And User navigates to "Dezaktywacja" screen through "<way>"
	Then User sees "Dezaktywacja" screen
	Examples: 
	| way         |
	| Użytkownicy |
	| Moje konto  |

# zephyr link
Scenario: USERS_SCREEN_2_IP2-152_deactivation_screen_through_users_screen_displayed_correctly
	When User navigates to "Dezaktywacja" screen through "Moje konto" 
	Then User sees "Dezaktywacja" screen
	
# zephyr link
Scenario: USERS_SCREEN_3_IP2-152_account_deactivated_correctly
	When User registers as "jankwalski" with surname "Kowalski"
	And User navigates to "Dezaktywacja" screen through "Moje konto" 
	And User writes "Kowalski" to "Nazwisko" field
	And User clicks "Dezaktywuj profil"
	Then User with username "jankowalski" profile is deactivated
	And User is not logged in

# zephyr link
Scenario: USERS_SCREEN_4_IP2-152_wrong_surname_provided
	When User registers as "jankwalski" with surname "Kowalski"
	And User navigates to "Dezaktywacja" screen through "Moje konto" 
	And User writes "notKowalski" to "Nazwisko" field
	And User clicks "Dezaktywuj profil"
	Then User sees "Dezaktywacja" screen
	
# zephyr link
Scenario: USERS_SCREEN_5_IP2-152_too_long_surname_provided
	When User registers as "jankwalski" with surname "Kowalski"
	And User navigates to "Dezaktywacja" screen through "Moje konto" 
	And User writes "21" characters to "Nazwisko" field
	Then User sees "20" characters in "Nazwisko" field
