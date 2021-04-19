Feature: User Search
	User Story: There will be a user story when it's ready
	Task in Java Board: https://tracker.intive.com/jira/browse/IP2-90
	Task in QA Board: https://tracker.intive.com/jira/browse/IP2-193

Background: 
Given endpoint is /api/users
And Customer sets the endpoint with method GET

# https://tracker.intive.com/jira/browse/IP2-332
Scenario Outline: USER_SEARCH_[/api/users]_[GET]_1_IP2-90_Searching_for_the_existing_user_by name_surname_or_username
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


# https://tracker.intive.com/jira/browse/IP2-381
Scenario: USER_SEARCH_[/api/users]_[GET]_2_IP2-90_Searching_for_user_by_two_valid_queries
Given User with first name "Tomasz" and last name "Nowak" exists in application
And Customer enters "?firstName=Tomasz&lastName=Nowak" as a query
When Customer sends the request to the endpoint
Then The server returns code 200
And JSON body contains <"firstName": "Tomasz"> and <"lastName": "Nowak">


# https://tracker.intive.com/jira/browse/IP2-382
Scenario: USER_SEARCH_[/api/users]_[GET]_3_IP2-90_Searching_for_user_by_first_valid_and_second_invalid_query_param
Given User with first name "Tomasz" and last name "Nowak" exists in application
And Customer enters "?firstName=Tomasz&lastNNNName=Nowak" as a query
When Customer sends the request to the endpoint
Then The server returns code 200
And JSON body contains <"firstName": "Tomasz">


# https://tracker.intive.com/jira/browse/IP2-383
Scenario: USER_SEARCH_[/api/users]_[GET]_4_IP2-90_Searching_for_user_by_first_invalid_and_second_valid_query_param
Given User with first name "Tomasz" and last name "Nowak" exists in application
And Customer enters "?firsdNName=Tomasz&lastName=Nowak" as a query
When Customer sends the request to the endpoint
Then The server returns code 400
And Error message is shown


# https://tracker.intive.com/jira/browse/IP2-333
Scenario Outline: USER_SEARCH_[/api/users]_[GET]_5_IP2-90_Searching_for_the_non-existing_user
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


# https://tracker.intive.com/jira/browse/IP2-384
Scenario Outline: USER_SEARCH_[/api/users]_[GET]_6_IP2-90_Sending_request_with_no_value_in_query
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