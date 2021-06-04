Feature: Adding projects to user account
	 	
	Task in Java Board: https://tracker.intive.com/jira/browse/IP2-676
	Task in QA Board: https://tracker.intive.com/jira/browse/IP2-772

Background: 
	Given Url is set

# Link to Zephyr
Scenario Outline: PROJECT_LIMIT_1_[api/users]_[PUT]_IP2-676_Adding_projects_to_user_account
	When User '<username>' sends the PUT request to add <count> projects
	Then Server returns status <code>
	
Examples: 
| username  | count | code |
| AnnaNowak | 1     | 200  |
| AnnaNowak | 2     | 200  |
| AnnaNowak | 3     | 200  |
| AnnaNowak | 4     | 200  |
| AnnaNowak | 5     | 200  |


#Link to Zephyr
Scenario Outline: PROJECT_LIMIT_2_[api/users]_[PUT]_IP2-676_Adding_more_than_five_projects_to_user_account
	When User '<username>' sends the PUT request to add <count> projects
	Then Server returns status <code> and error message '<message>' 

Examples:
| username  | count | code | message                                                       |
| AnnaNowak | 6     | 422  | Maximum number of projects in which you can participate is: 5 |
| AnnaNowak | 7     | 422  | Maximum number of projects in which you can participate is: 5 |


#Link to Zephyr
Scenario Outline: PROJECT_LIMIT_3_[api/users]_[PUT]_IP2-676_Adding_projects_to_user_account_that_does_not_exist
	When User '<username>' sends the PUT request to add <count> projects
	Then Server returns status <code> and error message '<message>'

Examples:
| username | count | code | message        |
| Roman    | 1     | 404  | User not found |
| Tomasz   | 2     | 404  | User not found |

