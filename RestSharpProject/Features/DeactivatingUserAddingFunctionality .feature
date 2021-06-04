Feature: DeactivatingUserAddingFunctionality 

Task in QA board: https://tracker.intive.com/jira/browse/IP2-842
Task in Java board: https://tracker.intive.com/jira/browse/IP2-358


# link to Zephyr_1_test

Scenario: USER_PROFILE_1_IP2-358_Correct_user_deactivation
Given User is active
And User is on his profile page
When  User clicks "Dezaktywuj profil" button
Then His status in the database will change to inactive