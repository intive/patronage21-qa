@ignore

Feature: IP2-546Calendar_Evets_View

#Link JS: https://tracker.intive.com/jira/browse/IP2-546
#Link QA: https://tracker.intive.com/jira/browse/IP2-648

Background:
Given User can see calendar

#Link to Zephyr1
Scenario: CALENDAR_EVENTS_VIEW_1_IP2-546_User_can_see_details_of_event
Given User clics on 'Kalendarz' button
And User is redirected to calendar
When User double clicks any day
And can see planned events on chosen day
Then User clicks 'Podgląd' button
And User click 'Wróć do kalendarza' button

#Link to Zephyr2
Scenario:CALENDAR_EVENTS_VIEW_2_IP2-546_User_can_edit_and_changes_details_of_event
Given User clics on 'Kalendarz' button
And User is redirected to calendar
When User double clicks any day
And can see planned events on chosen day
Then User click 'Edytuj' button
And can changes events detailis
Then User clicks 'Zaktualizuj wydarzenie' button to confirm changes
And User click 'Wróć do listy wydarzeń' button
And User cliks 'Wróc do kalendarza'

#Link to Zephyr3
Scenario:CALENDAR_EVENTS_VIEW_3_IP2-546_User_wants_delete_the_event
Given User clics on 'Kalendarz' button
And User is redirected to calendar
When User double clicks any day
And can see planned events on chosen day
And can click 'Usuń' button
And see warning   
Then User clicks 'Tak' button
Then User click 'Wróć do kalendarza' button

#Link to Zephyr4
Scenario:CALENDAR_EVENTS_VIEW_4_IP2-546_User_do_not_want_delete_the_event
Given User clics on 'Kalendarz' button
And User is redirected to calendar
When User double clicks any day
And can see planned events on chosen day
And can click 'Usuń' button
And see warning   
Then User clicks 'Nie' button
Then User click 'Wróć do kalendarza' button

#Link to Zephyr5
Scenario:CALENDAR_EVENTS_VIEW_5_IP2-546_User_checkes_are_there_any_planned_events_on_chosen_day
Given User clics on 'Kalendarz' button
And User is redirected to calendar
When User double clicks any day
And can see there is no planned events on chosen day
Then User click 'Wróć do kalendarza' button

#Link to Zephyr6
Scenario:CALENDAR_EVENTS_VIEW_6_IP2-546_User_can_add_new_event
Given User clics on 'Kalendarz' button
And User is redirected to calendar
When User cliks on'Dodaj nowe wydarzenie' button
And is redirected to the details of event
Then User fills details of new event
And Clicks 'Dodaj do kalendarza' button
Then User see success site
And clicks 'Ok' button
And clicks 'Wróć do kalendarza"