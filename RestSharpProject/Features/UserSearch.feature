Feature: User Search
	User Story: There will be a user story when it's ready
	Task in Java Board: https://tracker.intive.com/jira/browse/IP2-90
	Task in QA Board: https://tracker.intive.com/jira/browse/IP2-193

Background: 
Given Customer sets the endpoint as /api/users with method GET

# https://tracker.intive.com/jira/browse/IP2-332
Scenario Outline: USER_SEARCH_[/api/users]_[GET]_1_IP2-90_Searching_for_the_existing_user_by name_surname_or_username
Given Several users exist in application
And Customer enters valid <name> and <value> as a query parameter
When Customer sends the request to the endpoint
Then The server returns code 200 
And JSON body contains <name> and <value>
Examples:
| name      | value    |
| userName  | TomNowak |
| firstName | Tomasz   |
| lastName  | Nowak    |


# https://tracker.intive.com/jira/browse/IP2-381
Scenario: USER_SEARCH_[/api/users]_[GET]_2_IP2-90_Searching_for_user_by_two_valid_queries
Given User with 'firstName', 'Tomasz' and 'lastName', 'Nowak' exists in application
And Customer enters 'firstName', 'Tomasz' and 'lastName', 'Nowak' as a query parameter
When Customer sends the request to the endpoint
Then The server returns code 200
And JSON body contains valid 'name and value'



# https://tracker.intive.com/jira/browse/IP2-382
Scenario: USER_SEARCH_[/api/users]_[GET]_3_IP2-90_Searching_for_user_by_first_valid_and_second_invalid_query_param
Given User with 'firstName', 'Tomasz' and 'lastName', 'Nowak' exists in application
And Customer enters 'firstName', 'Tomasz' and 'lastNNName', 'Nowak' as a query parameter
When Customer sends the request to the endpoint
Then The server returns code 200
And JSON body contains valid 'user object'


# https://tracker.intive.com/jira/browse/IP2-383
Scenario: USER_SEARCH_[/api/users]_[GET]_4_IP2-90_Searching_for_user_by_first_invalid_and_second_valid_query_param
Given User with 'firstName', 'Tomasz' and 'lastName', 'Nowak' exists in application
And Customer enters 'firsdNName', 'Tomasz' and 'lastName', 'Nowak' as a query parameter
When Customer sends the request to the endpoint
Then The server returns code 400
And Error message 'message' is shown


# https://tracker.intive.com/jira/browse/IP2-333
Scenario Outline: USER_SEARCH_[/api/users]_[GET]_5_IP2-90_Searching_for_the_non-existing_user
Given Customer enters invalid <name> and <value> as a query paraneter
When Customer sends the request to the endpoint
Then The server returns code 200 
And JSON contains empty array
Examples:
| name      | value            |
| username  | nieznanaNazwa    |
| firstName | nieznaneImie     |
| lastName  | nieznaneNazwisko |


# https://tracker.intive.com/jira/browse/IP2-384
Scenario Outline: USER_SEARCH_[/api/users]_[GET]_6_IP2-90_Sending_request_with_no_value_in_query
Given Customer enters valid <name> as the query parameter
When Customer sends the request without any value in the query
Then The server returns code 400
And Error message 'meeesage' is shown
Examples:
| name      |
| username  |
| firstName |
| lastName  |