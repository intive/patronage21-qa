Feature: HAMBURGER_MENU Hamburger menu
	#Task in QA: https://tracker.intive.com/jira/browse/IP2-606
	#Task in JS: https://tracker.intive.com/jira/browse/IP2-541

#https://tracker.intive.com/jira/browse/IP2-705
Scenario Outline: HAMBURGER_MENU_1_IP2-541_User_clicks_on_page_name_in_header
	Given User is on '<page>'
	When User clicks on page name in header
	Then User is transferred to home page

	Examples:
		| page               |
		| strona główna      |
		| kalendarz          |

#https://tracker.intive.com/jira/browse/IP2-706
Scenario Outline: HAMBURGER_MENU_2_IP2-541_User_clicks_on_hamburger_menu
	Given User is on '<page>'
	When User clicks on hamburger menu
	Then Hamburger menu shows its options 

	Examples:
		| page          |
		| strona główna |
		| kalendarz     |

#https://tracker.intive.com/jira/browse/IP2-707
Scenario Outline: HAMBURGER_MENU_3_IP2-541_User_clicks_on_home_page_in_hamburger_menu
	Given User is on '<page>'
	And User clicks on hamburger menu
	When User clicks on home page
	Then User is transferred to home page

	Examples:
		| page               |
		| strona główna      |
		| kalendarz          |

#https://tracker.intive.com/jira/browse/IP2-708
Scenario Outline: HAMBURGER_MENU_4_IP2-541_User_clicks_on_calendar_in_hamburger_menu
	Given User is on '<page>'
	And User clicks on hamburger menu
	When User clicks on calendar
	Then User is transferred to calendar

	Examples:
		| page               |
		| strona główna      |
		| kalendarz          |

#https://tracker.intive.com/jira/browse/IP2-709
Scenario Outline: HAMBURGER_MENU_5_IP2-541_User_clicks_on_registration_in_hamburger_menu
	Given User is on '<page>'
	And User clicks on hamburger menu
	When User clicks on registration
	Then User is transferred to registration

	Examples:
		| page               |
		| strona główna      |
		| kalendarz          |