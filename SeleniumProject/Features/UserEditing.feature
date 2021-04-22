Feature: UserEditing
	
Task in QA board: https://tracker.intive.com/jira/browse/IP2-188
Task in Java board: https://tracker.intive.com/jira/browse/IP2-91
Sub – Tasks 3. 

Background: 
Given User is on the page of his user account
And User clicks the <Edytuj profil> button

# link to Zephyr_1 test
Scenario: USER_PROFILE_1_IP2-91 - Editing user description 
Given User edits his user description 
When User clicks on the <bio> field 
And User is writing his description 
Then The user description is saved 

# link to Zephyr_2 test
Scenario: USER_PROFILE_2_IP2-91 - Correct selection of the project to which the user belongs 
Given User changes the project 
When User clicks on the <Projekt> field 
And User selects a project from the list 
Then Project has been changed successfuly

# link to Zephyr_3 test
Scenario: USER_PROFILE_3_IP2-91 - Correct edition of the email address
Given User changes email adress
When User clicks on the <adres email> field
And User writes a valid email address
Then The address has been changed successfuly

# link to Zephyr_4 test
Scenario: USER_PROFILE_4_IP2-91 - Incorrect email address change 
Given User changes email adress
When User clicks on the  <adres email>  field
And User writes email address without @
Then The message invalid email address appears

# link to Zephyr_5 test
Scenario: USER_PROFILE_5_IP2-91 - Correct edition of the phone number
Given User changes phone number
When  User clicks on the  <numer telefonu>  field
And User writes a valid phone number
Then The phone number has been changed successfuly

# link to Zephyr_6 test
Scenario: USER_PROFILE_6_IP2-91 - Incorrect phone number change 
Given User changes phone number
When  User clicks on the <phone number> field
And User writes more or less than 9 numbers 
Then The message invalid phone number appears

# link to Zephyr_7 test
Scenario: USER_PROFILE_7_IP2-91 - Correct ediotion  of the github link 
Given User changes github link 
When User clicks on the <link do github> field
And User writes a valid github link
Then Github link has been changed successfuly

# link to Zephyr_8 test
Scenario: USER_PROFILE_8_IP2-91 - Incorrect github link change 
Given User changes github link 
When User clicks on the <link do github> field
And User writes an incorrect link
Then The message invalid link github appears