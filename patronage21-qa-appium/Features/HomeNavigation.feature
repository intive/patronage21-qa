﻿Feature: HomeNavigation
	User want to be able to navigate 
	throughout the application from Home Page
# https://tracker.intive.com/jira/browse/IP2-93

Background: 
	Given I am on Home page 

# https://tracker.intive.com/jira/browse/IP2-334
Scenario:HOME_PAGE_1_IP2-93_home_page_displayed_correctly
	Then I see "Home" page

# to be changed, in future Register page will be removed from this
# view and set as first page seen by unregistered user,
# so "register" example will have to be deleted/moved
# https://tracker.intive.com/jira/browse/IP2-335
Scenario Outline:HOME_PAGE_2_IP2-93_home_page_to_<destination>_navigation
	When I click on "<button_name>" button
	Then I see "<page_name>" page

Examples: 
| destination  | button_name          | page_name    |
| tech_groups  | Grupy technologiczne | Tech groups  |
| users        | Użytkownicy		  | Users		 |
| journal      | Dzienniczek          | Journal      |
| calendar     | Kalendarz            | Calendar     |
| events_audit | Audyt zdarzeń        | Events audit |
| register     | Rejestracja          | Register     |
	
# https://tracker.intive.com/jira/browse/IP2-336
Scenario Outline:HOME_PAGE_3_IP2-93_back_to_home_page_navigation
	When I click on "<button_name>" button
	And I click on "Back" button
	Then I see "Home" page

Examples: 
| button_name          |
| Grupy technologiczne |
| Użytkownicy          |
| Dzienniczek          |
| Kalendarz            |
| Audyt zdarzeń        |
