﻿Feature: UsersScreen
	User wants to be able to find
	other users, filter them 
	by groups and names and view 
	details about them
https://tracker.intive.com/jira/browse/IP2-152

Background: 
	Given User is on "Users" screen

# zephyr link
Scenario: USERS_SCREEN__IP2-152_users_screen_displayed_correctly
	Then "Szukaj użytkownika" field is empty
	And "Wybierz grupę" is set to "Wszystkie grupy technologiczne"
	And User see "liders" list
	And User see "participants" list
	
# zephyr link
Scenario Outline: USERS_SCREEN__IP2-152_search_existing_user
	Given Existing user "<name>" assigned to "<list>" list
	When User write "<name>" into "Szukaj użytkownika" field
	And User click "Enter" button
	Then User see "<name>" in "<list>" list

Examples: 
| name         | list       |
| Jan Kowalski | Uczestnicy |
| Anna Nowak   | Liderzy    |

# zephyr link
Scenario: USERS_SCREEN__IP2-152_search_not_existing_user
	Given No existing user named "not existing user"
	When User write "not existing user" into "Szukaj użytkownika" field
	And User click "Enter" button
	Then User see information that searched user does not exist
	
# zephyr link
Scenario Outline: USERS_SCREEN__IP2-152_search_group
	Given Existing user "<user>" assigned to "<list>" list and "<group>" group
	When User click "Wybierz grupę" 
	And User click "<group>" 
	Then User see user "<user>" in "<list>" list

Examples:
| user         | list       | group   |
| Jan Kowalski | Uczestnicy | Group 1 |
| Jan Kowalski | Uczestnicy | Group 2 |
| Anna Nowak   | Liderzy    | Group 3 |
| Anna Nowak   | Liderzy    | Group 4 |
	
# zephyr link
Scenario: USERS_SCREEN__IP2-152_search_all_groups
	Given Existing user "Jan Kowalski" assigned to "Uczestnicy" list and "Group 1" group
	And Second existing user "Anna Nowak" assigned to "Liderzy" list and "Group 3" group
	When User click "Wybierz grupę"
	And User click "Group 1"
	And User click "Wybierz grupę"
	And User click "Wszystkie grupy technologiczne"
	Then User see user "Jan Kowalski" in "Uczestnicy" list
	And User see user "Anna Nowak" in "Liderzy" list
	
# zephyr link
Scenario: USERS_SCREEN__IP2-152_empty_search_user_field_shows_all_users
	Given Existing user "Jan Kowalski" assigned to "Uczestnicy" list and "Group 1" group
	And Second existing user "Anna Nowak" assigned to "Liderzy" list and "Group 3" group
	When User write "anything" into "Szukaj użytkownika" field
	And User click "Enter" button
	And User clear "Szukaj użytkownika" field
	And User click "Enter" button
	Then User see user "Jan Kowalski" in "Uczestnicy" list
	And User see user "Anna Nowak" in "Liderzy" list
	
# zephyr link
Scenario Outline: USERS_SCREEN__IP2-152_search_user_and_group
	Given Existing user "<name>" assigned to "<list>" list and "<group>" group
	When User write "<name>" into "Szukaj użytkownika" field
	And User click "Enter" button
	And User click "Wybierz grupę"
	And User click "<group>"
	Then User see user "<name>" in "<list>" list

Examples: 
| name         | list       | group   |
| Jan Kowalski | Uczestnicy | Group 1 |
| Anna Nowak   | Liderzy    | Group 3 |

# zephyr link
Scenario Outline: USERS_SCREEN__IP2-152_search_group_and_user
	Given Existing user "<name>" assigned to "<list>" list and "<group>" group
	When User click "Wybierz grupę"
	And User click "<group>" 
	And User write "<name>" into "Szukaj użytkownika" field
	And User click "Enter" button
	Then User does not see user "<name>" in "<list>" list

Examples: 
| name         | list       | group   |
| Jan Kowalski | Uczestnicy | Group 1 |
| Anna Nowak   | Liderzy    | Group 3 |

