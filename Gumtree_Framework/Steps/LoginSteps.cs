using Gumtree.Context;
using Gumtree.Pages;
using TechTalk.SpecFlow;

namespace Gumtree.Steps
{
    [Binding]
    public class LoginSteps
    {
        private LoginPage _loginPage;
        TestContext testContext;

        public LoginSteps(TestContext context)
        {
            testContext = context;
            _loginPage = testContext.PageObjectManager.GetLoginPage();
        }

        [StepDefinition(@"I enter the below username and password")]
        public void WhenIEnterTheBelowUsernameAndPassword(Table table)
        {
            _loginPage.LoginToGumtree(table); 
        }

    }
}
