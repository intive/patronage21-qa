Feature: UserDownload

Task in QA board: https://tracker.intive.com/jira/browse/IP2-188
Task in Java board: https://tracker.intive.com/jira/browse/IP2-91
Sub – Tasks 2.

Background: 
Given User is on the <users> page

# link to Zephyr_1 test
Scenatio Outline: USERS_PAGE_1_IP2-91 -  User is looking for a specific user successfuly
When User enters the "user data" he wants to find in the <szukaj użytkownika> field
And  User selects a technology group 
Then A user with that name and surname is displayed

Examples:
User data        |Technology group                                  |
name and surname |Wszystkie grupy technologiczne                    |
name and surname |technological group in which this user is located |


# link to Zephyr_2 test
Scenario Outline: USERS_PAGE_2_IP2-91 - User is looking for a specific user without providing all data
When User enters the "user data" he wants to find in the <szukaj użytkownika> field
And  User selects a technology group 
Then The searched user is not displayed

Examples:
User data        |Technology group:              |Result:
name             |wszystkie grupy technologiczne |all users with that name                  |
surname          |wszystkie grupy technologiczne |all users with that surname               |
name             |specific technology group      |all users with that name in this group    |
surname          |specific technology group      |all users with that surname in this group |


# link to Zephyr_3 test
Scenario: USERS_PAGE_3_IP2-91 - User is looking for a specific user unsuccessfuly
When User writes the user's name and surname in the <szukaj użytkownika> field
And The user selects a technology group in which this user is not located
Then User with this name and surname is not displayed








