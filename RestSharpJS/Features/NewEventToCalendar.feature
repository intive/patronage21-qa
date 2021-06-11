﻿Feature: New event to calendar
#Task in QA Team: https://tracker.intive.com/jira/browse/IP2-633
#Task in JS Team: https://tracker.intive.com/jira/browse/IP2-548

#https://tracker.intive.com/jira/browse/IP2-797
Scenario: NEW_EVENT_TO_CALENDAR_1_IP2-548_request_with_correct_data_is_sent
	Given User filled data correctly
	When Request is sent to API
	Then The server should return status 200
	And JSON body with data about event

#https://tracker.intive.com/jira/browse/IP2-798
Scenario: NEW_EVENT_TO_CALENDAR_2_IP2-548_request_without_data_is_sent
	Given User didn't fill data
	When Request is sent to API
	Then The server should return status 400
	And JSON body with messages about mistakes

#https://tracker.intive.com/jira/browse/IP2-799
Scenario: NEW_EVENT_TO_CALENDAR_3_IP2-548_request_with_too_short_title_is_sent
	Given User filled too short title
	When Request is sent to API
	Then The server should return status 400
	And JSON body with message about too short title

#https://tracker.intive.com/jira/browse/IP2-800
Scenario: NEW_EVENT_TO_CALENDAR_4_IP2-548_request_with_too_long_title_is_sent
	Given User filled too long title
	When Request is sent to API
	Then The server should return status 400
	And JSON body with message about too long title

#https://tracker.intive.com/jira/browse/IP2-801
Scenario Outline: NEW_EVENT_TO_CALENDAR_5_IP2-548_request_with_incorrect_date_is_sent
	Given User filled incorrect <fieldName>
	When Request is sent to API
	Then The server should return status 400
	And JSON body with message about incorrect <fieldName>

	Examples: 
		| fieldName |
		| startDate |
		| endDate   |

#https://tracker.intive.com/jira/browse/IP2-802
Scenario: NEW_EVENT_TO_CALENDAR_6_IP2-548_request_with_end_date_which_is_earlier_than_start_date_is_sent
	Given User filled end event date incorrectly
	When Request is sent to API
	Then The server should return status 400
	And JSON body with message about too early end event date