using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;

namespace Booking.com_Alpha.Base
{
    public class BaseClass
    {
        public IWebDriver driver;


        private static string browser = "Chrome";
       
        public void chooseBrowser(String browser)
        {
            switch (browser)
            {
                case "Chrome":
                    driver = new ChromeDriver(@"C:\Users\Asma.Odeh\source\repos\Booking.com_Alpha\Booking.com_Alpha\drivers\");
                    break;
                case "Firefox":
                    driver = new FirefoxDriver();
                    break;
                default:
                    driver = new ChromeDriver();
                    break;
            }
        }
        [SetUp]
        public void Open()
        {
            chooseBrowser("FireFox");
            //driver = new ChromeDriver(@"C:\Users\Asma.Odeh\source\repos\Booking.com_Alpha\Booking.com_Alpha\drivers\");
            //driver.Navigate().GoToUrl("https://www.booking.com/");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Url = "https://www.booking.com/";
        }     

        [TearDown]
        public void Close()
        {
            //driver.Quit();
        }
    }
}

    
