@ignore
Feature: USER_PROFILE [/api/projects] UserDeactivation

Task in QA board: https://tracker.intive.com/jira/browse/IP2-654
Task in Java board: https://tracker.intive.com/jira/browse/IP2-358

Background:
Given User is registered 

# link to Zephyr_1_test
Scenario: USER_PROFILE_[/api/projects]_[PATCH]_1_IP2-358_Correct_user_deactivation
When User enters valid login

|login     |
|kowalski87|

And User sends a PATCH request 
Then Server returns the code 200 


# link to Zephyr_2_test
Scenario: USER_PROFILE_[/api/projects]_[PATCH]_2_IP2-358_Deactivation_after_entering_non-existent_login
When User enters non-existent login 

| login   |
| jan3    |

And User sends a PATCH request 
Then Server returns the code 404
And Message "User not found" is displayed


# link to Zephyr_3_test
Scenario Outline: USER_PROFILE_[/api/projects]_[PATCH]_3_IP2-358_Deactivation_after_entering_the_login_incorrectly
When User enters '<login>' with invalid characters 
And User sends a PATCH request 
Then Server returns the code 422
And Message "Invalid argument" is displayed

Examples:
| login      |
| J#n8       |
| J an8      |
| kowal**ski |