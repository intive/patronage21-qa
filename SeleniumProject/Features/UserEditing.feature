Feature: UserEditing
	
Task in QA board: https://tracker.intive.com/jira/browse/IP2-188
Task in Java board: https://tracker.intive.com/jira/browse/IP2-91
Sub – Tasks 3. 

Background: 
Given User is on the users page
And User clicks a field with his user data


# link to Zephyr_1 test
Scenario: USER_PROFILE_1_IP2-91_Editing_user_description 
When User clicks "Edytuj profil" button
And User clicks on the "bio" field 
And User is writing his description 
Then User clicks "Zatwierdź" button 
And The message "Dane zostały pomyślnie zaktualizowane" is displayed 

# link to Zephyr_2 test
Scenario: USER_PROFILE_2_IP2-91_Correct_adding_of_the_project_to_which_the_user_belongs 
When User enters project in the "projekt" field
And User enters role in the "rola" field 
And User clicks "+" button
Then User clicks "Zatwierdź" button
And The message "Dane zostały pomyślnie zaktualizowane" is displayed 

# link to Zephyr_3 test
Scenario: USER_PROFILE_3_IP2-91_Correct_edition_of_the_email_address
When User clicks on the "adres email" field
And User writes a valid email address
Then User clicks "Zatwierdź" button
And The message "Dane zostały pomyślnie zaktualizowane" is displayed 

# link to Zephyr_4 test
Scenario: USER_PROFILE_4_IP2-91_Incorrect_email_address_change 
When User clicks on the "adres email" field
And User writes invalid email address
And user clicks "Zatwierdź" button
Then The message "Nieprawidłowe dane" appears

# link to Zephyr_5 test
Scenario: USER_PROFILE_5_IP2-91_Correct_edition_of_the_phone_number
When User clicks on the "numer telefonu" field
And User writes a valid phone number
And User clicks "Zatwierdź" button
Then The message "Dane zostały pomyślnie zaktualizowane" is displayed 

# link to Zephyr_6 test
Scenario Outline: USER_PROFILE_6_IP2-91_Incorrect_phone_number_change 
When User clicks on the "numer telefonu" field
And User enters an incorrect '<digits>'
And User clicks "Zatwierdź" button
Then The message "Nieprawidłowe dane" appears

Examples: 
| digits      |
| 1112223     |
| 11122233345 |

# link to Zephyr_7 test
Scenario: USER_PROFILE_7_IP2-91_Correct_change_of_the_github_link
When User clicks on the "link do github" field
And User writes a valid github link
And User clicks "Zatwierdź" button
Then The message "Dane zostały pomyślnie zaktualizowane" is displayed 

# link to Zephyr_8 test
Scenario: USER_PROFILE_8_IP2-91_Incorrect_github_link_change 
When User clicks on the "link do github" field
And User writes an incorrect link
And User clicks "Zatwierdź" button
Then The message "Nieprawidłowe dane" appears