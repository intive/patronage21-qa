Feature: Form module - sign up
	Description
	#Task in QA Team: https://tracker.intive.com/jira/browse/IP2-182
	#Task in JS Team: https://tracker.intive.com/jira/browse/IP2-99
	
Background: 
	Given Set the Endpoint with method POST
	And Add Headers

#url to test in zephyr
Scenario: 1 Form module Send request with required data
	Given I fill required data
	When I send the request to API with required data
	Then The server should return empty body

#url to test in zephyr
Scenario: 2 Form module Send request filling data and checking all required fields
	Given I fill all data 
	When I send request to API 
	Then Successful execution and the server should return empty body 

#url to test in zephyr
Scenario: 3 Form module Send request without field 'Imię'
	Given I fill required data but without field 'Imię'
	When I send request to API without field 'Imię'
	Then The server should return error message about missing field 'Imię'

#url to test in zephyr
Scenario: 4 Form module Send request without field 'Nazwisko'
	Given I fill required data but without field 'Nazwisko'
	When I send request to API without field 'Nazwisko'
	Then The server should return error message about missing field 'Nazwisko'

#url to test in zephyr
Scenario: 5 Form module Send request without field 'Adres e-mail'
	Given I fill required data but without field 'Adres e-mail'
	When I send request to API without field 'Adres e-mail'
	Then The server should return error message about missing field 'Adres e-mail'

#url to test in zephyr
Scenario: 6 Form module Send request without field 'Numer telefonu'
	Given I fill required data but without field 'Numer telefonu'
	When I send request to API without field 'Numer telefonu'
	Then The server should return error message about missing field 'Numer telefonu'

#url to test in zephyr
Scenario: 7 Form module Send request without marked fields: 'JavaScript, Java, QA, Mobile'
	Given I fill required data without marked fields: 'JavaScript, Java, QA, Mobile'
	When I send request to API without marked fields: 'JavaScript, Java, QA, Mobile'
	Then The server should return error message about unmarked fields: 'JavaScript, Java, QA, Mobile'

#url to test in zephyr
Scenario: 8 Form module Send request marking all fields about technology groups
	Given I fill required data with marking all about technology groups
	When I send request to API marked all technology groups fields 
	Then The server should return error message about marked to much technology groups

#url to test in zephyr
Scenario: 9 Form module Send request marking only one field from 'Technologie'
	Given I fill required data with marking one field about technology groups
	When I send request to API marked only one field
	Then The server return empty body

#url to test in zephyr
Scenario: 10 Form module Send request marking three fields from 'Technologie'
	Given I fill required data with marking three fields from 'Technologie'
	When I send request to API marked three fields from 'Technologie'
	Then The server should execute request and return empty body

#url to test in zephyr
Scenario: 11 Form module Send request without fields: 'Hasło' and 'Powtórz hasło'
	Given I fill required data without fields: 'Hasło' and 'Powtórz hasło'
	When I send request to API without fields: 'Hasło' and 'Powtórz hasło'
	Then The server should return error message about missing fields: 'Hasło' and 'Powtórz hasło'

#url to test in zephyr
Scenario: 12 Form module Send request without repeated password field
	Given I fill required data without field 'Powtórz hasło'
	When I send request to API without field about repeated password
	Then The server should return error message about missing field 'Powtórz hasło'

#url to test in zephyr
Scenario: 13 Form module Send request without password field but with field 'Powtórz hasło'
	Given I fill required data without field 'Hasło'
	When I send request to API without field 'Hasło'
	Then The server should return error message about missing field 'Hasło'

#url to test in zephyr 
Scenario: 14 Form module Send request without marked field 'Zgoda obowiązkowa'
	Given I fill required data without field 'Zgoda obowiązkowa'
	When I send request to API without field 'Zgoda obowiązkowa'
	Then The server should return error message about unmarked field 'Zgoda obowiązkowa'

#url to test in zephyr
Scenario: 15 Form module Send request with empty form
	Given I send request to API without data
	Then The server should return error message about missing data
