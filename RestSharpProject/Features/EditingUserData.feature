Feature: Editing user data 

#Task in Java Board:https://tracker.intive.com/jira/browse/IP2-186
#Task in QA Board:https://tracker.intive.com/jira/browse/IP2-89

Background: 
Given User exists in the database 
| login     | firstName | lastName | email         | phoneNumber | gitHubUrl                | bio              | 
| AnnaNowak | Tomasz    | Nowak    | tom@gmail.com | 783984984   | https://github.com/tom7u | duhfisudfhisudfh | 

# https://tracker.intive.com/jira/browse/IP2-487
Scenario Outline: USER_EDIT_1_[/api/users]_[PUT]_IP2-89_API_editing_user_who_exists_in_the_database_success
When User sends a PUT request 
| login   | firstName   | lastName   | email   | phoneNumber   | gitHubUrl   | bio   |
| <login> | <firstName> | <lastName> | <email> | <phoneNumber> | <gitHubUrl> | <bio> | 
Then Server returns status <code> and Json body contain updated parameters

Examples:
| login     | firstName | lastName  | email                   | phoneNumber | gitHubUrl                  | bio         | code |
| AnnaNowak | Tomasz    | Nowak     | tom.dsfsf@gmail.com     | 783984899   | https://github.com/tom7u   | hgdhf       | 200  |
| AnnaNowak | Paweł     | Nowak     | tom.sdff@gmail.com      | 783984984   | https://github.com/tom7u   | dhfhd       | 200  |
| AnnaNowak | Tomasz    | Kowalczyk | tom.sdfsf@gmail.com     | 783984984   | https://github.com/tom7u   | dfhdhfd     | 200  |
| AnnaNowak | Tomasz    | Nowak     | tomek89.sdfsd@gmail.com | 783984984   | https://github.com/tom7u   | dhfhdfh     | 200  |
| AnnaNowak | Tomasz    | Biedronka | tom.sdfdsf@gmail.com    | 689984984   | https://github.com/tom7u   | dhfhdh      | 200  |
| AnnaNowak | Tomasz    | Nowak     | tom.sdfdsf@gmail.com    | 783984984   | https://github.com/tomiii4 | dhfhdh      | 200  |
| AnnaNowak | Piotr     | Mazurek   | piter.dsfd@gmail.com    | 689984984   | https://github.com/piter56 | dhfhdfh     | 200  |
| AnnaNowak | Anna      | Nowak     | ania1233d@gmail.com     | 111111111   | https://github.com/Ania    | jestem Ania | 200  |

# https://tracker.intive.com/jira/browse/IP2-488
Scenario Outline: USER_EDIT_2_[/api/users]_[PUT]_IP2-89_API_editing_user_who_exists_in_the_database_fail
When User sends a PUT request 
| login   | firstName   | lastName   | email   | phoneNumber   | gitHubUrl   | bio   | 
| <login> | <firstName> | <lastName> | <email> | <phoneNumber> | <gitHubUrl> | <bio> | 
Then Server returns status <code> and message '<message>'

