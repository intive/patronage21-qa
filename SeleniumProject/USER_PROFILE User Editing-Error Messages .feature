@ignore
Feature: USER_PROFILE User Editing-Error Messages

Task in QA board: https://tracker.intive.com/jira/browse/IP2-897
Task in Java board: https://tracker.intive.com/jira/browse/IP2-881

Background:
Given User is on his profile page 

#link to Zephyr test
Scenario: USER_PROFILE_1_IP2-881_User_doesn't_make_changes
When User clicks the "Edytuj profil" button 
Then The "Zatwierdź" button is inactive 

#link to Zephyr test
Scenario: USER_PROFILE_2_IP2-881_User_added_changes_correctly
When User clicks the "Edytuj profil" button
And User enters the correct data
And User clicks "Zatwierdź" button 
Then "Dane zostały pomyślnie zaktualizowane" will be displayed

#link to Zephyr test
Scenario: USER_PROFILE_3_IP2-881_user enters the data incorrectly
When User clicks the "Edytuj profil" button
And User enters his data incorrectly
And User clicks "Zatwierdź" button
Then "Nieprawidłowe dane" will be displayed and a hint what needs to be corrected