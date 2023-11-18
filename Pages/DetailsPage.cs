using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;

namespace Booking.com_Alpha.Pages
{
    public class DetailsPage
    {

        IWebDriver driver;
        private WebDriverWait wait;

        public DetailsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
        }

        // ------------------------------------- Locators -------------------------------------
        [FindsBy(How = How.Id, Using = "firstname")]
        [CacheLookup]
        private IWebElement firstName;

        [FindsBy(How = How.Id, Using = "lastname")]
        [CacheLookup]
        private IWebElement lastName;

        [FindsBy(How = How.Name, Using = "email")]
        [CacheLookup]
        private IWebElement emailAddress;

        [FindsBy(How = How.Name, Using = "phone")]
        [CacheLookup]
        private IWebElement phoneNumber;

        [FindsBy(How = How.Name, Using = "book")]
        [CacheLookup]
        private IWebElement bookButton;


        //------------------------------------- Methods -------------------------------------


        /// <summary>
        /// enter details in Entry details page
        /// </summary>
        /// <param name="first","last", "email", "phone">
        public void enterDetails(String first, String last, String email, String phone)
        {
            //Thread.Sleep(3000);
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("firstname")));

            firstName.SendKeys(first);
            lastName.SendKeys(last);
            emailAddress.SendKeys(email);
            phoneNumber.SendKeys(phone);
            Console.WriteLine("Details entered");

            bookButton.Click();
            Console.WriteLine("book button clicked");

            
        }
    }
}
