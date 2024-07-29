Feature: Login

Login web aplication

@tag1
Scenario: Login with correct credentials
	Given The user is on Login page
	When User enters the username
	And User enters the password
	And User clicks on Login button
	Then The user is redirected  to Home page
