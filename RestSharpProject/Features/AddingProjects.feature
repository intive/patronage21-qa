Feature: Adding projects to user account
	 	
	Task in Java Board: https://tracker.intive.com/jira/browse/IP2-676
	Task in QA Board: https://tracker.intive.com/jira/browse/IP2-772

Background: 
	Given Proper url is set

#https://tracker.intive.com/jira/browse/IP2-856
Scenario Outline: PROJECT_LIMIT_1_[api/users]_[PUT]_IP2-676_Adding_projects_to_user_account
	When User '<login>' sends the PUT request to add <count> projects
	Then Server returns status <code>
	
Examples: 
| login     | count | code |
| AnnaNowak | 1     | 200  |
| AnnaNowak | 2     | 200  |
| AnnaNowak | 3     | 200  |
| AnnaNowak | 4     | 200  |
| AnnaNowak | 5     | 200  |


#https://tracker.intive.com/jira/browse/IP2-857
Scenario Outline: PROJECT_LIMIT_2_[api/users]_[PUT]_IP2-676_Adding_more_than_five_projects_to_user_account
	When User '<login>' sends the PUT request to add <count> projects
	Then Server returns status <code> and error message '<message>' 

Examples:
| login     | count | code | message                                                       |
| AnnaNowak | 6     | 422  | Maximum number of projects in which you can participate is: 5 |
| AnnaNowak | 7     | 422  | Maximum number of projects in which you can participate is: 5 |


#https://tracker.intive.com/jira/browse/IP2-858
Scenario Outline: PROJECT_LIMIT_3_[api/users]_[PUT]_IP2-676_Adding_projects_to_user_account_that_does_not_exist
	When User '<login>' sends the PUT request to add <count> projects
	Then Server returns status <code> and error message '<message>'

Examples:
| login  | count | code | message        |
| Roman  | 1     | 404  | User not found |
| Tomasz | 2     | 404  | User not found |

