@ignore
Feature: USER_PROFILE Uploading Image

Adding a photo to the user's profile.
The photo can be up to 512 KB in size and can be in the following format: JPG, PNG or GIF

Task in QA board: https://tracker.intive.com/jira/browse/IP2-846
Task in Java board: https://tracker.intive.com/jira/browse/IP2-764

Background: 
Given User sets the endpoint with method POST


#https://tracker.intive.com/jira/browse/IP2-935
Scenario: USER_PROFILE_1_[/api/users/{login}/image]_[POST]_User_adds_a_photo_correct
When User enters valid login 

|login      |
|kowalski87 |

And User selects a photo of the correct size and format 
And User sends the request to the api
Then The server returns code 200 - OK


#https://tracker.intive.com/jira/browse/IP2-936
Scenario: USER_PROFILE_2_[/api/users/{login}/image]_[POST]_User_enters_an_incorrect_login
When User enters an incorrect login

|login      |
|kowalski88 |

And User selects a photo of the correct size and format 
And User sends the request to the api
Then The server returns code 404 
And Message "user not found" is displayed 


#https://tracker.intive.com/jira/browse/IP2-937
Scenario: USER_PROFILE_3_[/api/users/{login}/image]_[POST]_User_selects_the_wrong_photo 
When User enters valid login 

|login      |
|kowalski87 |

And User selects a photo of the incorrect size and format

|size    |format                   |
|< 512KB |other than JPG, PNG, GIF |

Then The server returns code 422
And Message "incorrect photo or login " is displayed