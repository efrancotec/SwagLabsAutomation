Feature: Login

Login web aplication

@tag1
Scenario: Login with correct credentials
	Given The user is on Login page
	When User enters the username
	And User enters the password
	And User clicks on Login button
	Then The user is redirected  to Home page

@ignore
Scenario Outline: Login with correct credentials Scenario Outline
	Given The user is on Login page with url "https://www.saucedemo.com/"
	When User enters the username "<username>"
	And User enters the password "secret_sauce"
	And User clicks on Login button so
	Then The user is redirected  to Home page so
	Examples: 
	| Test Case | username                |
	| TC01      | standard_user           |
	| TC02      | locked_out_user         |
	| TC 03     | problem_user            |
	| TC 04     | performance_glitch_user |
	| TC 05     | error_user              |
	| TC 06     | visual_user             |
