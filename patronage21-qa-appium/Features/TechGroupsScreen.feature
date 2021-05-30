Feature: TechGroupsScreen
	User wants to be able to 
	view available tech groups
#Task in QA Team: https://tracker.intive.com/jira/browse/IP2-251
#Task in Android Team: https://tracker.intive.com/jira/browse/IP2-140

Background: 
	Given User is on "Grupy technologiczne" screen

# zephyr link
Scenario: TECH_GROUPS_SCREEN_1_IP2-251_tech_groups_screen_displayed_correctly
	Then User sees "Grupy technologiczne" screen

# zephyr link
Scenario: TECH_GROUPS_SCREEN_2_IP2-251_tech_groups_spinner_displayed_correctly
	When User clicks "Wybierz grupę"
	Then User sees correct tech groups

# zephyr link
Scenario Outline: TECH_GROUPS_SCREEN_3_IP2-251_filter_groups
	When User clicks "Wybierz grupę"
	And User clicks "<group>"
	Then User sees groups with "<group>" technology

Examples: 
	| group            |
	| Java             |
	| JavaScript       |
	| QA               |
	| Mobile (Android) |

# zephyr link
Scenario Outline: TECH_GROUPS_SCREEN_4_IP2-251_navigate_to_and_back
	When User clicks "Dodaj grupę"
	And User clicks "Back" button
	And User clicks "Grupa I"
	And User clicks "Back" button
	Then User sees "Grupy technologiczne" screen
