Feature: UsersScreenTechGroupsFromApi
	User needs to see correct
	tech groups in Users screen
	while searching for users
#Task in QA Team: https://tracker.intive.com/jira/browse/IP2-474
#Task in Android Team: https://tracker.intive.com/jira/browse/IP2-469

# https://tracker.intive.com/jira/browse/IP2-563
Scenario: USERS_SCREEN_1_IP2-469_tech_groups_are_loaded_correctly
	Given User is on "Użytkownicy" screen
	When User clicks "Wszystkie grupy"
	Then User sees correct tech groups
