Feature: Form module - sign up
	Description
	#Task in QA Team: https://tracker.intive.com/jira/browse/IP2-182
	#Task in JS Team: https://tracker.intive.com/jira/browse/IP2-244
	
Background: 
	Given Set the Endpoint with method POST
	And Add Headers

#url to test in zephyr
Scenario: 1_Form_module - Send request with required data
	Given User filled required data
	When User interface sends the request to API
	Then The server should return status 200 with empty JSON body

#url to test in zephyr
Scenario: 2_Form_module - Send request filling data and checking all required fields
	Given User filled all data 
	When User interface sends the request to API 
	Then Successful execution, the server should return status 200 with empty JSON body 

#url to test in zephyr
Scenario: 3_Form_module - Send request without field 'Imię'
	Given User filled required data but without field 'Imię'
	When User interface sends the request to API
	Then The server should return status 400 and JSON body with message about missing field 'Imię'

#url to test in zephyr
Scenario: 4_Form_module - Send request without field 'Nazwisko'
	Given User filled required data but without field 'Nazwisko'
	When User interface sends the request to API
	Then The server should return status 400 and JSON body with message about missing field 'Nazwisko'

#url to test in zephyr
Scenario: 5_Form_module - Send request without field 'Adres e-mail'
	Given User filled required data but without field 'Adres e-mail'
	When User interface sends the request to API
	Then The server should return status 400 and JSON body with message about missing field 'Adres e-mail'

#url to test in zephyr
Scenario: 6_Form_module - Send request without field 'Numer telefonu'
	Given User filled required data but without field 'Numer telefonu'
	When User interface sends the request to API
	Then The server should return status 400 and JSON body with message about missing field 'Numer telefonu'

#url to test in zephyr
Scenario: 7_Form_module - Send request without marked fields: 'JavaScript, Java, QA, Mobile'
	Given User filled required data without checked fields: 'JavaScript, Java, QA, Mobile'
	When User interface sends the request to API
	Then The server should return status 400 and JSON body with message about unchecked fields: 'JavaScript, Java, QA, Mobile'

#url to test in zephyr
Scenario: 8_Form_module - Send request marking all fields about technology groups
	Given User filled required data with checking all about technology groups
	When User interface sends the request to API
	Then The server should return status 400 and JSON body with message about too many technology groups checked

#url to test in zephyr
Scenario: 9_Form_module - Send request marking only one field from 'Technologie'
	Given User filled required data with checking one field about technology groups
	When User interface sends the request to API
	Then The server returns status 200 and empty JSON body

#url to test in zephyr
Scenario: 10_Form_module - Send request marking three fields from 'Technologie'
	Given User filled required data with checking three fields from 'Technologie'
	When User interface sends the request to API
	Then The server should execute request and return status 200 and empty JSON body

#url to test in zephyr
Scenario: 11_Form_module - Send request without fields: 'Hasło' and 'Powtórz hasło'
	Given User filled required data without fields: 'Hasło' and 'Powtórz hasło'
	When User interface sends the request to API
	Then The server should return status 400 and JSON body with message about missing fields: 'Hasło' and 'Powtórz hasło'

#url to test in zephyr
Scenario: 12_Form_module - Send request without repeated password field
	Given User filled required data without field 'Powtórz hasło'
	When User interface sends the request to API
	Then The server should return status 400 and JSON body with message about missing field 'Powtórz hasło'

#url to test in zephyr
Scenario: 13_Form_module - Send request without password field but with field 'Powtórz hasło'
	Given User filled required data without field 'Hasło'
	When User interface sends the request to API
	Then The server should return status 400 and JSON body with message about missing field 'Hasło'

#url to test in zephyr 
Scenario: 14_Form_module - Send request without marked field 'Zgoda obowiązkowa'
	Given User filled required data without field 'Zgoda obowiązkowa'
	When User interface sends the request to API
	Then The server should return status 400 and JSON body with message about unmarked field 'Zgoda obowiązkowa'

#url to test in zephyr
Scenario: 15_Form_module - Send request with empty form
	Given User filled request to API without data
	Then The server should return status 400 and JSON body with message about missing data
