Feature: ScheduleGroupSelection

Scenario: Full group selection page
	Given group selection page is opened
	When I take page screenshot
	Then Screenshots don't have visual difference
	
Scenario: Menu buttons
	Given group selection page is opened
	When I take screenshot of menu buttons
	Then Screenshots don't have visual difference
		
Scenario: Hide logo
	Given group selection page is opened
	When I take page screenshot
	Then Screenshots don't have visual difference ignoring logo
