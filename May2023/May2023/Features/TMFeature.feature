Feature: TMFeature

As a TurnUp portal admin
I wwould like to create, edit time and material records
So that I can manage employees' time and materials successfully

Scenario: Create time and material record with valid details
	Given I logged into turnup up portal successfully
	When I navigate to Time and Material page
	And I create a new time and material record
	Then The record should be created successfully


