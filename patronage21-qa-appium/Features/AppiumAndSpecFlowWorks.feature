Feature: AppiumAndSpecFlowWorks
	As a tester, I want to be able to run
	application so I can test it further.

Scenario: Run app
	Given I run app using Appium server
	When I wait for app to start
	Then App should run