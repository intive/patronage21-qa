Feature: UserDownload

Task in QA board: https://tracker.intive.com/jira/browse/IP2-188
Task in Java board: https://tracker.intive.com/jira/browse/IP2-91
Sub – Tasks 2.

# link to Zephyr test 
Scenario: 1_User is looking for a specific user correctly
Given User is on the <users> page
When User writes the user's name and surname in the <szukaj użytkownika> field
And User selects <wszystkie grupy technologiczne> 
Then A user with that name and surname is displayed


# link to Zephyr test
Scenario: 2_User is looking for a specific user correctly
Given User is on the <users> page
When User writes the user's name and surname in the <szukaj użytkownika> field
And User selects the technological group in which this user is located 
Then A user with that name and surname is displayed


# link to Zephyr test
Scenario: 3_User is looking for a specific user incorrectly
Given User is on the <users> page
When User writes the user's name and surname  
And The user selects a technology group in which this user is not located 
Then User with this name and surname is not displayed 


# link to Zephyr test
Scenario: 4_User is looking for a specific user without providing all data 
Given  User is on the <users> page
When  User writes the user's name in the <szukaj użytkownika> field
And  User selects <wszystkie grupy technologiczne> 
Then  A list of users with that name is displayed 


# link to Zephyr test
Scenario: 5_User is looking for a specific user without providing all data 
Given User is on the <users> page
When User writes the user's surname in the <szukaj użytkownika> field
And  User selects <wszystkie grupy technologiczne> 
Then A list of users with that surname is displayed 


# link to Zephyr test
Scenario: 6_User is looking for a specific user without providing all data 
Given User is on the <users> page
When User writes the user's name in the <szukaj użytkownika> field
And User selects a specific technological group 
Then Users with that name in this group are showing up 


# link to Zephyr test
Scenario: 7_User is looking for a specific user without providing all data 
Given User is on the <users> page
When User writes the user's surname in the <szukaj użytkownika> field
And User selects a specific technological group 
Then Users with that surname in this group are showing up