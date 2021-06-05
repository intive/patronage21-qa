Feature: Searching User

#Task in Java Board:https://tracker.intive.com/jira/browse/IP2-90
#Task in Java Board:https://tracker.intive.com/jira/browse/IP2-85
#Task in Java Board:https://tracker.intive.com/jira/browse/IP2-457
					
#Task in QA Board:https://tracker.intive.com/jira/browse/IP2-193
#Task in QA Board:https://tracker.intive.com/jira/browse/IP2-190
#Task in QA Board:https://tracker.intive.com/jira/browse/IP2-484

Background: 
Given Url is set

#https://tracker.intive.com/jira/browse/IP2-854
Scenario Outline: LIST_USER_1_[/api/users][GET]_IP2-90_Getting_list_of_users_with_given_parameter_success
When User sends the GET request with a '<query>' parameter
Then Server return the code <code> 
And JSON body contain list of users with proper '<parameter>' with '<value>'  

Examples:
| query                      | code | parameter       | value      |
|                            | 200  |                 |            |
| firstName=ilona            | 200  | firstName       | ilona      |
| firstName=Tomeczek         | 200  | firstName       | Tomeczek   |
| firstName=Wiesław          | 200  | firstName       | Wiesław    |
| lastName=Kowalski          | 200  | lastName        | Kowalski   |
| lastName=asd-esdf          | 200  | lastName        | asd-esdf   |
| lastName=asd esdf          | 200  | lastName        | asd esdf   |
| login=AnnaNowak            | 200  | login           | AnnaNowak  |
| login=kowalski87           | 200  | login           | kowalski87 |
| login=karol                | 200  | login           | karol      |
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
Scenario Outline: LIST_USER_2_[/api/users][GET]_IP2-90_Getting_list_of_users_with_given_parameter_fail
When User sends the GET request with a '<query>' parameter
Then Server returns the code <code> and the message '<firstMessage>'

Examples:
| query                                               | code | firstMessage                                                                                                                                    |
| firstName=Oleg435435                                | 422  | Letters only, capital and Polish letters allowed, minimum 2 characters, maximum 30 characters                                                   |
| firstName=marta paluszek                            | 422  | Letters only, capital and Polish letters allowed, minimum 2 characters, maximum 30 characters                                                   |
| firstName=mar-pal                                   | 422  | Letters only, capital and Polish letters allowed, minimum 2 characters, maximum 30 characters                                                   |
| lastName=3dhu-5dsu                                  | 422  | Letters only, capital and Polish letters allowed, either dash or space in case of two-part surname, minimum 2 characters, maximum 30 characters |
| lastName=2wresdf                                    | 422  | Letters only, capital and Polish letters allowed, either dash or space in case of two-part surname, minimum 2 characters, maximum 30 characters |
| login=Kas$dd                                        | 422  | Letters and numbers, minimum 2 characters, maximum 15 characters                                                                                |
| login=Kas dd                                        | 422  | Letters and numbers, minimum 2 characters, maximum 15 characters                                                                                |
| firstName=tom%asz&lastName=karola3k&login=AnnaNowak | 422  | Letters only, capital and Polish letters allowed, minimum 2 characters, maximum 30 characters                                                   |
| firstName=tomasz&lastName=karola3k&login=AnnaNowak  | 422  | Letters only, capital and Polish letters allowed, either dash or space in case of two-part surname, minimum 2 characters, maximum 30 characters |
| firstName=tomasz&lastName=karolak&login=anna nowa   | 422  | Letters and numbers, minimum 2 characters, maximum 15 characters                                                                                |
| firstName=6tgfgh&lastName=5&login=tom3              | 422  | Letters only, capital and Polish letters allowed, minimum 2 characters, maximum 30 characters                                                   |              
                                    
