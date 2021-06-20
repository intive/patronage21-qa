Feature: USER PROFILE [/api/users] Editing user data 

#Task in Java Board:https://tracker.intive.com/jira/browse/IP2-186
#Task in QA Board:https://tracker.intive.com/jira/browse/IP2-89

Background: 
Given User exists in the database 
| login      | firstName | lastName | email         | phoneNumber | gitHubUrl                | bio              |
| kowalski87 | Tomasz    | Nowak    | tom@gmail.com | 783984984   | https://github.com/tom7u | duhfisudfhisudfh |

# https://tracker.intive.com/jira/browse/IP2-487
Scenario Outline: USER_PROFILE_[/api/users]_[PUT]_1_IP2-89_API_editing_user_who_exists_in_the_database_success
When User sends a PUT request 
| login   | firstName   | lastName   | email   | phoneNumber   | gitHubUrl   | bio   |
| <login> | <firstName> | <lastName> | <email> | <phoneNumber> | <gitHubUrl> | <bio> | 
Then Server returns status <code> and Json body contain updated parameters

Examples:
| login      | firstName | lastName  | email                   | phoneNumber | gitHubUrl                  | bio         | code |
| kowalski87 | Tomasz    | Nowak     | tom.dsfsf@gmail.com     | 783984899   | https://github.com/tom7u   | hgdhf       | 200  |
| kowalski87 | Paweł     | Nowak     | tom.sdff@gmail.com      | 783984984   | https://github.com/tom7u   | dhfhd       | 200  |
| kowalski87 | Tomasz    | Kowalczyk | tom.sdfsf@gmail.com     | 783984984   | https://github.com/tom7u   | dfhdhfd     | 200  |
| kowalski87 | Tomasz    | Nowak     | tomek89.sdfsd@gmail.com | 783984984   | https://github.com/tom7u   | dhfhdfh     | 200  |
| kowalski87 | Tomasz    | Biedronka | tom.sdfdsf@gmail.com    | 689984984   | https://github.com/tom7u   | dhfhdh      | 200  |
| kowalski87 | Tomasz    | Nowak     | tom.sdfdsf@gmail.com    | 783984984   | https://github.com/tomiii4 | dhfhdh      | 200  |
| kowalski87 | Piotr     | Mazurek   | piter.dsfd@gmail.com    | 689984984   | https://github.com/piter56 | dhfhdfh     | 200  |
| kowalski87 | Anna      | Nowak     | ania1233d@gmail.com     | 111111111   | https://github.com/Ania    | jestem Ania | 200  |

# https://tracker.intive.com/jira/browse/IP2-488
Scenario Outline: USER_PROFILE_[/api/users]_[PUT]_2_IP2-89_API_editing_user_who_exists_in_the_database_fail
When User sends a PUT request 
| login   | firstName   | lastName   | email   | phoneNumber   | gitHubUrl   | bio   | 
| <login> | <firstName> | <lastName> | <email> | <phoneNumber> | <gitHubUrl> | <bio> | 
Then Server returns status <code> and message '<message>'

