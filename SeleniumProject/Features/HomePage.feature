Feature: Home page

Background: 
	Given User is on home page

Scenario: HOME_PAGE_1_IP2-542_user_clicks_on_calendar
	Given Kalendarz is on home page
	When User clicks on Kalendarz
	Then User is transferred to page about calendar

Scenario Outline: HOME_PAGE_2_IP2-542_user_clicks_on_module
	When '<Module>' is on home page
	Then '<Module>' is inactive

	Examples: 
		| Module               |
		| Grupy technologiczne |
		| Użytkownicy          |
		| Dzienniczek          |
		| Autyd zdarzeń        |