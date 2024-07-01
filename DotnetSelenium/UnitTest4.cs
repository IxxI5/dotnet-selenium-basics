using DotnetSelenium.Pages;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using DotnetSelenium.Models;
using System.Text.Json;
using FluentAssertions;

namespace DotnetSelenium
{ 
    public class UnitTest4
    {
        /* WebDriver Instance Field
         * Holds and makes available the instance of the WebDriver within the UnitTest3 class
         */
        private IWebDriver driver;

        /* LoginPage Instance Field
         * Holds and makes available the instance of the LoginPage within the UnitTest3 class
         */
        private LoginPage loginPage;

        /* Set the Initial Conditions for all subseqeunt Tests (Test1, Test2, etc):
         * 1. Instantiate the ChromeDriver
         * 2. Navigate to the targer URL: http://eaapp.somee.com/
         * 3. Maximize the driver (browser) window
         * 4. Instantiate the Page Object Model -> LoginPage
         */
        [SetUp]
        public void SetUp()
        {
            /* Arrange */

            this.driver = new ChromeDriver();
            this.driver.Navigate().GoToUrl("http://eaapp.somee.com/");
            this.driver.Manage().Window.Maximize();

            loginPage = new LoginPage(this.driver);
        }

        /* EA Website Data Driven Test using the Page Object Model and TestCaseSource
         * 1. Create the LoginModel
         * 2. Create the IEnumerable<LoginModel> Login that is passed as the data source in Test1.
         *    In other words, the data are provided through the Enumerable function to the Test1
         * 3. In Test1, it is required to pass the LoginModel as parameter, otherwise the TestCaseSource shows an error
         * 4. In TestCaseSource use nameof if the IEnumerable is under the same class, otherwise use typeof -> requires a new class file
         */
        [Test]
        [Category("ddt")]
        [TestCaseSource(nameof(Login))]
        public void Test1(LoginModel loginModel)
        {
            /* Act */

            loginPage.ClickLogin();
            loginPage.Login(loginModel.UserName, loginModel.Password);
        }

        /* EA Website Data Driven Test using the Page Object Model and a JSON file as data source
         * 1. Create the LoginModel (already available)
         * 2. Right click on DotnetSelenium Project -> Add New folder named "Data"
         * 3. Create the login.json in the created Data folder
         * 4. Populate the login.json with an array of serialized (key/value pairs) LoginModel objects 
         * 5. In login.json properties, set Copy to Output Directory -> Copy always
         * 6. Create the IEnumerable<LoginModel> LoginJsonDataSource that is passed as the deserialized data source (JSON file) in Test2
         *    In other words, the data (key/value pairs of the JSON file) are transformed to an object (LoginModel) through the Enumerable function to the Test2
         * 7. In Test2, it is required to pass the LoginModel as parameter, otherwise the TestCaseSource shows an error
         * 8. In TestCaseSource use nameof if the IEnumerable is under the same class, otherwise use typeof -> requires a new class file
         */
        [Test]
        [Category("ddt")]
        [TestCaseSource(nameof(LoginJsonDataSource))]
        public void Test2(LoginModel loginModel)
        {
            /* Act */

            loginPage.ClickLogin();
            loginPage.Login(loginModel.UserName, loginModel.Password);
        }

        /* EA Website Data Driven Test using the Page Object Model and a JSON file as data source
         * Simple Assertion: Assert.That
         */
        [Test]
        [Category("ddt")]
        [TestCaseSource(nameof(LoginJsonDataSource))]
        public void Test3(LoginModel loginModel)
        {
            /* Act */

            loginPage.ClickLogin();
            loginPage.Login(loginModel.UserName, loginModel.Password);

            /* Assert */

            Assert.That(loginPage.IsLoggedIn(), Is.True);
        }

