@ignore
Feature: USER_PROFILE User photo
	User can add, edit and delete photo in his account

#Task in QA: https://tracker.intive.com/jira/browse/IP2-878
#Task in Java: https://tracker.intive.com/jira/browse/IP2-767


Background:
Given User is in the user module

#https://tracker.intive.com/jira/browse/IP2-938
Scenario: USER_PROFILE_1_IP2-767_Uploading_photo_in_correct_format_to_user_account
When User clicks Edytuj profil
And User clicks Camera icon
And User chooses the photo from his device storage
Then Photo is visible in the user account
And User receives the message 'Zdjęcie zostało pomyślnie zaktualizowane'

#https://tracker.intive.com/jira/browse/IP2-939
Scenario: USER_PROFILE_2_IP2-767_Uploading_photo_in_incorrect_format_to_user_account
When User clicks Edytuj profil
And User clicks Camera icon
And User chooses the photo from his device storage
Then User receives the message 'Nieprawidłowy format zdjęcia'

#https://tracker.intive.com/jira/browse/IP2-940
Scenario: USER_PROFILE_3_IP2-767_Uploading_too_large_photo_to_user_account
When User clicks Edytuj profil
And User clicks Camera icon
And User chooses the photo from his device storage
Then User receives the message 'Zdjęcie przekracza maksymalny dozwolony rozmiar 524288 bajtów'

#https://tracker.intive.com/jira/browse/IP2-941
Scenario: USER_PROFILE_4_IP2-767_Deleting_photo_from_the_user_account
Given User already has the photo
When User clicks Edytuj profil
And User clicks Bin icon
And User clicks Potwierdź
Then User sees default placeholder