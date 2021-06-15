@ignore
Feature: USERS_PAGE Search By Login

Task in QA board: https://tracker.intive.com/jira/browse/IP2-897
Task in Java board: https://tracker.intive.com/jira/browse/IP2-790

Background:
Given User is on the "Użytkownicy" page 

#https://tracker.intive.com/jira/browse/IP2-926
Scenario: USER_PAGE_1_IP2-790_User_enters_an_existing_login 
When User enters a valid login in the "Szukaj użytkownika" field 

|login      |
|kowalski87 |

Then User with this login is displayed 


#https://tracker.intive.com/jira/browse/IP2-927
Scenario: USER_PAGE_2_IP2-790_User_enters_a_non-existent_login
When User enters a invalid login in the "Szukaj użytkownika" field 

|login       |
|kowalski878 |

Then The message "brak wyników" is displayed


#https://tracker.intive.com/jira/browse/IP2-928
Scenario: USER_PAGE_3_IP2-790_User_enters_at_least_2_login_characters
When User enters a fragment of an existing login

|login   |
|kow     |

Then User with this login is displayed