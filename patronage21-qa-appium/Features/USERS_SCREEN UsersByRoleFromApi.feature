@ignore
Feature: USERS_SCREEN UsersByRoleFromApi
	User needs to see correct
	users in lists in Users screen
	while searching for users
#Task in QA Team: https://tracker.intive.com/jira/browse/IP2-470
#Task in Android Team: https://tracker.intive.com/jira/browse/IP2-339

# https://tracker.intive.com/jira/browse/IP2-1010
Scenario Outline: USERS_SCREEN_1_IP2-339_users_lists_data_from_api_loaded_correctly
	Given User is on "Użytkownicy" screen
	And Existing user "<user>" assigned to "<list>" list
	Then User sees user "<user>" in "<list>" list
	And User does not see "<user> in "<not_in_list>" list

Examples: 
| user           | list       | not_in_list |
| Anna Nowak     | Liderzy    | Uczestnicy  |
| Marshall Smith | Uczestnicy | Liderzy     |
