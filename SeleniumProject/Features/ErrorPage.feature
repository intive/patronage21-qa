Feature: Site "Wystąpił błąd"
	There should be possibility to be transfered to main site from "Wystąpił błąd" site.


# QA: https://tracker.intive.com/jira/browse/IP2-172 and https://tracker.intive.com/jira/browse/IP2-658
# JS: https://tracker.intive.com/jira/browse/IP2-137 and https://tracker.intive.com/jira/browse/IP2-540

Background:
Given Wrong operation redirects user to Error Page

#https://tracker.intive.com/jira/browse/IP2-303
Scenario: ERROR_PAGE_1_IP2-137_User_should_be_able_to_go_back_to_main_site
	When User clicks "Strona główna" button
	Then User is transferred to main site