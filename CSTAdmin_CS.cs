using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using System.Threading;
using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Timers;
using NUnit.Framework.Interfaces;
//using ScreenRecorderLib;
//using MediaToolkit.Model;
using TestProject_CSTAdmin.utilities;
using TestProject_CSTAdmin.pageObjects;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Gherkin.Model;
using Microsoft.Extensions.Logging.Console.Internal;

namespace TestProject_CSTAdmin
{
    internal class CSTAdmin_CS : Base
    {


        [Test]
        public void SearchPlayer_LongField()
        {
            SearchPlayerPage clear_button = new SearchPlayerPage(getDriver());
            clear_button.clearButton(); 
            
            
            SearchPlayerPage waitTime = new SearchPlayerPage(getDriver());
            waitTime.thinkTime(2); 
           
           
            // Long fields
            // Find and fill the input fields
            SearchPlayerPage fill_input = new SearchPlayerPage(getDriver());
           
            fill_input.FillInput("account", "123456789012345678901");
            fill_input.FillInput("username", "superduperverylongusername");
            fill_input.FillInput("last4ssn", "12345");
            fill_input.FillInput("firstname", "Loooooo0ongfirstnamelimit1");
            fill_input.FillInput("lastname", "Loooooo0onglasttnamelimit1");
            fill_input.FillInput("email", "Test-CSTQAAAAAAAAAAAAA.com");
          

            SearchPlayerPage click_button = new SearchPlayerPage(getDriver());
            click_button.clickButton("submit");

            SearchPlayerPage check_error = new SearchPlayerPage(getDriver());
            check_error.checkError("account");
            check_error.checkError("username");
            check_error.checkError("last4ssn");
            check_error.checkError("firstname");
            check_error.checkError("lastname");
            check_error.checkError("email");

            Console.WriteLine("TEST PASSED: PLAYER SEARCH - LONG FIELD");
        }



        [Test]
        public void SearchPlayer_SpecialChar_InvalidFormat()
        {
            SearchPlayerPage waitTime = new SearchPlayerPage(getDriver());
            waitTime.thinkTime(1); 
            
            SearchPlayerPage clear_button = new SearchPlayerPage(getDriver());
            clear_button.clearButton(); 
            
            //SearchPlayerPage waitTime = new SearchPlayerPage(getDriver());
            waitTime.thinkTime(1);

            //Special characters
            //Find and fill the input fields
            SearchPlayerPage fill_input = new SearchPlayerPage(getDriver());
            fill_input.FillInput("account", "12345-6789012345");
            fill_input.FillInput("username", "superdupe@ongusername");
            fill_input.FillInput("last4ssn", "123A");
            fill_input.FillInput("firstname", "firstn@me");
            fill_input.FillInput("lastname", "La$tname");
            fill_input.FillInput("email", "BG36cstqacom");

            SearchPlayerPage click_button = new SearchPlayerPage(getDriver());
            click_button.clickButton("submit");

            SearchPlayerPage check_error = new SearchPlayerPage(getDriver());
            check_error.checkError("account");
            check_error.checkError("username");
            check_error.checkError("last4ssn");
            check_error.checkError("firstname");
            check_error.checkError("lastname");
            check_error.checkError("email");


            Console.WriteLine("TEST PASSED: PLAYER SEARCH - SPECIAL CHAR / INVALID FORMAT");
        }


        [Test]

