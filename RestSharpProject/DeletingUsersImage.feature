Feature: DeletingUsersImage

Task in QA board: https://tracker.intive.com/jira/browse/IP2-795
Task in Java board: https://tracker.intive.com/jira/browse/IP2-765

Background:
Given Endpoint is /frontend-api/users/{login}/image

# link to Zephyr_1_test
Scenario: 1_[frontend-api/users/{login}/image]_[DELETE]_Delete_users_image_correct
Given Client sets the endpoint with method DELETE
And enters valid login 

|login      |
|kowalski87 |

When Client sends the request to the endpoint
Then The server returns code 200 - image removed


#link to Zephyr_2_test
Scenario: 2_[frontend-api/users/{login}/image]_[DELETE]_Incorrect_login_entered_when_deleting_photo
Given Client sets the endpoint with method DELETE
And enters wrong login 

|login     |
|kowalski80|

When Client sends the request to the endpoint
Then The server returns code 404
And message "User not found" is displayed


#link to Zephyr_3_test
Scenario: 3_[frontend-api/users/{login}/image]_[DELETE]_Entering_login_with_an_illegal_character_when_deleting_photo
Given Client sets the endpoint with method DELETE
And enters login with an illegal character

|login      |
|kowalski@@ |

When Client sends the request to the endpoint
Then The server returns code 422
And message "Invalid argument" is displayed