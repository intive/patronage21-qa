Feature: Adding projects to user account
	 	
	Task in Java Board: https://tracker.intive.com/jira/browse/IP2-676
	Task in QA Board: https://tracker.intive.com/jira/browse/IP2-772

Background: 
	Given Url is set

# Link to Zephyr
Scenario outline: PROJECT_LIMIT_1_[api/users]_[PUT]_IP2-676_Adding_project_to_user_account
	When User sends the PUT request to add <count> projects
	Then Server returns status <code> 
	And JSON body contain a list of added projects

Examples: 
| count | code |
| 1     | 200  |
| 2     | 200  |
| 3     | 200  |
| 4     | 200  |
| 5     | 200  |


#Link to Zephyr
Scenario outline: PROJECT_LIMIT_2_[api/users]_[PUT]_IP2-676_Adding_more_than_five_different_projects_to_user_account
	When User sends the PUT request to add <count> different projects
	Then Server returns status <code> and message about the limit

Examples:
| count | code |
| 6     | 422  |
| 7     | 422  |
