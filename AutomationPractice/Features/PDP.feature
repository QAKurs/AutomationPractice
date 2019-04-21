Feature: PDP
	In order to buy products
	As a user
	I want to be able to interacte with product details

@Cart
Scenario: User can add product to cart
	Given user opens 'Dresses' section
	And opens first product from the list
	And increases quantity to 2
	When user clicks on add to cart button
	And user proceeds to checkout
	Then cart is opened and product is added to the cart

#Scenario: User can search for a product and add it to the cart
#	Given user enters a 'dress' search term
#	And user submits the search
#	And opens first product from the list
#	When user clicks on add to cart button
#	And user proceeds to checkout
#	Then cart is opened