@ignore
Feature: USER_PROFILE [frontend-api/users/{login}/image] Deleting Users Image

Task in QA board: https://tracker.intive.com/jira/browse/IP2-795
Task in Java board: https://tracker.intive.com/jira/browse/IP2-765

Background:
Given Endpoint is /frontend-api/users/{login}/image

# https://tracker.intive.com/jira/browse/IP2-849
Scenario: USER_PROFILE_[frontend-api/users/{login}/image]_[DELETE]_1_IP2-765_Delete_users_image_correct
Given Client sets the endpoint with method DELETE
And enters valid login 

|login      |
|kowalski87 |

When Client sends the request to the endpoint
Then The server returns code 200 - image removed


# https://tracker.intive.com/jira/browse/IP2-850
Scenario: USER_PROFILE_[frontend-api/users/{login}/image]_[DELETE]_2_IP2-765_Incorrect_login_entered_when_deleting_photo
Given Client sets the endpoint with method DELETE
And enters wrong login 

|login     |
|kowalski80|

When Client sends the request to the endpoint
Then The server returns code 404
And message "User not found" is displayed


# https://tracker.intive.com/jira/browse/IP2-851
Scenario: USER_PROFILE_[frontend-api/users/{login}/image]_[DELETE]_3_IP2-765_Entering_login_with_an_illegal_character_when_deleting_photo
Given Client sets the endpoint with method DELETE
And enters login with an illegal character

|login      |
|kowalski@@ |

When Client sends the request to the endpoint
Then The server returns code 422
And message "Invalid argument" is displayed