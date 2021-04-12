Feature: Listing users by given role
	User Story: There will be a user story when it's ready
	Task in Java Board: https://tracker.intive.com/jira/browse/IP2-85
	Task in QA Board: https://tracker.intive.com/jira/browse/IP2-190

Background: 
Given URL endpoint is /api/users

@mytag
# link do testu 1 w Zephyr
Scenario Outline: [/api/users][GET]_1_Getting list of users with given role
Given Customer sets the endpoint with method GET
And Several users with different roles exist in application
And Customer enters valid <role> as a query parameter
When Customer sends the request to the endpoint
Then The server returns code 200 
And JSON body contains <email_1> and <email_2> address of users with given role
Examples:
| role            | email_1              | email_2               |
| ?role=LEADER    | lider_1@wp.pl        | lider_2@onet.eu       |
| ?role=CANDIDATE | kandydat_1@gmail.com | kandydat_2@interia.pl |