@ignore
Feature: CALENDAR [api/events/event/{id}] Get Event

#Task in QA Team: https://tracker.intive.com/jira/browse/IP2-944
#Task in JS Team: https://tracker.intive.com/jira/browse/IP2-884

Background:
	Given User get list of events

Scenario: CALENDAR_[api/events/event/{id}]_[GET]_1_IP2-884_Get_event_request_with_correct_id_is_sent
	Given User chose event
	When Request is sent to API
	Then The server should return status 200
	And JSON body with data about event

Scenario Outline: CALENDAR_[api/events/event/{id}]_[GET]_2_IP2-884_Get_event_request_with_incorrect_id_is_sent
	Given User chose event with '<inccorectId>'
	When Request is sent to API
	Then The server should return status 404
	And JSON body with error message

	Examples:
		| dataType | inccorectId                          |
		| string   | stringId                             |
		| uuid     | e3a63d60-db3d-4c06-926a-30c70a7da7dd |
		| int      | 12                                   |
		| float    | 10000.23                             |
		| null     | null                                 |