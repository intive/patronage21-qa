Feature: UserDetailsScreen
	User wants to be able to 
	view informations about
	himself and other users

# zephyr link
Scenario Outline: USER_DETAILS_SCREEN_1_IP2-269_user_details_screen_displayed_correctly
	Given User registers as "<username>"
	When User clicks "Użytkownicy"
	And User selects "<user>" from "Użytkownicy" list
	Then User sees "Szczegóły użytkownika" screen
	And "Szczegóły użytkownika" screen is displayed correctly

Examples: 
	| username       | user        |
	| JanKowalski    | JanKowalski |
	| NiejanKowalski | JanKowalski |
	
# zephyr link
Scenario: USER_DETAILS_SCREEN_2_IP2-269_navigate_to_other_screen_and_back
	Given User registers as "JanKowalski"
	When User clicks "Użytkownicy"
	And  User selects "JanKowalski" from "Użytkownicy" list
	And User clicks "Edytuj profil"
	And User clicks "Back" button
	And User clicks "Dezaktywuj profil"
	And User clicks "Back" button
	Then User sees "Szczegóły użytkownika" screen

@ignore
# zephyr link
Scenario Outline: USER_DETAILS_SCREEN_3_IP2-269_contact_buttons_works
	Given User registers as "<username>"
	When User clicks "Użytkownicy"
	And  User selects "<user>" from "Użytkownicy" list
	And User clicks "<button>"
	Then User is redirected to "<redirection>"

Examples: 
	| username       | user        | button           | redirection    |
	| NiejanKowalski | JanKowalski | Wyślij wiadomość | Email app      |
	| NiejanKowalski | JanKowalski | Zadzwoń          | Phone call app |
	| NiejanKowalski | JanKowalski | Otwórz link      | Web browser    |