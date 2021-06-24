@ignore
Feature: EVENTS_AUDIT_SCREEN SearchFieldSearchOnKeyInput
	User wants to be able to search
	events automatically during 
	writing values he is 
	looking for
#Task in QA Team: https://tracker.intive.com/jira/browse/IP2-596
#Task in Android Team: https://tracker.intive.com/jira/browse/IP2-426

# https://tracker.intive.com/jira/browse/IP2-1024
Scenario: EVENTS_AUDIT_1_IP2-426_automatic_search_on_every_key_input
	Given User is on "Audyt zdarzeń" screen
	And Value of "Wyszukaj" field is set to "Udana rejestracja"
	And Displayed event "Udana rejestracja" in events list
	When User writes "Udana rejestracjaa" to "Wyszukaj" field 
	Then Events list is empty
	