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
	When User completes form correctly
		| name | surname  | email                 | phone     | login        | password | passwordConfirm | Github                              |
		| Jan  | Kowalski | jankowalski@gmail.com | 123456789 | JanKowalski1 | Qwerty+8 | Qwerty+8        | https://www.github.com/jan-kowalski |
	Then User "can" sign up
	And User sees "Email verification" page

# Zephyr link
Scenario Outline:REGISTRATION_PAGE_3_IP2-261_registration_form_has_proper_validation
	When User completes "<element>" "<in a way>" with "<data>"
	Then User is informed if "<element>" is valid 

	Examples:
	| element          | in a way                                    | data                                                            |
	| name             | correctly                                   | Jan                                                             |
	| name             | with no data                                |                                                                 |
	| name             | too short                                   | J                                                               |
	| name             | too long                                    | JanJanJanJanJanJanJanJanJanJanJa                                |
	| name             | with digit                                  | Jan1                                                            |
	| name             | with special character                      | Jan@                                                            |
	| surname          | correctly                                   | Kowalski                                                        |
	| surname          | with no data                                |                                                                 |
	| surname          | too short                                   | K                                                               |
	| surname          | too long                                    | KowalskiKowalskiKowalskiKowalski                                |
	| surname          | with digit                                  | Kowalski1                                                       |
	| surname          | with special character                      | Kowalski#                                                       |
	| email            | correctly                                   | jankowalski@gmail.com                                           |
	| email            | with no data                                |                                                                 |
	| email            | with no @                                   | jankowalskigmail.com                                            |
	| email            | with no sign before @                       | jankowalskigmailcom                                             |
	| email            | with no . after @                           | jankowalski@gmailcom                                            |
	| email            | with no data before . after @               | jankowalski@.com                                                |
	| email            | with no data after . after @                | jankowalski@gmail.                                              |
	| phone            | correctly                                   | 123456789                                                       |
	| phone            | with no data                                |                                                                 |
	| phone            | too short                                   | 12345678                                                        |
	| phone            | too long                                    | 1234567890                                                      |
	| phone            | with letter                                 | 123456789a                                                      |
	| technologies     | correctly                                   |                                                                 |
	| technologies     | with too few selections                     |                                                                 |
	| technologies     | with to many selections                     |                                                                 |
	| login            | correctly                                   | JanKowalski1                                                    |
	| login            | with no data                                |                                                                 |
	| login            | too short                                   | J                                                               |
	| login            | too long                                    | JanKowalski1JanKowalski1                                        |
	| login            | with special character                      | JanKowalski1JanKowalski1#                                       |
	| password         | correctly                                   | Qwerty+8                                                        |
	| password         | with no data                                |                                                                 |
	| password         | too short                                   | Qwert+5                                                         |
	| password         | too long                                    | Qwertyuiopasdfghjkl+1                                           |
	| password         | with no uppercase letter                    | qwerty+8                                                        |
	| password         | with no digit                               | qwertyu+                                                        |
	| password         | with no special character                   | qwertyu8                                                        |
	| password confirm | correctly                                   | Qwerty+8                                                        |
	| password confirm | with wrong password                         | Qwerty+7                                                        |
	| Github           | correctly                                   | https://www.github.com/jan-kowalski                             |
	| Github           | with no https                               | www.github.com/jan-kowalski                                     |
	| Github           | with no www                                 | https://github.com/jan-kowalski                                 |
	| Github           | with no github.com                          | https://www./jan-kowalski                                       |
	| Github           | with no username                            | https://www.github.com/                                         |
	| Github           | with too long username                      | https://www.github.com/jan-kowalskijan-kowalskijan-kowalskijank |
	| Github           | with non-alphanumeric character in username | https://www.github.com/jankowalski@#%                           |
	| Github           | with hyphen at start in username            | https://www.github.com/-jan-kowalski                            |
	| Github           | with hyphen at end in username              | https://www.github.com/jan-kowalski-                            |
	| consent          | correctly                                   |                                                                 |
	| consent          | by leave required                           |                                                                 |

# Zephyr link
Scenario Outline:REGISTRATION_PAGE_4_IP2-261_registration_is_not_possible_after_filling_in_the_form_incorrectly
	When User completes form correctly
		| name | surname  | email                 | phone     | login        | password | passwordConfirm | Github                              |
		| Jan  | Kowalski | jankowalski@gmail.com | 123456789 | JanKowalski1 | Qwerty+8 | Qwerty+8        | https://www.github.com/jan-kowalski |
	And User completes "<element>" "<in a way>" with "<data>"
	Then User "can not" sign up

	Examples:
	| element          | in a way                | data                        |
	| name             | with no data            |                             |
	| surname          | with no data            |                             |
	| email            | with no data            |                             |
	| phone            | with no data            |                             |
	| technologies     | with too few selections |                             |
	| login            | with no data            |                             |
	| password         | with no data            |                             |
	| confirm password | with wrong password     | Qwerty+7                    |
	| Github           | with no https           | www.github.com/jan-kowalski |
	| consent          | by leave required       |                             |

# Zephyr link
Scenario:REGISTRATION_PAGE_5_IP2-261_registration_is_not_possible_with_email_which_was_used_before
	When User signs up
	And User signs up again with the same email
	Then User "can not" sign up
