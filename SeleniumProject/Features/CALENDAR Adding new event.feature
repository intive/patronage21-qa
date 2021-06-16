@ignore
Feature: CALENDAR Adding new event

#link JS https://tracker.intive.com/jira/browse/IP2-545
#link QA https://tracker.intive.com/jira/browse/IP2-644

Background:
Given User is on adding event site

#zephyr link
Scenario: CALENDAR_1_IP2-545_Event_can_be_created_when_title_is_given
When user inserts title
And clicks 'Dodaj do kalendarza' button 
Then event is created
And user sees message 'Dodano wydarzenie do kalendarza'

#zephyr link
Scenario: CALENDAR_2_IP2-545_Title_can_not_have_less_than_3_characters
When user enters '1b' in title field
Then 'Dodaj do kalendarza' button is inactive
And user sees message 'Tytuł musi mieć minimalnie 3 znaki'

#zephyr link
Scenario: CALENDAR_3_IP2-545_Title_can_not_have_more_than_50_characters
When user enters too many characters in title field
Then 'Dodaj do kalendarza' button is inactive
And user sees message 'Tytuł może mieć maksymalnie 50 znaków'

#zephyr link 
Scenario: CALENDAR_4_IP2-545_Event_can_not_take_place_in_the_past
Given correct title is present
When user chooses date in the past
Then 'Dodaj do kalendarza' button is inactive
And user sees message about error
 
#zephyr link
Scenario: CALENDAR_5_IP2-545_Start_of_event_can_not_begin_after_end_of_event
Given correct title is present
When user chooses false end-time of event
Then user sees message 'Czas zakończenia musi być po czasie rozpoczęcia'

#zephyr link
Scenario: CALENDAR_6_IP2-545_Description_can_not_have_more_than_200_characters
Given correct title is present
When user enters too many characters in Opis field
Then 'Dodaj do kalendarza' button is inactive

#zephyr link
Scenario: CALENDAR_7_IP2-545_User_can_go_back_to_calendar_page
When user clicks 'Wróć do kalendarza'
Then user is transferred to Kalendarz page