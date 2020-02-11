using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Gumtree.Pages
{
    public class LoginPage : BasePage
    {
        private IWebElement _linkSignIn => FindElementByXpath("//a[normalize-space()='Sign In']");
        private IWebElement _inputLoginEmail => FindElementByCssSelector("input#login-email");
        private IWebElement _inputLoginPassword => FindElementByCssSelector("input#login-password");
        private IWebElement _btnSignIn => FindElementByCssSelector("button#btn-submit-login");
        
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public void LoginToGumtree(Table table)
        {
            dynamic credentials = table.CreateDynamicInstance();
            ClickElement(_linkSignIn);
            ClearAndSendKeys(_inputLoginEmail, credentials.Username);
            ClearAndSendKeys(_inputLoginPassword, credentials.Password);
            ClickElement(_btnSignIn);
        }
    }
}
