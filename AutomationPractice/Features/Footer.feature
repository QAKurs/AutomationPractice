Feature: Footer
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@Footer
Scenario Outline: User can open links under Information section
	When user clicks on '<information link>' option
	Then correct '<page>' is displayed
Examples: 
	| information link | page         |
	| Specials         | Price drop   |
	| New products     | New products |
	| Best sellers     | Best sellers |
	| Our stores       | Our store    |
	| Contact us       | Contact      |
	| Terms and conditions of use | Terms and conditions of use |
	| About us         | About us     |
	| Sitemap          | Sitemap      |