Feature: User Search
	User Story: There will be a user story when it's ready
	Task in Java Board: https://tracker.intive.com/jira/browse/IP2-90
	Task in QA Board: https://tracker.intive.com/jira/browse/IP2-193

Background: 
Given endpoint is /api/users
And Customer sets the endpoint with method GET

# https://tracker.intive.com/jira/browse/IP2-332
Scenario Outline: [/api/users][GET]_1_Searching for the existing user by name, surname or username
Given Several users exist in application
And Customer enters valid <query>
When Customer sends the request to the endpoint
Then The server returns code 200 
And JSON body contains <body>
Examples:
| query              | body                   |
| ?userName=TomNowak | "userName": "TomNowak" |
| ?firstName=Tomasz  | "firstName": "Tomasz"  |
| ?lastName=Nowak    | "lastName": "Nowak"    |


# link to Zephyr will be added after review
Scenario: [/api/users][GET]_2_Searching for user by two valid queries
Given User with first name "Tomasz" and last name "Nowak" exists in application
And Customer enters "?firstName=Tomasz&lastName=Nowak" as a query
When Customer sends the request to the endpoint
Then The server returns code 200
And JSON body contains "firstName": "Tomasz" and "lastName": "Nowak"


# link to Zephyr will be added after review
Scenario: [/api/users][GET]_3_Searching for user by first valid and second invalid query params
Given User with first name "Tomasz" and last name "Nowak" exists in application
And Customer enters "?firstName=Tomasz&lastNNNName=Nowak" as a query
When Customer sends the request to the endpoint
Then The server returns code 400
And Error message is shown


# https://tracker.intive.com/jira/browse/IP2-333
Scenario Outline: [/api/users][GET]_4_Searching for the non-existing user
Given Customer sets the endpoint with method GET
And Customer enters invalid <searchData> as a query
When Customer sends the request to the endpoint
Then The server returns code 200 
And JSON contains empty array
Examples:
| searchData                 |
| ?username=nieznanaNazwa    |
| ?firstName=nieznaneImie    |
| ?lastName=nieznaneNazwisko |


# link to Zephyr will be added after review
Scenario Outline: [/api/users][GET]_5_Sending request with no value in query
Given Customer sets the endpoint with method GET
And Customer enters valid <key> as the query parameter
When Customer sends the request without any value in the query
Then The server returns code 400
And Error message is shown
Examples:
| key         |
| ?username=  |
| ?firstName= |
| ?lastName=  |