Feature: User Search
	User Story: There will be a user story when it's ready
	Task in Java Board: https://tracker.intive.com/jira/browse/IP2-90
	Task in QA Board: https://tracker.intive.com/jira/browse/IP2-193

Background: 
Given Customer sets the endpoint as /frontend-api/users with method GET

# https://tracker.intive.com/jira/browse/IP2-332
Scenario: USER_SEARCH_[/frontend-api/users]_[GET]_1_IP2-90_Searching_for_the_existing_user_by_firstName_lastName_or_userName
Given Customer enters <key> and <value> as a query parameter
When Customer sends the request to the endpoint
// przypisanie response'a w WHEN
Then The server returns code 200 
And JSON body contains list


# https://tracker.intive.com/jira/browse/IP2-381
Scenario: USER_SEARCH_[/frontend-api/users]_[GET]_2_IP2-90_Searching_for_user_by_two_valid_queries
Given Customer enters 'key' and 'value' as a query parameter
When Customer sends the request to the endpoint
Then The server returns code 200
And JSON body contains valid 'name and value'



# https://tracker.intive.com/jira/browse/IP2-382 
Scenario: USER_SEARCH_[/frontend-api/users]_[GET]_3_IP2-90_Searching_for_firstName_and_lastName_shorter_than_two_characters
When Customer sends the firstName value as 'a' and lastName value as 'a'
Then The server returns code 422
And JSON body contains rejectedValue 'a'


# https://tracker.intive.com/jira/browse/IP2-383
Scenario: USER_SEARCH_[/frontend-api/users]_[GET]_4_IP2-90_Searching_for_firstName_and_lastName_with_number_inside
When Customer sends the firstName value as 'John1' and lastName value as 'Doe1'
Then The server returns code 422
And JSON body contains rejectedValue 'Tomasz1'


# Brak linku
Scenario: USER_SEARCH_[/frontend-api/users]_[GET]_5_IP2-90_Searching_for_lastName_with_double_barreled lastName
When Customer sends the lastName value as 'Doe-Nowak'
Then The server returns code 200
And JSON body contains array


# https://tracker.intive.com/jira/browse/IP2-333
Scenario: USER_SEARCH_[/frontend-api/users]_[GET]_5_IP2-90_Searching_for_the_non-existing_user
Given Customer enters 'firstName' and 'Jacek' as a query parameter
When Customer sends the request to the endpoint
Then The server returns code 200 
And JSON body contains array


# https://tracker.intive.com/jira/browse/IP2-384
Scenario: USER_SEARCH_[/frontend-api/users]_[GET]_6_IP2-90_Sending_request_with_no_query_parameter
When Customer sends the request without any query parameter
Then The server returns code 200
And JSON body contains array