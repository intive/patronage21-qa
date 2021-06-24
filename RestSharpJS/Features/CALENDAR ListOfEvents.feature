@ignore
Feature: CALENDAR [/api/events/list/{fromDate}/{toDate}] list of events

#Task in QA Team: https://tracker.intive.com/jira/browse/IP2-624
#Task in JS Team: https://tracker.intive.com/jira/browse/IP2-547

#https://tracker.intive.com/jira/browse/IP2-946
Scenario Outline: CALENDAR_[/api/events/list/{fromDate}/{toDate}]_[GET]_1_IP2-547_Get_events_request_with_correct_date_is_sent
	Given User filled data correctly
	When Request is sent to API
	Then The server should return status 200
	And JSON body with list of events

#https://tracker.intive.com/jira/browse/IP2-947
Scenario Outline: CALENDAR_[/api/events/list/{fromDate}/{toDate}]_[GET]_2_IP2-547_Get_events_request_with_correct_fromDate_field_is_sent
	Given User filled correctly '<fromDate>' field 
	When Request is sent to API
	Then The server should return status 200
	And JSON body with list of events

	Examples: 
		| fromDate            |
		| 2021-01-02T00:00:00 |
		| 2021-01-02          |
		| 2021-01             |
		| 2021                |

#https://tracker.intive.com/jira/browse/IP2-948
Scenario Outline: CALENDAR_[/api/events/list/{fromDate}/{toDate}]_[GET]_3_IP2-547_Get_events_request_with_incorrect_field_fromDate_is_sent
	Given User filled '<fromDate>' incorrect 
	And User filled '<toDate>' correct
	When Request is sent to API
	Then The server should return status 500
	And JSON body with error message

	Examples: 
		| fromDate              | toDate                |
		| 21-01-01T00:00:00     | 2021-01-03TT23:59:59  |
		| 01-01-2021T00:00:00   | 2021-01-03TT23:59:59  |
		| wrongDateT00:00:00    | 2021-01-03TT23:59:59  |
		| empty                 | 2021-01-03TT23:59:59  |
		| '2021-01-02T00:00:00' | 2021-01-03TT23:59:59  |
		| "2021-01-02T00:00:00" | 2021-01-03TT23:59:59  |

#https://tracker.intive.com/jira/browse/IP2-949
Scenario Outline: CALENDAR_[/api/events/list/{fromDate}/{toDate}]_[GET]_4_IP2-547_Get_events_request_with_incorrect_field_toDate_is_sent
	Given User filled '<fromDate>' incorrect 
	And User filled '<toDate>' correct
	When Request is sent to API
	Then The server should return status 500
	And JSON body with error message

	Examples: 
		| fromDate            | toDate                |
		| 2021-01-02T00:00:00 | 21-01-01T23:59:59     |
		| 2021-01-02T00:00:00 | 01-01-2021T23:59:59   |
		| 2021-01-02T00:00:00 | wrongDateT23:59:59    |
		| 2021-01-02T00:00:00 | empty                 |
		| 2021-01-02T00:00:00 | '2021-01-02T23:59:59' |
		| 2021-01-02T00:00:00 | "2021-01-02T23:59:59" |

#https://tracker.intive.com/jira/browse/IP2-950
Scenario: CALENDAR_[/api/events/list/{fromDate}/{toDate}]_[GET]_5_IP2-547_Get_events_request_with_toDate_field_which_is_earlier_than_fromDate_field_is_sent
	Given User filled toDate field incorrectly
	When Request is sent to API
	Then The server should return status 400
	And JSON body with message about too early field toDate
