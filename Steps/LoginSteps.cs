using TechTalk.SpecFlow;
using Microsoft.Playwright;
using System.Threading.Tasks;
using FluentAssertions;

namespace BDD_Demo.Steps
{
    [Binding]
    public class LoginSteps
    {
        private IBrowser? _browser;
        private IBrowserContext? _context;
        private IPage? _page;

        private string _username = string.Empty;
        private string _password = string.Empty;

        [Given(@"I navigate to the herokuapp login page")]
        public async Task GivenINavigateToTheHerokuappLoginPage()
        {
            var playwright = await Playwright.CreateAsync();
            _browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false // 可见浏览器
            });
            _context = await _browser.NewContextAsync();
            _page = await _context.NewPageAsync();
            await _page.GotoAsync("https://the-internet.herokuapp.com/login");
        }

        [When(@"I enter username '(.*)' and password '(.*)'")]
        public async Task WhenIEnterUsernameAndPassword(string username, string password)
        {
            _username = username;
            _password = password;

            await _page!.FillAsync("#username", username);
            await _page.FillAsync("#password", password);
            await _page.ClickAsync("button[type='submit']");
        }

        [Then(@"I should (.*) the secure area")]
        public async Task ThenIShouldSeeTheSecureArea(string result)
        {
            if (result.Contains("see"))
            {
                // 登录成功
                await _page!.WaitForURLAsync("**/secure");
                var successMessage = await _page.TextContentAsync(".flash.success");
                successMessage.Should().Contain("You logged into a secure area!");
            }
            else if (result.Contains("not"))
            {
                // 登录失败
                var errorMessage = await _page!.TextContentAsync(".flash.error");
                errorMessage.Should().Contain("Your username is invalid!");
            }

            await _browser!.CloseAsync();
        }
    }
}
