Feature: User contact
	User can contact with another users via application (phone, email) and see their github repository

#Task in QA: https://tracker.intive.com/jira/browse/IP2-877
#Task in Java: https://tracker.intive.com/jira/browse/IP2-792


Background: 
Given User is in the user module

#https://tracker.intive.com/jira/browse/IP2-901
Scenario: USER_CONTACT_1_IP2-792_Contact_with_other_users_by_correct_email_available_in_the_user_account
Given User has access to the email application
When User clicks Wyślij wiadomość
Then User sees a window to send an e-mail with 'Do' field completed

#https://tracker.intive.com/jira/browse/IP2-902
Scenario: USER_CONTACT_2_IP2-792_Contact_with_other_users_by_correct_phone_available_in_the_user_account
Given User has access to Skype application
When User clicks Zadzwoń
Then User sees skype window with the correct phone number

#https://tracker.intive.com/jira/browse/IP2-905
Scenario: USER_CONTACT_3_IP2-792_Access_to_github_repository_via_correct_link_available_in_the_user_account
When User clicks Otwórz link
Then User sees the github page in the new tab