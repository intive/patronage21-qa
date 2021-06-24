@ignore
Feature: CALENDAR_WEEK_SCREEN
	User wants to be able to 
	view calendar week view
	containing upcoming 
	and past meets 
#Task in QA Team: https://tracker.intive.com/jira/browse/IP2-282
#Task in Android Team: https://tracker.intive.com/jira/browse/IP2-208

Background: 
	Given User is on "Kalendarz tygodniowy" screen

# https://tracker.intive.com/jira/browse/IP2-1036
Scenario: CALENDAR_WEEK_SCREEN_1_IP2-208_screen_displayed_correctly
	Then User sees "Kalendarz widok tygodniowy" screen
	And "Kalendarz tygodniowy" screen is displayed correctly

# https://tracker.intive.com/jira/browse/IP2-1037
Scenario Outline: CALENDAR_WEEK_SCREEN_2_IP2-208_change_viewed_time_interval
	When User clicks "<switch>"
	Then "Kalendarz tygodniowy" screen "<switch>" is displayed correctly

	Examples: 
	| switch                      |
	| Poprzedni przedział czasowy |
	| Kolejny przedział czasowy   |
	
# https://tracker.intive.com/jira/browse/IP2-1038
Scenario: CALENDAR_WEEK_SCREEN_3_IP2-208_navigate_to_add_event_screen_and_back
	When User clicks "Data z wydarzeniem"
	And User clicks on "Back" button
	And User clicks "Dodaj wydarzenie"
	And User clicks on "Back" button
	Then User sees "Kalendarz tygodniowy" screen
	
# https://tracker.intive.com/jira/browse/IP2-1039
Scenario Outline: CALENDAR_WEEK_SCREEN_4_IP2-208_change_viewed_time_interval_view_event_and_back
	When User clicks "<switch>"
	And User clicks "Data z wydarzeniem"
	And User clicks on "Back" button
	Then "Kalendarz tygodniowy" screen "<switch>" is displayed correctly

	Examples: 
	| switch                      |
	| Poprzedni przedział czasowy |
	| Kolejny przedział czasowy   |