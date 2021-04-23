Feature: Events Audit screen
	User should be able to see the list of app's events and people associated with them
	Task in Android board: https://tracker.intive.com/jira/browse/IP2-158
	Task in QA board: https://tracker.intive.com/jira/browse/IP2-273

Background:
	Given User is on "Events audit" screen

# 
Scenario: EVENTS_AUDIT_1_IP2-158_Events_audit_displays_correctly
	Then Header "Audyt zdarzeń" is visible
	And "Search icon" is visible
	And "Filter icon" is visible
	And Events list is visible

# 
Scenario: EVENTS_AUDIT_2_IP2-158_Events_are_displayed_by_default_from_most_recent
	Then Events are displayed in order "Od najnowszych"

# 
Scenario Outline: EVENTS_AUDIT_3_IP2-158_Changing_display_order_of_events
	When User chooses to sort events '<order>'
	Then Events are displayed in order '<order>'

	Examples: 
	| order           |
	| Od najstarszych |
	| Od najnowszych  |

# 
Scenario Outline: EVENTS_AUDIT_4_IP2-158_Display_events_for_an_existing_user
	Given User '<user_name>' exists in database
	When User searches for '<user_name>' in events list
	Then Events list contains entries only for '<user_name>'

	Examples: 
	| user_name |
	| Kowalski  |
	| Nowak     |

#
Scenario Outline: EVENTS_AUDIT_5_IP2-158_Display_events_for_a_nonexistent_user
	Given User '<user_name>' does not exist in database
	When User searches for '<user_name>' in events list
	Then Events list is empty

	Examples: 
	| user_name |
	| zxc123    |

#
Scenario Outline: EVENTS_AUDIT_6_IP2-158_Display_events_for_a_specific_event
	When User searches for '<event>' in events list
	Then Events list contains entries only for '<event>'

	Examples:
	| event               |
	| Logowanie           |
	| Wylogowanie         |
	| Aktualizacja danych |