        public void SearchPlayer_NotInSystem()
        {
            SearchPlayerPage clear_button = new SearchPlayerPage(getDriver());
            clear_button.clearButton(); 
            
            SearchPlayerPage waitTime = new SearchPlayerPage(getDriver());
            waitTime.thinkTime(1);

            //NOT in the system
            //Find and fill ACCOUNT field
            SearchPlayerPage fill_input = new SearchPlayerPage(getDriver());
            fill_input.FillInput("username", "333333333");

            SearchPlayerPage click_button = new SearchPlayerPage(getDriver());
            click_button.clickButton("submit");

            //checkError("account");
            //SearchPlayerPage check_error = new SearchPlayerPage(getDriver());
            //check_error.checkError("account");


            clear_button.clearButton();
            waitTime.thinkTime(1);
            //NOT in the system
            //Find and fill USERNAME field
            fill_input.FillInput("username", "ABC123");
            click_button.clickButton("submit");

            //check_error.checkError("username");



            clear_button.clearButton();
            waitTime.thinkTime(1);
            //NOT in the system
            //Find and fill FIRST NAME field
            fill_input.FillInput("firstname", "Samplename");
            click_button.clickButton("submit");

            //check_error.checkError("firstname");



            clear_button.clearButton();
            waitTime.thinkTime(1);
            //NOT in the system
            //Find and fill LAST NAME field
            fill_input.FillInput("lastname", "Samplename");
            click_button.clickButton("submit");

            //check_error.checkError("lastname");



            clear_button.clearButton();
            waitTime.thinkTime(1);
            //NOT in the system
            //Find and fill EMAIL field
            fill_input.FillInput("email", "abc@cstqa.com");
            click_button.clickButton("submit");

            //check_error.checkError("email");


            Console.WriteLine("TEST PASSED: SEARCH PLAYER - NOT IN SYSTEM");
        }




        [Test]
        public void SearchPlayer_EmptyField()
        {
            SearchPlayerPage waitTime = new SearchPlayerPage(getDriver());
            waitTime.thinkTime(1);

            SearchPlayerPage clear_button = new SearchPlayerPage(getDriver());
            clear_button.clearButton();

            waitTime.thinkTime(1);
            SearchPlayerPage click_button = new SearchPlayerPage(getDriver());
            click_button.clickButton("submit");

            //waitTime.thinkTime(2);
            //DO NOT ENTER ANY DATA
            SearchPlayerPage check_error = new SearchPlayerPage(getDriver());
            check_error.emptyfieldError();

            Console.WriteLine("TEST PASSED: PLAYER SEARCH - EMPTPY FIELDS");
        }



        [Test]
        public void SearchPlayer_ValidData_AllFields()
        {
            SearchPlayerPage waitTime = new SearchPlayerPage(getDriver());
            waitTime.thinkTime(2); 
            
            
            SearchPlayerPage clear_button = new SearchPlayerPage(getDriver());
            clear_button.clearButton(); 
            
            
            //Valid data
            //Find and fill ALL the input fields
            SearchPlayerPage fill_input = new SearchPlayerPage(getDriver());
            fill_input.FillInput("account", "4975368575");
            fill_input.FillInput("username", "amy0828");
            fill_input.FillInput("firstname", "Amie");
            fill_input.FillInput("lastname", "Villa");
            fill_input.FillInput("email", "amie@cstqa.com");

            SearchPlayerPage click_button = new SearchPlayerPage(getDriver());
            click_button.clickButton("submit");

            SearchPlayerPage assertResult = new SearchPlayerPage(getDriver());
            assertResult.AssertSearchResult();

            Console.WriteLine("TEST PASSED: PLAYER SEARCH - VALID DATA_ALL FIELDS");
        }



        [Test]

