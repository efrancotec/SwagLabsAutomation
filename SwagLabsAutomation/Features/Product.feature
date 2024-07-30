Feature: Product

A short summary of the feature

@product
Scenario: Add producto to cart
	Given User is in home product pege
	When The user clicks on product title "Sauce Labs Fleece Jacket"
	And The user clicks on Add to cart button
	Then The product is shown on cart
