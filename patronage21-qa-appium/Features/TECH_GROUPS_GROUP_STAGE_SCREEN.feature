@ignore
Feature: TECH_GROUPS_GROUP_STAGE_SCREEN
	User wants to be able to 
	view details about stages
	of certain tech group
#Task in QA Team: https://tracker.intive.com/jira/browse/IP2-247
#Task in Android Team: https://tracker.intive.com/jira/browse/IP2-142

Background: 
	Given User is on "Grupa I" group "Etap I" stage screen

# https://tracker.intive.com/jira/browse/IP2-820
Scenario: TECH_GROUPS_GROUP_STAGE_1_IP2-247_stage_screen_displayed_correctly
	Then User sees "Grupa I" group "Etap I" stage screen
	And User sees "Grupa I" group "Etap I" stage description 
	And User sees "Grupa I" group "Etap I" stage meetings 
	And Meetings counter is correct
	And User sees "Grupa I" group "Etap I" completion level

# https://tracker.intive.com/jira/browse/IP2-821
# to be changed, there is no concept of those buttons yet
Scenario Outline: TECH_GROUPS_GROUP_STAGE_2_IP2-247_get_materials
	When User clicks "Pobierz materiały"
	Then User sees "Materiały"

Examples: 
	| button              | destination |
	| Pobierz materiały   | Materiały   |
	| Sprawdź dzienniczek | Dzienniczek |
	
# https://tracker.intive.com/jira/browse/IP2-822
Scenario: TECH_GROUPS_GROUP_STAGE_3_IP2-247_view_meeting
	When User clicks first meeting
	Then User sees first meeting details

# https://tracker.intive.com/jira/browse/IP2-823
# to be changed, there is no concept of those buttons yet
Scenario: TECH_GROUPS_GROUP_STAGE_4_IP2-247_navigate_to_and_back
	When User clicks "Pobierz materiały"
	And User clicks "Back" button
	And User clicks "Sprawdź dzienniczek"
	And User clicks "Back" button
	And User clicks first meeting
	And User clicks "Back" button
	Then User sees "Grupa I" group "Etap I" stage screen
