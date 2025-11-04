Feature: Login
    In order to access the secure area
    As a registered user
    I want to log in with valid credentials

Scenario: Successful login with valid credentials
    Given I navigate to the herokuapp login page
    When I enter username 'tomsmith' and password 'SuperSecretPassword!'
    Then I should see the secure area

Scenario: Failed login with invalid credentials
    Given I navigate to the herokuapp login page
    When I enter username 'wrongUser' and password 'wrongPass'
    Then I should not see the secure area

