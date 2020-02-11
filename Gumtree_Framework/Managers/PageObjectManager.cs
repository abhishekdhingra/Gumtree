using Gumtree.Pages;
using OpenQA.Selenium;

namespace Gumtree.Managers
{
    public class PageObjectManager
    {
        private IWebDriver _driver;
        private Homepage _homePage;
        private LoginPage _loginPage;
        private AdvertDetailsPage _advertDetails;

        public PageObjectManager(IWebDriver driver)
        {
            _driver = driver;
        }

        public Homepage GetHomePage()
        {
            return (_homePage == null) ? _homePage = new Homepage(_driver) : _homePage;
        }

        public AdvertDetailsPage GetAdvertDetailsPage()
        {
            return (_advertDetails == null) ? _advertDetails = new AdvertDetailsPage(_driver) : _advertDetails;
        }

        public LoginPage GetLoginPage()
        {
            return (_loginPage == null) ? _loginPage = new LoginPage(_driver) : _loginPage;
        }
    }
}
