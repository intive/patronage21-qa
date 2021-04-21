Feature: Form module
	Description
	#Task in QA Team: https://tracker.intive.com/jira/browse/IP2-182
	#Task in JS Team: https://tracker.intive.com/jira/browse/IP2-244
	
Background: 
	Given Endpoint is /api/register
	And Add Headers

#https://tracker.intive.com/jira/browse/IP2-314
Scenario: Form_Module_[/api/register]_[POST]_1_IP-182_send_request_with_required_data
	Given User filled required data
	When User interface sends the request to API
	Then The server should return positive status 200 
	And JSON body without sensitive data

#https://tracker.intive.com/jira/browse/IP2-317
Scenario: Form_Module_[/api/register]_[POST]_2_IP-182_send_request_filling_data_and_checking_all_required_fields
	Given User filled all data 
	When User interface sends the request to API 
	Then The server should return positive status 200 
	And JSON body without sensitive data

#https://tracker.intive.com/jira/browse/IP2-318
Scenario: Form_Module_[/api/register]_[POST]_3_IP-182_send_request_without_data_in_field_'Imię'
	Given User filled required data but without data in field Imię
	When User interface sends the request to API
	Then The server should return status 400
	And JSON body with message about missing field Imię

#https://tracker.intive.com/jira/browse/IP2-319
Scenario: Form_Module_[/api/register]_[POST]_4_IP-182_send_request_without_data_in_field_'Nazwisko'
	Given User filled required data but without data in field Nazwisko
	When User interface sends the request to API
	Then The server should return status 400 
	And JSON body with message about missing field Nazwisko

#https://tracker.intive.com/jira/browse/IP2-320
Scenario: Form_Module_[/api/register]_[POST]_5_IP-182_send_request_without_data_in_field_'Adres e-mail'
	Given User filled required data but without data in field Adres e-mail
	When User interface sends the request to API
	Then The server should return status 400 
	And JSON body with message about missing field Adres e-mail

#https://tracker.intive.com/jira/browse/IP2-321
Scenario: Form_Module_[/api/register]_[POST]_6_IP-182_send_request_without_data_in_field_'Numer telefonu'
	Given User filled required data but without data in field Numer telefonu
	When User interface sends the request to API
	Then The server should return status 400 
	And JSON body with message about missing field Numer telefonu

#https://tracker.intive.com/jira/browse/IP2-322
Scenario: Form_Module_[/api/register]_[POST]_7_IP-182_send_request_without_checked_fields:_'JavaScript, Java, QA, Mobile'
	Given User filled required data without checked fields: JavaScript, Java, QA, Mobile
	When User interface sends the request to API
	Then The server should return status 400 
	And JSON body with message about unchecked fields: JavaScript, Java, QA, Mobile

#https://tracker.intive.com/jira/browse/IP2-323
Scenario: Form_Module_[/api/register]_[POST]_8_IP-182_send_request_marking_all_fields_about_technology_groups
	Given User filled required data with checking all technology groups
	When User interface sends the request to API
	Then The server should return status 400
	And JSON body with message about too many technology groups checked

#https://tracker.intive.com/jira/browse/IP2-324
Scenario: Form_Module_[/api/register]_[POST]_9_IP-182_send_request_marking_only_one_field_from_'Technologie'
	Given User filled required data with checking one field about technology groups
	When User interface sends the request to API
	Then The server should return positive status 200 
	And JSON body without sensitive data

#https://tracker.intive.com/jira/browse/IP2-325
Scenario: Form_Module_[/api/register]_[POST]_10_IP-182_send_request_marking_three_fields_from_'Technologie'
	Given User filled required data with checking three fields from Technologie
	When User interface sends the request to API
	Then The server should return positive status 200 
	And JSON body without sensitive data

#https://tracker.intive.com/jira/browse/IP2-326
Scenario: Form_Module_[/api/register]_[POST]_11_IP-182_send_request_without_data_in_field_'Github link'
	Given User filled required data without data in field github link
	When User interface sends the request to API
	Then The server should return status 400 
	And JSON body with message about incorrect github link

#https://tracker.intive.com/jira/browse/IP2-327
Scenario: Form_Module_[/api/register]_[POST]_12_IP-182_send_request_without_data_in_password_field
	Given User filled required data without data in field Hasło
	When User interface sends the request to API
	Then The server should return status 400 
	And JSON body with message about missing field Hasło

#https://tracker.intive.com/jira/browse/IP2-328
Scenario: Form_Module_[/api/register]_[POST]_13_IP-182_send_request_with_empty_form
	Given User didn't fill data
	Then The server should return status 400
	And JSON body with message about missing data

#https://tracker.intive.com/jira/browse/IP2-329
Scenario: Form_Module_[/api/register]_[POST]_14_IP-182_send_request_with_too_long_phone_number
	Given User filled request to API with too long phone number
	When User interface sends the request to API
	Then The server should return status 400 
	And JSON body with message about incorrect phone number

#https://tracker.intive.com/jira/browse/IP2-330
Scenario: Form_Module_[/api/register]_[POST]_15_IP-182_send_request_with_too_short_phone_number
	Given User filled request to API with too short phone number
	When User interface sends the request to API
	Then The server should return status 400 
	And JSON body with message about incorrect phone number

#https://tracker.intive.com/jira/browse/IP2-385
Scenario: Form_Module_[/api/register]_[POST]_16_IP-182_form_with_incorrect_field_'Github link'
	Given User fills field github link with random letters
	When User interface sends the request to API
	Then The server should return status 400 
	And JSON body with message about incorrect github link

#zephyr link
Scenario: Form_Module_[/api/register]_[POST]_17_IP-182_form_with_too_long_first_name
	Given User fills too long first name
	When User interface sends the request to API
	Then The server should return status 400 
	And JSON body with message about incorrect first name

#zephyr link
Scenario: Form_Module_[/api/register]_[POST]_19_IP-182_form_with_too_long_last_name
	Given User fills too long last name
	When User interface sends the request to API
	Then The server should return status 400 
	And JSON body with message about incorrect last name

#zephyr link
Scenario: Form_Module_[/api/register]_[POST]_20_IP-182_form_incorrect_email
	Given User fills incorrect email 
	When User interface sends the request to API
	Then The server should return status 400 
	And JSON body with message about incorrect email

#zephyr link
Scenario: Form_Module_[/api/register]_[POST]_21_IP-182_form_with_incorrect_password
	Given User fills incorrect password 
	When User interface sends the request to API
	Then The server should return status 400 
	And JSON body with message about incorrect password

#zephyr link
Scenario: Form_Module_[/api/register]_[POST]_22_IP-182_form_with_email_assigned_to_another_account
	Given User fills email which is not unique 
	When User interface sends the request to API
	Then The server should return status 400 
	And JSON body with message about incorrect email

#zephyr link
Scenario: Form_Module_[/api/register]_[POST]_23_IP-182_form_with_login_assigned_to_another_account
	Given User fills login which is not unique 
	When User interface sends the request to API
	Then The server should return status 400 
	And JSON body with message about incorrect login

#zephyr link
Scenario: Form_Module_[/api/register]_[POST]_24_IP-182_send_request_without_data_about_title
	Given User filled required data but without data about title
	When User interface sends the request to API
	Then The server should return status 400
	And JSON body with message about incorrect title