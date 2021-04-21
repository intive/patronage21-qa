Feature: Feature: Using PUT method on URL /api/users to edit User data

Background:
Given User created for testing purposes
| usernameBefore | firstNameBefore | lastNameBefore | emailBefore   | phoneNumberBefore | gitHubUrlBefore          |
| Tom34          | Tomasz          | Nowak          | tom@gmail.com | 783984984         | https://github.com/tom7u |


Scenario Outline: 1_USER_EDIT_[/api/users]_[PUT]_IP2-89_editing_user_who_exists_in_the_database_success
When User sends a PUT request 
| usernameRequest   | firstNameRequest   | lastNameRequest   | emailRequest   | phoneNumberRequest   | gitHubUrlRequest   |
| <usernameRequest> | <firstNameRequest> | <lastNameRequest> | <emailRequest> | <phoneNumberRequest> | <gitHubUrlRequest> |
Then The server returns status <code> and the message <message>
And JSON body should contain updated data
| usernameAfter   | firstNameAfter   | lastNameAfter   | emailAfter   | phoneNumberAfter   | gitHubUrlAfter   | code   | message   |
| <usernameAfter> | <firstNameAfter> | <lastNameAfter> | <emailAfter> | <phoneNumberAfter> | <gitHubUrlAfter> | <code> | <message> |


Examples:
| usernameRequest | firstNameRequest | lastNameRequest | emailRequest      | phoneNumberRequest | gitHubUrlRequest           | code | message                                               |
| Wojti34         | Tomasz           | Nowak           | tom@gmail.com     | 783984984          | https://github.com/tom7u   | 200  | userName has been successfully changed                |
| Tom34           | Wojciech         | Nowak           | tom@gmail.com     | 783984984          | https://github.com/tom7u   | 200  | firstName has been successfully changed               |
| Tom34           | Tomasz           | Kowalski        | tom@gmail.com     | 783984984          | https://github.com/tom7u   | 200  | lasttName has been successfully changed               |
| Tom34           | Tomasz           | Nowak           | tomek89@gmail.com | 783984984          | https://github.com/tom7u   | 200  | email has been successfully changed                   |
| Tom34           | Tomasz           | Nowak           | tom@gmail.com     | 689984984          | https://github.com/tom7u   | 200  | phoneNumber has been successfully changed             |
| Tom34           | Tomasz           | Nowak           | tom@gmail.com     | 783984984          | https://github.com/tomiii4 | 200  | gitHubUrl has been successfully changed               |
| Piter89         | Piotr            | Mazurek         | piter@gmail.com   | 689984984          | https://github.com/piter56 | 200  | all data has been successfully changed                |
| Tom34           | Piotr            | Kowalski        | tom@gmail.com     | 783984984          | https://github.com/tomiii4 | 200  | firstName and lastName have been successfully changed |  


Scenario Outline: 2_USER_EDIT_[/api/users]_[PUT]_IP2-89_editing_user_who_exists_in_the_database_fail
When User sends a PUT request 
| usernameRequest   | firstNameRequest   | lastNameRequest   | emailRequest   | phoneNumberRequest   | gitHubUrlRequest   |
| <usernameRequest> | <firstNameRequest> | <lastNameRequest> | <emailRequest> | <phoneNumberRequest> | <gitHubUrlRequest> |
Then The server returns status <code> and the message <message>
And JSON body should contain original data
| usernameAfter   | firstNameAfter   | lastNameAfter   | emailAfter   | phoneNumberAfter   | gitHubUrlAfter   | code   | message   |
| <usernameAfter> | <firstNameAfter> | <lastNameAfter> | <emailAfter> | <phoneNumberAfter> | <gitHubUrlAfter> | <code> | <message> |


Examples:
| usernameRequest | firstNameRequest         | lastNameRequest       | emailRequest  | phoneNumberRequest | gitHubUrlRequest         | code | message                  |
| Tom34           | To                       | Nowak                 | tom@gmail.com | 783984984          | https://github.com/tom7u | 400  | firstName is too short   |
| Tom34           | Tomasztomasztomasztomasz | Nowak                 | tom@gmail.com | 783984984          | https://github.com/tom7u | 400  | firstName is too long    |
| Tom34           | Tomasz                   | No                    | tom@gmail.com | 783984984          | https://github.com/tom7u | 400  | lastName is too short    |
| Tom34           | Tomasz                   | Nowaknowaknowaknowakn | tom@gmail.com | 783984984          | https://github.com/tom7u | 400  | lastName is too long     |
| To              | Tomasz                   | Nowak                 | tom@gmail.com | 783984984          | https://github.com/tom7u | 400  | userName is invalid      |
| Tom34           | Tomasz                   | Nowak                 | tomgmail.com  | 783984984          | https://github.com/tom7u | 400  | email is invalid         |
| Tom34           | Tomasz                   | Nowak                 | tom@gmail.com | 78398              | https://github.com/tom7u | 400  | phoneNumber is too short |
| Tom34           | Tomasz                   | Nowak                 | tom@gmail.com | 78398498456        | https://github.com/tom7u | 400  | phoneNumber is too long  |
| Tom34           | Tomasz                   | Nowak                 | tom@gmail.com | 783984984          | htts://github.com/tom7u  | 400  | gitHubUrl is invalid     |


Scenario Outline: 3_USER_EDIT_[/api/users]_[PUT]_IP2-89_editing_userName_to_one_that_already_exists_in_the_databse
Given Second user is created for testing purposes
| usernameBefore2   | firstNameBefore2   | lastNameBefore2   | emailBefore2   | phoneNumberBefore2   | gitHubUrlBefore2   |
| <usernameBefore2> | <firstNameBefore2> | <lastNameBefore2> | <emailBefore2> | <phoneNumberBefore2> | <gitHubUrlBefore2> |
When User1 sends a PUT request 
| usernameRequest   | firstNameRequest   | lastNameRequest   | emailRequest   | phoneNumberRequest   | gitHubUrlRequest   |
| <usernameRequest> | <firstNameRequest> | <lastNameRequest> | <emailRequest> | <phoneNumberRequest> | <gitHubUrlRequest> |
Then The server returns status 400 and the message "userName is already used"
And JSON body should contain original data
| usernameAfter   | firstNameAfter   | lastNameAfter   | emailAfter   | phoneNumberAfter   | gitHubUrlAfter   | 
| <usernameAfter> | <firstNameAfter> | <lastNameAfter> | <emailAfter> | <phoneNumberAfter> | <gitHubUrlAfter> |


Scenario Outline: 4_ USER_EDIT_[/api/users]_[PUT]_IP2-89_editing_user_who_does_not_exist_in_the_database 
Given User who does not exist in the database
| usernameBefore3   | firstNameBefore3   | lastNameBefore3   | emailBefore3   | phoneNumberBefore3   | gitHubUrlBefore3   |
| <usernameBefore3> | <firstNameBefore3> | <lastNameBefore3> | <emailBefore3> | <phoneNumberBefore3> | <gitHubUrlBefore3> |
When User sends a PUT request 
| usernameRequest   | firstNameRequest   | lastNameRequest   | emailRequest   | phoneNumberRequest   | gitHubUrlRequest   |
| <usernameRequest> | <firstNameRequest> | <lastNameRequest> | <emailRequest> | <phoneNumberRequest> | <gitHubUrlRequest> |
Then The server returns status code 400
And JSON body is empty 


