using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject_CSTAdmin.pageObjects
{

    public class PlayerInfoPage
    {
        IWebDriver driver;

        public PlayerInfoPage(IWebDriver driver)
        {

            this.driver = driver;
        }


        public void thinkTime(Int16 seconds)
        {
            Thread.Sleep(seconds * 1000);
        }

        //public void implicitWait()
        //{
        //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        //}


        public void FillInput(String locator, string filltext)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id(locator)));
            IWebElement element = driver.FindElement(By.Id(locator));
            element.Clear();
            element.SendKeys(filltext);

        }


        public void ViewPlayerInfo()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20)); 
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//td[contains(@class,'whitespace-nowrap')][1]")));
            IWebElement search = driver.FindElement(By.XPath("//td[contains(@class,'whitespace-nowrap')][1]"));
            search.Click();
        }

        public void editButton()
        {
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20)); 
            //wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[normalize-space()='Edit'][1]"))); 
            IWebElement edit = driver.FindElement(By.XPath("//button[normalize-space()='Edit'][1]"));
            edit.Click();
        }



        public void UpdateInput(String locator, string filltext)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20)); 
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id(locator)));
            IWebElement element = driver.FindElement(By.Id(locator));
            element.Clear();
            element.SendKeys(filltext);
        }


        public void selectDropdown(String locator)
        {
            IWebElement dropdown = driver.FindElement(By.Id(locator));
            SelectElement dropdownItem = new SelectElement(dropdown);
            dropdownItem.SelectByIndex(2);
        }


        public void checkError(String locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IWebElement errorMessage = driver.FindElement(By.XPath("//div[@class='validation-message']"));
            String errorText = errorMessage.Text;
            Console.WriteLine(errorText); // Outputs the error message

        }
  

        public void clickButton(String locator)
        {
            IWebElement button = driver.FindElement(By.CssSelector("button[type='" + locator + "']"));
            button.Click();
        }


        public void warningError(String locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20)); 
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id(locator)));
            IWebElement errorMessage = driver.FindElement(By.XPath("//*[@id='" + locator + "']/following-sibling::div[@class='text-warning']"));
            String errorText = errorMessage.Text;
            Console.WriteLine(errorText); // Outputs the error message
        }

        public void validationError(String locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20)); 
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id(locator)));
            IWebElement errorMessage = driver.FindElement(By.XPath("//*[@id='" + locator + "']/following-sibling::div[@class='validation-message']"));
            String errorText = errorMessage.Text;
            Console.WriteLine(errorText); // Outputs the error message
        }


        public void address2(String locator, String filltext)
        {
            IWebElement streetAddress = driver.FindElement(By.XPath("(//input[@id='" + locator + "'])[2]"));
            streetAddress.Clear();
            streetAddress.SendKeys(filltext);
        }


        public void address1Dropdown(String locator)
        {
            IWebElement dropdown = driver.FindElement(By.XPath("(//select[@id='" + locator + "'])[1]"));
            SelectElement dropdownItem = new SelectElement(dropdown);
            dropdownItem.SelectByIndex(2);
        }


        public void address2Dropdown(String locator)
        {
            IWebElement dropdown = driver.FindElement(By.XPath("(//select[@id='" + locator + "'])[2]"));
            SelectElement dropdownItem = new SelectElement(dropdown);
            dropdownItem.SelectByIndex(2);
        }


        public void validationError_2(String locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20)); 
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id(locator)));
            IWebElement errorMessage = driver.FindElement(By.XPath("(//input[@id='" + locator + "'])[2]/following-sibling::div[@class='validation-message']"));
            String errorText = errorMessage.Text;
            Console.WriteLine(errorText); // Outputs the error message
        }


        public void dismissButton()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[normalize-space()='Dismiss'][1]")));
            IWebElement dismiss = driver.FindElement(By.XPath("//button[normalize-space()='Dismiss'][1]"));
            dismiss.Click();
        }


    }




}
