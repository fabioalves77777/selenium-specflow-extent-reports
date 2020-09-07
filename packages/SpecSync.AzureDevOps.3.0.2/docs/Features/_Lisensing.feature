Feature: Lisensing

Scenario: Prints expiration date
	Given there is a VSTS project
	And the synchronizer is configured to use an Standard license expires at 5/15/1978
	And there is a local workspace with a scenario
	When the local workspace is synchronized with push
	Then the log should contain "1978/05/15"

Scenario: Shows remaining days when less than 30 days remain
	Given there is a VSTS project
	And the synchronizer is configured to use an Standard license expires in 29 days
	And there is a local workspace with a scenario
	When the local workspace is synchronized with push
	Then the log should contain "Your license is expiring in 29 days."
	And the synchronization should not fail

Scenario: Can be used on the last day of expiration
	Given there is a VSTS project
	And the synchronizer is configured to use an Standard license expires today
	And there is a local workspace with a scenario
	When the local workspace is synchronized with push
	Then the log should contain "Your license is expiring in 0 days."
	And the synchronization should not fail

Scenario: Shows license expired message and does not allow to use SpecSync
	Given there is a VSTS project
	And the synchronizer is configured to use an Standard license expires 15 days ago
	And there is a local workspace with a scenario
	When the local workspace is synchronized with push
	Then the log should contain "Your license has expired."
	And the synchronization should finish with errors

Scenario: Shows license expired message but allows using the tool for 5 more days (grace period)
	Given there is a VSTS project
	And the synchronizer is configured to use an Standard license expires 5 days ago
	And there is a local workspace with a scenario
	When the local workspace is synchronized with push
	Then the log should contain "Your license has expired."
	And the synchronization should not fail

Scenario: Does not allow publishing test results of enterprise integrations
	Given there is a VSTS project with an empty test suite 'MySuite'
	And the synchronizer is configured to use an Standard license
	And the synchronizer is configured to add test cases to test suite 'MySuite'
	And there is a feature file that was already synchronized before
		"""
		Feature: Sample feature

		@tc:[id-of-test-case]
		Scenario: Sample scenario
			When I do something
		"""
	And there is a test result file with
		| name                              | className                | adapterTypeName                     | test result name | outcome |
		| Sample scenario in Sample feature | MyProject.Sample feature | executor://specrun/executorV3.0.216 | Sample scenario  | Passed  |
	When the test result is published to configuration "Windows 8"
	Then the log should contain "Your license type does not allow SpecFlow+ Runner (SpecRun) integration. "
	And the synchronization should finish with errors
