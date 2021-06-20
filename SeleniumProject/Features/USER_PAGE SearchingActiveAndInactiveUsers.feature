@ignore
Feature: USER_PAGE Searching active and inactive users
	
Task in QA board: https://tracker.intive.com/jira/browse/IP2-983
Task in Java board: https://tracker.intive.com/jira/browse/IP2-668

#https://tracker.intive.com/jira/browse/IP2-1001
Scenario: USER_PAGE_1_IP2-668_User_can_display_active_and_inactive_users
	Given User is in the user search module
	When User marks box 'Pokaż również nieaktywnych'
	Then User sees active and inactive users