Feature: User photo
	User can add, edit and delete phone in his account

#Task in QA: https://tracker.intive.com/jira/browse/IP2-878
#Task in Java: https://tracker.intive.com/jira/browse/IP2-767


Background:
Given User is in the user module


Scenario: USER_PHOTO_1_Adding_photo_to_user_account
When User clicks Dodaj zdjęcie
And User chooses the photo from his device storage
Then Photo is visible in the user account


Scenario: USER_PHOTO_2_Editing_photo_in_the_user_account
Given User already has the photo
When User clicks Edycja
And User chooses the photo from his device storage
Then New photo is visible in the user account


Scenario: USER_PHOTO_3_Deleting_photo_in_the_user_account
Given User already has the photo
When User clicks Usuń
Then Photo is deleted
And User sees default placeholder