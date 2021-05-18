Feature: List of technology groups
	Task in Java Board: https://tracker.intive.com/jira/browse/IP2-454
	Task in QA Board: https://tracker.intive.com/jira/browse/IP2-590


# Link to Zephyr
Scenario Outline: 1_LIST_GROUP_[/api/groups]_[GET]_IP2-590_Getting_a_list_of_technology_groups 
Given User sets the proper url
When User sends GET request 
Then The server returns the code 200 and JSON body contain a list of technology groups