# zephyr link
Scenario Outline: USERS_SCREEN__IP2-152_search_user_and_wrong_group
	Given Existing user "<name>" assigned to "<list>" list and not to "<group>" group
	And No other user is named "<name>"
	When User write "<name>" into "Szukaj użytkownika" field
	And User click "Enter" button
	And User click "Wybierz grupę"
	And User click "<group>" 
	Then User does not see user "<name>" in "<list>" list

Examples: 
| name         | list       | group   |
| Jan Kowalski | Uczestnicy | Group 3 |
| Anna Nowak   | Liderzy    | Group 1 |

# zephyr link
Scenario Outline: USERS_SCREEN__IP2-152_search_group_and_wrong_user
	Given Existing user "<name>" assigned to "<list>" list and "<group>" group
	And No other user is named "<name>"
	When User click "Wybierz grupę"
	And User click "<group>" 
	And User write "<name>wrong" into "Szukaj użytkownika" field
	And User click "Enter" button
	Then User does not see user "<name>" in "<list>" list

Examples: 
| name         | list       | group   |
| Jan Kowalski | Uczestnicy | Group 1 |
| Anna Nowak   | Liderzy    | Group 3 |

# zephyr link
Scenario Outline: USERS_SCREEN__IP2-152_view_user_details
	Given Existing user "<name>" assigned to "<list>" list
	When User click "<name>" in "<list>" list
	Then User see "Details" screen

Examples: 
| name         | list       |
| Jan Kowalski | Uczestnicy |
| Anna Nowak   | Liderzy    |

# zephyr link
Scenario Outline: USERS_SCREEN__IP2-152_user_details_back_to_users_screen_navigation
	Given Existing user "<name>" assigned to "<list>" list
	When User click "<name>" in "<list>" list
	And User click "Back" button
	Then User is on "Users" screen

Examples: 
| name         | list       |
| Jan Kowalski | Uczestnicy |
| Anna Nowak   | Liderzy    |

# zephyr link
Scenario: USERS_SCREEN__IP2-152_records_are_not_duplicated
	Given Existing user "Jan Kowalski" assigned to "Uczestnicy" list and "Group 1" and "Group 2" groups
	And No other user is named "Jan Kowalski"
	When User write "Jan Kowalski" into "Szukaj użytkownika" field
	And User click "Enter" button
	Then User see only one occurance of "Jan Kowalski" in "Uczestnicy" list
	
# zephyr link
Scenario Outline: USERS_SCREEN__IP2-152_all_users_counter_is_correct
	Given Existing users in "<group>" group and "<list>" list
	When User click "Wybierz grupę"
	And User click "<group>" 
	Then "<list>" list users counter is correct

Examples:
| group   | list       |
| Group 3 | Liderzy    |
| Group 1 | Uczestnicy |

# zephyr link
Scenario: USERS_SCREEN__IP2-152_no_users_found_counter_is_correct
	Given No existing user named "not existing user"
	When User write "not existing user" into "Szukaj użytkownika" field
	And User click "Enter" button
	Then "Liderzy" list users counter is correct
	And "Użytkownicy" list users counter is correct
	
# zephyr link
Scenario Outline: USERS_SCREEN__IP2-152_user_own_account_is_marked
	Given User is logged in as "<user>" assigned to "<list>" list
	And No other user is named "<user>"
	Then User see "Ty" mark next to user "<user>" in "<list>"
	And No other user is marked with "Ty"

Examples:
| user         | list       |
| Jan Kowalski | Uczestnicy |
| Anna Nowak   | Liderzy    |

# zephyr link
Scenario Outline: USERS_SCREEN__IP2-152_user_own_account_is_marked_and_other_user_with_the_same_name_is_not_marked
	Given User is logged in as "<name>" assigned to "<list>" list
	And Two users named "<name>" assigned to "<list>" exists
	Then User see "Ty" mark next to his name "<name>" in "<list>" list
	And User does not see "Ty" mark next to other user named "<name>

Examples:
| user         | list       |
| Jan Kowalski | Uczestnicy |
| Anna Nowak   | Liderzy    |
