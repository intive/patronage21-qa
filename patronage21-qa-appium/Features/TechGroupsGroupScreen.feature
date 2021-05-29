Feature: TechGroupsGroupScreen
	User wants to be able to 
	view details about certain
	tech group
#Task in QA Team: https://tracker.intive.com/jira/browse/IP2-249
#Task in Android Team: https://tracker.intive.com/jira/browse/IP2-141

# zephyr link
Scenario: TECH_GROUPS_GROUP_SCREEN_1_IP2-249_group_screen_displayed_correctly
	Given User is on "Grupy technologiczne" screen
	When User clicks "Grupa I"
	Then User sees "Grupa I" group screen
	And User sees "Grupa I" technologies
	And User sees "Grupa I" stages
	And "Liderzy" list counter is correct
	And "Kandydaci" list counter is correct

# zephyr link
# there is no ready concept of signing to group yet
@ignore
Scenario: TECH_GROUPS_GROUP_SCREEN_2_IP2-249_sign_in_to_group
	Given User is registered as "JanKowalski"
	When User navigates to "Grupy technologiczne"
	And User clicks "Grupa I"
	And User clicks "Zapisz się do grupy"
	Then User is signed to "Grupa I"
	
# zephyr link
# there is no ready concept of signing to group yet
@ignore
Scenario: TECH_GROUPS_GROUP_SCREEN_3_IP2-249_sign_out_from_group
	Given User is registered as "JanKowalski"
	When User navigates to "Grupy technologiczne"
	And User clicks "Grupa I"
	And User clicks "Zapisz się do grupy"
	And User clicks "Zrezygnuj z kandydatury"
	Then User is not signed to "Grupa I"
	
# zephyr link
Scenario: TECH_GROUPS_GROUP_SCREEN_4_IP2-249_navigate_to_stage_and_back
	Given User is on "Grupy technologiczne" screen
	When User clicks "Grupa I"
	And User clicks "Etap I"
	And User clicks on "Back" button
	Then User sees "Grupa I" group screen