Feature: EditUserScreenDataFromApi
	User needs to see correct
	data while editing his account
#Task in QA Team: https://tracker.intive.com/jira/browse/IP2-894
#Task in Android Team: https://tracker.intive.com/jira/browse/IP2-762

# https://tracker.intive.com/jira/browse/IP2-912
Scenario: EDIT_USER_SCREEN_1_IP2-762_user_data_is_loaded_correctly
	Given User is on "Edycja użytkownika" screen
	Then User sees correct user data
