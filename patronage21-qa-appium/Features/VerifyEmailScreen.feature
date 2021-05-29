Feature: VerifyEmailScreen
	User wants to be able to
	activate his account during 
	registration process
#Task in QA Team: https://tracker.intive.com/jira/browse/IP2-258
#Task in Android Team: https://tracker.intive.com/jira/browse/IP2-145

# zephyr link
Scenario: VERIFY_EMAIL_1_IP2-258_verify_email_screen_displayed_correctly
	When User registers as "JanKowalski"
	Then User sees "Aktywacja" screen

# zephyr link
Scenario: VERIFY_EMAIL_2_IP2-258_correct_code_provided
	When User registers as "JanKowalski"
	And User writes code assigned to "JanKowalski" to "Kod" field
	And User clicks "Zatwierdź kod"
	Then User sees "Potwierdzenie rejestracji" screen

# zephyr link
Scenario: VERIFY_EMAIL_3_IP2-258_wrong_code_provided
	When User registers as "JanKowalski"
	And User clicks "Zatwierdź kod"
	And User writes code different than assigned to "JanKowalski" to "Kod" field
	And User clicks "Zatwierdź kod"
	And User writes "1234567" to "Kod" field
	And User clicks "Zatwierdź kod"
	Then User sees "Aktywacja" screen

# zephyr link
Scenario: VERIFY_EMAIL_4_IP2-258_code_field_max_length
	When User registers as "JanKowalski"
	And User writes "123456789" to "Kod" field
	Then User sees "12345678" in "Kod" field