Feature: Registration form
	User signs up to Patronage by form.
	#Task in JS Board: https://tracker.intive.com/jira/browse/IP2-98 and https://tracker.intive.com/jira/browse/IP2-243
	#Task in QA Board: https://tracker.intive.com/jira/browse/IP2-180

Background:
	Given User is on registration page

#zephyr link
Scenario: REGISTRATION_FORM_1_IP2-243_form_with_correctly_data
	Given User fills data correctly
	When User clicks on the Załóż konto button
	Then User should be on site about e-mail verification

#zephyr link
Scenario: REGISTRATION_FORM_2_IP2-243_empty_form
	Given User doesn't fill data
	Then User can't click on the button Załóż konto

#zephyr link
Scenario Outline: REGISTRATION_FORM_3_IP2-243_form_with_incorrect:_email_phoneNumber_password_confirmPassword
	Given User fills <fieldName> incorrect
	When User clicks on the Załóż konto button
	Then User should see that field <fieldName> is incorrect

Examples:
	| fieldName      |
	| Adres email    |
	| Numer telefonu |
	| Hasło          |
	| Powtórz hasło  |
	| Github link    |

#zephyr link
Scenario Outline: REGISTRATION_FORM_4_IP2-243_form_with_data_which_is_too_short
	Given User fills too short <fieldName>
	When User clicks on the Załóż konto button
	Then User should see error message about too short <fieldName>
	
Examples:
	| fieldName         |
	| Numer telefonu |
	| Hasło             |
	| Login             |

#zephyr link
Scenario Outline: REGISTRATION_FORM_5_IP2-243_form_with_data_which_is_too_long
	Given User fills too short <fieldName>
	When User clicks on the Załóż konto button
	Then User should see error message about too short <fieldName>

Examples:
	| fieldName			|
	| Imie				|
	| Nazwisko			|
	| Numer telefonu |
	| Login             |

#zephyr link
Scenario: REGISTRATION_FORM_6_IP2-243_form_filled_with_unchecked_fields:_'JavaScript,Java,QA,Mobile'
	Given User fills required data
	And User doesn't check fields about technology groups
	When User clicks on the Załóż konto button
	Then User should see error message about unchecked technology groups
	
#zephyr link
Scenario: REGISTRATION_FORM_7_IP2-243_form_filled_with_checked_all_fields:_'JavaScript,Java,QA,Mobile'
	Given User fills required data 
	And User checks all fields about technology grups
	When User clicks on the Załóż konto button
	Then User should see error message about checked too many technology groups

#zephyr link
Scenario: REGISTRATION_FORM_8_IP2-243_form_with_checked_three_fields:_'JavaScript,Java,QA,Mobile'
	Given User fills required data 
	And User checks three technology groups
	When User clicks on the Załóż konto button
	Then User should be on site about e-mail verification 

#zephyr link
Scenario: REGISTRATION_FORM_9_IP2-243_form_without_checked_field_'Regulamin'
	Given User fills required data 
	When Users doesn't check field Regulamin
	Then Then The button is inactive

#zephyr link
Scenario Outline: REGISTRATION_FORM_10_IP2-243_form_without_data_in_field
	Given User doesn't fill data in <fieldName>
	Then User can't click on the button Załóż konto

Examples: 
	| fieldName       |
	| Imie            |
	| Nazwisko        |
	| Adres email     |
	| Numer telefonu  |
	| Link do Githuba |
	| Login           |
	| Hasło           |
	| Powtórz hasło   |
