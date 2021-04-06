Feature: HomeNavigation
	As a User I want to be able to navigate 
	throughout the application from Home Page
https://tracker.intive.com/jira/browse/IP2-93

Background: 
	Given I am on "Home" page 

# zephyr link
Scenario:HOME_PAGE_1_IP2-93_home_page_displayed_correctly
	Then I see "Home" page navigation

# zephyr link
Scenario:HOME_PAGE_2_IP2-93_home_page_to_tech_groups_navigation
	When I click on "Grupy technologiczne" button
	Then I am on "Tech groups" page
	
# zephyr link
Scenario:HOME_PAGE_3_IP2-93_home_page_to_users_navigation
	When I click on "Użytkownicy" button
	Then I am on "Users" page
	
# zephyr link
Scenario:HOME_PAGE_4_IP2-93_home_page_to_journal_navigation
	When I click on "Dzienniczek" button
	Then I am on "Journal" page
	
# zephyr link
Scenario:HOME_PAGE_5_IP2-93_home_page_to_calendar_navigation
	When I click on "Kalendarz" button
	Then I am on "Calendar" page
	
# zephyr link
Scenario:HOME_PAGE_6_IP2-93_home_page_to_events_audit_navigation
	When I click on "Audyt zdarzeń" button
	Then I am on "Events audit" page
	
# to be changed, in future Register page will be removed from this
# view and set as first page seen by unregistered user
# zephyr link?
Scenario:HOME_PAGE_7_IP2-93_home_page_to_register_navigation
	When I click on "Rejestracja" button
	Then I am on "Register" page
	
# zephyr link
Scenario:HOME_PAGE_8_IP2-93_back_to_home_page_navigation
	And I click on "Grupy technologiczne" button
	And I click on "Back" button
	And I click on "Użytkownicy" button
	And I click on "Back" button
	And I click on "Dzienniczek" button
	And I click on "Back" button
	And I click on "Kalendarz" button
	And I click on "Back" button
	And I click on "Events audit" button
	And I click on "Back" button
	Then I am on "Home

# to be changed, there is no ready concept
# for breadcrumbs appearance or behaviour yet
# zephyr link
#Scenario:HOME_PAGE__IP2-93_home_page_breadcrumbs_navigation_to_home_page
# 	When I click on "Strona główna" in breadcrumbs
# 	Then I am on "Home" page 