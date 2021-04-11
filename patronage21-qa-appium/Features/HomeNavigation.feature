Feature: HomeNavigation
	User want to be able to navigate 
	throughout the application from Home Page
https://tracker.intive.com/jira/browse/IP2-93

Background: 
	Given User is on "Home" page 

# zephyr link
Scenario:HOME_PAGE_1_IP2-93_home_page_displayed_correctly
	Then User see "Home" page navigation

# to be changed, in future Register page will be removed from this
# view and set as first page seen by unregistered user,
# so "register" example will have to be deleted/moved
# zephyr links
Scenario Outline:HOME_PAGE_2_IP2-93_home_page_to_<destination>_navigation
	When User click on "<button_name>" button
	Then User is on "<page_name>" page

Examples: 
| destination  | button_name          | page_name    |
| tech_groups  | Grupy technologiczne | Tech groups  |
| users        | Użytkownicy          | Users        |
| journal      | Dzienniczek          | Journal      |
| calendar     | Kalendarz            | Calendar     |
| events_audit | Audyt zdarzeń        | Events audit |
| register     | Rejestracja          | Register     |
	
# zephyr link
Scenario Outline:HOME_PAGE_3_IP2-93_back_to_home_page_navigation
	When User click on "<button_name>" button
	And User click on "Back" button
	Then User is on "Home" page

Examples: 
| button_name          |
| Grupy technologiczne |
| Użytkownicy          |
| Dzienniczek          |
| Kalendarz            |
| Audyt zdarzeń        |
