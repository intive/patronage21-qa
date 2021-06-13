@ignore
Feature: REGISTRATION_PAGE [/api/projects] UserRegistration

Task in QA board: https://tracker.intive.com/jira/browse/IP2-191
Task in Java board: https://tracker.intive.com/jira/browse/IP2-88

# link to Zephyr_1_test
Scenario: REGISTRATION_PAGE_[/api/projects]_[POST]_1_IP2-88_User_registration_after_correctly_filling_in_the_form 
Given User completes form correctly

|login |firstName |lastName |email         |phoneNumber  |gitHubUrl                           |userName|
|Jan21 |Jan       |Kowalski |jan.kow@o2.pl |111222333    |https://www.github.com/jan-kowalski |Jan     |

When User sends a POST request 	
Then Server returns the code 200 
And Message "User saved" is displayed 


# link to Zephyr_2_test
Scenario Outline: REGISTRATION_PAGE_[/api/projects]_[POST]_2_IP2-88_User_registration_without_filling_in_all_data  
Given User fills in all the data correctly and "<element>" with "<data>"
When User sends a POST request 	
Then Server returns the code 400 
And Message is displayed which <element> must be entered 

Examples: 
| element     | data |
| login       |      |
| firstName   |      |
| lastName    |      |
| email       |      |
| phoneNumber |      |
| gitHubUrl   |      |
| userName    |      |


# link to Zephyr_3_test
Scenario Outline: REGISTRATION_PAGE_[/api/projects]_[POST]_3_IP2-88_User_registration_after_entering_data_incorrectly
Given User fills in all the data correctly and "<element>" "<in a way>" with "<data>"
When User sends a POST request
Then Server returns the code 400
And Message is displayed which <element> must be correctly entered

Examples: 
| element     | in_a_way                | data                    |
| login       | illegal characters      | ###                     |
| firstName   | with digits             | J3n                     |
| lastName    | with digits             | Kow45lski               |
| email       | without @               | jankowo2.pl             |
| phoneNumber | too many digits         | 1112223334              |
| gitHubUrl   | with no username        | https://www.github.com/ |
| userName    |with illegal characters  |J@#                      |


# link to Zephyr_4_test
Scenario: REGISTRATION_PAGE_[/api/projects]_[POST]_4_IP2-88_User_registration_that_already_exists 
Given User completes form correctly

|login |firstName |lastName |email         |phoneNumber  |gitHubUrl                           |userName|
|Jan21 |Jan       |Kowalski |jan.kow@o2.pl |111222333    |https://www.github.com/jan-kowalski |Jan     |

When User sends a POST request 	
Then Server returns the code 400
And Message is displayed that such a user already exists