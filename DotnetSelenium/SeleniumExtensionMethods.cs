using OpenQA.Selenium;

namespace DotnetSelenium
{
    public static class SeleniumExtensionMethods
    {
        public static void Submit(this IWebElement locator)
        {
            locator.Click();
        }

        public static void EnterText(this IWebElement locator, string text)
        {
            locator.Clear();
            locator.SendKeys(text);
        }
    }
}
