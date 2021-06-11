Feature: Error Site
	There should be possibility to be transferred to main site from "Wystąpił błąd" site.


# QA: https://tracker.intive.com/jira/browse/IP2-172 and https://tracker.intive.com/jira/browse/IP2-658
# JS: https://tracker.intive.com/jira/browse/IP2-137 and https://tracker.intive.com/jira/browse/IP2-540

Background:
Given Wrong Url redirects user to Error Site

#https://tracker.intive.com/jira/browse/IP2-303
Scenario: ERROR_SITE_1_IP2-137_User_should_be_able_to_go_back_to_main_site
	Given User sees information about false url address
	When User clicks "Strona główna" 
	Then User should be transferred to main site

@ignore
#https://tracker.intive.com/jira/browse/IP2-827
Scenario: ERROR_SITE_2_IP2-137_User_should_be_able_to_go_back_to_previous_site
	When User clicks "Wróć" 
	Then User is transferred to the last opened page