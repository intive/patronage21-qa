@ignore
Feature: CALENDAR [api/events/] Update of event
	
#link JS https://tracker.intive.com/jira/browse/IP2-564
#link QA https://tracker.intive.com/jira/browse/IP2-638

Background:
Given Endpoint is api/events/
And event is present in calendar 

#link Zephyr
Scenario: CALENDAR_1_[api/events/]_IP2-564_Event_can_be_changed
	When request for change is sent to API
	Then response is successful
	And message "Wydarzenie zostało zedytowane" is present
	And event is updated

#link Zephyr
Scenario: CALENDAR_2_IP2-564_[api/events/]_False_parameter_can_not_change_event
	When request for change with false id is sent to API
	Then response contains Status 400
	And message "Wydarzenie o takim id nie istnieje" is present
	And event is not changed

#link Zephyr
Scenario: CALENDAR_3_IP2-564_[api/events/]_Event_can_not_be_changed_when_title_is_too_short
	When request for change with too short title is sent to API
	Then response contains Status 400
	And message "Tytuł musi mieć minimalnie 3 znaki" is present
	And event is not changed

#link Zephyr
Scenario: CALENDAR_4_IP2-564_[api/events/]_Event_can_not_be_changed_when_title_is_too_long
	When request for change with too long title is sent to API
	Then response contains Status 400
	And message "Tytuł może mieć maksymalnie 50 znaków" is present
	And event is not changed