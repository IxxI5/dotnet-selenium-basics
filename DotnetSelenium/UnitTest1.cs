using DotnetSelenium.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace DotnetSelenium
{
    /* IMPORTANT NOTE for new .NET 8.0 or VS2022 Installations in an x64 PC
     * KEEP the dotnet folder under Program Files
     * ATTENTION! Delete the dotnet folder under Program Files (x86), otherwise in
     * TERMINAL, the dotnet commands will not be recognized 
     * RESTART VS2022
     * CREATE a new NUnit Cross platform project
     * SOLUTION EXPLORER: Double click on solution -> Dependencies are visible (Analyzers, Frameworks, Packages)
     * RIGHT CLICK: on Dependencies -> Manage NU Packages
     * SEARCH for and INSTALL: Selenium.WebDriver (> 107M Downloads)
     * CHECK: Dependencies -> Packages => Selenium.WebDriver (4.22.0 or later)
     * TEST EXPLORER: View -> Test Explorer
     * TEST EXPLORER: Select the icon with the chemical bottle to see the list of tests (IF NOT VISIBLE, read below this line)
     * CLICK ON: .sln file -> It makes available the List of Tests e.g. Test1, Test2..etc
    */

    /* Selenium .NET API Docs
     * URL: https://www.selenium.dev/selenium/docs/api/dotnet/
     * e.g. Class By => On the right you see the Properties and Methods for this Class
     */

    /* Selenium Open Source
     * Github: https://github.com/SeleniumHQ/selenium/tree/trunk/dotnet
     */

    /* SelectorsHub 
     * URL: https://chromewebstore.google.com/detail/selectorshub/ndgimibanhlabgdgjcpbbndiehljcpfh?hl=en
     * xPath plugin to auto generate, write and verify xpath & cssSelector. 
     * SelectorsHub is a xpath plugin and cssSelector plugin. 
     * It can be used as smart editor to write and verify xpath, 
     * cssSelector, Playwright selectors, jQuery and JS Path. 
     * SelectorsHub can also be used to auto generate the 
     * unique #xpath, css Selector and all possible selectors.
     */

    public class UnitTest1
    {
        [SetUp]
        public void Setup()
        {
        }

        /* Google Search Basic Test (https://www.google.com/)
         * 1. Create a new instance of Selenium Web Driver => Initial delay due to once downloading the driver 
         * 2. Navigate to the URL
         * 3. Maximize the browser window
         * 4. Find the button element (id="L2AGLb") having the Text "Accept Cookies" 
         * 5. Find the textarea element (name="q")
         * 6. Type in textarea element the word "Selenium"
         * 7. Press Enter key within the textarea element
         *    => Output: Google search displays the found results that match the word "Selenium"
         */
        [Test]
        public void Test1()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://www.google.com");
            driver.Manage().Window.Maximize();

            IWebElement webelement = driver.FindElement(By.Id("L2AGLb"));

            webelement.Click();

            IWebElement search = driver.FindElement(By.Name("q"));

            search.SendKeys("Selenium");
            search.SendKeys(Keys.Enter);
        }

        /* EA Website Basic Test (http://eaapp.somee.com/)
         * 1. Create a new instance of Selenium Web Driver
         * 2. Navigate to the URL
         * 3. Maximize the browser window
         * 4. Find the Login link 
         * 5. Click the Login link
         * 6. Find the UserName element (id="UserName")
         * 7. Find the Password element (id="Password")
         * 8. Fill out the UserName with "admin"
         * 9. Fill out the Password with "password"
         * 10. Press the submit button with text "Log in"
         */
        [Test]
        public void Test2()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://eaapp.somee.com/");
            driver.Manage().Window.Maximize();

            IWebElement loginLink = driver.FindElement(By.Id("loginLink"));
            
            /* Or IWebElement loginLink = driver.FindElement(By.LinkText("Login"));
             */

            loginLink.Click();

            IWebElement txtUserName = driver.FindElement(By.Name("UserName"));
            IWebElement txtPassword = driver.FindElement(By.Id("Password"));

            txtUserName.SendKeys("admin");
            txtPassword.SendKeys("password");

            /* Hint: Chrome Console | Search elements via CSS classes
             * $$(".btn")
             * [input.btn.btn-default]
             */

            IWebElement submit = driver.FindElement(By.ClassName("btn-default"));

            /* Or IWebElement submit = driver.FindElement(By.CssSelector(".btn"));
             */

            submit.Click();
        }

        /* EA Website Basic Test (Refactored) 
         */
        [Test]
        public void Test3()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://eaapp.somee.com/");
            driver.Manage().Window.Maximize();

            driver.FindElement(By.Id("loginLink")).Click();

            driver.FindElement(By.Name("UserName")).SendKeys("admin");
            driver.FindElement(By.Id("Password")).SendKeys("password");

            driver.FindElement(By.ClassName("btn-default")).Click();
        }

        /* EA Website Dropdown Element Test 
         * 1. Create a new instance of Selenium Web Driver
         * 2. Navigate to the URL
         * 3. Maximize the browser window
         * 4. Find and click the Login link 
         * 5. Find and fill out the UserName element (id="UserName")
         * 6. Find and fill out Password element (id="Password")
         * 7. Find and click the submit button with text "Log in"
         * 8. Find and click the Manage Users link
         * 9. Selenium.Support must be installed (through Dependencies)
         * 10. Find all Dropdown elements with id="RoleName"
         * 11. Select the third listed dropdown element under the Roles column
         * 12. Select the third option of the selected dropdown element
         * 13. Close the driver (browser) after 3 secs
         */
        [Test]
        public void Test4()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://eaapp.somee.com/");
            driver.Manage().Window.Maximize();

            driver.FindElement(By.Id("loginLink")).Click();

            driver.FindElement(By.Name("UserName")).SendKeys("admin");
            driver.FindElement(By.Id("Password")).SendKeys("password");
            driver.FindElement(By.ClassName("btn-default")).Click();

            driver.FindElement(By.LinkText("Manage Users")).Click();
            
            IList<IWebElement> dropDowns = driver.FindElements(By.Id("RoleName"));

            /* Or var dropDowns = driver.FindElements(By.Id("RoleName"));
             */

            /* Required: Selenium.Support Install (through Dependencies
             * Right click on Dependencies => Manage NuGet Packages
             * Search and install the Selenium.Support
             */

            if (dropDowns.Count > 0) 
            {
                IWebElement thirdDropdown = dropDowns[3];

                SelectElement selectElement = new SelectElement(thirdDropdown);
                selectElement.SelectByIndex(2);

                /* Or var options = selectElement.AllSelectedOptions
                 * by iterating with a foreach loop through all options
                 */

                Console.WriteLine("Third dropdown: third option selected.");
            }
            else
            {
                Console.WriteLine("No dropdown elements found.");
            }

            Thread.Sleep(3000);

            driver.Quit();
        }

        /* EA Website Basic Test using Custom Methods
         * 1. Create a public class named "SeleniumCustomMethods" in the same project
         * 2. Create public static void methods
         * 3. Pass the driver, locator (and other data) as parameters on the created static methods
         * 4. Usage e.g. SeleniumCustomMethods.Click(driver, By.Id("loginLink"))
         */
        [Test]
        public void Test5()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://eaapp.somee.com/");
            driver.Manage().Window.Maximize();

            SeleniumCustomMethods.Click(driver, By.Id("loginLink"));

            SeleniumCustomMethods.EnterText(driver, By.Id("UserName"), "admin");
            SeleniumCustomMethods.EnterText(driver, By.Id("Password"), "password");

            SeleniumCustomMethods.Click(driver, By.ClassName("btn-default"));
            SeleniumCustomMethods.Click(driver, By.LinkText("Manage Users"));

            SeleniumCustomMethods.SelectDropDown(driver, By.Id("RoleName"), 5, 3);
        }

        /* EA Website Test using the Page Object Model 
         * 1. Create the Folder Pages
         * 2. Create the class file LoginPage.cs
         * 3. In LoginPage create a field that holds the instance of the WebDriver
         * 4. In LoginPage create the parameterized constructor having as parameter the instance of the WebDriver
         * 5. Create properties holding the locators of interest e.g. public IWebElement LoginLink => driver.FindElement(By.Id("LoginLnk"));
         * 6. Create methods that utilize the availability of the locators within the LoginPage class
         */
        [Test]
        public void Test6()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://eaapp.somee.com/");
            driver.Manage().Window.Maximize();

            /* Instantiate the Page Object Model -> LoginPage */
            LoginPage loginPage = new LoginPage(driver);

            loginPage.ClickLogin();
            loginPage.Login("admin", "password");
        }

        /* EA Website Test using the Page Object Model and the SeleniumCustomMethods class
         * that use the IWebElement as parameter to Actions (methods)
         */
        [Test]
        public void Test7()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://eaapp.somee.com/");
            driver.Manage().Window.Maximize();

            /* Instantiate the Page Object Model -> LoginPage */
            LoginPage loginPage = new LoginPage(driver);

            loginPage.ClickLogin2();
            loginPage.Login2();
        }

        /* EA Website Test using the Page Object Model and the SeleniumExtensionMethods class
         * 1. Create a class file named "SeleniumExtensionMethods"
         * 2. Make the class public static class
         * 3. Create static methods that extends the functionality of a Selenium class
         * e.g. public static void EnterText(this IWebElement locator, string text)
         * Usage from within the Page Object Mode (LoginPage) e.g. TxtUserName.EnterText("admin");
         * Where the TxtUserName is a IWebElement locator
         */
        [Test]
        public void Test8()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://eaapp.somee.com/");
            driver.Manage().Window.Maximize();

            /* Instantiate the Page Object Model -> LoginPage */
            LoginPage loginPage = new LoginPage(driver);

            loginPage.ClickLogin3();
            loginPage.Login3();
        }
    }
}