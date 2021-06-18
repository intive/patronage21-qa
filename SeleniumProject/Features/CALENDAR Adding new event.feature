@ignore
Feature: CALENDAR Adding new event

#link JS https://tracker.intive.com/jira/browse/IP2-545
#link QA https://tracker.intive.com/jira/browse/IP2-644

Background:
Given User is on adding event site

#https://tracker.intive.com/jira/browse/IP2-985
Scenario: CALENDAR_1_IP2-545_Event_can_be_created_when_title_is_given
When user inserts title
And clicks 'Dodaj do kalendarza' button 
Then event is created
And user sees message 'Dodano wydarzenie do kalendarza'

#https://tracker.intive.com/jira/browse/IP2-986
Scenario: CALENDAR_2_IP2-545_Title_can_not_have_less_than_3_characters
When user enters '1b' in title field
Then 'Dodaj do kalendarza' button is inactive
And user sees message 'Tytuł musi mieć minimalnie 3 znaki'

#https://tracker.intive.com/jira/browse/IP2-987
Scenario: CALENDAR_3_IP2-545_Title_can_not_have_more_than_50_characters
When user enters too many characters in title field
Then 'Dodaj do kalendarza' button is inactive
And user sees message 'Tytuł może mieć maksymalnie 50 znaków'
 
#https://tracker.intive.com/jira/browse/IP2-988
Scenario: CALENDAR_4_IP2-545_Start_of_event_can_not_begin_after_end_of_event
Given correct title is present
When user chooses end-time of event before start of event
Then user sees message 'Czas zakończenia musi być po czasie rozpoczęcia'

#https://tracker.intive.com/jira/browse/IP2-989
Scenario: CALENDAR_5_IP2-545_Description_can_not_have_more_than_200_characters
Given correct title is present
When user enters too many characters in Opis field
Then 'Dodaj do kalendarza' button is inactive

#https://tracker.intive.com/jira/browse/IP2-990
Scenario: CALENDAR_6_IP2-545_User_can_go_back_to_calendar_page
When user clicks 'Wróć do kalendarza'
Then user is transferred to Kalendarz page