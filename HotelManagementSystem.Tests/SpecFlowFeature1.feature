Feature: Add hotel
	In order to simulate hotel management system
	As api consumer
	I want to be able to add hotel,get hotel details and book hotel

@AddHotel
Scenario Outline: User adds hotel in database by providing valid inputs
	Given User provided valid Id '<id>'  and '<name>'for hotel 
	And User has added required details for hotel
	When User calls AddHotel api
	Then Hotel with name '<name>' should be present in the response
Examples: 
| id | name   |
| 1  | hotel1 |
| 2  | hotel2 |
| 3  | hotel3 |

@GetHotelById
Scenario Outline: User finds hotel in database by providing valid inputs
    Given User provided valid Id '<id>'  and '<name>'for hotel 
	And User has added required details for hotel
    And User called AddHotel api
	When User calls GetHotelById api by Id '<id>'
	Then Hotel with given name '<name>' should be present in the response
Examples: 
| id | name   |
| 4  | hotel1 |
| 5  | hotel2 |
| 6  | hotel3 |

@GetAllHotels
Scenario Outline: User add multiple hotels and find all hotels in database
   Given User provided valid Id '<id>'  and '<name>'for hotel
   And User has added required details for hotel
   And User called AddHotel api
   And User provided valid Id '<id1>'  and '<name1>'for hotel
   And User has added required details for hotel
   And User called AddHotel api
   And User provided valid Id '<id2>'  and '<name2>'for hotel
   And User has added required details for hotel
   And User called AddHotel api
   When User calls GetAllHotels api
   Then Hotel with given names '<name>' and '<name1>' and '<name2>' should be present in the response

   Examples: 
| id | name   | id1 | name1  | id2 | name2  |
| 7  | hotel1 | 8   | hotel2 | 9   | hotel3 |
| 10 | hotel1 | 11  | hotel2 | 12  | hotel3 |
| 13 | hotel1 | 14  | hotel2 | 15  | hotel3 |




