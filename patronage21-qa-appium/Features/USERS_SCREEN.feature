Feature: USERS_SCREEN
	User wants to be able to find
	other users, filter them 
	by groups and names and view 
	details about them
#Task in QA Team: https://tracker.intive.com/jira/browse/IP2-270
#Task in Android Team: https://tracker.intive.com/jira/browse/IP2-152

Background: 
	Given User is on "Użytkownicy" screen

# https://tracker.intive.com/jira/browse/IP2-489
@ignore
Scenario: USERS_SCREEN_1_IP2-152_users_screen_displayed_correctly
	Then "Szukaj użytkownika" field is empty
	And "Wybierz grupę" is set to "Wszystkie grupy technologiczne"
	And User sees "Liderzy" list
	And User sees "Uczestnicy" list
	
# https://tracker.intive.com/jira/browse/IP2-486
Scenario Outline: USERS_SCREEN_2_IP2-152_search_existing_user
	Given Existing user "<name>" assigned to "<list>" list
	When User writes "<name>" into "Szukaj użytkownika" field
	Then User sees user "<name>" in "<list>" list

Examples: 
| name        | list       |
| Anna Nowak  | Liderzy    |
| Tomek Nowak | Uczestnicy |

# https://tracker.intive.com/jira/browse/IP2-490
Scenario: USERS_SCREEN_3_IP2-152_search_not_existing_user
	When User writes "not existing user" into "Szukaj użytkownika" field
	Then User sees information that searched user does not exist
	
# https://tracker.intive.com/jira/browse/IP2-491
Scenario Outline: USERS_SCREEN_4_IP2-152_search_group
	Given Existing user "[unique]ggg" assigned to "<group>" group
	When User clicks "Wybierz grupę" 
	And User clicks "<group>" 
	And User scrolls to bottom
	Then User sees user "[unique]ggg [unique]ggg" in "Uczestnicy" list

Examples:
| group      |
| Java       |
| JavaScript |
| QA         |
	
# https://tracker.intive.com/jira/browse/IP2-492
Scenario: USERS_SCREEN_5_IP2-152_search_all_groups
	When User clicks "Wybierz grupę"
	And User clicks "QA"
	And User clicks "Wybierz grupę"
	And User clicks "Wszystkie grupy"
	Then User sees user "Anna Nowak" in "Liderzy" list
	
# https://tracker.intive.com/jira/browse/IP2-493
Scenario: USERS_SCREEN_6_IP2-152_empty_search_user_field_shows_all_users
	When User writes "anything" into "Szukaj użytkownika" field
	And User clears "Szukaj użytkownika" field
	Then User sees user "Anna Nowak" in "Liderzy" list
	
# https://tracker.intive.com/jira/browse/IP2-494
Scenario Outline: USERS_SCREEN_7_IP2-152_search_user_and_group
	Given Existing user "[unique]ggg" assigned to "<group>" group
	When User writes "[unique]ggg" into "Szukaj użytkownika" field
	And User clicks "Wybierz grupę"
	And User clicks "<group>"
	Then User sees user "[unique]ggg [unique]ggg" in "Uczestnicy" list

Examples: 
| group      |
| Java       |
| JavaScript |
| QA         |

# https://tracker.intive.com/jira/browse/IP2-495
Scenario Outline: USERS_SCREEN_8_IP2-152_search_group_and_user
	Given Existing user "[unique]ggg" assigned to "<group>" group
	When User clicks "Wybierz grupę"
	And User clicks "<group>" 
	And User writes "[unique]ggg" into "Szukaj użytkownika" field
	Then User sees user "[unique]ggg [unique]ggg" in "Uczestnicy" list

Examples: 
| group      |
| Java       |
| JavaScript |
| QA         |

# https://tracker.intive.com/jira/browse/IP2-496
Scenario Outline: USERS_SCREEN_9_IP2-152_search_user_and_wrong_group
	Given Existing user "[unique]ggg" assigned to "Mobile (Android)" group
	When User writes "[unique]ggg" into "Szukaj użytkownika" field
	And User clicks "Wybierz grupę"
	And User clicks "<group>" 
	Then User does not see user "[unique]ggg [unique]ggg" in "Uczestnicy" list

Examples: 
| group      |
| JavaScript |
| Java       |
| QA         |

# https://tracker.intive.com/jira/browse/IP2-497
Scenario Outline: USERS_SCREEN_10_IP2-152_search_group_and_wrong_user
	Given Existing user "[unique]ggg" assigned to "<group>" group
	When User clicks "Wybierz grupę"
	And User clicks "<group>" 
	And User writes "[unique]wrong" into "Szukaj użytkownika" field
	Then User does not see user "[unique]ggg [unique]ggg" in "<list>" list

Examples: 
| group |
| Java  |
| QA    |

# https://tracker.intive.com/jira/browse/IP2-498
Scenario: USERS_SCREEN_11_IP2-152_view_user_details
	Given Existing user "Anna Nowak" assigned to "Liderzy" list
	When User clicks "Anna Nowak" in "Liderzy" list
	Then User sees "Anna Nowak" "Szczegóły użytkownika" screen

# https://tracker.intive.com/jira/browse/IP2-499
Scenario: USERS_SCREEN_12_IP2-152_user_details_back_to_users_screen_navigation
	When User clicks "Anna Nowak" in "Liderzy" list
	And User clicks "Back" button
	Then User is on "Użytkownicy" screen

# https://tracker.intive.com/jira/browse/IP2-500
Scenario: USERS_SCREEN_13_IP2-152_records_are_not_duplicated
	Given Existing user "[unique]ggg" assigned to "QA" group
	When User writes "[unique]ggg" into "Szukaj użytkownika" field
	Then User sees only one occurance of "[unique]ggg [unique]ggg" in "Uczestnicy" list
	
# https://tracker.intive.com/jira/browse/IP2-501
Scenario Outline: USERS_SCREEN_14_IP2-152_all_users_counter_is_correct
	When User clicks "Wybierz grupę"
	And User clicks "<group>" 
	Then "<list>" list users counter is correct

Examples:
| group | list    |
| QA    | Liderzy |
| Java  | Liderzy |

# https://tracker.intive.com/jira/browse/IP2-502
Scenario: USERS_SCREEN_15_IP2-152_no_users_found_counter_is_correct
	When User writes "not existing user" into "Szukaj użytkownika" field
	Then "Liderzy" list users counter is "0"
	And "Uczestnicy" list users counter is "0"
	
# https://tracker.intive.com/jira/browse/IP2-503
Scenario: USERS_SCREEN_16_IP2-152_user_own_account_is_marked
	Then User sees "Ty" mark next to his username in "Uczestnicy" list
	And No other user is marked with "Ty"

# https://tracker.intive.com/jira/browse/IP2-504
Scenario: USERS_SCREEN_17_IP2-152_user_own_account_is_marked_and_other_user_with_the_same_name_is_not_marked
	Given User is logged in as "[unique]" assigned to "Uczestnicy" list
	And Existing user with name "[unique]" assigned to "Uczestnicy" list
	Then User sees "Ty" mark next to his username in "Uczestnicy" list
	And No other user is marked with "Ty"
