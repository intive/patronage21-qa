Feature: HomeNavigation
	User want to be able to navigate 
	throughout the application from Home Page
# https://tracker.intive.com/jira/browse/IP2-93

Background: 
	Given User is on Home page 

# https://tracker.intive.com/jira/browse/IP2-334
Scenario:HOME_PAGE_1_IP2-93_home_page_displayed_correctly
	Then User sees "Home" page

# to be changed, in future Register page will be removed from this
# view and set as first page seen by unregistered user,
# so "register" example will have to be deleted/moved
# https://tracker.intive.com/jira/browse/IP2-335
Scenario Outline:HOME_PAGE_2_IP2-93_home_page_to_<destination>_navigation
	When User clicks on "<button_name>" button
	Then User sees "<page_name>" page

Examples: 
| destination  | button_name           | page_name             |       
| tech_groups  | Grupy technologiczne  | Grupy technologiczne  |
| users        | Użytkownicy		   | Użytkownicy		   |
| journal      | Dzienniczek		   | Dzienniczek           |
| calendar     | Kalendarz			   | Kalendarz             |
| events_audit | Audyt zdarzeń		   | Audyt zdarzeń         |
| register     | Rejestracja		   | Rejestracja           |
	
# https://tracker.intive.com/jira/browse/IP2-336
Scenario Outline:HOME_PAGE_3_IP2-93_back_to_home_page_navigation
	When User clicks on "<button_name>" button
	And User clicks on "Back" button
	Then User sees "Home" page

Examples: 
| button_name                             |
| Miniaturka modułu grup technologicznych |
| Miniaturka modułu użytkowników          |
| Miniaturka modułu dzienniczka           |
| Miniaturka modułu kalendarza            |
| Miniaturka modułu audytu zdarzeń        |
| Miniaturka modułu rejestracji           |