        /* EA Website Data Driven Test using the Page Object Model and a JSON file as data source
         * Tuple Assertion: Assert.That
         */
        [Test]
        [Category("ddt")]
        [TestCaseSource(nameof(LoginJsonDataSource))]
        public void Test4(LoginModel loginModel)
        {
            /* Act */

            loginPage.ClickLogin();
            loginPage.Login(loginModel.UserName, loginModel.Password);

            /* Assert */

            Assert.That(loginPage.IsLoggedIn2().employeeDetails && loginPage.IsLoggedIn2().manageUsers, Is.True);
        }

        /* EA Website Data Driven Test using the Page Object Model and a JSON file as data source
         * Website: https://fluentassertions.com/introduction
         * 1. Right click on Dependencies -> Manage NuGet package
         * 2. Search for "FluentAssertions" and Install it
         * Fluent Simple Assertion: loginPage.IsLoggedIn().Should().BeTrue();
         */
        [Test]
        [Category("ddt")]
        [TestCaseSource(nameof(LoginJsonDataSource))]
        public void Test5(LoginModel loginModel)
        {
            /* Act */

            loginPage.ClickLogin();
            loginPage.Login(loginModel.UserName, loginModel.Password);

            /* Assert */

            loginPage.IsLoggedIn().Should().BeTrue();
        }

        /* EA Website Data Driven Test using the Page Object Model and a JSON file as data source
         * Website: https://fluentassertions.com/introduction
         * IF FluentAssertions ARE NOT Installed through NuGet package then:
         * 1. Right click on Dependencies -> Manage NuGet package
         * 2. Search for "FluentAssertions" and Install it
         * Fluent Multiple Assertions:
         * loginPage.IsLoggedIn2().employeeDetails.Should().BeTrue();
         * loginPage.IsLoggedIn2().manageUsers.Should().BeTrue();
         */
        [Test]
        [Category("ddt")]
        [TestCaseSource(nameof(LoginJsonDataSource))]
        public void Test6(LoginModel loginModel)
        {
            /* Act */

            loginPage.ClickLogin();
            loginPage.Login(loginModel.UserName, loginModel.Password);

            /* Assert */

            loginPage.IsLoggedIn2().employeeDetails.Should().BeTrue();
            loginPage.IsLoggedIn2().manageUsers.Should().BeTrue();
        }


        /* Login Enumerable Data Source 
         * It reads the key/value pairs from the Login() source and provides them as an object to Test1 through the LoginModel
         */
        public static IEnumerable<LoginModel> Login()
        {
            yield return new LoginModel()
            {
                UserName = "admin",
                Password = "password"
            };

            yield return new LoginModel()
            {
                UserName = "admin1",
                Password = "password"
            };

            yield return new LoginModel()
            {
                UserName = "admin2",
                Password = "password"
            };
        }

        /* LoginJsonDataSource Enumerable Data Source 
         * It reads the key/value pairs from the JSON file source and provides them as a List of objects to Test2 through the LoginModel
         */
        public static IEnumerable<LoginModel> LoginJsonDataSource()
        {
            string relativePath = Path.Combine("data", "login.json");
            string jsonFileFullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);

            var jsonString = File.ReadAllText(jsonFileFullPath);

            /* Following code applies for a List of objects (List of LoginModel) parsed from the JSON file */
            var loginModel = JsonSerializer.Deserialize<List<LoginModel>>(jsonString);

            foreach (var loginData in loginModel)
            {
                yield return loginData;
            }

            /* Following code applies just for a single object (ListModel) parsed from the JSON file
            var loginModel = JsonSerializer.Deserialize<LoginModel>(jsonString);

            yield return loginModel;
            */
        }

        /* Dispose Resources on Each Test Run e.g. Test1, Test2, etc.
         * 1. Wait 1000 msec
         * 2. Dispose the WebDriver (driver)
         * e.g. On Test1 completion, the driver (Browser) will be disposed (and automatically closed)
         */
        [TearDown]
        public void TearDown()
        {
            Thread.Sleep(1000);

            this.driver.Dispose();
        }
    }
}
