using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject_CSTAdmin.pageObjects
{
    public class AccountDetailsPage
    {
        IWebDriver driver;

        public AccountDetailsPage(IWebDriver driver)
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


        //public void FillInput(String locator, string filltext)
        //{
        //    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        //    wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id(locator)));
        //    IWebElement element = driver.FindElement(By.Id(locator));
        //    element.Clear();
        //    element.SendKeys(filltext);
        //}


        //public void ViewPlayerInfo()
        //{
        //    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        //    wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//td[contains(@class,'whitespace-nowrap')][1]")));
        //    IWebElement search = driver.FindElement(By.XPath("//td[contains(@class,'whitespace-nowrap')][1]"));
        //    search.Click();
        //}


        public void accountDetails()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[normalize-space()='Account Details']")));
            IWebElement account = driver.FindElement(By.XPath("//span[normalize-space()='Account Details']"));
            account.Click();
        }


        public void assertAccountBalance()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("h3[class='text-base font-semibold leading-7 text-gray-900 sm:col-span-4 mt-5']")));
            IWebElement balance = driver.FindElement(By.CssSelector("h3[class='text-base font-semibold leading-7 text-gray-900 sm:col-span-4 mt-5']"));
            Boolean checkBalance = balance.Displayed;
            Assert.IsTrue(checkBalance);
        }


        public void editButton()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[normalize-space()='Edit'][1]")));
            IWebElement edit = driver.FindElement(By.XPath("//button[normalize-space()='Edit'][1]"));
            edit.Click();
        }


        public void accountStatus(String locator)
        {
            IWebElement dropdown = driver.FindElement(By.Id(locator));
            SelectElement dropdownItem = new SelectElement(dropdown);
            var selectionText = dropdownItem.SelectedOption.Text;
            if (selectionText == "Active")
            {
                dropdownItem.SelectByValue("AccountLocked");
            }
            else
            {
                dropdownItem.SelectByValue("Active");
            }
        }

        public void checkBox(String locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id(locator)));
            IWebElement element = driver.FindElement(By.Id(locator));
            Actions actions = new Actions(driver);
            actions.MoveToElement(element).Click().Perform();
        }


        public void selectResidency()
        {
            IWebElement dropdown = driver.FindElement(By.Id("residencyStatus"));
            SelectElement dropdownItem = new SelectElement(dropdown);


            var selectionText = dropdownItem.SelectedOption.Text;
            if (selectionText == "US Resident")
            {
                dropdownItem.SelectByValue("3");
            }
            else
            {
                dropdownItem.SelectByValue("2");
            }
        }


        public bool withholdingState(String locator)
        {
            try
            {
                IWebElement dropdown = driver.FindElement(By.Id(locator));
                SelectElement dropdownItem = new SelectElement(dropdown);
                var selectionText = dropdownItem.SelectedOption.Text;
                if (selectionText == "Nevada")
                {
                    dropdownItem.SelectByValue("1434");
                }
                else
                {
                    dropdownItem.SelectByValue("1458");
                }
            }
            catch (NoSuchElementException e)
            {
                return false;
            }

            return true;
        }


        public void wageringStatus(String locator)
        {
            IWebElement dropdown = driver.FindElement(By.XPath("//td[normalize-space()='" + locator + "']/following-sibling::td/select[@name='jur.JurisdictionWageringStatus']"));
            SelectElement dropdownItem = new SelectElement(dropdown);
            var selectionText = dropdownItem.SelectedOption.Text;
            if (selectionText == "Wagering Enabled")
            {
                dropdownItem.SelectByValue("WageringDisabled");
            }
            else
            {
                dropdownItem.SelectByValue("WageringEnabled");
            }
        }


        public void KYCStatus(String locator)
        {
            IWebElement dropdown = driver.FindElement(By.XPath("//td[normalize-space()='" + locator + "']/following-sibling::td/select[@name='jur.IsKycVerifiedAsString']"));
            SelectElement dropdownItem = new SelectElement(dropdown);
            var selectionText = dropdownItem.SelectedOption.Text;
            if (selectionText == "Verified")
            {
                dropdownItem.SelectByValue("False");
            }
            else
            {
                dropdownItem.SelectByValue("True");
            }
        }


        public bool fillReason(String locator, string filltext)
        {
            try
            {
                IWebElement element = driver.FindElement(By.XPath("//td[normalize-space()='" + locator + "']/following-sibling::td/input[@name='jur.StatusReason']"));

                element.Clear();
                element.SendKeys(filltext);
            }
            catch (NoSuchElementException e)
            {
                return false;
            }

            return true;
        }


        //public void clickDismissButton()
        //{
        //    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        //    wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[normalize-space()='Dismiss'][1]")));
        //    IWebElement dismissButton = driver.FindElement(By.XPath("//button[normalize-space()='Dismiss'][1]"));
        //    dismissButton.Click();
        //}



    }
}
