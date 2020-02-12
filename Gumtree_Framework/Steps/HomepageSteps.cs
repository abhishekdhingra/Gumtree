using Gumtree.Pages;
using Gumtree.Context;
using TechTalk.SpecFlow;

namespace Gumtree.Steps
{
    [Binding]
    public class HomepageSteps
    {
        private Homepage _homePage;
        TestContext testContext;

        public HomepageSteps(TestContext context) 
        {
            testContext = context;
            _homePage = testContext.PageObjectManager.GetHomePage();
        }

        [StepDefinition(@"I navigate to Gumtree application")]
        public void GivenINavigateToGumtreeApplication()
        {
            _homePage.NavigateToGumtreeUrl();
        }

        [StepDefinition(@"I search for the item using the below specfications")]
        public void WhenISearchForTheItemUsingTheBelowSpecfications(Table searchDetails)
        {
            _homePage.SearchItem(searchDetails);
        }


        [StepDefinition(@"the number of products on displayed should be same as the label showing the count")]
        public void ThenTheNumberOfProductsOnDisplayedShouldBeSameAsTheLabelShowingTheCount()
        {
            _homePage.ValidateCountForProductsDisplayed();
        }

        [StepDefinition(@"I click the the below page numbers")]
        public void WhenIClickTheTheBelowPageNumbers(Table pageNumbers)
        {
            _homePage.ClickThePageNumbers(pageNumbers);
        }

        [StepDefinition(@"I open a random advert on the page")]
        public void WhenIOpenARandomAdvertOnThePage()
        {
            _homePage.OpenRandomAdvert();
        }
    }
}