        public void SearchPlayer_ValidData_EachField()
         {
            SearchPlayerPage waitTime = new SearchPlayerPage(getDriver());
            waitTime.thinkTime(2); 
            
            SearchPlayerPage clear_button = new SearchPlayerPage(getDriver());
            clear_button.clearButton();

            //Valid data
            //Find and fill USERNAME field
            waitTime.thinkTime(2);
            SearchPlayerPage fill_input = new SearchPlayerPage(getDriver());
            fill_input.FillInput("username", "joy0825");

            SearchPlayerPage click_button = new SearchPlayerPage(getDriver());
            click_button.clickButton("submit");

            SearchPlayerPage assertResult = new SearchPlayerPage(getDriver());
            assertResult.AssertSearchResult();

            
            clear_button.clearButton();
            waitTime.thinkTime(2);
            //Valid data
            //Find and fill FIRST NAME field
            fill_input.FillInput("firstname", "Amie");
            click_button.clickButton("submit");
            assertResult.AssertSearchResult();


            clear_button.clearButton();
            waitTime.thinkTime(2);
            //Valid data
            //Find and fill LAST NAME field
            fill_input.FillInput("lastname", "Villa");
            click_button.clickButton("submit");
            assertResult.AssertSearchResult();


            clear_button.clearButton();
            waitTime.thinkTime(2);
            //Valid data
            //Find and fill EMAIL field
            fill_input.FillInput("email", "amie@cstqa.com");
            click_button.clickButton("submit");
            assertResult.AssertSearchResult();

            Console.WriteLine("TEST PASSED: SEARCH PLAYER - VALID DATA_EACH FIELD");
        }




        [Test]
        public void SearchPlayer_ValidData_PartialData()
        {
            SearchPlayerPage waitTime = new SearchPlayerPage(getDriver());
            waitTime.thinkTime(2); 
            
            SearchPlayerPage clear_button = new SearchPlayerPage(getDriver());
            clear_button.clearButton();


            //Valid data
            //Find and fill PARTIAL DATA the input fields
            waitTime.thinkTime(2);
            SearchPlayerPage fill_input = new SearchPlayerPage(getDriver());
            fill_input.FillInput("username", "ruthy");

            SearchPlayerPage click_button = new SearchPlayerPage(getDriver());
            click_button.clickButton("submit");

            SearchPlayerPage assertResult = new SearchPlayerPage(getDriver()); 
            assertResult.AssertSearchResult();

            clear_button.clearButton();
            waitTime.thinkTime(2);
            //Valid data
            //Find and fill FIRST NAME field
            fill_input.FillInput("firstname", "jim");
            click_button.clickButton("submit");
            assertResult.AssertSearchResult();


            clear_button.clearButton();
            waitTime.thinkTime(2);
            //Valid data
            //Find and fill LAST NAME field
            fill_input.FillInput("lastname", "last");
            click_button.clickButton("submit");
            assertResult.AssertSearchResult();

            Console.WriteLine("TEST PASSED: PLAYER SEARCH - VALID DATA_PARTIAL DATA");
        }



        [Test]

