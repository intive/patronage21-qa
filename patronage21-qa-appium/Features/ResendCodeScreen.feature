﻿Feature: ResendCodeScreen
	User wants to be able to 
	resend activation code
	during registration process
#Task in QA Team: https://tracker.intive.com/jira/browse/IP2-253
#Task in Android Team: https://tracker.intive.com/jira/browse/IP2-146

# zephyr link
Scenario: RESEND_CODE_SCREEN_1_IP2-253_resend_code_screen_displayed_correctly
	Given User registers as "JanKowalski" with "jankowalski@email.com" email
	When User clicks "Nie otrzymałem/am kodu" on "Weryfikacja adresu email" screen
	Then User sees "Wyślij ponownie kod" screen

# zephyr link
@ignore
Scenario: RESEND_CODE_SCREEN_2_IP2-253_code_resent_correctly
	Given User registers as "JanKowalski" with "jankowalski@email.com" email
	When User clicks "Nie otrzymałem/am kodu" on "Weryfikacja adresu email" screen
	And User writes "jankowalski@email.com" to "Email" field
	And User clicks "Wyślij kod" on "Wyślij ponownie kod" screen
	Then User sees "Weryfikacja adresu email" screen
	And Code is sent to "jankowalski@email.com" email

# zephyr link
Scenario: RESEND_CODE_SCREEN_3_IP2-253_wrong_email_provided
	Given User registers as "JanKowalski" with "jankowalski@email.com" email
	When User clicks "Nie otrzymałem/am kodu" on "Weryfikacja adresu email" screen
	And User clicks "Wyślij kod" on "Wyślij ponownie kod" screen
	And User writes "jankowalskigmail.com" to "Email" field
	And User clicks "Wyślij kod" on "Wyślij ponownie kod" screen
	And User writes "jankowalskigmailcom" to "Email" field
	And User clicks "Wyślij kod" on "Wyślij ponownie kod" screen
	And User writes "jankowalski@gmailcom" to "Email" field
	And User clicks "Wyślij kod" on "Wyślij ponownie kod" screen
	And User writes "jankowalski@.com" to "Email" field
	And User clicks "Wyślij kod" on "Wyślij ponownie kod" screen
	And User writes "jankowalski@gmail." to "Email" field
	And User clicks "Wyślij kod" on "Wyślij ponownie kod" screen
	Then User sees "Wyślij ponownie kod" screen