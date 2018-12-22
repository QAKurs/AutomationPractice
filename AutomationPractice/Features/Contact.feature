Feature: Contact
	In order to contact customer service
	As a end user
	I want to be able to use contact us form

@Contact
Scenario: User can contact customer service
	Given user opens contact us page
	And fills in all required fields with 'Webmaster' heading and 'QA Test' message
	When user submits the form
	Then message 'Your message has been successfully sent to our team.' is presented to the user