        public void PlayerInfo_LongField()
        {
            PlayerInfoPage waitTime = new PlayerInfoPage(getDriver());
            waitTime.thinkTime(2); 
            
            SearchPlayerPage clear_button = new SearchPlayerPage(getDriver());
            clear_button.clearButton();


            //Valid data
            //Find player and fill ALL/ANY the input fields
            waitTime.thinkTime(2);
            PlayerInfoPage fill_input = new PlayerInfoPage(getDriver());
            fill_input.FillInput("username", "amy0828");


            PlayerInfoPage click_button = new PlayerInfoPage(getDriver());
            click_button.clickButton("submit");

            PlayerInfoPage view_playerInfo = new PlayerInfoPage(getDriver());
            view_playerInfo.ViewPlayerInfo();

            waitTime.thinkTime(3);

            PlayerInfoPage edit_button = new PlayerInfoPage(getDriver());
            edit_button.editButton();

            //Update with INVALID data
            //Long fields
            PlayerInfoPage update_input = new PlayerInfoPage(getDriver());
            update_input.UpdateInput("firstname", "Macsdddddddddddddddddddddd");
            update_input.UpdateInput("lastname", "Donaldsddddddddddddddddddddd");
            update_input.UpdateInput("middlename", "Testingdddddddddddddddddddddd");
            update_input.UpdateInput("alias", "Testdddddddddddddddddddddddddddddddddddddddddddddddd");
            update_input.UpdateInput("street-address", "Test Cityssssssssssssssssdddddddddddddddddddddddddggggggggggggggggggggggggggggggggggggggggggggggggdggggh");
            update_input.UpdateInput("street-address2", "Las Vegasdddddddddddddddddddddddddddddddddddddddddggggggggggggggggggggggggggggggggggggggggggggggggggggjjhgg");
            update_input.UpdateInput("postal-code", "6310333366666555");
            update_input.UpdateInput("city", "Test Citydddddddddddddddddddddddddddddddddddddddddddddddddddddddgggggd");

            PlayerInfoPage update_address2 = new PlayerInfoPage(getDriver());
            update_address2.address2("street-address", "Test Cityssssssssssssssssdddddddddddddddddddddddddggggggggggggggggggggggggggggggggggggggggggggggggdgggjjkgggggggggggggggg");
            update_address2.address2("street-address2", "Testing Cityssgggssssssssssssssdddddddddddddddddddddddddggggggggggggggggggggggggggggggggggggggggggggggggdgggjjggggggggggk");
            update_address2.address2("city", "Las Vegas Cityggggggggggggggggggggggggggggggggggggggggggghhhhhhhhhhh");
            update_address2.address2("postal-code", "8903155555555555");

            update_input.UpdateInput("phone", "702-501-22335556666677");
            update_input.UpdateInput("playercardnumber", "55667755666666666666666665555556565");

            PlayerInfoPage select_dropdown = new PlayerInfoPage(getDriver());
            select_dropdown.selectDropdown("identificationtype");

            update_input.UpdateInput("idnumber", "77889913333333333333333333333333");

            click_button.clickButton("submit");


            PlayerInfoPage warning_error = new PlayerInfoPage(getDriver());
            warning_error.warningError("firstname");
            PlayerInfoPage validation_error = new PlayerInfoPage(getDriver());
            validation_error.validationError("lastname");
            validation_error.validationError("middlename");
            validation_error.validationError("alias");
            //validation_error("street-address");
            //validation_error("street-address2");
            //validation_error("city");
            //validation_error("postal-code");

            //PlayerInfoPage validation_error_2 = new PlayerInfoPage(getDriver());
            //validation_error_2.validationError_2("street-address");
            //validation_error_2.validationError_2("street-address2");
            //validation_error_2.validationError_2("city");
            //validation_error_2.validationError_2("postal-code");


            validation_error.validationError("playercardnumber");
            validation_error.validationError("idnumber");


            PlayerInfoPage dismiss_button = new PlayerInfoPage(getDriver());
            dismiss_button.dismissButton();

            Console.WriteLine("TEST PASSED: UPDATE PLAYER INFO - LONG FIELD");
        }




        [Test]

        public void PlayerInfo_SpecialChar_InvalidFormat()

