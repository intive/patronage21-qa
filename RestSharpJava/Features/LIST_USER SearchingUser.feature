Feature: LIST_USER [/api/users] Searching User

#Task in Java Board:https://tracker.intive.com/jira/browse/IP2-90
#Task in Java Board:https://tracker.intive.com/jira/browse/IP2-85
#Task in Java Board:https://tracker.intive.com/jira/browse/IP2-457
					
#Task in QA Board:https://tracker.intive.com/jira/browse/IP2-193
#Task in QA Board:https://tracker.intive.com/jira/browse/IP2-190
#Task in QA Board:https://tracker.intive.com/jira/browse/IP2-484

Background: 
Given Url is set

#https://tracker.intive.com/jira/browse/IP2-854
Scenario Outline: LIST_USER_[/api/users]_[GET]_1_IP2-90_Getting_list_of_users_with_given_parameter_success
When User sends the GET request with a '<query>' parameter
Then Server return the code <code> 
And JSON body contain list of users with proper '<parameter>' with '<value>'  

Examples:
| query                      | code | parameter       | value      |
|                            | 200  |                 |            |
| firstName=Anna             | 200  | firstName       | Anna       |
| firstName=Wiesław          | 200  | firstName       | Wiesław    |
| lastName=Nowak             | 200  | lastName        | Nowak      |
| lastName=asd-esdf          | 200  | lastName        | asd-esdf   |
| lastName=asd esdf          | 200  | lastName        | asd esdf   |
| login=kowalski87           | 200  | login           | kowalski87 |
| login=AnnaNowak            | 200  | login           | AnnaNowak  |
| other=Tom                  | 200  | other           | Tom        |
| other=Atom                 | 200  | other           | Atom       |
| other=Nowa                 | 200  | other           | Nowa       |
| other=nna                  | 200  | other           | nna        |
| other=kowal                | 200  | other           | kowal      |
| technologyGroup=QA         | 200  | technologyGroup | QA         |
| technologyGroup=Java       | 200  | technologyGroup | Java       |
| technologyGroup=Javascript | 200  | technologyGroup | Javascript |
| technologyGroup=Android    | 200  | technologyGroup | Android    |
| role=LEADER                | 200  | role            | LEADER     |
| role=CANDIDATE             | 200  | role            | CANDIDATE  |
| role=                      | 200  | role            |            |
     

#https://tracker.intive.com/jira/browse/IP2-855
Scenario Outline: LIST_USER_[/api/users]_[GET]_2_IP2-90_Getting_list_of_users_with_given_parameter_fail
When User sends the GET request with a '<query>' parameter
Then Server returns the code <code> and the message '<firstMessage>'

Examples:
| query                                               | code | firstMessage                                                                                                                                                                           |
| firstName=Oleg435435                                | 422  | Jedynie litery, dozwolone polskie i wielkie litery, minimalnie 2 znaki, maksymalnie 30 znaków.                                                                                         |
| firstName=marta paluszek                            | 422  | Jedynie litery, dozwolone polskie i wielkie litery, minimalnie 2 znaki, maksymalnie 30 znaków.                                                                                         |
| firstName=mar-pal                                   | 422  | Jedynie litery, dozwolone polskie i wielkie litery, minimalnie 2 znaki, maksymalnie 30 znaków.                                                                                         |
| lastName=3dhu-5dsu                                  | 422  | Jedynie litery, polskie i wielkie litery dozwolone, w przypadku dwuczłonowego nazwiska możliwość oddzielenia członów spacją lub myślnikiem, minimalnie 2 znaki, maksymalnie 30 znaków. |
| lastName=2wresdf                                    | 422  | Jedynie litery, polskie i wielkie litery dozwolone, w przypadku dwuczłonowego nazwiska możliwość oddzielenia członów spacją lub myślnikiem, minimalnie 2 znaki, maksymalnie 30 znaków. |
| login=Kas$dd                                        | 422  | Litery i cyfry, minimalnie 2 znaki, maksymalnie 15 znaków.                                                                                                                             |
| login=Kas dd                                        | 422  | Litery i cyfry, minimalnie 2 znaki, maksymalnie 15 znaków.                                                                                                                             |
| firstName=tom%asz&lastName=karola3k&login=AnnaNowak | 422  | Jedynie litery, dozwolone polskie i wielkie litery, minimalnie 2 znaki, maksymalnie 30 znaków.                                                                                         |
| firstName=tomasz&lastName=karola3k&login=AnnaNowak  | 422  | Jedynie litery, polskie i wielkie litery dozwolone, w przypadku dwuczłonowego nazwiska możliwość oddzielenia członów spacją lub myślnikiem, minimalnie 2 znaki, maksymalnie 30 znaków. |
| firstName=tomasz&lastName=karolak&login=anna nowa   | 422  | Litery i cyfry, minimalnie 2 znaki, maksymalnie 15 znaków.                                                                                                                             |
| firstName=6tgfgh&lastName=5&login=tom3              | 422  | Jedynie litery, dozwolone polskie i wielkie litery, minimalnie 2 znaki, maksymalnie 30 znaków.                                                                                         |             
                                    
