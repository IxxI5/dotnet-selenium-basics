using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetSelenium.Pages
{
    public class LoginPage
    {
        /* WebDriver Instance Field
         * Holds and makes available the instance of the WebDriver within the LoginPage class
         */
        private readonly IWebDriver driver;

        /* Parameterized Constructor 
         * The constructor (instance) of the class assigns the instance of the WebDriver to the driver field
         */
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        /* Properties 
         * -Locators-
         */

        /* public IWebElement LoginLink 
           { 
               get 
                { 
                    return driver.FindElement(By.Id("LoginLnk")); 
                } 
           }
        */

        public IWebElement LoginLink => driver.FindElement(By.Id("loginLink"));

        public IWebElement TxtUserName => driver.FindElement(By.Id("UserName"));

        public IWebElement TxtPassword => driver.FindElement(By.Id("Password"));

        public IWebElement BtnLogin => driver.FindElement(By.CssSelector(".btn"));

        public IWebElement LinkEmployeeDetails => driver.FindElement(By.LinkText("Employee Details"));

        public IWebElement LinkManageUsers => driver.FindElement(By.LinkText("Manage Users"));

        /* Methods 
         * -Actions-
         */

        /* ClickLogin() 
         * Clicks the Login link to open the Login page
         */
        public void ClickLogin()
        {
            LoginLink.Click();
        }

        /* Login(string username, string password)
         * Enters the user credentials and submits the form (Login form)
         */
        public void Login(string username, string password)
        {
            TxtUserName.SendKeys(username);
            TxtPassword.SendKeys(password);

            BtnLogin.Submit();
        }

        /* SeleniumCustomMethods based on IWebElement that utilizes 
         * the LoginPage locator properties as parameters to Actions (methods)
         */

        public void ClickLogin2()
        {
            SeleniumCustomMethods.Click(LoginLink);
        }

        public void Login2()
        {
            SeleniumCustomMethods.EnterText(TxtUserName, "admin");
            SeleniumCustomMethods.EnterText(TxtPassword, "password");

            SeleniumCustomMethods.Click(BtnLogin);
        }

        /* SeleniumExtensionMethods based on this IWebElement
         * 1. Create a class file named "SeleniumExtensionMethods"
         * 2. Make the class public static class
         * 3. Create static methods that extends the functionality of a Selenium class
         * e.g.
         */

        public void ClickLogin3()
        {
            LoginLink.Click();
        }

        public void Login3()
        {
            TxtUserName.EnterText("admin");
            TxtPassword.EnterText("password");

            BtnLogin.Submit();
        }

        /* Display Conditions | Important: DO NOT use Assertions within the Page Object Model
         * since it leads to an anti-pattern design (no separation of concerns)
         */

        /* Simple 
         * Display Condition 
         */
        public bool IsLoggedIn()
        {
            return LinkEmployeeDetails.Displayed;
        }

        /* Tuple 
         * Display Condition 
         */
        public (bool employeeDetails, bool manageUsers) IsLoggedIn2() 
        {
            return (LinkEmployeeDetails.Displayed, LinkManageUsers.Displayed);
        }
    }
}
