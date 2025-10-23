using Authentication.UITests.Configs;
using Authentication.UITests.Constants;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Text.Json;

namespace Authentication.UITests
{
    [TestFixture]
    public class SwaggerTests
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;
        private AppConfig _config;

        [SetUp]
        public void Setup()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless=new");

            _driver = new ChromeDriver(options);
            _config = AppConfig.Load(ConfigurationFiles.AppSettings);
            _wait = new WebDriverWait(
                _driver, 
                TimeSpan.FromSeconds(_config.TimeoutSeconds)
            );

            _driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown() => _driver.Dispose();

        [Test]
        public void Swagger_ShouldBeAccessible()
        {
            _driver.Navigate().GoToUrl(_config.BaseUrl);
        }

        [Test]
        public void Login_ShouldSucceed_WithValidCredentials()
        {
            _driver.Navigate().GoToUrl(_config.BaseUrl);

            _driver.FindElement(By.CssSelector("#operations-Auth-post_api_auth button")).Click();
            _wait.Until(d => d.FindElement(By.CssSelector(".try-out__btn"))).Click();

            var area = _driver.FindElement(By.CssSelector(".body-param__text"));
            area.Clear();
            area.SendKeys(JsonSerializer.Serialize(_config.Request));

            _driver.FindElement(By.CssSelector(".execute")).Click();

            var response = _wait.Until(d => d.FindElement(By.CssSelector(".highlight-code .microlight")));
            Assert.That(response.Text, Does.Contain("access"));
        }
    }
}