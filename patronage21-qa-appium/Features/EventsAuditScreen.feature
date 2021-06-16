Feature: EventsAuditScreen
	User wants to be able to inspect 
	logs of events that are
	assotiated with his account
#Task in QA Team: https://tracker.intive.com/jira/browse/IP2-273
#Task in Android Team: https://tracker.intive.com/jira/browse/IP2-158

Background: 
	Given User is on "Audyt zdarzeń" screen

# https://tracker.intive.com/jira/browse/IP2-806
Scenario: EVENTS_AUDIT_1_IP2-273_events_audit_screen_displayed_correctly
	Then Users sees "Audyt zdarzeń" screen
	
# https://tracker.intive.com/jira/browse/IP2-807
Scenario Outline: EVENTS_AUDIT_2_IP2-273_display_events_in_order
	When User clicks "Sortuj"
	And User clicks "<sort_by>"
	Then Events are displayed in "<sort_by>" order

Examples: 
	| sort_by         |
	| Od najnowszych  |
	| Od najstarszych |
	
# https://tracker.intive.com/jira/browse/IP2-808
Scenario Outline: EVENTS_AUDIT_3_IP2-273_search_events_of_type
	When User clicks "Szukaj"
	And User writes "<search>" to "Wyszukaj" field 
	Then "<search>" events are displayed

Examples: 
	| search      |
	| Logowanie   |
	| Wylogowanie |
	| Rejestracja |
	
# https://tracker.intive.com/jira/browse/IP2-809
Scenario Outline: EVENTS_AUDIT_4_IP2-273_search_events_by_username
	When User clicks "Szukaj"
	And User writes "<search>" to "Wyszukaj" field 
	Then User "<search>" events are displayed

Examples: 
	| search      |
	| JanKowalski |
	| AnnaNowak   |
	
# https://tracker.intive.com/jira/browse/IP2-810
Scenario: EVENTS_AUDIT_5_IP2-273_scroll_to_bottom_and_back
	Given User sees first element of events list
	When User scroll down
	And User clicks "Przewiń do góry"
	Then User sees first element of events list