Examples:
| login                 | firstName                       | lastName                        | email         | phoneNumber | gitHubUrl                | bio      | code | message                                                                                                                                                                                |
| kowalski87            | W                               | Kowalski                        | tom@gmail.com | 783984984   | https://github.com/tom7u | dhfdhdfh | 422  | Jedynie litery, dozwolone polskie i wielkie litery, minimalnie 2 znaki, maksymalnie 30 znaków.                                                                                         |
| kowalski87            | qwertyuioplkoiujhytrewrqtertysi | Kowalski                        | tom@gmail.com | 783984984   | https://github.com/tom7u | dhfdhdfh | 422  | Jedynie litery, dozwolone polskie i wielkie litery, minimalnie 2 znaki, maksymalnie 30 znaków.                                                                                         |
| kowalski87            | W5                              | Kowalski                        | tom@gmail.com | 783984984   | https://github.com/tom7u | dhfdhdfh | 422  | Jedynie litery, dozwolone polskie i wielkie litery, minimalnie 2 znaki, maksymalnie 30 znaków.                                                                                         |
| kowalski87            | Tomasz                          | qwertyuioplkjhgfdsazxcvbnmmlokt | tom@gmail.com | 783984984   | https://github.com/tom7u | dhfdhdfh | 422  | Jedynie litery, polskie i wielkie litery dozwolone, w przypadku dwuczłonowego nazwiska możliwość oddzielenia członów spacją lub myślnikiem, minimalnie 2 znaki, maksymalnie 30 znaków. |
| kowalski87            | Tomasz                          | W                               | tom@gmail.com | 783984984   | https://github.com/tom7u | dhfdhdfh | 422  | Jedynie litery, polskie i wielkie litery dozwolone, w przypadku dwuczłonowego nazwiska możliwość oddzielenia członów spacją lub myślnikiem, minimalnie 2 znaki, maksymalnie 30 znaków. |
| kowalski87            | Tomasz                          | Nowak45                         | tom@gmail.com | 783984984   | https://github.com/tom7u | dhfdhdfh | 422  | Jedynie litery, polskie i wielkie litery dozwolone, w przypadku dwuczłonowego nazwiska możliwość oddzielenia członów spacją lub myślnikiem, minimalnie 2 znaki, maksymalnie 30 znaków. |
| kowalski87            | Tomasz                          | Nowak                           | tom@gmail.com | 783984984   | https://githubcom/tom7u  | dhfdhdfh | 422  | Litery, cyfry i myślniki dozwolone, nazwa użytkownika minimalnie 4 znaki, maksymalnie 39 znaków, powinien zaczynać się od https://www.github.com/.                                     |
| kowalski87            | Tomasz                          | Nowak                           | tom@gmail.com | 783984984   | https:/github.com/tom7u  | dhfdhdfh | 422  | Litery, cyfry i myślniki dozwolone, nazwa użytkownika minimalnie 4 znaki, maksymalnie 39 znaków, powinien zaczynać się od https://www.github.com/.                                     |
| kowalski87            | Tomasz                          | Nowak                           | tom@gmail.com | 783984984   | https://gihub.com/tom7u  | dhfdhdfh | 422  | Litery, cyfry i myślniki dozwolone, nazwa użytkownika minimalnie 4 znaki, maksymalnie 39 znaków, powinien zaczynać się od https://www.github.com/.                                     |
| Tom322222222222222224 | Tomasz                          | Nowak                           | tom@gmail.com | 783984984   | https://github.com/tom7u | dhfdhdfh | 422  | Litery i cyfry, minimalnie 2 znaki, maksymalnie 15 znaków.                                                                                                                             |
| kowalski87            | Tomasz                          | Nowak                           | tom@gmail.com | 78398498456 | https://github.com/tom7u | dhfdhdfh | 422  | Wymagane 9 cyfr.                                                                                                                                                                       |
| kowalski87            | Tomasz                          | Nowak                           | tom@gmail.com | 1212        | htts://github.com/tom7u  | dhfdhdfh | 422  | Wymagane 9 cyfr.                                                                                                                                                                       |
| kowalski87            | Tomasz                          | Nowak                           | tomgmail.com  | 78398m984   | htts://github.com/tom7u  | dhfdhdfh | 422  | Przykładowy e-mail: example.Mail123@mail.com, nazwa użytkownika minimalnie 3 znaki, maksymalnie 30 znaków.                                                                             |
| kowalski87            | Tomasz                          | Nowak                           | tom@gmailcom  | 783984984   | htts://github.com/tom7u  | dhfdhdfh | 422  | Przykładowy e-mail: example.Mail123@mail.com, nazwa użytkownika minimalnie 3 znaki, maksymalnie 30 znaków.                                                                             |
| kowalski87            | Tomasz                          | Nowak                           | tomgmail.com  | 783984984   | htts://github.com/tom7u  | dhfdhdfh | 422  | Przykładowy e-mail: example.Mail123@mail.com, nazwa użytkownika minimalnie 3 znaki, maksymalnie 30 znaków.                                                                             |
| kowalski87            | Tomasz                          | Nowak                           | tom@gmailcomi | 783984984   | htts://github.com/tom7u  | dhfdhdfh | 422  | Przykładowy e-mail: example.Mail123@mail.com, nazwa użytkownika minimalnie 3 znaki, maksymalnie 30 znaków.                                                                             |


# https://tracker.intive.com/jira/browse/IP2-505
Scenario Outline: USER_PROFILE_[/api/users]_[PUT]_3_IP2-89_API_editing_user_who_does_not_exists_in_the_database
When User sends a PUT request 
| login   | firstName   | lastName   | email   | phoneNumber   | gitHubUrl   | bio   | 
| <login> | <firstName> | <lastName> | <email> | <phoneNumber> | <gitHubUrl> | <bio> | 
Then Server returns status <code> and message '<message>'

Examples:
| login      | firstName | lastName | email         | phoneNumber | gitHubUrl                | bio       | code | message                           |
| JanKowalsk | Tomasz    | Nowak    | tom@gmail.com | 783983333   | https://github.com/tom7u | 4dhfdhdfh | 404  | Użytkownik nie został znaleziony. |
| Martap     | Marta     | Paluch   | mar@gmail.com | 123123123   | https://github.com/marta | fgsxhfgf  | 404  | Użytkownik nie został znaleziony. |