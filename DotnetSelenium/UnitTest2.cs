using DotnetSelenium.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DotnetSelenium
{
    public class UnitTest2
    {
        /* WebDriver Instance Field
         * Holds and makes available the instance of the WebDriver within the UnitTest2 class
         */
        private IWebDriver driver;

        /* Set the Initial Conditions for all subseqeunt Tests (Test1, Test2, etc):
         * 1. Instantiate the ChromeDriver
         * 2. Navigate to the targer URL: http://eaapp.somee.com/
         * 3. Maximize the driver (browser) window
         */
        [SetUp]
        public void SetUp()
        {
            this.driver = new ChromeDriver();
            this.driver.Navigate().GoToUrl("http://eaapp.somee.com/");
            this.driver.Manage().Window.Maximize();
        }

        /* EA Website Test using the Page Object Model
         * 1. Instantiate the LoginPage (Page Object Model)
         * 2. Click on Log in Link
         * 3. Login (Sign In) with the credentials "admin" and "password"
         */
        [Test]
        public void Test1()
        {
            /* Instantiate the Page Object Model -> LoginPage */
            LoginPage loginPage = new LoginPage(this.driver);

            loginPage.ClickLogin();
            loginPage.Login("admin", "password");
        }

        /* Dispose Resources on Each Test Run
         * e.g. On Test1 completion, the driver (Browser) will be disposed (and automatically closed)
         */
        [TearDown]
        public void TearDown()
        {
            this.driver.Dispose();
        }
    }
}
