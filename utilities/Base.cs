using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace TestProject_CSTAdmin.utilities
{
    public class Base
    {
        public ExtentReports extent;
        public ExtentTest test;

        [OneTimeSetUp]
        public void Setup()

        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            String reportPath = projectDirectory + "//index.html";
            var htmlReporter = new ExtentHtmlReporter(reportPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Environment", "DEV");
            extent.AddSystemInfo("QA Tester", "Ruthel Villaespin");
            extent.AddSystemInfo("CS", "PlayerInfo_LongField");
            extent.AddSystemInfo("CS", "PlayerInfo_SpecialChar_InvalidFormat");
            extent.AddSystemInfo("CS", "PlayerInfo_ValidData");
            extent.AddSystemInfo("CS", "SearchPlayer_LongField");
            extent.AddSystemInfo("CS", "SearchPlayer_SpecialChar_InvalidFormat");
            extent.AddSystemInfo("CS", "SearchPlayer_ValidData_AllFields");
            extent.AddSystemInfo("CS", "SearchPlayer_ValidData_EachField");
            extent.AddSystemInfo("CS", "SearchPlayer_ValidData_PartialData");


        }

        public required IWebDriver driver;

        [SetUp]
        public void StartBrowser()

        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            String browserName = ConfigurationManager.AppSettings["browser"];

            InitBrowser(browserName);
          
            driver.Url = "https://cstadmin.dev.circasports-tech.com/Player";
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);


        }

        public IWebDriver getDriver()

        {
            return driver;
        }

        public void InitBrowser(string browserName)

        {

            switch (browserName)
            {

                case "Firefox":

                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
                    break;



                case "Chrome":

                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver();
                    
                    //new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    //var chromeOptions = new ChromeOptions();
                    //chromeOptions.AddArgument("--incognito");
                    //driver = new ChromeDriver(chromeOptions);
                    
                    //driver.Navigate().Refresh();
                    //var chromeOptions = new ChromeOptions();
                    //driver = new ChromeDriver(chromeOptions);
                    //chromeOptions.AddArgument("--headless");
                    break;


                case "Edge":
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    driver = new EdgeDriver();
                    break;

            }


        }

        [TearDown]
        public void Close_Browser()
        {

            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = TestContext.CurrentContext.Result.StackTrace;



            DateTime time = DateTime.Now;
            String fileName = "Screenshot_" + time.ToString("h_mm_ss") + ".png";

            if (status == TestStatus.Failed)
            {

                test.Fail("Test failed", captureScreenShot(driver, fileName));
                test.Log(Status.Fail, "test failed with logtrace" + stackTrace);

            }
            else if (status == TestStatus.Passed)
            {

            }

            extent.Flush();


            driver.Quit();
            driver.Dispose();

        }

        public MediaEntityModelProvider captureScreenShot(IWebDriver driver, String screenShotName)

        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            var screenshot = ts.GetScreenshot().AsBase64EncodedString;

            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, screenShotName).Build();

        }



    }
}