        {
            PlayerInfoPage waitTime = new PlayerInfoPage(getDriver());
            waitTime.thinkTime(2);

            SearchPlayerPage clear_button = new SearchPlayerPage(getDriver());
            clear_button.clearButton();

            //Valid data
            //Find player and fill ALL/ANY the input fields
            waitTime.thinkTime(2);
            PlayerInfoPage fill_input = new PlayerInfoPage(getDriver());
            fill_input.FillInput("username", "amy0828");


            PlayerInfoPage click_button = new PlayerInfoPage(getDriver());
            click_button.clickButton("submit");

            PlayerInfoPage view_playerInfo = new PlayerInfoPage(getDriver());
            view_playerInfo.ViewPlayerInfo();

            waitTime.thinkTime(3);

            PlayerInfoPage edit_button = new PlayerInfoPage(getDriver());
            edit_button.editButton();


            waitTime.thinkTime(2);


            //Update with INVALID data
            //Special Characters / Expired Date / Invalid format
            PlayerInfoPage update_input = new PlayerInfoPage(getDriver());
            update_input.UpdateInput("firstname", "Macs@#$");
            update_input.UpdateInput("lastname", "Donald$%^");
            update_input.UpdateInput("middlename", "Clarkson#@$#");
            update_input.UpdateInput("dateofbirth", "03/22/2023");
            update_input.UpdateInput("street-address", "Test City$#%&");
            update_input.UpdateInput("street-address2", "Las Vegas#$#$");
            update_input.UpdateInput("postal-code", "8907#$@");
            update_input.UpdateInput("city", "Test City#$#@#");

            PlayerInfoPage update_address2 = new PlayerInfoPage(getDriver());
            update_address2.address2("street-address", "Test City#$%");
            update_address2.address2("street-address2", "Testing City&*#$");
            update_address2.address2("city", "Las Vegas City#$%");
            update_address2.address2("postal-code", "890#$");

            update_input.UpdateInput("email", "thestcstqa.com");
            update_input.UpdateInput("phone", "6666667AABB");
            update_input.UpdateInput("playercardnumber", "556677#$%%");

            PlayerInfoPage select_dropdown = new PlayerInfoPage(getDriver());
            select_dropdown.selectDropdown("identificationtype");

            update_input.UpdateInput("idnumber", "77889$%#$");
            update_input.UpdateInput("idexpirationdate", "03/22/2020");

            waitTime.thinkTime(2);
            click_button.clickButton("submit");

            PlayerInfoPage warning_error = new PlayerInfoPage(getDriver());
            warning_error.warningError("firstname");
            PlayerInfoPage validation_error = new PlayerInfoPage(getDriver());
            validation_error.validationError("lastname");
            validation_error.validationError("middlename");
            validation_error.validationError("dateofbirth");
            //validation_error("street-address");
            //validation_error("street-address2");
            //validation_error("city");
            //validation_error("postal-code");

            //PlayerInfoPage validation_error_2 = new PlayerInfoPage(getDriver());
            //validation_error_2.validationError_2("street-address");
            //validation_error_2.validationError_2("street-address2");
            //validation_error_2.validationError_2("city");
            //validation_error_2.validationError_2("postal-code");

            validation_error.validationError("email");
            validation_error.validationError("phone");
            validation_error.validationError("playercardnumber");
            validation_error.validationError("idnumber");
            validation_error.validationError("idexpirationdate");

            PlayerInfoPage dismiss_button = new PlayerInfoPage(getDriver());
            dismiss_button.dismissButton();


            Console.WriteLine("TEST PASSED: UPDATE PLAYER INFO - SPECIAL CHAR / INVALID FORMAT");
        }




        [Test]

        public void PlayerInfo_ValidData()

        {
            PlayerInfoPage waitTime = new PlayerInfoPage(getDriver());
            waitTime.thinkTime(2);

            SearchPlayerPage clear_button = new SearchPlayerPage(getDriver());
            clear_button.clearButton();


            //Valid data
            //Find player and fill ALL/ANY the input fields
            PlayerInfoPage fill_input = new PlayerInfoPage(getDriver());
            fill_input.FillInput("username", "amy0828");

            PlayerInfoPage click_button = new PlayerInfoPage(getDriver());
            click_button.clickButton("submit");

            PlayerInfoPage view_playerInfo = new PlayerInfoPage(getDriver());
            view_playerInfo.ViewPlayerInfo();

            waitTime.thinkTime(2);

            PlayerInfoPage edit_button = new PlayerInfoPage(getDriver());
            edit_button.editButton();


            waitTime.thinkTime(2);


            //Update ALL fields with valid data
            PlayerInfoPage update_input = new PlayerInfoPage(getDriver());
            update_input.UpdateInput("firstname", "Max");
            update_input.UpdateInput("lastname", "Donalds");
            update_input.UpdateInput("middlename", "Test");
            update_input.UpdateInput("alias", "Testing");
            update_input.UpdateInput("dateofbirth", "02/12/1985");
            update_input.UpdateInput("street-address", "123 Test");
            update_input.UpdateInput("street-address2", "Test");
            update_input.UpdateInput("postal-code", "8932");
            update_input.UpdateInput("city", "Test City");

            PlayerInfoPage adress1_dropdown = new PlayerInfoPage(getDriver());
            adress1_dropdown.address1Dropdown("country");
            adress1_dropdown.address1Dropdown("state");

            PlayerInfoPage update_address2 = new PlayerInfoPage(getDriver());
            update_address2.address2("street-address", "222 Test");
            update_address2.address2("street-address2", "Test Address2");
            update_address2.address2("postal-code", "89022");
            update_address2.address2("city", "Las Vegas City");
 

            update_input.UpdateInput("email", "theliangg@cstqa.com");
            update_input.UpdateInput("phone", "702-501-4828");
            update_input.UpdateInput("playercardnumber", "556677");

            PlayerInfoPage select_dropdown = new PlayerInfoPage(getDriver());
            select_dropdown.selectDropdown("identificationtype");

            update_input.UpdateInput("idnumber", "112233");
            update_input.UpdateInput("idexpirationdate", "05/25/2027");


            click_button.clickButton("submit");

            //PlayerInfoPage dismiss_button = new PlayerInfoPage(getDriver());
            //dismiss_button.dismissButton();

            Console.WriteLine("TEST PASSED: UPDATE PLAYER INFO - VALID DATA");
        }


