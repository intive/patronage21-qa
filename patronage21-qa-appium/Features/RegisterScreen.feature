Feature: RegisterScreen
	New user wants to be able to register an account
	to apply for the Patronative program

Background: 
	Given User is on Registration page
	
# zephyr link
Scenario: REGISTER_SCREEN_1_IP2-261_register_screen_displayed_correctly
	Then User sees "Rejestracja" screen
	
# zephyr link
Scenario Outline: REGISTER_SCREEN_2_IP2-261_register_successfully
	When User completes form correctly but with "<field>" set to "<value>"
	Then Submit button is active

	Examples:
	| field      | value                                                          |
	| Imiê       | Ja                                                             |
	| Imiê       | JanJanJanJanJanJanJanJanJanJan                                 |
	| Imiê       | Jan[znakidiakrytyczne]                                         |
	| Nazwisko   | Kowalski[znakidiakrytyczne]                                    |
	| Nazwisko   | KowalskiKowalskiKowalskiKowals                                 |
	| Nazwisko   | Ko                                                             |
	| Login      | Ja                                                             |
	| Login      | JanKowalskiJanK                                                |
	| Login      | Jan1234567890                                                  |
	| Password   | A@$!%?&a                                                       |
	| Password   | AqwerAqwerAqwer@@@@@                                           |
	| Github URL | https://www.github.com/Jan-Kowalski                            |
	| Github URL | https://www.github.com/J                                       |
	| Github URL | https://www.github.com/JanKoJanKoJanKoJanKoJanKoJanKoJanKoJanK |
	| Github URL | https://www.github.com/JanKowalski                             |
	| Github URL | http://www.github.com/JanKowalski                              |
	| Github URL | www.github.com/JanKowalski                                     |
	| Github URL | https://github.com/JanKowalski                                 |
	| Github URL | http://github.com/JanKowalski                                  |
	| Github URL | github.com/JanKowalski                                         |

	
# zephyr link
Scenario: REGISTER_SCREEN_2_IP2-261_incorrect_tech_groups_checkboxes_all_selected
	When User completes form correctly but with every tech group selected
	Then Submit button is inactive
	
# zephyr link
Scenario: REGISTER_SCREEN_2_IP2-261_incorrect_tech_groups_checkboxes_none_selected
	When User completes form correctly but without any tech group selected
	Then Submit button is inactive
	
# zephyr link
Scenario: REGISTER_SCREEN_2_IP2-261_incorrect_consents
	When User completes form correctly but with "Login" set to "JanKowalski"
	And User clicks "Pierwsza zgoda" checkbox
	And User submits register form
	And User clicks "Druga zgoda" checkbox
	And User submits register form
	And User clicks "Pierwsza zgoda" checkbox
	Then Submit button is inactive

# zephyr link
Scenario Outline:REGISTRATION_SCREEN_3_IP2-261_incorrect_field_validation
	When User completes form correctly but with "<field>" set to "<value>"
	Then Submit button is inactive

	Examples:
	| field           | value                                                           |
	| Imiê            | J                                                               |
	| Imiê            | JanJanJanJanJanJanJanJanJanJanJ                                 |
	| Imiê            | Jan1                                                            |
	| Imiê            | Jan@                                                            |
	| Imiê            | [Empty]                                                         |
	| Nazwisko        | K                                                               |
	| Nazwisko        | KowalskiKowalskiKowalskiKowalsk                                 |
	| Nazwisko        | Kowalski1                                                       |
	| Nazwisko        | Kowalski#                                                       |
	| Nazwisko        | [Empty]                                                         |
	| Email           | jankowalskigmail.com                                            |
	| Email           | jankowalskigmailcom                                             |
	| Email           | jankowalski@gmailcom                                            |
	| Email           | jankowalski@.com                                                |
	| Email           | jankowalskigmail.com                                            |
	| Email           | jankowalski@gmail.                                              |
	| Email           | [Empty]                                                         |
	| Numer telefonu  | 12345678                                                        |
	| Numer telefonu  | 1234567890                                                      |
	| Numer telefonu  | 12345678a                                                       |
	| Numer telefonu  | 12345678a                                                       |
	| Numer telefonu  | [Empty]                                                         |
	| Login           | J                                                               |
	| Login           | JanKowalskiJanKo                                                |
	| Login           | JanKowalski1JanKowalski1                                        |
	| Login           | JanKowalski1JanKowalski1#                                       |
	| Login           | [Empty]                                                         |
	| Has³o           | Qwert+5                                                         |
	| Has³o           | Qwertyuiopasdfghjkl+1                                           |
	| Has³o           | qwerty+8                                                        |
	| Has³o           | Qwertyu+                                                        |
	| Has³o           | [Empty]                                                         |
	| PotwierdŸ has³o | Niepasujace@2                                                   |
	| PotwierdŸ has³o | [Empty]                                                         |
	| Github URL      | https://www./jan-kowalski                                       |
	| Github URL      | https://www.github.com/                                         |
	| Github URL      | https://www.github.com/jan-kowalskijan-kowalskijan-kowalskijank |
	| Github URL      | https://www.github.com/jankowalski@#%                           |
	| Github URL      | https://www.github.com/-jan-kowalski                            |
	| Github URL      | https://www.github.com/jan-kowalski-                            |
