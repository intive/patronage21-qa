Feature: USERS_PAGE UserDownload

Task in QA board: https://tracker.intive.com/jira/browse/IP2-188
Task in Java board: https://tracker.intive.com/jira/browse/IP2-91
Sub – Tasks 2.

Background: 
Given User is on the users page

# https://tracker.intive.com/jira/browse/IP2-535
Scenario Outline: USERS_PAGE_1_IP2-91_User_is_looking_for_a_specific_user_successfuly
Given User clicks on search field
When User typing '<user_data>' for find specific person
And User selects a '<technology_group>'
Then A user with name and surname is displayed

Examples:
| user_data        | technology_group                                  |
| Tomek Kowalski   | Wszystkie grupy technologiczne                    |
| Tomek Kowalski   | Java                                              |


# https://tracker.intive.com/jira/browse/IP2-536
Scenario Outline: USERS_PAGE_2_IP2-91_User_is_looking_for_a_specific_user_without_providing_all_data
Given User clicks on search field
When User typing incomplete '<user_data>' for find specific person
And User selects a '<technology_group>'
Then Is displayed '<result>'

Examples:
| user_data | technology_group               | result                                    |
| Tomek     | wszystkie grupy technologiczne | all users with that name                  |
| Kowalski  | wszystkie grupy technologiczne | all users with that surname               |
| Tomek     | Java                           | all users with that name in this group    |
| Kowalski  | Java                           | all users with that surname in this group |


# https://tracker.intive.com/jira/browse/IP2-537
Scenario Outline: USERS_PAGE_3_IP2-91_User_is_looking_for_a_specific_user_unsuccessfuly
Given User clicks on search field
When User typing '<user_data>' for find specific person
And  The user selects a '<technology_group>' in which this user is not located
Then The message "Brak wyników" is displayed 

Examples:
| user_data      | technology_group |
| Tomek Kowalski | Mobile (Android) |