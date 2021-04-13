Feature: Updating user data with PUT method
Description
#Task in QA Team: https://tracker.intive.com/jira/browse/IP2-185 
#Task in Java Team: https://tracker.intive.com/jira/browse/IP2-89 

Background:
Given User created for testing purposes
|username| firstName| lastName | email | phoneNumber | gitHubUrl |
|Tom34| Tomasz | Nowak | tom@gmail.com | 783984984 | https://github.com/tom7u |


Scenario Outline: 1_Editing user who exists in database
Given User exist in database
|username| firstName| lastName | email | phoneNumber | gitHubUrl |
|<username> | <firstName> | <lastName> | <email> | <phoneNumber> | <gitHubUrl> |
When User send a request 
Then The server return status code <code> and the message <message>
And Updated user data can be checked
|username| firstName| lastName | email | phoneNumber | gitHubUrl | code | message |
|<username> | <firstName> | <lastName> | <email> | <phoneNumber> | <gitHubUrl> | <code> | <message> |


# codes and messages will be corrected after implementation
Example:
|username| firstName| lastName | email | phoneNumber | gitHubUrl | code | message |
|Tom34| Wojciech | Nowak | tom@gmail.com | 783984984 | https://github.com/tom7u |200| firstName has been successfully changed|
|Tom34|          | Nowak | tom@gmail.com | 783984984 | https://github.com/tom7u | 200 | firstName field is required |
|Pablo21| Wojciech | Nowak | tom@gmail.com | 783984984 | https://github.com/tom7u | 200 |userName is already used |
|Tom34| Wojciech | Nowak | tomgmail.com | 783984984 | https://github.com/tom7u | 200 |email is incorrect| 
|Tom34| Wojciech | Nowak | tom@gmail.com | 7839849 | https://github.com/tom7u | 200 |phoneNumber is incorrect| 
|Tom34| Wojciech | Nowak | tom@gmail.com | 783984984 | htts://github.com/tom7u | 200 |gitHubUrl is incorrect | 


Scenario Outline: 2_ Editing user who doesn’t exist in database 
Given User doesn’t exist in database
|username| firstName| lastName | email | phoneNumber | gitHubUrl |
|<username> | <firstName> | <lastName> | <email> | <phoneNumber> | <gitHubUrl> |
When User send a request 
Then The server return status code <code>
And JSON body in empty 
|username| firstName| lastName | email | phoneNumber | gitHubUrl | code | 
|<username> | <firstName> | <lastName> | <email> | <phoneNumber> | <gitHubUrl> | <code> |

Example
|username| firstName| lastName | email | phoneNumber | gitHubUrl | code | 
|        |          |          |       |             |           |404|



TO DO: testing roles (not implemented yet).
