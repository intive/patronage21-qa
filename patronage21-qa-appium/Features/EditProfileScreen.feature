Feature: EditProfileScreen
	User wants to be able to 
	edit his profile data
#Task in QA Team: https://tracker.intive.com/jira/browse/IP2-266
#Task in Android Team: https://tracker.intive.com/jira/browse/IP2-154

# zephyr link
Scenario: EDIT_PROFILE_SCREEN_1_IP2-154_edit_profile_screen_displayed_correctly
	When User registers as "JanKowalski" with surname "Kowalski"
	And User navigates to "Edycja profilu" screen through "Użytkownicy"
	Then User sees "Edycja użytkownika" screen

# zephyr link
Scenario: EDIT_PROFILE_SCREEN_2_IP2-154_edit_profile_correctly
	When User registers
	| title | first_name | last_name | email                 | phone     | github                             | bio      |
	| Pan   | Jan        | Kowalski  | jankowalski@email.com | 123456789 | www.github.com/jankowalski12874509 | Test bio |
	And User navigates to "Edycja profilu" screen through "Użytkownicy"
	And User fills edit form with data
	| titleEdit | first_nameEdit | last_nameEdit | emailEdit                | phoneEdit | githubEdit                            | bioEdit         |
	| Pani      | Janina         | Kowalska      | janinakowalska@email.com | 987654321 | www.github.com/janinakowalska12874509 | Test bio janina |
	And User clicks "Zapisz"
	Then User "JanKowalski" data is
	| titleEdit | first_nameEdit | last_nameEdit | emailEdit                | phoneEdit | githubEdit                            | bioEdit         |
	| Pani      | Janina         | Kowalska      | janinakowalska@email.com | 987654321 | www.github.com/janinakowalska12874509 | Test bio janina |

# zephyr link
Scenario: EDIT_PROFILE_SCREEN_3_IP2-154_incorrect_first_name_provided
	When User registers
	| title | first_name | last_name | email                 | phone     | github                             | bio      |
	| Pan   | Jan        | Kowalski  | jankowalski@email.com | 123456789 | www.github.com/jankowalski12874509 | Test bio |
	And User navigates to "Edycja profilu" screen through "Użytkownicy"
	And User writes "" to "Imię" field
	And User clicks "Zapisz"
	And User writes "J" to "Imię" field
	And User clicks "Zapisz"
	And User writes "Jan1" to "Imię" field
	And User clicks "Zapisz"
	And User writes "Jan!" to "Imię" field
	And User clicks "Zapisz"
	Then User "JanKowalski" "Imię" is "Jan"

# zephyr link
Scenario: EDIT_PROFILE_SCREEN_4_IP2-154_incorrect_last_name_provided
	When User registers
	| title | first_name | last_name | email                 | phone     | github                             | bio      |
	| Pan   | Jan        | Kowalski  | jankowalski@email.com | 123456789 | www.github.com/jankowalski12874509 | Test bio |
	And User navigates to "Edycja profilu" screen through "Użytkownicy"
	And User writes "" to "Nazwisko" field
	And User clicks "Zapisz"
	And User writes "K" to "Nazwisko" field
	And User clicks "Zapisz"
	And User writes "Kowalski1" to "Nazwisko" field
	And User clicks "Zapisz"
	And User writes "Kowalski!" to "Nazwisko" field
	And User clicks "Zapisz"
	Then User "JanKowalski" "Nazwisko" is "Kowalski"

# zephyr link
Scenario: EDIT_PROFILE_SCREEN_5_IP2-154_incorrect_email_provided
	When User registers
	| title | first_name | last_name | email                 | phone     | github                             | bio      |
	| Pan   | Jan        | Kowalski  | jankowalski@email.com | 123456789 | www.github.com/jankowalski12874509 | Test bio |
	And User navigates to "Edycja profilu" screen through "Użytkownicy"
	And User writes "" to "Email" field
	And User clicks "Zapisz"
	And User writes "jankowalskigmail.com" to "Email" field
	And User clicks "Zapisz"
	And User writes "jankowalskigmailcom" to "Email" field
	And User clicks "Zapisz"
	And User writes "jankowalski@gmailcom" to "Email" field
	And User clicks "Zapisz"
	And User writes "jankowalski@.com" to "Email" field
	And User clicks "Zapisz"
	And User writes "jankowalski@gmail." to "Email" field
	And User clicks "Zapisz"
	Then User "JanKowalski" "Email" is "jankowalski@email.com"

# zephyr link
Scenario: EDIT_PROFILE_SCREEN_6_IP2-154_incorrect_phone_number_provided
	When User registers
	| title | first_name | last_name | email                 | phone     | github                             | bio      |
	| Pan   | Jan        | Kowalski  | jankowalski@email.com | 123456789 | www.github.com/jankowalski12874509 | Test bio |
	And User navigates to "Edycja profilu" screen through "Użytkownicy"
	And User writes "" to "Numer telefonu" field
	And User clicks "Zapisz"
	And User writes "12345678" to "Numer telefonu" field
	And User clicks "Zapisz"
	And User writes "12345678a" to "Numer telefonu" field
	And User clicks "Zapisz"
	Then User "JanKowalski" "Numer telefonu" is "123456789"

# zephyr link
Scenario: EDIT_PROFILE_SCREEN_7_IP2-154_incorrect_github_provided
	When User registers
	| title | first_name | last_name | email                 | phone     | github                             | bio      |
	| Pan   | Jan        | Kowalski  | jankowalski@email.com | 123456789 | www.github.com/jankowalski12874509 | Test bio |
	And User navigates to "Edycja profilu" screen through "Użytkownicy"
	And User writes "https://www./jan-kowalski" to "Github" field
	And User clicks "Zapisz"
	And User writes "https://www.github.com/" to "Github" field
	And User clicks "Zapisz"
	And User writes "https://www.github.com/jankowalski@#%" to "Github" field
	And User clicks "Zapisz"
	And User writes "https://www.github.com/-jan-kowalski" to "Github" field
	And User clicks "Zapisz"
	And User writes "https://www.github.com/jan-kowalski-" to "Github" field
	And User clicks "Zapisz"
	Then User "JanKowalski" "Github" is "www.github.com/jankowalski12874509"

# zephyr link
Scenario: EDIT_PROFILE_SCREEN_8_IP2-154_fields_max_length
	When User registers as "JanKowalski" with surname "Kowalski"
	And User navigates to "Edycja profilu" screen through "Użytkownicy"
	And User writes "ImięęImięęImięęImięęImięęImięęę" to "Imię" field
	And User writes "NazwiNazwiNazwiNazwiNazwiNazwis" to "Nazwisko" field
	And User writes "1234567890" to "Numer telefonu" field
	And User writes "www.github.com/githugithugithugithugithugithugithugithu" to "Github" field
	Then User sees "ImięęImięęImięęImięęImięęImięę" in "Imię" field
	And User sees "NazwiNazwiNazwiNazwiNazwiNazwi" in "Nazwisko" field
	And User sees "123456789" in "Numer telefonu" field
	And User sees "www.github.com/githugithugithugithugithugithugithugith" in "Github" field