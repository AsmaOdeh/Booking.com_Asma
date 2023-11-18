using Booking.com_Alpha.Base;
using Booking.com_Alpha.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Booking.com_Alpha.TestCases
{
    [TestFixture]
    public class TestClass: BaseClass
    {

        //private IWebDriver driver;
        //HomePage home = new HomePage(driver);
        //HomePage home = new HomePage();



        //[SetUp]
        /* public void InitScript()
         {

             driver = new ChromeDriver();
         }*/


        [Test]

        public void bookFor2adults_Istanbul_For10Days()

        {
            // Creating objects 
            HomePage home = new HomePage(driver);
            SearchResultsPage searchResultsPage = new SearchResultsPage(driver);
            ApartmentDetails apartmentDetails = new ApartmentDetails(driver);
            DetailsPage detailsPage = new DetailsPage(driver);
            PaymentPage paymentPage = new PaymentPage(driver);

            // Variables
            String destination = "Istanbul";
            String nightsNum = "10 nights";
            String adulstNum = "2 adults";
            String firstName = "Asma";
            String lastName = "Odeh";
            String email = "asmaodeh73@gmail.com";
            String phone = "598496956";

            String cardNum = "3566000020000410";
            String expDate = "02/26";
            String cvc = "123";

            //-------------------------- Home page actions --------------------------
            home.closeSignInPopup();
            home.enterCityName(destination);
            home.pickDates();
            home.clickOnSearchButton();

            //-------------------------- Search results page actions --------------------------
            searchResultsPage.verifySearchResultsContainDetinationWord(destination);
            searchResultsPage.verifySearchResultsForNightsAndPersons(nightsNum, adulstNum);
            searchResultsPage.selectApartmentCheckbox();
            searchResultsPage.clickOnSeeAvailability();

            // -------------------------- Apartment details page actions --------------------------
            apartmentDetails.clickOnReserveButton();

            // -------------------------- Enter guest information --------------------------
            detailsPage.enterDetails(firstName,lastName, email, phone);

            // -------------------------- Enter payment details --------------------------
            //paymentPage.enterPaymentDetails(cardNum, expDate, cvc);

        }
    }
}
    