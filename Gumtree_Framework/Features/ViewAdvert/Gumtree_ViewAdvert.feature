Feature: Gumtree_SearchAndView_Advert
	This feature verfies the search and view advertisement functionality of Gumtree application

Background: 
	Given I navigate to Gumtree application

Scenario: Verify if user is able to search and view the advertisement successfully
	When I search for the item using the below specfications
	| Item   | Area       | Range |
	| Toyota | Wollongong | 20km  |
	Then the number of products on displayed should be same as the label showing the count
	When I click the the below page numbers
	| page number |
	| 2           |
	| 3           |
	| 4           |
	And I open a random advert on the page
	And I click on images button on advert
	Then I should be able to view all the images