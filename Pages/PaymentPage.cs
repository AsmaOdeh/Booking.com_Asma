using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using SeleniumExtras.WaitHelpers;

namespace Booking.com_Alpha.Pages
{
    public class PaymentPage
    {


        IWebDriver driver;
        private WebDriverWait wait;

        public PaymentPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        // ------------------------------------- Locators -------------------------------------
        [FindsBy(How = How.XPath, Using = @"//input[contains(@id,'pc-card-number')]")]
        [CacheLookup]
        private IWebElement cardNumber;

        [FindsBy(How = How.XPath, Using = @"//input[@type='text'][@name='expirationDate']")]
        [CacheLookup]
        private IWebElement expirationDate;

        [FindsBy(How = How.XPath, Using = @"//input[@type='text'][@name='cvc']")]
        [CacheLookup]
        private IWebElement cvc;

        [FindsBy(How = How.XPath, Using = "//button[contains(@class,'complete-booking')]")]
        [CacheLookup]
        private IWebElement completeBooking;


        //------------------------------------- Methods -------------------------------------

        /// <summary>
        /// enter payment details 
        /// </summary>
        /// <param name="card","exp", "cvcnum">
        public void enterPaymentDetails(String card, String exp, String cvcNum)
        {
            Thread.Sleep(6000);

            //cardNumber.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[contains(@id,'pc-card-number')]")));
            ////cardNumber.Click();
            //cardNumber.SendKeys(card);

            expirationDate.Click();
            expirationDate.SendKeys(exp);
            
            cvc.Click();
            cvc.SendKeys(cvcNum);
            
            Console.WriteLine("Payment Details Entered");

            completeBooking.Click();
            Console.WriteLine("Complete Booking clicked");

            Thread.Sleep(3000);

        }
    }
}
