using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Booking.com_Alpha.Pages
{
    public class SearchResultsPage
    {


        IWebDriver driver;
        private WebDriverWait wait;

        public SearchResultsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        }

        // ------------------------------------- Locators -------------------------------------

        [FindsBy(How = How.XPath, Using = @"(//h3[text()='Property Type']/ancestor::div[contains(@id,'filter_group')]//div//input[contains(@aria-label,'Apartments:')])[1]")]
        [CacheLookup]
        private IWebElement apartment_checkbox;

        [FindsBy(How = How.XPath, Using = @"(//div[@data-testid='availability-cta']//span[text()='See availability'])[1]")]
        [CacheLookup]
        private IWebElement seeAvalabilityButton;
        
        //------------------------------------- Methods -------------------------------------

        /// <summary>
        /// select apartment checkbox
        /// </summary>
        public void selectApartmentCheckbox()
        {

            apartment_checkbox.Click();
            Console.WriteLine("Apartment check box is selected");
        }

        /// <summary>
        /// click on see availability button
        /// </summary>
        public void clickOnSeeAvailability()
        {
            Thread.Sleep(3000);
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//div[@data-testid='availability-cta']//span[text()='See availability'])[1]")));
            seeAvalabilityButton.Click();
            Console.WriteLine("Clicked On See Avaiability");
        }

        /// <summary>
        /// verify that the destination name is available in the search result
        /// </summary>
        /// /// <param name="destinationName">
        public void verifySearchResultsContainDetinationWord(String destinationName)
        {
            Thread.Sleep(3000);
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//div[@data-testid='availability-cta']//span[text()='See availability'])[1]")));
            List<IWebElement> searchResults = new List<IWebElement>
                (driver.FindElements(By.XPath("//h2[text()='Browse the results for Istanbul']//..//div[@data-testid='property-card']//descendant::span[@data-testid='address']")));

            bool isWordPresent = IsWordPresentInElements(searchResults, destinationName);
            // Assert that the word is present in any of the elements
            Assert.IsTrue(IsWordPresentInElements(searchResults, destinationName), $"The word '{destinationName}' is not present in the list.");

            // Output a success message
            Console.WriteLine($"The word '{destinationName}' is present in the list.");
        }

        /// <summary>
        /// verify that the nights number and adults number name is available in the search result and correct
        /// </summary>
        /// /// <param name="nightsNum", "adulstNum">
        public void verifySearchResultsForNightsAndPersons(String nightsNum, String adulstNum)
        {
            
            List<IWebElement> searchResults = new List<IWebElement>
                (driver.FindElements(By.XPath("//h2[text()='Browse the results for Istanbul']//..//div[@data-testid='property-card']//descendant::div[@data-testid='price-for-x-nights']")));

            bool isWordPresent = IsWordPresentInElements(searchResults, nightsNum);

            // Assert that the nights number is present in any of the elements
            Assert.IsTrue(IsWordPresentInElements(searchResults, nightsNum), $"The word '{nightsNum}' is not present in the list.");

            // Output a success message
            Console.WriteLine($"The word '{nightsNum}' is present in the list.");

            // Assert that the adults number number is present in any of the elements
            Assert.IsTrue(IsWordPresentInElements(searchResults, adulstNum), $"The word '{adulstNum}' is not present in the list.");

            // Output a success message
            Console.WriteLine($"The word '{adulstNum}' is present in the list.");
        }

        /// <summary>
        /// Check if a specific word is displayed in list (used in another methods)
        /// </summary>
        /// /// <param name="elements", "targetWord">
        static bool IsWordPresentInElements(IList<IWebElement> elements, string targetWord)
        {
            foreach (var element in elements)
            {
                // Extract the text content of the element
                string elementText = element.Text;

                // Check if the target word is present in the element text
                if (elementText.Contains(targetWord, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }


    }
}

