@ignore
Feature: USER_PROFILE Editing Profile Photo

User wants to change profile picture.
The photo can be up to 512 KB in size and can be in the following format: JPG, PNG or GIF.

Task in QA board: https://tracker.intive.com/jira/browse/IP2-847
Task in Java board: https://tracker.intive.com/jira/browse/IP2-766

Background: 
Given User sets the endpoint with method PATCH

#https://tracker.intive.com/jira/browse/IP2-932
Scenario: USER_PROFILE_1_[/api/users/{login}/image]_[PATCH]_User_edits_profile_picture_correctly 
When User enters valid login 

|login      |
|kowalski87 |

And User will delete existing photo 
And User selects a photo of the correct size and format 
And User sends the request to the api
Then The server returns code 200 - OK

#https://tracker.intive.com/jira/browse/IP2-933
Scenario: USER_PROFILE_2_[/api/users/{login}/image]_[PATCH]_User_enters_an_incorrect_login
When User enters an incorrect login

|login      |
|kowalski88 |

And User will delete existing photo 
And User selects a photo of the correct size and format 
And User sends the request to the api
Then The server returns code 404
And Message "user not found" is displayed 

#https://tracker.intive.com/jira/browse/IP2-934
Scenario: USER_PROFILE_3_[/api/users/{login}/image]_[PATCH]_User_selects_the_wrong_photo 
When User enters valid login 

|login      |
|kowalski87 |

And User will delete existing photo 
And User selects a photo of the incorrect size and format

|size    |format                   |
|< 512KB |other than JPG, PNG, GIF |

Then The server returns code 422
And Message "incorrect photo or login " is displayed