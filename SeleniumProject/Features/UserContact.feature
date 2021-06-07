Feature: User contact
	User can contact with another users via application (phone, email) and see their github repository

#Task in QA: https://tracker.intive.com/jira/browse/IP2-877
#Task in Java: https://tracker.intive.com/jira/browse/IP2-792


Background: 
Given User is in the user module

#Link to Zephyr
Scenario: USER_CONTACT_1_Contact_with_other_users_by_correct_email_available_in_the_user_account
When User clicks Wyślij wiadomość
Then User sees a window to send an e-mail with the 'Do' field completed

#Link to Zephyr
Scenario: USER_CONTACT_2_Contact_with_other_users_by_incorrect_email_available_in_the_user_account
When User clicks Wyślij wiadomość
Then Button Wyślij wiadomość is inactive

#Link to Zephyr
Scenario: USER_CONTACT_3_Contact_with_other_users_by_correct_phone_available_in_the_user_account
When User clicks Zadzwoń
Then User sees links 'call to' and 'skype'

#Link to Zephyr
Scenario: USER_CONTACT_4_Contact_with_other_users_by_incorrect_phone_available_in_the_user_account
When User clicks Zadzwoń
Then Button Zadzwoń is inactive

#Link to Zephyr
Scenario: USER_CONTACT_5_Access_to_github_repository_via_correct_link_available_in_the_user_account
When User clicks Otwórz link
Then User sees the link to github
And User clicks on github link
And User sees the github page in the new tab

#Link to Zephyr
Scenario: USER_CONTACT_6_Access_to_github_repository_via_incorrect_link_available_in_the_user_account
When User clicks Otwórz link
Then Button Otwórz link is inactive