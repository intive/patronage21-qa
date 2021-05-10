Feature: User list
This feature will allow to show a list of users, which are activated.

# link JS: https://tracker.intive.com/jira/browse/IP2-294
# link QA: https://tracker.intive.com/jira/browse/IP2-312

Background:
Given Endpoint is api/list

#Zephyr
Scenario: USER_LIST_1_IP2-294_List_of_all_user_is_visible
When Client send request with active parameter set to false
Then Response is successfull
And contains list of all users

#Zephyr
Scenario: USER_LIST_2_IP2-294_ List_of_active_users_is_visible
When Client send request with active parameter set to true
Then Response is successfull
And contains list of active users

