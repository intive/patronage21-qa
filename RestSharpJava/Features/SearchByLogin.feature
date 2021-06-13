Feature: SearchByLogin

Task in QA board: https://tracker.intive.com/jira/browse/IP2-897
Task in Java board: https://tracker.intive.com/jira/browse/IP2-790

Background:
Given User is on the "Użytkownicy" page 

#link to Zephyr test
Scenario: 1_USER_PAGE_IP2-790_User_enters_an_existing_login 
When User enters a valid login in the "Szukaj użytkownika" field 

|login      |
|kowalski87 |

Then User with this login is displayed 


#link to Zephyr test 
Scenario: 2_USER_PAGE_IP2-790_User_enters_a_non-existent_login
When User enters a invalid login in the "Szukaj użytkownika" field 

|login       |
|kowalski878 |

Then The message "brak wyników" is displayed


#link to Zephyr test
Scenario: 3_USER_PAGE_IP2-790_User_enters_at_least_2_login_characters
When User enters a fragment of an existing login

|login   |
|kow     |

Then User with this login is displayed