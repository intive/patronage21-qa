Feature: DeactivatingUserAddingFunctionality 

Task in QA board: https://tracker.intive.com/jira/browse/IP2-842
Task in Java board: https://tracker.intive.com/jira/browse/IP2-358


# https://tracker.intive.com/jira/browse/IP2-852
Scenario: USER_MODULE_1_IP2-358_Correct_user_deactivation
Given User is active
And User is on his profile page
When  User clicks "Dezaktywuj profil" button
Then The "Edytuj profil" button becomes inactive