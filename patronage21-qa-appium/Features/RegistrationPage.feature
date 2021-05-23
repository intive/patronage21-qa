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
		| name | surname  | phone     | password | passwordConfirm | Github                              |
		| Jan  | Kowalski | 123456789 | Qwerty+8 | Qwerty+8        | https://www.github.com/jan-kowalski |
	Then User "can" sign up
	And User sees "Email verification" page

# Zephyr link
Scenario Outline:REGISTRATION_PAGE_3_IP2-261_registration_form_has_proper_validation
	When User completes "<element>" "<in a way>" with "<data>"
	Then User is informed if "<element>" is "<valid>"

	Examples:
	| element          | in a way                                    | data                                                            | valid |
	| name             | correctly                                   | Jan                                                             | OK    |
	| name             | with no data                                |                                                                 | NOK   |
	| name             | too short                                   | J                                                               | NOK   |
	| name             | too long                                    | JanJanJanJanJanJanJanJanJanJanJa                                | NOK   |
	| name             | with digit                                  | Jan1                                                            | NOK   |
	| name             | with special character                      | Jan@                                                            | NOK   |
	| surname          | correctly                                   | Kowalski                                                        | OK    |
	| surname          | with no data                                |                                                                 | NOK   |
	| surname          | too short                                   | K                                                               | NOK   |
	| surname          | too long                                    | KowalskiKowalskiKowalskiKowalski                                | NOK   |
	| surname          | with digit                                  | Kowalski1                                                       | NOK   |
	| surname          | with special character                      | Kowalski#                                                       | NOK   |
	| email            | correctly                                   | jankowalski@gmail.com                                           | OK    |
	| email            | with no data                                |                                                                 | NOK   |
	| email            | with no @                                   | jankowalskigmail.com                                            | NOK   |
	| email            | with no sign before @                       | jankowalskigmailcom                                             | NOK   |
	| email            | with no . after @                           | jankowalski@gmailcom                                            | NOK   |
	| email            | with no data before . after @               | jankowalski@.com                                                | NOK   |
	| email            | with no data after . after @                | jankowalski@gmail.                                              | NOK   |
	| phone            | correctly                                   | 123456789                                                       | OK    |
	| phone            | with no data                                |                                                                 | NOK   |
	| phone            | too short                                   | 12345678                                                        | NOK   |
	| phone            | too long                                    | 1234567890                                                      | NOK   |
	| phone            | with letter                                 | 12345678a                                                       | NOK   |
	| technologies     | correctly                                   | 1                                                               | OK    |
	| technologies     | with too few selections                     | 0                                                               | NOK   |
	| technologies     | with to many selections                     | 4                                                               | NOK   |
	| login            | correctly                                   | JanKowalski1                                                    | OK    |
	| login            | with no data                                |                                                                 | NOK   |
	| login            | too short                                   | J                                                               | NOK   |
	| login            | too long                                    | JanKowalski1JanKowalski1                                        | NOK   |
	| login            | with special character                      | JanKowalski1JanKowalski1#                                       | NOK   |
	| password         | correctly                                   | Qwerty+8                                                        | OK    |
	| password         | with no data                                |                                                                 | NOK   |
	| password         | too short                                   | Qwert+5                                                         | NOK   |
	| password         | too long                                    | Qwertyuiopasdfghjkl+1                                           | NOK   |
	| password         | with no uppercase letter                    | qwerty+8                                                        | NOK   |
	| password         | with no digit                               | qwertyu+                                                        | NOK   |
	| password         | with no special character                   | qwertyu8                                                        | NOK   |
	| password confirm | correctly                                   | Qwerty+8                                                        | OK    |
	| password confirm | with wrong password                         | Qwerty+7                                                        | NOK   |
	| Github           | correctly                                   | https://www.github.com/jan-kowalski                             | OK    |
	| Github           | with no https                               | www.github.com/jan-kowalski                                     | NOK   |
	| Github           | with no www                                 | https://github.com/jan-kowalski                                 | NOK   |
	| Github           | with no github.com                          | https://www./jan-kowalski                                       | NOK   |
	| Github           | with no username                            | https://www.github.com/                                         | NOK   |
	| Github           | with too long username                      | https://www.github.com/jan-kowalskijan-kowalskijan-kowalskijank | NOK   |
	| Github           | with non-alphanumeric character in username | https://www.github.com/jankowalski@#%                           | NOK   |
	| Github           | with hyphen at start in username            | https://www.github.com/-jan-kowalski                            | NOK   |
	| Github           | with hyphen at end in username              | https://www.github.com/jan-kowalski-                            | NOK   |
	| consents         | correctly                                   | 2                                                               | OK    |
	| consents         | by leave required                           | 1                                                               | NOK   |

# Zephyr link
Scenario Outline:REGISTRATION_PAGE_4_IP2-261_registration_is_not_possible_after_filling_in_the_form_incorrectly
	When User completes form correctly
		| name | surname  | phone     | password | passwordConfirm | Github                              |
		| Jan  | Kowalski | 123456789 | Qwerty+8 | Qwerty+8        | https://www.github.com/jan-kowalski |
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
Scenario:REGISTRATION_PAGE_5_IP2-261_registration_is_not_possible_with_element_which_was_used_before
	When User signs up
		| name | surname  | phone     | password | passwordConfirm | Github                              |
		| Jan  | Kowalski | 123456789 | Qwerty+8 | Qwerty+8        | https://www.github.com/jan-kowalski |
	And User signs up again with the same "<element>"
		| name | surname  | phone     | password | passwordConfirm | Github                              |
		| Jan  | Kowalski | 123456789 | Qwerty+8 | Qwerty+8        | https://www.github.com/jan-kowalski |
	Then User is informed if "<element>" is "repeated"

	Examples:
	| element |
	| email   |
	| login   |