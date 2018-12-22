Feature: PDP
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@Cart
Scenario: User can add product to cart
	Given user opens 'Dresses' section
	And opens first product from the list
	And increases quantity to 2
	When user clicks on add to cart button
	And user proceeds to checkout
	Then cart is opened and product is added to the cart
