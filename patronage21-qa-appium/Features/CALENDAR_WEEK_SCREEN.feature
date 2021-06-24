@ignore
Feature: CALENDAR_WEEK_SCREEN
	User wants to be able to 
	view calendar week view
	containing upcoming 
	and past meets 
#Task in QA Team: https://tracker.intive.com/jira/browse/IP2-282
#Task in Android Team: https://tracker.intive.com/jira/browse/IP2-208

# zephyr link
Scenario: CALENDAR_WEEK_SCREEN_1_IP2-208_screen_displayed_correctly
	Given User is on "Kalendarz tygodniowy" screen
	And User navigates to "Dezaktywacja" screen through "<way>"
	Then User sees "Kalendarz widok tygodniowy" screen
	And "Kalendarz tygodniowy" screen is displayed correctly

# zephyr link
Scenario Outline: CALENDAR_WEEK_SCREEN_2_IP2-208_change_viewed_time_interval
	Given User is on "Kalendarz tygodniowy" screen
	When User clicks "<switch>"
	Then "Kalendarz tygodniowy" screen "<switch>" is displayed correctly

	Examples: 
	| switch                      |
	| Poprzedni przedział czasowy |
	| Kolejny przedział czasowy   |
	
# zephyr link
Scenario: CALENDAR_WEEK_SCREEN_3_IP2-208_navigate_to_add_event_screen_and_back
	Given User is on "Kalendarz tygodniowy" screen
	When User clicks "Data z wydarzeniem"
	And User clicks on "Back" button
	And User clicks "Dodaj wydarzenie"
	And User clicks on "Back" button
	Then User sees "Kalendarz tygodniowy" screen
	
# zephyr link
Scenario: CALENDAR_WEEK_SCREEN_4_IP2-208_change_viewed_time_interval_view_event_and_back
	Given User is on "Kalendarz tygodniowy" screen
	When User clicks "<switch>"
	And User clicks "Data z wydarzeniem"
	And User clicks on "Back" button
	Then "Kalendarz tygodniowy" screen "<switch>" is displayed correctly

	Examples: 
	| switch                      |
	| Poprzedni przedział czasowy |
	| Kolejny przedział czasowy   |