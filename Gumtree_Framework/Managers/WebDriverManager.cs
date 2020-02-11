using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Configuration;
using System.IO;

namespace Gumtree.Managers
{
    public class WebDriverManager
    {
        private IWebDriver _driver;
        private static string _driverType; 
 
        public WebDriverManager(){
            _driverType = ConfigurationManager.AppSettings["Browser"];
        }

        public IWebDriver GetDriver()
        {
            if (_driver == null) _driver = CreateDriver();
            return _driver;
        }

        private IWebDriver CreateDriver()
        {
            switch (_driverType.ToLower())
            {
                // Can add more cases to support cross browser testing for future scope
                case "chrome":
                    var options = new ChromeOptions();
                    options.AddArgument("start-maximized");
                    options.AddArguments("--disable-extensions");
                    options.AddArguments("--disable-infobars");
                    _driver = new ChromeDriver(options);
                    break;
            }
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(double.Parse(ConfigurationManager.AppSettings["ImplicitWaitTimeout"]));
            return _driver;
        }
    }
}
