@ignore
Feature: USER PROFILE [/api/users] Editing user data end to end
Using PUT method on URL /api/users to edit User data

Description
#Task in QA Team: https://tracker.intive.com/jira/browse/IP2-185 
#Task in Java Team: https://tracker.intive.com/jira/browse/IP2-89 

Background:
Given User created for testing purposes
| username | firstName | lastName | email         | phoneNumber | gitHubUrl                |
| Tom34    | Tomasz    | Nowak    | tom@gmail.com | 783984984   | https://github.com/tom7u |


Scenario Outline: USER_PROFILE_[/api/users]_[PUT]_1_IP2-89_editing_user_who_exists_in_the_database_success
When User sends a PUT request 
| username   | firstName   | lastName   | email   | phoneNumber   | gitHubUrl   |
| <username> | <firstName> | <lastName> | <email> | <phoneNumber> | <gitHubUrl> |
Then The server returns status <code> and the message <message>
And JSON body should contain updated data
| username   | firstName   | lastName   | email   | phoneNumber   | gitHubUrl   | code   | message   |
| <username> | <firstName> | <lastName> | <email> | <phoneNumber> | <gitHubUrl> | <code> | <message> |


Examples:
| username | firstName | lastName | email             | phoneNumber | gitHubUrl                  | code | message                                               |
| Wojti34  | Tomasz    | Nowak    | tom@gmail.com     | 783984984   | https://github.com/tom7u   | 200  | userName has been successfully changed                |
| Tom34    | Wojciech  | Nowak    | tom@gmail.com     | 783984984   | https://github.com/tom7u   | 200  | firstName has been successfully changed               |
| Tom34    | Tomasz    | Kowalski | tom@gmail.com     | 783984984   | https://github.com/tom7u   | 200  | lasttName has been successfully changed               |
| Tom34    | Tomasz    | Nowak    | tomek89@gmail.com | 783984984   | https://github.com/tom7u   | 200  | email has been successfully changed                   |
| Tom34    | Tomasz    | Nowak    | tom@gmail.com     | 689984984   | https://github.com/tom7u   | 200  | phoneNumber has been successfully changed             |
| Tom34    | Tomasz    | Nowak    | tom@gmail.com     | 783984984   | https://github.com/tomiii4 | 200  | gitHubUrl has been successfully changed               |
| Piter89  | Piotr     | Mazurek  | piter@gmail.com   | 689984984   | https://github.com/piter56 | 200  | all data has been successfully changed                |
| Tom34    | Piotr     | Kowalski | tom@gmail.com     | 783984984   | https://github.com/tomiii4 | 200  | firstName and lastName have been successfully changed |


Scenario Outline: USER_PROFILE_[/api/users]_[PUT]_2_IP2-89_editing_user_who_exists_in_the_database_fail
When User sends a PUT request 
| username   | firstName   | lastName   | email   | phoneNumber   | gitHubUrl   |
| <username> | <firstName> | <lastName> | <email> | <phoneNumber> | <gitHubUrl> |
Then The server returns status <code> and the message <message>
And JSON body should contain original data
| username   | firstName   | lastName   | email   | phoneNumber   | gitHubUrl   | code   | message   |
| <username> | <firstName> | <lastName> | <email> | <phoneNumber> | <gitHubUrl> | <code> | <message> |


Examples:
| username | firstName                | lastName              | email         | phoneNumber | gitHubUrl                | code | message                  |
| Tom34    | To                       | Nowak                 | tom@gmail.com | 783984984   | https://github.com/tom7u | 400  | firstName is too short   |
| Tom34    | Tomasztomasztomasztomasz | Nowak                 | tom@gmail.com | 783984984   | https://github.com/tom7u | 400  | firstName is too long    |
| Tom34    | Tomasz                   | No                    | tom@gmail.com | 783984984   | https://github.com/tom7u | 400  | lastName is too short    |
| Tom34    | Tomasz                   | Nowaknowaknowaknowakn | tom@gmail.com | 783984984   | https://github.com/tom7u | 400  | lastName is too long     |
| To       | Tomasz                   | Nowak                 | tom@gmail.com | 783984984   | https://github.com/tom7u | 400  | userName is invalid      |
| Tom34    | Tomasz                   | Nowak                 | tomgmail.com  | 783984984   | https://github.com/tom7u | 400  | email is invalid         |
| Tom34    | Tomasz                   | Nowak                 | tom@gmail.com | 78398       | https://github.com/tom7u | 400  | phoneNumber is too short |
| Tom34    | Tomasz                   | Nowak                 | tom@gmail.com | 78398498456 | https://github.com/tom7u | 400  | phoneNumber is too long  |
| Tom34    | Tomasz                   | Nowak                 | tom@gmail.com | 783984984   | htts://github.com/tom7u  | 400  | gitHubUrl is invalid     |


Scenario Outline: USER_PROFILE_[/api/users]_[PUT]_3_IP2-89_editing_userName_to_one_that_already_exists_in_the_databse
Given Second user is created for testing purposes
| username   | firstName   | lastName   | email   | phoneNumber   | gitHubUrl   |
| <username> | <firstName> | <lastName> | <email> | <phoneNumber> | <gitHubUrl> |
When First User sends a PUT request 
| username   | firstName   | lastName   | email   | phoneNumber   | gitHubUrl   |
| <username> | <firstName> | <lastName> | <email> | <phoneNumber> | <gitHubUrl> |
Then The server returns status 400 and the message "userName is already used"
And JSON body should contain original data
| username   | firstName   | lastName   | email   | phoneNumber   | gitHubUrl   |
| <username> | <firstName> | <lastName> | <email> | <phoneNumber> | <gitHubUrl> |


Scenario Outline: USER_PROFILE_[/api/users]_[PUT]_4_IP2-89_editing_user_who_does_not_exist_in_the_database 
Given User who does not exist in the database
| username   | firstName   | lastName   | email   | phoneNumber   | gitHubUrl   |
| <username> | <firstName> | <lastName> | <email> | <phoneNumber> | <gitHubUrl> |
When User sends a PUT request 
| username   | firstName   | lastName   | email   | phoneNumber   | gitHubUrl   |
| <username> | <firstName> | <lastName> | <email> | <phoneNumber> | <gitHubUrl> |
Then The server returns status code 400
And JSON body is empty 


