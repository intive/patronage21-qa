Feature: Site "Wystąpił błąd"
	There should be possibility to be transfered to main site from "Wystąpił błąd" site.


# QA: https://tracker.intive.com/jira/browse/IP2-172
# JS: https://tracker.intive.com/jira/browse/IP2-137
#FYI there will be other ticket related to this issue, please enclose link

#https://tracker.intive.com/jira/browse/IP2-303
Scenario: ERROR_PAGE_1_IP2-137_User_should_be_able_to_go_back_to_main_site
	Given User is on "Wystąpił błąd" site
	When User clicks "Strona główna" button
	Then User is tranferred to main site