Feature: List of projects
	Task in Java Board: https://tracker.intive.com/jira/browse/IP2-525
	Task in QA Board: https://tracker.intive.com/jira/browse/IP2-592


# Link to Zephyr
Scenario Outline: 1_LIST_PROJECT_[/api/projects]_[GET]_IP2-592_Getting_a_list_of_projects
Given User sets the url
When User sends a GET request 
Then Server returns the code 200 and JSON body contain a list of projects

