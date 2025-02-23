Feature: Test scenarios for Skills management in the profile page.
1. Adding Skills
2. Editing Skills
3. Deleting Skills

Scenario Outline: A.Verify user is able to add Skill in Skills tab in the profile page
	Given User logs into Mars Portal
	And navigates to Skills tab in Profile Page
	When user enters Skill "<Skill>" and Skill Level "<Level>"
	Then the Skill "<Skill>" should be added to Skills tab in Profile Page

Examples:
	| Skill         | Level              |
    | Python        | Intermediate       |
	| C++           | Beginner           |
	|               | Choose Skill Level |
	| Communication | Expert             |
	| SQL           | Intermediate       |


Scenario Outline: B.Verify user is able to edit Skill in Skills tab in the profile page
	Given User logs into Mars Portal
	And navigates to Skills tab in Profile Page
	When user edits Skill "<Skill>" and Skill Level "<Level>"
	Then the Skill "<Skill>" should be updated to Skills tab in Profile Page

Examples:
	| Skill       | Level              |
	| Python*?*   | Beginner           |
	|             | Choose Skill Level |
	| C++         | Beginner           |
	| Java        | Expert             |

Scenario Outline: C.Verify user is able to delete Skill in Skills tab in the profile page
	Given User logs into Mars Portal
	And navigates to Skills tab in Profile Page
	When user deletes Skill "<Skill>"
	Then the Skill "<Skill>"should be deleted from Skills tab in Profile Page

Examples:
	| Skill |
	| Java  |