        [Test]

        public void AccountDetails_ValidaData()

        {
            SearchPlayerPage waitTime = new SearchPlayerPage(getDriver());
            waitTime.thinkTime(2);

            SearchPlayerPage clear_button = new SearchPlayerPage(getDriver());
            clear_button.clearButton();

            //Valid data
            //Find player and update ALL the input fields
            waitTime.thinkTime(2);
            SearchPlayerPage fill_input = new SearchPlayerPage(getDriver());
            fill_input.FillInput("username", "amy0828");

            SearchPlayerPage click_button = new SearchPlayerPage(getDriver());
            click_button.clickButton("submit");

            PlayerInfoPage view_playerInfo = new PlayerInfoPage(getDriver());
            view_playerInfo.ViewPlayerInfo();

            waitTime.thinkTime(2);
            AccountDetailsPage account_Details = new AccountDetailsPage(getDriver());
            account_Details.accountDetails();

            waitTime.thinkTime(2);
            AccountDetailsPage edit_button = new AccountDetailsPage(getDriver());
            edit_button.editButton();

            AccountDetailsPage account_status = new AccountDetailsPage(getDriver());
            account_status.accountStatus("accountStatus");

            AccountDetailsPage check_box = new AccountDetailsPage(getDriver());
            check_box.checkBox("marketingOptIn");

            AccountDetailsPage select_residency = new AccountDetailsPage(getDriver());
            select_residency.selectResidency();

            waitTime.thinkTime(2);

            AccountDetailsPage withholding_status = new AccountDetailsPage(getDriver());
            withholding_status.withholdingState("withholdingState");

            AccountDetailsPage wagering_status = new AccountDetailsPage(getDriver());
            wagering_status.wageringStatus("Nevada");

            AccountDetailsPage kyc_status = new AccountDetailsPage(getDriver());
            kyc_status.KYCStatus("Nevada");

            AccountDetailsPage fill_reason = new AccountDetailsPage(getDriver());
            fill_reason.fillReason("Nevada", "Testing Automation");

            AccountDetailsPage wagering_status2 = new AccountDetailsPage(getDriver());
            wagering_status2.wageringStatus("Kentucky");

            AccountDetailsPage kyc_status2 = new AccountDetailsPage(getDriver());
            kyc_status2.KYCStatus("Kentucky");

            AccountDetailsPage fill_reason2 = new AccountDetailsPage(getDriver());
            fill_reason2.fillReason("Kentucky", "Testing Automation_2");

            click_button.clickButton("submit");

            PlayerInfoPage dismiss_button = new PlayerInfoPage(getDriver());
            dismiss_button.dismissButton();


        }

    }
}








       

