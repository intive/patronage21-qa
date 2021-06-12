@ignore
Feature: CALENDAR [api/events/] Update of event
	
#link JS https://tracker.intive.com/jira/browse/IP2-564
#link QA https://tracker.intive.com/jira/browse/IP2-638

Background:
Given Endpoint is api/events/
And event is present in calendar 

#https://tracker.intive.com/jira/browse/IP2-915
Scenario: CALENDAR_[api/events/]_[PATCH]_1_IP2-564_Event_can_be_changed
	When request for change is sent to API
	Then response is successful
	And message "Wydarzenie zostało zedytowane" is present
	And event is updated

#https://tracker.intive.com/jira/browse/IP2-916
Scenario: CALENDAR_[api/events/]_[PATCH]_2_IP2-564_False_parameter_can_not_change_event
	When request for change with false id is sent to API
	Then response contains Status 400
	And message "Wydarzenie o takim id nie istnieje" is present
	And event is not changed

#https://tracker.intive.com/jira/browse/IP2-917
Scenario: CALENDAR_[api/events/]_[PATCH]_3_IP2-564_Event_can_not_be_changed_when_title_is_too_short
	When request for change with too short title is sent to API
	Then response contains Status 400
	And message "Tytuł musi mieć minimalnie 3 znaki" is present
	And event is not changed

#https://tracker.intive.com/jira/browse/IP2-918
Scenario: CALENDAR_[api/events/]_[PATCH] 4_IP2-564_Event_can_not_be_changed_when_title_is_too_long
	When request for change with too long title is sent to API
	Then response contains Status 400
	And message "Tytuł może mieć maksymalnie 50 znaków" is present
	And event is not changed