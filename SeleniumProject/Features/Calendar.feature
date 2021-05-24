﻿Feature: Calendar. Creation of Calendar Part 1.

	#link JS https://tracker.intive.com/jira/browse/IP2-543
	#link QA https://tracker.intive.com/jira/browse/IP2-614

Background:
Given User is on calendar page

#Zephyr link
Scenario: CALENDAR_Part1_1_IP2-543_Present_day_is_highlighted
Then Present day is highlighted

@ignore
# Zephyr link
Scenario: CALENDAR_Part1_2_IP2-543_Every_date_can_be_highlighted
When User click on randomly picked date
Then date is highlighted

@ignore
#Zephyr link
Scenario: CALENDAR_Part1_3_IP2-544_Months_can_be_changed 
When User changes <month>
|month			|
|previous month |
|next month     |
Then Month and number of days are changed

#Zephyr link
Scenario: CALENDAR_Part1_4_IP2-544_User_can_add_new_event
When User clicks "Dodaj nowe wydarzenie" button
Then Event-adding-form opens

@ignore
#Zephyr link
Scenario: CALENDAR_Part1_5_IP2-544_Events_can_be_inspected
When user double clicks on particular date
Then user sees events of the day 	