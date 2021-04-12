Feature: User Search
	User Story: There will be a user story when it's ready
	Task in Java Board: https://tracker.intive.com/jira/browse/IP2-90
	Task in QA Board: https://tracker.intive.com/jira/browse/IP2-193

Background: 
Given URL endpoint is /api/users

@mytag
# https://tracker.intive.com/jira/browse/IP2-332
Scenario Outline: [/api/users][GET]_1_Searching for the existing user by name, surname or username
Given Customer sets the endpoint with method GET
And Several users exist in application
And Customer enters valid <searchData> as a query parameter
When Customer sends the request to the endpoint
Then The server returns code 200 
And JSON body contains <searchData>
Examples:
| searchData                 |
| ?userName=nazwaUzytkownika |
| ?firstName=Imie            |
| ?lastName=Nazwisko         |

# https://tracker.intive.com/jira/browse/IP2-333
Scenario Outline: [/api/users][GET]_2_Searching for the non-existing user
Given Customer sets the endpoint with method GET
And Customer enters invalid <searchData> as a query parameter
When Customer sends the request to the endpoint
Then The server returns code 200 
And JSON body is empty
Examples:
| searchData                         |
| ?username=nieznanaNazwaUzytkownika |
| ?firstName=nieznaneImie            |
| ?lastName=nieznaneNazwisko         |