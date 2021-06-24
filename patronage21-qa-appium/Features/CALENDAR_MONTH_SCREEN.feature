@ignore
Feature: CALENDAR_MONTH_SCREEN
	User wants to be able to 
	view calendar month view
	containing upcoming 
	and past meets 
#Task in QA Team: https://tracker.intive.com/jira/browse/IP2-279
#Task in Android Team: https://tracker.intive.com/jira/browse/IP2-210

# zephyr link
Scenario: CALENDAR_MONTH_SCREEN_1_IP2-208_screen_displayed_correctly
	Given User is on "Kalendarz miesięczny" screen
	Then User sees "Kalendarz widok miesięczny" screen
	And "Kalendarz miesięczny" screen is displayed correctly
	
# zephyr link
Scenario Outline: CALENDAR_MONTH_SCREEN_2_IP2-208_change_viewed_time_interval
	Given User is on "Kalendarz miesięczny" screen
	When User clicks "<switch>"
	Then "Kalendarz miesięczny" screen "<switch>" is displayed correctly

	Examples: 
	| switch                      |
	| Poprzedni przedział czasowy |
	| Kolejny przedział czasowy   |
	
# zephyr link
Scenario: CALENDAR_MONTH_SCREEN_3_IP2-208_navigate_to_screen_and_back
	Given User is on "Kalendarz miesięczny" screen
	When User clicks "Data z wydarzeniem"
	And User clicks on "Back" button
	When User clicks "Dodaj wydarzenie"
	And User clicks on "Back" button
	Then User sees "Kalendarz miesięczny" screen

# zephyr link
@ignore
Scenario: CALENDAR_MONTH_SCREEN_4_IP2-208_leave_screen_and_come_back
	Given User is on "Kalendarz miesięczny" screen
	And User clicks on "Back" button
	And User clicks "Kalendarz" on "Home" screen
	Then User sees "Kalendarz miesięczny" screen
	And Spinner is set to "Miesiąc"
	
# zephyr link
Scenario Outline: CALENDAR_MONTH_SCREEN_5_IP2-208_change_viewed_time_interval_view_event_and_back
	Given User is on "Kalendarz miesięczny" screen
	When User clicks "<switch>"
	And User clicks "Data z wydarzeniem"
	And User clicks on "Back" button
	Then "Kalendarz miesięczny" screen "<switch>" is displayed correctly

	Examples: 
	| switch                      |
	| Poprzedni przedział czasowy |
	| Kolejny przedział czasowy   |
