using Gumtree.Managers;
namespace Gumtree.Context
{
    public class TestContext
    {
        public WebDriverManager WebDriverManager { get; private set; }
        public PageObjectManager PageObjectManager { get; private set ; }

        public TestContext()
        {
            WebDriverManager = new WebDriverManager();
            PageObjectManager = new PageObjectManager(WebDriverManager.GetDriver());
        }
    }
}
