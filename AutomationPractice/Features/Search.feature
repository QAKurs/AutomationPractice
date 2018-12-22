Feature: Search
	In order to find products
	As a user
	I want to be able to search for a term

@Search
Scenario: User can search for a term
	Given user enters a 'dress' search term
	When user submits the search
	Then results for a 'dress' search term are displayed
