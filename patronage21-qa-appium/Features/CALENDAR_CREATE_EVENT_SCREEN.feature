@ignore
Feature: CALENDAR_CREATE_EVENT_SCREEN
	User needs to be able to create
	new events
#Task in QA Team: https://tracker.intive.com/jira/browse/IP2-275
#Task in Android Team: https://tracker.intive.com/jira/browse/IP2-212

Background: 
	Given User is on "Dodaj nowe wydarzenie" screen

# zephyr link
Scenario: CALENDAR_CREATE_EVENT_SCREEN_1_IP2-212_screen_displayed_correctly
	Then User sees "Dodaj nowe wydarzenie" screen
	
# zephyr link
Scenario: CALENDAR_CREATE_EVENT_SCREEN_2_IP2-212_incorrect_submit_form_no_title
	When User submits correct form but with no title provided
	Then User sees "Dodaj nowe wydarzenie" screen
	
# zephyr link
Scenario: CALENDAR_CREATE_EVENT_SCREEN_3_IP2-212_incorrect_submit_form_no_tech_groups_selected
	When User submits correct form but with no tech groups selected
	Then User sees "Dodaj nowe wydarzenie" screen
	
# zephyr link
Scenario: CALENDAR_CREATE_EVENT_SCREEN_4_IP2-212_correct_submit_form_all_tech_groups_selected
	When User writes "title" to "Nazwa wydarzenia" field
	And User clicks "Java checkbox"
	And User clicks "JavaScript checkbox"
	And User clicks "QA checkbox"
	And User clicks "Android checkbox"
	And User clicks "Zatwierdź"
	Then User sees "Kalendarz tydzień" screen
	
# zephyr link
Scenario: CALENDAR_CREATE_EVENT_SCREEN_5_IP2-212_incorrect_datetime_provided
	When User writes "title" to "Nazwa wydarzenia" field
	And User clicks "Java checkbox"
	And User sets "Od data" month "<begin_month>" day "<begin_day>"
	And User sets "Od czas" hour "<begin_hour>" minute "<begin_minute>"
	And User sets "Do data" month "<end_month>" day "<end_day>"
	And User sets "Do czas" hour "<end_hour>" minute "<end_minute>"
	And User clicks "Zatwierdź"
	Then User sees "Dodaj nowe wydarzenie" screen

Examples: 
| begin_month | begin_day | begin_hour | begin_minute | end_month | end_day | end_hour | end_minute |
| previous    | 15        | 15         | 30           | previous  | 16      | 16       | 31         |
| previous    | 15        | 15         | 30           | next      | 16      | 16       | 31         |
| next        | 15        | 15         | 30           | next      | 15      | 15       | 30         |
| next        | 15        | 15         | 30           | next      | 15      | 15       | 29         |
| next        | 15        | 15         | 30           | next      | 15      | 14       | 30         |
| next        | 15        | 15         | 30           | next      | 14      | 15       | 30         |
| next        | 15        | 15         | 30           | previous  | 15      | 15       | 30         |
	
# zephyr link
Scenario: CALENDAR_CREATE_EVENT_SCREEN_6_IP2-212_correct_datetime_provided
	When User writes "title" to "Nazwa wydarzenia" field
	And User clicks "Java checkbox"
	And User sets "Od data" month "<begin_month>" day "<begin_day>"
	And User sets "Od czas" hour "<begin_hour>" minute "<begin_minute>"
	And User sets "Do data" month "<end_month>" day "<end_day>"
	And User sets "Do czas" hour "<end_hour>" minute "<end_minute>"
	And User clicks "Zatwierdź"
	Then User sees "Kalendarz tydzień" screen

Examples: 
| begin_month | begin_day | begin_hour | begin_minute | end_month | end_day | end_hour | end_minute |
| next        | 15        | 15         | 30           | next      | 15      | 15       | 31         |
| next        | 15        | 15         | 30           | next      | 15      | 16       | 30         |
| next        | 15        | 15         | 30           | next      | 16      | 15       | 30         |
| next        | 15        | 15         | 30           | nextnext  | 15      | 15       | 30         |
| next        | 15        | 15         | 30           | next      | 15      | 15       | 30         |