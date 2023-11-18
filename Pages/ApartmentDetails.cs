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
    internal class ApartmentDetails
    {
        IWebDriver driver;
        private WebDriverWait wait;

        public ApartmentDetails(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
        }

        // ------------------------------------- Locators -------------------------------------

        [FindsBy(How = How.XPath, Using = @"//button[@id='hp_book_now_button']//span[@class='bui-button__text']")]
        [CacheLookup]
        private IWebElement reserveApartment;
        
        [FindsBy(How = How.XPath, Using = @"//div//select[contains(@name,'nr_rooms_')]")]
        [CacheLookup]
        private IWebElement NumOfRooms;

        [FindsBy(How = How.XPath, Using = @"(//button[contains(@class,'-reservation-button')]//span[contains(@class,'reservation-button_')])[1]")]
        [CacheLookup]
        private IWebElement IWillReserve;

        //------------------------------------- Methods -------------------------------------

        /// <summary>
        /// Click on reserve button
        /// </summary>
        public void clickOnReserveButton()
        {
            string originalWindow = driver.CurrentWindowHandle;

            //Loop through until we find a new window handle
            foreach (string window in driver.WindowHandles)
            {
                if (originalWindow != window)
                {
                    driver.SwitchTo().Window(window);
                    wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@id='hp_book_now_button']//span[@class='bui-button__text']")));
                    reserveApartment.Click();
                    Thread.Sleep(1000);
                    //wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//button[contains(@class,'-reservation-button')]//span[contains(@class,'reservation-button_')])[1]")));
                    IWillReserve.Click();
                    Console.WriteLine("Reserve button is clicked");
                    break;
                }
            }


        }
    }
}
