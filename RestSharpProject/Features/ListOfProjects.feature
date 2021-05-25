Feature: List of projects
	Task in Java Board: https://tracker.intive.com/jira/browse/IP2-525
	Task in QA Board: https://tracker.intive.com/jira/browse/IP2-592


Background: 
Given User sets the url

# Link to Zephyr
Scenario Outline: LIST_PROJECT_1_[/api/projects]_[GET]_IP2-592_Getting_a_list_of_projects_valid_year_provided
When User sends a GET request with a valid '<year>'
Then Server returns the code <code>

Examples:
| year | code |
| 2050 | 200  |
| 2021 | 200  |
| 1999 | 200  |

# Link to Zephyr
Scenario Outline: LIST_PROJECT_2_[/api/projects]_[GET]_IP2-592_Getting_a_list_of_projects_invalid_year_provided
When User sends a GET request with an invalid '<year>'
Then Server returns the code <code>

Examples:
| year | code |
| B*7  | 422  |
| 5$   | 422  |
| B4   | 422  | 

# Link to Zephyr
Scenario Outline: LIST_PROJECT_3_[/api/projects]_[GET]_IP2-592_Getting_a_list_of_projects_empty_year
When User sends a GET request without any year
Then Server returns the code <code> 
And JSON body contain a list of projects from current year 

Examples:
| year | code |
| 2021 | 200  |
