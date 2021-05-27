Feature: New event to calendar
#Task in QA Team: https://tracker.intive.com/jira/browse/IP2-633
#Task in JS Team: https://tracker.intive.com/jira/browse/IP2-548

#zephyr link
Scenario: NEW_EVENT_TO_CALENDAR_1_IP2-548_send_request_with_correctly_data
	Given User filled data correctly
	When Request sends to API
	Then The server should return status 200
	And JSON body with data about event

#zephyr link
Scenario: NEW_EVENT_TO_CALENDAR_2_IP2-548_send_request_without_data
	Given User didn't fill data
	When Request sends to API 
	Then The server should return status 400
	And JSON body with messages about mistakes

#zephyr link
Scenario: NEW_EVENT_TO_CALENDAR_3_IP2-548_send_request_with_too_short_title
	Given User filled too short title
	When Request sends to API
	Then The server should return status 400
	And JSON body with message about too short title

#zephyr link
Scenario: NEW_EVENT_TO_CALENDAR_4_IP2-548_send_request_with_too_long_title
	Given User filled too long title
	When Request sends to API 
	Then The server should return status 400
	And JSON body with message about too long title

#zephyr link
Scenario Outline: NEW_EVENT_TO_CALENDAR_5_IP2-548_send_request_with_incorrect_date
	Given User filled incorrect <fieldName>
	When Request sends to API 
	Then The server should return status 400
	And JSON body with message about incorrect <fieldName>

	Examples: 
		| fieldName |
		| startDate |
		| endDate   |

#zephyr link
Scenario: NEW_EVENT_TO_CALENDAR_6_IP2-548_send_request_with_end_date_which_is_earlier_than_start_date
	Given Users filled end event date incorrect
	When Request sends to API
	Then The server should return status 400
	And JSON body with message about too early end event date