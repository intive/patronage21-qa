@ignore
Feature: USER_PROFILE GettingOneUser
	
Task in QA board: https://tracker.intive.com/jira/browse/IP2-645
Task in Java board: https://tracker.intive.com/jira/browse/IP2-507


#https://tracker.intive.com/jira/browse/IP2-1002
Scenario: USER_PROFILE_[/api/users/{login}]_[GET]_1_IP2-507_Getting_information_about_one_user_using_login_that_exists_in_database
Given User exists in the database
When User sends a GET request using a proper login
|login     |
|kowalski87|
Then Server returns status 200
And Json body contain information about the user

#https://tracker.intive.com/jira/browse/IP2-1003
Scenario: USER_PROFILE_[/api/users/{login}]_[GET]_2_IP2-507_Getting_information_about_one_user_using_login_that_does_not_exist_in_database
Given User does not exist in the database
When User sends a GET request using a login that does not exist
| login  |
| blabla |
Then Server returns status 404
And Message "Użytkownik nie został znaleziony." is displayed

#https://tracker.intive.com/jira/browse/IP2-1004
Scenario: USER_PROFILE_[/api/users/{login}]_[GET]_3_IP2-507_Getting_information_about_one_user_using_invalid_login
Given User does not exist in the database
When User sends a GET request using invalid login
| login |
| 4 4   |
Then Server returns status 422
And Message "Błędny argument." is displayed