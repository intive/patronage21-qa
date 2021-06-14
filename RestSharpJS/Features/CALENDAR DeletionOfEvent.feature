@ignore
Feature: CALENDAR [/api/events/delete/] Deletion Of Event
	
# link QA: https://tracker.intive.com/jira/browse/IP2-640
# link JS: https://tracker.intive.com/jira/browse/IP2-549

Background:
	Given Endpoint is /api/events/delete
	And Event is created

# https://tracker.intive.com/jira/browse/IP2-885
Scenario: CALENDAR_[/api/events/delete/]_[DELETE]_1_IP2-549_Event_can_be_deleted
	When request with correct event id is sent to API
	Then response is successful
	And event is deleted
	And message "Wydarzenie zostało usunięte z kalendarza" is present

# https://tracker.intive.com/jira/browse/IP2-886
Scenario: CALENDAR_[/api/events/delete/]_[DELETE]_2_IP2-549_False_event_id_can_not_delete_event
	When request with false event id is sent to API
	Then response contains Status 404 
	And event is not deleted
	And message "Usuwanie wydarzenia nie powiodło się" is present