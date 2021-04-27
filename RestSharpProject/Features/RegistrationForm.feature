Feature: Registration form
	#Task in QA Team: https://tracker.intive.com/jira/browse/IP2-182
	#Task in JS Team: https://tracker.intive.com/jira/browse/IP2-244

#https://tracker.intive.com/jira/browse/IP2-314
Scenario: REGISTRATION_FORM_[/api/register]_[POST]_1_IP-244_send_request_with_correctly_data
	Given User filled data correctly
	When Request sends to API 
	Then The server should return positive status 200 
	And JSON body without sensitive data

Examples:
	| firstName | lastName | email			   | phoneNumber | technologies | password        | login       | githubLink         |
	| Jan       | Kowalski | example@email.com | 123456789   | QA           | randomPassword@ | randomLogin | github.com/example |

#https://tracker.intive.com/jira/browse/IP2-317
Scenario: REGISTRATION_FORM_[/api/register]_[POST]_2_IP-244_send_request_filling_data_and_checking_all_required_fields
	Given User filled all data 
	When Request sends to API 
	Then The server should return positive status 200 
	And JSON body without sensitive data

#https://tracker.intive.com/jira/browse/IP2-318
Scenario Outline: REGISTRATION_FORM_[/api/register]_[POST]_3_IP-244_send_request_without_data_in_field_<fieldName>
	Given User filled required data but without data in field <fieldName>
	When Request sends to API 
	Then The server should return status 400
	And JSON body with message about empty field <fieldName>

Examples:
	| fieldName      |
	| Imię           |
	| Nazwisko       |
	| Adres email    |
	| Numer telefonu |
	| Technologie    |
	| Hasło          |
	| Login          |
	| Github link    |

#https://tracker.intive.com/jira/browse/IP2-319
Scenario: REGISTRATION_FORM_[/api/register]_[POST]_4_IP-244_send_request_checked_all_fields_about_technology_groups
	Given User filled required data with checking all technology groups
	When Request sends to API 
	Then The server should return status 400
	And JSON body with message about too many technology groups checked

#https://tracker.intive.com/jira/browse/IP2-320
Scenario: REGISTRATION_FORM_[/api/register]_[POST]_5_IP-244_send_request_marking_only_one_field_from_'Technologie'
	Given User filled required data with checking one field about technology groups
	When Request sends to API 
	Then The server should return positive status 200 
	And JSON body without sensitive data

#https://tracker.intive.com/jira/browse/IP2-321
Scenario: REGISTRATION_FORM_[/api/register]_[POST]_6_IP-244_send_request_with_empty_form
	Given User didn't fill data
	Then The server should return status 400
	And JSON body with message about missing data

#https://tracker.intive.com/jira/browse/IP2-322
Scenario Outline: REGISTRATION_FORM_[/api/register]_[POST]_7_IP-244_send_request_with_too_long_fields:_Imie_Nazwisko_Numer_telefonu_Login
	Given User filled request to API with too long <fieldName>
	When Request sends to API 
	Then The server should return status 400 
	And JSON body with error message about too long <fieldName>

Examples: 
	| fieldName      |
	| Imię           |
	| Nazwisko       |
	| Numer telefonu |
	| Login          |

#https://tracker.intive.com/jira/browse/IP2-323
Scenario Outline: REGISTRATION_FORM_[/api/register]_[POST]_8_IP-244_send_request_with_too_short_fields:_Imie_Nazwisko_Numer_telefonu_Login
	Given User filled request to API with too short <fieldName>
	When Request sends to API 
	Then The server should return status 400 
	And JSON body with error message about too short <fieldName>

Examples: 
	| fieldName      |
	| Imię           |
	| Nazwisko       |
	| Numer telefonu |
	| Login          |

#https://tracker.intive.com/jira/browse/IP2-324
Scenario Outline: REGISTRATION_FORM_[/api/register]_[POST]_9_IP-244_form_with_incorrect_fields:_email_password_github_link
	Given User fills incorrect <fieldName>
	When Request sends to API 
	Then The server should return status 400 
	And JSON body with message about incorrect <fieldName>

Examples: 
	| fieldName      |
	| Adres email    |
	| Hasło          |
	| Github link    |

#https://tracker.intive.com/jira/browse/IP2-325
Scenario: REGISTRATION_FORM_[/api/register]_[POST]_10_IP-244_form_with_email_assigned_to_another_account
	Given Creates user account
	And User fills email which is not unique 
	When Request sends to API 
	Then The server should return status 400 
	And JSON body with message about not unique email

Examples:
	| firstName | lastName | email			   | phoneNumber | technologies | password        | login       | githubLink         |
	| Jan       | Kowalski | example@email.com | 123456789   | QA           | randomPassword@ | randomLogin | github.com/example |

#https://tracker.intive.com/jira/browse/IP2-326
Scenario: REGISTRATION_FORM_[/api/register]_[POST]_11_IP-244_form_with_login_assigned_to_another_account
	Given Creates user account
	And User fills login which is not unique 
	When Request sends to API 
	Then The server should return status 400 
	And JSON body with message about not unique login

Examples:
	| firstName | lastName | email			   | phoneNumber | technologies | password        | login       | githubLink         |
	| Jan       | Kowalski | example@email.com | 123456789   | QA           | randomPassword@ | randomLogin | github.com/example |