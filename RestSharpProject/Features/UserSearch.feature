Feature: User Search
	User Story: There will be a user story when it's ready
	Task in Java Board: https://tracker.intive.com/jira/browse/IP2-90
	Task in QA Board: https://tracker.intive.com/jira/browse/IP2-193

Background: 
Given URL endpoint is /api/users

@mytag
# link do testu 1 w Zephyr
Scenario Outline: 1_Searching for the existing user by name, surname or username
Given Customer sets the endpoint with method GET
And Customer enters <searchData> as a query parameter
And <searchData> exists in the database
When Customer sends the request to the endpoint
Then The server returns code 200 
And JSON body contains <searchData>
Examples:
| searchData                 |
| ?userName=nazwaUzytkownika |
| ?firstName=Imie            |
| ?lastName=Nazwisko         |

# link do testu 2 w Zephyr
Scenario Outline: 2_Searching for the non-existing user
Given Customer sets the endpoint with method GET
And Customer enters <searchData> as a query parameter
And <searchData> doesn't exist in the database
When Customer sends the request to the endpoint
Then The server returns code 400 
And JSON body contains message "Użytkownik nie istnieje"
Examples:
| searchData                         |
| ?username=nieznanaNazwaUzytkownika |
| ?firstName=nieznaneImie            |
| ?lastName=nieznaneNazwisko         |

# link do testu 3 w Zephyr
Scenario: 3_Using non-allowed methods for the endpoint
Given Customer sets the endpoint with non-allowed method
When Customer sends the request to the endpoint
Then The server returns code 405