Feature: RegistrationPage
	New user wants to be able to register an account
	to apply for the Patronative program

# Zephyr link
Background: 
	Given User is on Registration page

# Zephyr link
Scenario:REGISTRATION_PAGE_1_IP2-261_registration_page_displayed_correctly
	Then User sees Registration page

# Zephyr link
Scenario:REGISTRATION_PAGE_2_IP2-261_registration_is_possible_after_filling_in_the_form_correctly
	When User completes "form" "correctly"
	Then User "can" sign up
	And User sees "Email verification" page

# Zephyr link
Scenario Outline:REGISTRATION_PAGE_3_IP2-261_registration_form_has_proper_validation
	When User completes "<data>" "<in a way>"
	Then User is informed about validation result of entered "<data>"

	Examples:
	| data             | in a way                                    |
	| name             | correctly                                   |
	| name             | with no data                                |
	| name             | too short                                   |
	| name             | too long                                    |
	| name             | with digit                                  |
	| name             | with special character                      |
	| surname          | correctly                                   |
	| surname          | with no data                                |
	| surname          | too short                                   |
	| surname          | too long                                    |
	| surname          | with digit                                  |
	| surname          | with special character                      |
	| email            | correctly                                   |
	| email            | with no data                                |
	| email            | with no @                                   |
	| email            | with no sign before @                       |
	| email            | with no . after @                           |
	| email            | with no sign before . after @               |
	| email            | with no sign after . after @                |
	| phone            | correctly                                   |
	| phone            | with no data                                |
	| phone            | too short                                   |
	| phone            | too long                                    |
	| phone            | with letter                                 |
	| technologies     | correctly                                   |
	| technologies     | with too few selections                     |
	| technologies     | with to many selections                     |
	| login            | correctly                                   |
	| login            | with no data                                |
	| login            | too short                                   |
	| login            | too long                                    |
	| login            | with special character                      |
	| password         | correctly                                   |
	| password         | with no data                                |
	| password         | too short                                   |
	| password         | too long                                    |
	| password         | with no uppercase letter                    |
	| password         | with no digit                               |
	| password         | with no special character                   |
	| confirm password | correctly                                   |
	| confirm password | with wrong password                         |
	| Github           | correctly                                   |
	| Github           | with no http                                |
	| Github           | with no www                                 |
	| Github           | with no github.com                          |
	| Github           | with no username                            |
	| Github           | with too long username                      |
	| Github           | with non-alphanumeric character in username |
	| Github           | with hyphen at start in username            |
	| Github           | with hyphen at end in username              |
	| consent          | correctly                                   |
	| consent          | by leave required                           |

# Zephyr link
Scenario Outline:REGISTRATION_PAGE_4_IP2-261_registration_is_not_possible_after_filling_in_the_form_incorrectly
	When User completes "form" "correctly"
	And User completes "<data>" "<incorrectly>"
	Then User "can not" sign up

	Examples:
	| data             | incorrectly             |
	| name             | with no data            |
	| surname          | with no data            |
	| email            | with no data            |
	| phone            | with no data            |
	| technologies     | with too few selections |
	| login            | with no data            |
	| password         | with no data            |
	| confirm password | with wrong password     |
	| Github           | with no http            |
	| consent          | by leave required       |

# Zephyr link
Scenario:REGISTRATION_PAGE_5_IP2-261_registration_is_not_possible_with_email_which_was_used_before
	When User signs up
	And User signs up again with the same email
	Then User "can not" sign up
