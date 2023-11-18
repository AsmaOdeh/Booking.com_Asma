using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using NUnit.Framework;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
// For supporting Page Object Model
// Obsolete - using OpenQA.Selenium.Support.PageObjects;
using SeleniumExtras.PageObjects;
using Booking.com_Alpha.Base;
using System.IO;
using SeleniumExtras.WaitHelpers;


namespace Booking.com_Alpha.Pages
{
    public class HomePage

    {
        //String test_url = "https://www.booking.com";

        IWebDriver driver;
        private WebDriverWait wait;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        }

        // ------------------------------------- Locators -------------------------------------

        [FindsBy(How = How.Name, Using = "ss")]
        [CacheLookup]
        private IWebElement elem_city_text;

        [FindsBy(How = How.XPath, Using = "//div[@role='button']//div[text()='Istanbul']")]
        [CacheLookup]
        private IWebElement istanbul_city;

        [FindsBy(How = How.XPath, Using = "//div[@data-testid='searchbox-dates-container']")]
        [CacheLookup]
        private IWebElement DatesField;

        [FindsBy(How = How.XPath, Using = @"//div[@class='c2-button c2-button-further']")]
        public IWebElement GoRight { get; set; }

        [FindsBy(How = How.XPath, Using = @"//button[@data-testid='occupancy-config']")]
        public IWebElement Persons { get; set; }
    
        [FindsBy(How = How.XPath, Using = "//button[@aria-label='Dismiss sign-in info.']")]
        [CacheLookup]
        private IWebElement singInPopup_CloseIcon;

        [FindsBy(How = How.XPath, Using = @"//button//span[text()='Search']")]
        [CacheLookup]
        private IWebElement searchButton;

        //------------------------------------- Methods -------------------------------------


        /// <summary>
        /// Close the popup that displayed for signin/sign up
        /// </summary>
        public void closeSignInPopup()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            singInPopup_CloseIcon.Click();
            Console.WriteLine("1. The popup closed");
        }

  
        /// <summary>
        /// Enter city name
        /// </summary>
        /// <param name="destination">
        public void enterCityName(String destination)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Name("ss")));
            elem_city_text.Click();

            elem_city_text.SendKeys(destination);
            Console.WriteLine("2. The city name is entered");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            istanbul_city.Click();
        }

        /// <summary>
        /// pick 10 days from date picker
        /// </summary>
        public void pickDates()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//nav[@data-testid='datepicker-tabs']")));
            IWebElement checkInInput = driver.FindElement(By.XPath("//nav[@data-testid='datepicker-tabs']"));
            checkInInput.Click();

            // Get the current date
            DateTime currentDate = DateTime.Now;

            // Calculate the check-out date (10 days later)
            DateTime checkOutDate = currentDate.AddDays(10);

            // Select the current date as the check-in date
            SelectDate(checkInInput, currentDate);

            // Locate and click the check-out date input field (adjust the selector based on your HTML structure)
            IWebElement checkOutInput = driver.FindElement(By.XPath("//nav[@data-testid='datepicker-tabs']"));
            checkOutInput.Click();

            // Select the calculated check-out date
            SelectDate(checkOutInput, checkOutDate);
            Console.WriteLine("10 days are selected from the date picker");

        }
        /// <summary>
        /// select date from date picker
        /// </summary>
        /// <param name="datepicker", "dateToSelect">
        static void SelectDate(IWebElement datePicker, DateTime dateToSelect)
        {
            // Find the date picker container (adjust the selector based on your HTML structure)
            IWebElement datePickerContainer = datePicker.FindElement(By.XPath("//nav[@data-testid='datepicker-tabs']"));

            // Wait for the date picker to be visible
            Thread.Sleep(5000);
            //WebDriverWait wait = new WebDriverWait(datePickerContainer, TimeSpan.FromSeconds(10));
            //wait.Until(SeleniumExtras.ExpectedConditions.ElementIsVisible(By.CssSelector(".datepicker__months")));

            // Extract month and year from the date to be selected
            string targetMonthYear = dateToSelect.ToString("MMMM yyyy");

            // Loop until the target month and year are displayed
            while (!datePickerContainer.Text.Contains(targetMonthYear))
            {
                // Click the next month button
                IWebElement nextMonthButton = datePickerContainer.FindElement(By.XPath("(//button[@class='a83ed08757 c21c56c305 f38b6daa18 d691166b09 f671049264 deab83296e f4552b6561 dc72a8413c f073249358'])[1]"));
                nextMonthButton.Click();
            }

            // Locate and click the day for the date to be selected
            IWebElement targetDay = datePickerContainer.FindElement(By.XPath($"//span[text()='{dateToSelect.Day}']"));
            targetDay.Click();
        }


        /// <summary>
        /// Click on search button
        /// </summary>
        public void clickOnSearchButton()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button//span[text()='Search']")));
            searchButton.Click();
            Console.WriteLine("Search button is clicked");
        }










    }
}
