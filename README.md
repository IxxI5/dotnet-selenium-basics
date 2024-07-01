# .NET Selenium Basics

Author: IxxI5

### Description

Selenium with C#.NET for Beginners. This is the resulting (slightly modified by IxxI5) code from Karthik KK's Udemy course. 

**1: Troubleshooting Hints after Installing .NET 8.0 or VS2022 Community Edition in a x64 Machine**
```
- KEEP the dotnet folder under Program Files
- ATTENTION! Delete the dotnet folder under Program Files (x86), otherwise in
- TERMINAL, the dotnet commands will not be recognized 
- RESTART VS2022

Note: As long as VS2022 and.NET are available without issues, ignore this step.
```

**2: Installing Selenium on a New NUnit Project**
```
- CREATE a new NUnit Cross platform project
- SOLUTION EXPLORER: Doublick click on solution -> Dependencies are visible (Analyzers, Frameworks, 
  Packages)
- RIGHT CLICK: on Dependencies -> Manage NU Packages
- SEARCH for and INSTALL: Selenium.WebDriver (> 107M Downloads)
- CHECK: Dependencies -> Packages -> Selenium.WebDriver (4.22.0 or later)
- TEST EXPLORER: View -> Test Explorer
- TEST EXPLORER: Select the icon with the chemical bottle to see the list of tests (IF NOT VISIBLE, 
  read below this line)
- CLICK ON: .sln file -> List of Tests becomes available e.g. Test1, Test2..etc

Note: This step applies not to the current project but to creating a new one from scratch.
```

**3: Google Search Basic Test with NUnit**
```
UnitTest1.Test1(): Google Search Basic Test (https://www.google.com/). Searching Test.

--- Keywords ---
IWebDriver, ChromeDriver, Navigate, GoToUrl, Manage, Maximize, FindElement, By.Id, By.Name, 
SendKeys  
```

**4: EA Website Basic Test with NUnit**
```
UnitTest1.Test2(): EA Website Basic Test (http://eaapp.somee.com/). Sign In Test.

--- Keywords ---
IWebDriver, ChromeDriver, Navigate, GoToUrl, Manage, Maximize, FindElement, By.Id, By.Name, 
SendKeys  
```

**5: EA Website Basic Test (Refactored)**
```
UnitTest1.Test3(): EA Website Basic Test (http://eaapp.somee.com/). 

--- Keywords ---
IWebDriver, ChromeDriver, Navigate, GoToUrl, Manage, Maximize, FindElement, By.Id, By.Name, 
SendKeys  
```

**6: EA Website Dropdown Element Test**
```
UnitTest1.Test4(): EA Website Basic Test (http://eaapp.somee.com/). Dropdown Element Test.

--- Prerequisites ---
Selenium.Support library should be preinstalled -> Dependecies -> Manage NuGet Packages

--- Keywords ---
IWebDriver, ChromeDriver, Navigate, GoToUrl, Manage, Maximize, FindElement, By.Id, By.Name, 
By.ClassName, SendKeys, Click, LinkText, FindElements, IList<IWebElement>, SelectElement, 
SelectByIndex
```

**7: EA Website Basic Test using Custom Methods**
```
UnitTest1.Test5(): EA Website Basic Test (http://eaapp.somee.com/). Creating/Invoking Custom 
Methods.

--- Prerequisites ---
A separate public class e.g. SeleniumCustomMethods, having public static methods e.g. Click() 
should be available.

Usage e.g. SeleniumCustomMethods.Click(driver, By.Id("loginLink"))

--- Keywords ---
SeleniumCustomMethods.Click, SeleniumCustomMethods.EnterText, SeleniumCustomMethods.SelectDropDown
```

**8: EA Website Test using the Page Object Model**
```
UnitTest1.Test6(): EA Website Test using the Page Object Model (LoginPage.cs).

--- Prerequisites ---
Page Object Model, also known as POM, is a design pattern in Selenium that creates an object 
repository for storing all web elements. It helps reduce code duplication and improves test case 
maintenance. In Page Object Model, consider each web page of an application as a class file e.g. 
LoginPage.

--- Keywords ---
IWebDriver, IWebElement, FindElement
```

**9: EA Website Test using the Page Object Model and the SeleniumCustomMethods class**
```
UnitTest1.Test7(): EA Website Test using the Page Object Model (LoginPage.cs).

--- Prerequisites ---
Page Object Model, also known as POM, is a design pattern in Selenium that creates an object 
repository for storing all web elements. It helps reduce code duplication and improves test case 
maintenance. In Page Object Model, consider each web page of an application as a class file e.g. 
LoginPage.

--- Keywords ---
IWebDriver, IWebElement, FindElement, SeleniumCustomMethods
```

**10: EA Website Test using the Page Object Model and the SeleniumExtensionMethods class**
```
UnitTest1.Test8(): EA Website Test using the Page Object Model (LoginPage.cs).

--- Prerequisites ---
Page Object Model, also known as POM, is a design pattern in Selenium that creates an object 
repository for storing all web elements. It helps reduce code duplication and improves test case 
maintenance. In Page Object Model, consider each web page of an application as a class file e.g. 
LoginPage.

A separate public class e.g. SeleniumExtensionMethods, having public static methods extending the 
Selenium classe.g. Submit(), should be available.

--- Keywords ---
IWebDriver, IWebElement, FindElement, SeleniumExtensionMethods
```

**11: EA Website Test using the Page Object Model and the SetUp Method**
```
UnitTest2.Test1(): EA Website Test using the Page Object Model and the SetUp Method.

--- Prerequisites ---
The SetUp method holds the initialization of the test as the WebDriver along with initial actions 
that are common in all Tests if the same UnitTest2.cs.
```

**12: EA Website Test using the Page Object Model, the TextFixture and TestCase Attributes**
```
UnitTest3.Test1(), UnitTest3.Test2():  EA Website Test using the Page Object Model, the TextFixture 
and TestCase Attributes.

--- Keywords ---
TestFixture, Author, Category, TestCase
```

**13:  Launching Selenium C# Tests using PowerShell Commands**
```
To run all tests:
dotnet test 

To run Test5 of UnitTest1.cs only:
dotnet test --filter "FullyQualifiedName~DotnetSelenium.UnitTest1.Test5" 

To run all tests in UnitTest3:
dotnet test --filter "FullyQualifiedName~DotnetSelenium.UnitTest3" 

To run all tests of the project having category "smoke":
dotnet test --filter "Category=smoke" 

To run all tests of the UnitTest3 having category "smoke":
dotnet test --filter "FullyQualifiedName~DotnetSelenium.UnitTest3&Category=smoke"
```

**14: EA Website Data Driven Test using the TestCaseSource Attribute and the IEnumerable Login as Data Source**
```
UnitTest4.Test1(): EA Website Data Driven Test using the TestCaseSource Attribute and the 
IEnumerable<LoginModel> Login as data source.

--- Keywords ---
IEnumerable
```

**15: EA Website Data Driven Test using the TestCaseSource Attribute and a JSON file as Data Source**
```
UnitTest4.Test2(): EA Website Data Driven Test using the TestCaseSource Attribute and a JSON file 
as Data Source.
```

**16: EA Website Data Driven Test using the Arrange/Act/Assert Principle | Simple, Tuple and Fluent Assertions**
```
UnitTest4.Test3(), UnitTest4.Test5(), UnitTest4.Test6(): EA Website Data Driven Test using the 
Arrange/Act/Assert Principle | Simple, Tuple and Fluent Assertions.

--- Keywords ---
Assert.That, Should().BeTrue()
```
