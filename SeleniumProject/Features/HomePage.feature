Feature: Home page
	#Task in QA: https://tracker.intive.com/jira/browse/IP2-618
	#Task in JS: https://tracker.intive.com/jira/browse/IP2-542

Background: 
	Given User is on home page

#https://tracker.intive.com/jira/browse/IP2-718
Scenario: HOME_PAGE_1_IP2-542_user_clicks_on_calendar
	Given Kalendarz is on home page
	When User clicks on Kalendarz
	Then User is transferred to page about calendar

#https://tracker.intive.com/jira/browse/IP2-719
Scenario Outline: HOME_PAGE_2_IP2-542_module_exists_and_is_inactive
	When <Module> is on home page
	Then <Module> is inactive

	Examples: 
		| Module               |
		| Grupy technologiczne |
		| Użytkownicy          |
		| Dzienniczek          |
		| Audyt zdarzeń        |