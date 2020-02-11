using Gumtree.Context;
using Gumtree.Pages;
using TechTalk.SpecFlow;

namespace Gumtree.Steps
{
    [Binding]
    class AdvertDetailsSteps
    {
        private AdvertDetailsPage _advertDetailsPage;
        TestContext testContext;

        public AdvertDetailsSteps(TestContext context)
        {
            testContext = context;
            _advertDetailsPage = testContext.PageObjectManager.GetAdvertDetailsPage();
        }
        
        [StepDefinition(@"I click on images button on advert")]
        public void WhenIClickOnImagesButtonOnAdvert()
        {
            _advertDetailsPage.ClickOnAdvertImage();
        }

        [StepDefinition(@"I should be able to view all the images")]
        public void ThenIShouldBeAbleToViewAllTheImages()
        {
            _advertDetailsPage.ViewAllImagesinAdvert();
        }

    }
}