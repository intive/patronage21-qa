Feature: PROJECT_LIMIT [api/users] Adding projects to user account
	 	
	Task in Java Board: https://tracker.intive.com/jira/browse/IP2-676
	Task in QA Board: https://tracker.intive.com/jira/browse/IP2-772

Background: 
	Given Url to add projects is api/users

#https://tracker.intive.com/jira/browse/IP2-856
Scenario Outline: PROJECT_LIMIT_[api/users]_[PUT]_1_IP2-676_Adding_projects_to_user_account
	When User '<username>' sends the PUT request to add <count> projects
	Then Server returns status <code>
	
Examples: 
| username   | count | code |
| kowalski87 | 1     | 200  |
| kowalski87 | 2     | 200  |
| kowalski87 | 3     | 200  |
| kowalski87 | 4     | 200  |
| kowalski87 | 5     | 200  |


#https://tracker.intive.com/jira/browse/IP2-857
Scenario Outline: PROJECT_LIMIT_[api/users]_[PUT]_2_IP2-676_Adding_more_than_five_projects_to_user_account
	When User '<username>' sends the PUT request to add <count> projects
	Then Server returns status <code> and error message '<message>' 

Examples:
| username   | count | code | message                                                               |
| kowalski87 | 6     | 422  | Maksymalna liczba projektów, w których możesz brać udział wynosi: 5.5 |
| kowalski87 | 7     | 422  | Maksymalna liczba projektów, w których możesz brać udział wynosi: 5.5 |


#https://tracker.intive.com/jira/browse/IP2-858
Scenario Outline: PROJECT_LIMIT_[api/users]_[PUT]_3_IP2-676_Adding_projects_to_user_account_that_does_not_exist
	When User '<username>' sends the PUT request to add <count> projects
	Then Server returns status <code> and error message '<message>'

Examples:
| username | count | code | message                           |
| Roman    | 1     | 404  | Użytkownik nie został znaleziony. |
| Tomasz   | 2     | 404  | Użytkownik nie został znaleziony. |

