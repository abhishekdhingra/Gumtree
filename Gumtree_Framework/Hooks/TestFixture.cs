using Gumtree.Context;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using NUnit.Framework.Interfaces;
namespace Gumtree.Hooks
{
    [Binding]
    public class TestFixture
    {
        private readonly FeatureContext _featureContext;
        private readonly TestContext _testContext;
        public IWebDriver driver { get; private set; }

        public TestFixture(FeatureContext featureContext, TestContext testContext)
        {
            _featureContext = featureContext;
            _testContext = testContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            driver = _testContext.WebDriverManager.GetDriver();
        }
        
        [AfterScenario]
        public void AfterScenario()
        {
            if (NUnit.Framework.TestContext.CurrentContext.Result.Outcome != ResultState.Success)
                CaptureScreenshot();
            driver.Quit();
        }

        private void CaptureScreenshot()
        {
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            var screenshotFileName = (NUnit.Framework.TestContext.CurrentContext.Test.MethodName);
            System.IO.Directory.CreateDirectory(NUnit.Framework.TestContext.CurrentContext.TestDirectory + @"\Screenshots\");
            screenshot?.SaveAsFile(NUnit.Framework.TestContext.CurrentContext.TestDirectory + @"\Screenshots\" + screenshotFileName + ".jpg", ScreenshotImageFormat.Jpeg);
        }
    }
}
