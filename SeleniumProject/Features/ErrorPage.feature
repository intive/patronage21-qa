Feature: Site "Wystąpił błąd"
	There should be possibility to be transfered to main site from "Wystąpił błąd" site.

https://tracker.intive.com/jira/browse/IP2-137
#FYI there will be other ticket related to this issue, please enclose link

#https://tracker.intive.com/jira/browse/IP2-303
Scenario: 1_Module Error Page - User should be able to go back to main site
	Given User is on "Wystąpił błąd" site
	When User clicks "Strona główna" button
	Then User is tranferred to main site