Feature: UserDownload

Task in QA board: https://tracker.intive.com/jira/browse/IP2-188
Task in Java board: https://tracker.intive.com/jira/browse/IP2-91
Sub – Tasks 2.


# link to Zephyr_1 test
Scenario Outline: USERS_PAGE_1_IP2-91_User_is_looking_for_a_specific_user_successfuly
Given User '<user_data>' exists
When User enters the '<user_data>' in the "szukaj użytkownika" field
And  User selects a '<technology_group>'
Then A user with name and surname equal '<user_data>' is displayed

Examples:
| user_data        | technology_group                                  |
| name and surname | Wszystkie grupy technologiczne                    |
| name and surname | technological group in which this user is located |


# link to Zephyr_2 test
Scenario Outline: USERS_PAGE_2_IP2-91_User_is_looking_for_a_specific_user_without_providing_all_data
Given User is on the "users" page
When User enters the '<user_data>' in the "szukaj użytkownika" field
And  User selects '<technology_group>' 
Then The searched user doesn't appear
And Is displayed '<result>'

Examples:
| user_data | technology_group               | result                                    |
| name      | wszystkie grupy technologiczne | all users with that name                  |
| surname   | wszystkie grupy technologiczne | all users with that surname               |
| name      | specific technology group      | all users with that name in this group    |
| surname   | specific technology group      | all users with that surname in this group |


# link to Zephyr_3 test
Scenario: USERS_PAGE_3_IP2-91_User_is_looking_for_a_specific_user_unsuccessfuly
Given User is on the "users" page
When User writes '<user_data>' in the "szukaj użytkownika" field
And  The user selects a '<technology_group>' in which this user is not located
Then User with this name and surname is not displayed