Examples:
| login                 | firstName                       | lastName                        | email         | phoneNumber | gitHubUrl                | bio      | code | message                                                                                                                                                                          |
| AnnaNowak             | We                              | qwertyuioplkjhgfdsazxcvbnmmlok1 | tom@gmail.com | 783984984   | https://github.com/tom7u | dhfdhdfh | 422  | Only letters, dash or space allowed for two part surnames, each surname 2 to 30 letters                                                                                          |
| AnnaNowak             | W                               | Kowalski                        | tom@gmail.com | 783984984   | https://github.com/tom7u | dhfdhdfh | 422  | Only letters, 2 to 30 letters                                                                                                                                                    |
| AnnaNowak             | qwertyuioplkoiujhytrewrqtertysi | Kowalski                        | tom@gmail.com | 783984984   | https://github.com/tom7u | dhfdhdfh | 422  | Only letters, 2 to 30 letters                                                                                                                                                    |
| AnnaNowak             | W5                              | Kowalski                        | tom@gmail.com | 783984984   | https://github.com/tom7u | dhfdhdfh | 422  | Only letters, 2 to 30 letters                                                                                                                                                    |
| AnnaNowak             | Tomasz                          | qwertyuioplkjhgfdsazxcvbnmmlokt | tom@gmail.com | 783984984   | https://github.com/tom7u | dhfdhdfh | 422  | Only letters, dash or space allowed for two part surnames, each surname 2 to 30 letters                                                                                          |
| AnnaNowak             | Tomasz                          | W                               | tom@gmail.com | 783984984   | https://github.com/tom7u | dhfdhdfh | 422  | Only letters, dash or space allowed for two part surnames, each surname 2 to 30 letters                                                                                          |
| AnnaNowak             | Tomasz                          | Nowak45                         | tom@gmail.com | 783984984   | https://github.com/tom7u | dhfdhdfh | 422  | Only letters, dash or space allowed for two part surnames, each surname 2 to 30 letters                                                                                          |
| AnnaNowak             | Tomasz                          | Nowak                           | tom@gmail.com | 783984984   | https://githubcom/tom7u  | dhfdhdfh | 422  | Letters, numbers and dashes allowed, username minimum 4 characters, should start with https://www.github.com/, username cannot start or end with dash, username cannot exceed 39 |
| AnnaNowak             | Tomasz                          | Nowak                           | tom@gmail.com | 783984984   | https:/github.com/tom7u  | dhfdhdfh | 422  | Letters, numbers and dashes allowed, username minimum 4 characters, should start with https://www.github.com/, username cannot start or end with dash, username cannot exceed 39 |
| AnnaNowak             | Tomasz                          | Nowak                           | tom@gmail.com | 783984984   | https://gihub.com/tom7u  | dhfdhdfh | 422  | Letters, numbers and dashes allowed, username minimum 4 characters, should start with https://www.github.com/, username cannot start or end with dash, username cannot exceed 39 |
| Tom322222222222222224 | Tomasz                          | Nowak                           | tom@gmail.com | 783984984   | https://github.com/tom7u | dhfdhdfh | 422  | Letters and numbers, 2 to 15 characters                                                                                                                                          |
| AnnaNowak             | Tomasz                          | Nowak                           | tom@gmail.com | 78398498456 | https://github.com/tom7u | dhfdhdfh | 422  | 9 digits required                                                                                                                                                                |
| AnnaNowak             | Tomasz                          | Nowak                           | tom@gmail.com | 1212        | htts://github.com/tom7u  | dhfdhdfh | 422  | 9 digits required                                                                                                                                                                |
| AnnaNowak             | Tomasz                          | Nowak                           | tomgmail.com  | 78398m984   | htts://github.com/tom7u  | dhfdhdfh | 422  | Example e-mail: example.Mail123@mail.com, username part 3 to 30 characters                                                                                                       |
| AnnaNowak             | Tomasz                          | Nowak                           | tom@gmailcom  | 783984984   | htts://github.com/tom7u  | dhfdhdfh | 422  | Example e-mail: example.Mail123@mail.com, username part 3 to 30 characters                                                                                                       |
| AnnaNowak             | Tomasz                          | Nowak                           | tomgmail.com  | 783984984   | htts://github.com/tom7u  | dhfdhdfh | 422  | Example e-mail: example.Mail123@mail.com, username part 3 to 30 characters                                                                                                       |
| AnnaNowak             | Tomasz                          | Nowak                           | tom@gmailcomi | 783984984   | htts://github.com/tom7u  | dhfdhdfh | 422  | Example e-mail: example.Mail123@mail.com, username part 3 to 30 characters                                                                                                       |


# https://tracker.intive.com/jira/browse/IP2-505
Scenario Outline: USER_EDIT_3_[/api/users]_[PUT]_IP2-89_API_editing_user_who_does_not_exists_in_the_database
When User sends a PUT request 
| login   | firstName   | lastName   | email   | phoneNumber   | gitHubUrl   | bio   | 
| <login> | <firstName> | <lastName> | <email> | <phoneNumber> | <gitHubUrl> | <bio> | 
Then Server returns status <code> and message '<message>'

Examples:
| login      | firstName | lastName | email         | phoneNumber | gitHubUrl                | bio       | code | message        |
| JanKowalsk | Tomasz    | Nowak    | tom@gmail.com | 783983333   | https://github.com/tom7u | 4dhfdhdfh | 404  | User not found |
| Martap     | Marta     | Paluch   | mar@gmail.com | 123123123   | https://github.com/marta | fgsxhfgf  | 404  | User not found |