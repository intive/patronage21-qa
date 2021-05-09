Feature: UserRegistration

Task in QA board: https://tracker.intive.com/jira/browse/IP2-191
Task in Java board: https://tracker.intive.com/jira/browse/IP2-88

Background:
Given User is on the registration page

# link to Zephyr_1_test
Scenario Outline: REGISTRATION_PAGE_1_IP2-88_Correct_user_registration
When User enters name '<Imię>' 
And User enters surname '<Nazwisko>'
And User enters email address '<Adres email>'
And User enters phone number '<Numer telefonu>'
And User selects one, two or three technological groups '<Grupy Technologiczne>'
And User enters password '<Hasło>'
And User repeats password '<Powtórz hasło>'
And User selects consent as '<Zgoda>'
And User clicks "Załóż konto" button 
Then The creation of a new user was '<Result>'
And User is transferred to the next page

Examples:
|Imię |Nazwisko |Adres_email |Numer_telefonu |Grupy_Technologiczne  |Hasło |Powtórz_hasło |Zgoda  |Result     |
|Jan  |Kowalski |jankow@o2.pl|111222333      |Java Script, QA, Java |1234  |1234          |Marked |successful |
|Jan  |Kowalski |jankow@o2.pl|111222333      |Java Script, QA,      |1234  |1234          |Marked |successful |
|Jan  |Kowalski |jankow@o2.pl|111222333      |Java Script           |1234  |1234          |Marked |successful |


# link to Zephyr_2_test
Scenario: REGISTRATION_PAGE_2_IP2-88_User_registration_without_"Nazwisko"_field
Given User enters all data, but without "Nazwisko" field 
When User clicks "Załóż konto" button 
Then Empty field is displayed in red


# link to Zephyr_3_test
Scenario: REGISTRATION_PAGE_3_IP2-88_User_registration_without_"Adres email"_field
Given User enters all data, but without "Adres email" field
When User clicks "Załóż konto" button
Then Empty field is displayed in red


# link to Zephyr_4_test
Scenario: REGISTRATION_PAGE_4_IP2-88_User_registration_without_"Numer telefonu"_field
Given User enters all data, but without "Numer telefonu" field 
When User clicks "Załóż konto" button 
Then Empty field is displayed in red


# link to Zephyr_5_test
Scenario: REGISTRATION_PAGE_5_IP2-88_User_registration_ without_checking_fields:_"JavaScript,_Java,_QA,_Mobile(Android)"
Given User enters all data, but doesn't check "JavaScript, Java, QA, Mobile(Android)" fields
When User clicks "Załóż konto" button 
Then Empty fields are displayed in red


# link to Zephyr_6_test
Scenario: REGISTRATION_PAGE_6_IP2-88_User_registration_with_marking_of_all_technological_groups 
Given User enters all data and check all "JavaScript, Java, QA, Mobile(Android)" fields
When User clicks "Załóż konto" button 
Then Checked fields are displayed in red

# link to Zephyr_7_test
Scenario: REGISTRATION_PAGE_7_IP2-88_User_registration_without_"Hasło"_field
Given User enters all data, but without "Hasło" field 
When User clicks "Załóż konto" button 
Then Empty field is displayed in red


# link to Zephyr_8_test
Scenario: REGISTRATION_PAGE_8_IP2-88_User_registration_without_"Powtórz hasło"_field
Given User enters all data, but without "Powtórz hasło" field 
When User clicks "Załóż konto" button 
Then Empty field is displayed in red


# link to Zephyr_9_test
Scenario: REGISTRATION_PAGE_9_IP2-88_Registration_with_wrong_password_repeated
Given User enters all data, but password is repeated incorrectly in "Powtórz hasło" field 
When User clicks "Załóż konto" button 
Then "Powtórz hasło" field is displayed in red


# link to Zephyr_10_test
Scenario: REGISTRATION_PAGE_10_IP2-88_User_registration_without_checking_"Zgoda"_field
Given User enters all data, but doesn't check "Zgoda" field
When User clicks "Załóż konto" button 
Then Empty field is displayed in red


# link to Zephyr_11_test
Scenario: REGISTRATION_PAGE_11_IP2-88_User_registration_without_entering_data
Given User doesn't enter any data
When User clicks "Załóż konto" button 
Then All required fields are displayed in red