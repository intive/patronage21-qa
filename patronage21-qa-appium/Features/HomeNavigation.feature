Feature: HomeNavigation
	As a User I want to be able to navigate 
	throughout the application from Home Page
https://tracker.intive.com/jira/browse/IP2-93

Background: 
	Given I am on "Home" page 

# zephyr link
Scenario:1_HOME_PAGE_IP2-93_Home Page displayed correctly
	Then I see "Home" page navigation

# zephyr link
Scenario:2_HOME_PAGE_IP2-93_Home Page to Tech groups navigation
	When I click on "Grupy technologiczne" button
	Then I am on "Tech groups" page
	
# zephyr link
Scenario:3_HOME_PAGE_IP2-93_Home Page to Users navigation
	When I click on "Użytkownicy" button
	Then I am on "Users" page
	
# zephyr link
Scenario:4_HOME_PAGE_IP2-93_Home Page to Journal navigation
	When I click on "Dzienniczek" button
	Then I am on "Journal" page
	
# zephyr link
Scenario:5_HOME_PAGE_IP2-93_Home Page to Calendar navigation
	When I click on "Kalendarz" button
	Then I am on "Calendar" page
	
# zephyr link
Scenario:6_HOME_PAGE_IP2-93_Home Page to Events audit navigation
	When I click on "Audyt zdarzeń" button
	Then I am on "Events audit" page
	
# to be changed, in future Register page will be removed from this
# view and set as first page seen by unregistered user
# zephyr link?
Scenario:7_HOME_PAGE_IP2-93_Home Page to Register navigation
	When I click on "Rejestracja" button
	Then I am on "Register" page

# to be changed, there is no ready concept
# for breadcrumbs appearance or behaviour yet
# zephyr link
#Scenario:8_HOME_PAGE_IP2-93_Home Page breadcrumbs navigation to Home Page
# 	When I click on "Strona główna" in breadcrumbs
# 	Then I am on "Home" page 