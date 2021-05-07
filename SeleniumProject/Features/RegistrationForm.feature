﻿Feature: Registration form
	User signs up to Patronage by form.
	#Task in JS Board: https://tracker.intive.com/jira/browse/IP2-98 and https://tracker.intive.com/jira/browse/IP2-243
	#Task in QA Board: https://tracker.intive.com/jira/browse/IP2-180

#zephyr link
Scenario: REGISTRATION_FORM_1_IP2-243_form_with_correctly_data
	Given User fills data correctly
		| firstName | lastName | email             | phone       | githubLink             | login        | password         | passwordConfirm  |
		| Jan       | Kowalski | example@email.com | 123456789   | github.com/exampleLink | exampleLogin | examplePassword@ | examplePassword@ |
	Then Button Załóż konto is active

#zephyr link
Scenario: REGISTRATION_FORM_2_IP2-243_empty_form
	Given User doesn't fill data
	Then Button Załóż konto is inactive

#zephyr link
Scenario Outline: REGISTRATION_FORM_3_IP2-243_form_with_incorrect:_email_phoneNumber_password_confirmPassword
	Given User fills <fieldName> incorrect
		| firstName | lastName | email             | phone       | githubLink             | login        | password         |
		| Jan       | Kowalski | example@email.com | 123456789   | github.com/exampleLink | exampleLogin | examplePassword@ |
	When User clicks on next <nextFieldName>
	Then User should see that field <fieldName> is incorrect
	And Button Załóż konto is inactive

Examples:
	| fieldName      | nextFieldName  |
	| Adres email    | Numer telefonu |
	| Numer telefonu | Github link    |
	| Github link    | Technologie    |
	| Hasło			 | Powtórz hasło  |
	| Powtórz hasło  | Regulamin      |

#zephyr link
Scenario Outline: REGISTRATION_FORM_4_IP2-243_form_with_data_which_is_too_short
	Given User fills too short <fieldName>
		| firstName | lastName | email             | githubLink             |
		| Jan       | Kowalski | example@email.com | github.com/exampleLink |
	When User clicks on next <nextFieldName>
	Then User should see error message about too short <fieldName>
	And Button Załóż konto is inactive
	
Examples:
	| fieldName      | nextFieldName |
	| Numer telefonu | Github link   |
	| Login          | Hasło         |
	| Hasło          | Powtórz hasło |

#zephyr link
Scenario Outline: REGISTRATION_FORM_5_IP2-243_form_with_data_which_is_too_long
	Given User fills too long <fieldName>
	When User clicks on next <nextFieldName>
	Then User should see error message about too long <fieldName>
	And Button Załóż konto is inactive

Examples:
	| fieldName      | nextFieldName |
	| Imie           | Nazwisko      |
	| Nazwisko       | Adres email   |
	| Numer telefonu | Github link   |
	| Login          | Hasło         |

#zephyr link
Scenario: REGISTRATION_FORM_6_IP2-243_form_filled_with_unchecked_fields:_'JavaScript,Java,QA,Mobile'
	Given User fills data which is before technologies field
		| firstName | lastName | email             | phone       | githubLink             |
		| Jan       | Kowalski | example@email.com | 123456789   | github.com/exampleLink |
	When User clicks on Login field
	Then Button Załóż konto is inactive
	
#zephyr link
Scenario: REGISTRATION_FORM_7_IP2-243_form_filled_with_checked_all_fields:_'JavaScript,Java,QA,Mobile'
	Given User fills data which is before technologies field
		| firstName | lastName | email             | phone       | githubLink             |
		| Jan       | Kowalski | example@email.com | 123456789   | github.com/exampleLink |
	When User checks all fields about technologies grups
	Then User should see error message about checked too many technology groups
	And Button Załóż konto is inactive

#zephyr link
Scenario: REGISTRATION_FORM_8_IP2-243_form_with_checked_three_fields:_'JavaScript,Java,QA,Mobile'
	Given User fills all data without technologies
		| firstName | lastName | email             | phone       | githubLink             | login        | password         | passwordConfirm  |
		| Jan       | Kowalski | example@email.com | 123456789   | github.com/exampleLink | exampleLogin | examplePassword@ | examplePassword@ |
	When User checks three technologies groups
	Then Button Załóż konto is active

#zephyr link
Scenario: REGISTRATION_FORM_9_IP2-243_form_without_checked_field_'Regulamin'
	Given User fills all data
		| firstName | lastName | email             | phone     | githubLink             | technologies | login       | password         | passwordConfirm  |
		| Jan       | Kowalski | example@email.com | 123456789 | github.com/exampleLink | QA           |exampleLogin | examplePassword@ | examplePassword@ |
	When Users doesn't check field Regulamin
	Then Button Załóż konto is inactive