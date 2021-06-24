@ignore
Feature: CALENDAR_EVENT_SCREEN
	User needs to see correct
	data about selected event
#Task in QA Team: https://tracker.intive.com/jira/browse/IP2-276
#Task in Android Team: https://tracker.intive.com/jira/browse/IP2-211

Background: 
	Given User is on "Kalendarz tygodniowy" screen

# https://tracker.intive.com/jira/browse/IP2-1013
Scenario: CALENDAR_EVENT_SCREEN_1_IP2-211_screen_displayed_correctly_navigated_from_week_view
	When User clicks "<switch>"
	And User clicks "Data z wydarzeniem"
	Then User sees "Wydarzenie <isupcoming>" screen
	
	Examples: 
	| switch                      | isupcoming  |
	| Poprzedni przedział czasowy | przeszłe    |
	| Kolejny przedział czasowy   | nadchodzące |

# https://tracker.intive.com/jira/browse/IP2-1014
Scenario: CALENDAR_EVENT_SCREEN_2_IP2-211_screen_displayed_correctly_navigated_from_month_view
	When User clicks "Zmień widok"
	And User clicks "Miesiąc"
	When User clicks "<switch>"
	And User clicks "Data z wydarzeniem"
	Then User sees "Wydarzenie <isupcoming>" screen
	
	Examples: 
	| switch                      | isupcoming  |
	| Poprzedni przedział czasowy | przeszłe    |
	| Kolejny przedział czasowy   | nadchodzące |