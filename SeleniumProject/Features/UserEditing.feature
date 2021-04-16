Feature: UserEditing
	
Task in QA board: https://tracker.intive.com/jira/browse/IP2-188
Task in Java board: https://tracker.intive.com/jira/browse/IP2-91
Sub – Tasks 3. 

Background: 
Given User is on the page of his user account
And User clicks the <Edytuj profil> button

# link to Zephyr test
Scenario: 1_Editing user description 
Given User edits his user description 
When user clicks on the <bio> field 
And User is writing his description  
Then The user description is saved 

# link to Zephyr test
Scenario: 2_Correct edition of the project
Given User changes the project 
When User clicks on the <Projekt> field 
And User selects and clicks his correct project 
Then Project has been changed correctly

# link to Zephyr test
Scenario: 3_Correct edition of the email address
Given User changes email adress
When User clicks on the <adres email> field
And User writes a valid email address 
Then The address has been changed correctly

# link to Zephyr test
Scenario: 4_Incorrect email address change 
Given User changes email adress
When User clicks on the  <adres email>  field
And User writes email address without @  
Then An error appears 

# link to Zephyr test
Scenario: 5_Correct edition of the phone number
Given User changes phone number
When  User clicks on the  <numer telefonu>  field
And User writes a valid phone number 
Then The phone number has been changed correctly

# link to Zephyr test
Scenario: 6_Incorrect phone number change 
Given User changes phone number
When  User clicks on the <phone number> field
And User writes more or less than 9 numbers  
Then An error appears 

# link to Zephyr test
Scenario: 7_Correct ediotion  of the github link 
Given User changes github link 
When User clicks on the <link do github> field
And User writes a valid github link 
Then Github link has been changed correctly

# link to Zephyr test
Scenario: 8_Incorrect github link change 
Given User changes github link 
When User clicks on the <link do github> field
And User writes an incorrect link 
Then An error appears