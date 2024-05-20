using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject_CSTAdmin.pageObjects
{
    public class SearchPlayerPage
    {
        IWebDriver driver;
       
        public SearchPlayerPage(IWebDriver driver)
        {
            this.driver = driver;
  

        }


        public void thinkTime(Int16 seconds)
        {
            Thread.Sleep(seconds * 1000);
        }


        public void FillInput(String locator, string filltext)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id(locator)));
            IWebElement element = driver.FindElement(By.Id(locator));
            //element.Clear();
            element.SendKeys(filltext);
        }


        public void checkError(String locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));      
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id(locator)));
            IWebElement errorMessage = driver.FindElement(By.XPath("//*[@id='" + locator + "']/following-sibling::div[@class='validation-message']"));
            String errorText = errorMessage.Text;
            Console.WriteLine(errorText); // Outputs the error message

        }


        public void emptyfieldError()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20)); 
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[text()='At least one field must contain search criteria.']")));
            IWebElement errorMessage = driver.FindElement(By.XPath("//div[text()='At least one field must contain search criteria.']"));
            String errorText = errorMessage.Text;
            Console.WriteLine(errorText); // Outputs the error message
        }


        public void clickButton(String locator)
        {
            IWebElement button = driver.FindElement(By.CssSelector("button[type='" + locator + "']"));
            button.Click();
        }


        public void clearButton()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[normalize-space()='Clear']")));
            IWebElement clear = driver.FindElement(By.XPath("//button[normalize-space()='Clear']"));
            clear.Click();
        }


        public void AssertSearchResult()
        {
            IWebElement search = driver.FindElement(By.XPath("//td[contains(@class,'whitespace-nowrap')][1]"));
            Boolean searchResult = search.Displayed;
            Assert.IsTrue(searchResult);
        }


        //public void implicitWait()
        //{
        //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        //}     


    }
}
