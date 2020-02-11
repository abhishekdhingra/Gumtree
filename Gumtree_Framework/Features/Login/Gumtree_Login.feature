Feature: Gumtree_Login
	This feature is to verify the login functionality for Gumtree application

Background: 
	Given I navigate to Gumtree application

Scenario: Verify the login functionality for Gumtree
	When I enter the below username and password
	| Username          | Password     |
	| test@nwesmail.com | Password@123 |