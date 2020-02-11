using OpenQA.Selenium;
using System.Threading;

namespace Gumtree.Pages
{
    public class AdvertDetailsPage : BasePage
    {
        
        private IWebElement _btnRightArrow => FindElementByCssSelector("button.vip-ad-gallery__nav-btn--next");
        private By _btnByRightArrow => By.CssSelector("button.vip-ad-image__legend-cta");

        public AdvertDetailsPage(IWebDriver driver) : base(driver)
        {
        }

        public void ClickOnAdvertImage()
        {
            try
            {
                driver.FindElement(_btnByRightArrow); 
            }catch(StaleElementReferenceException){
                driver.FindElement(_btnByRightArrow);
            }
            ClickElement(driver.FindElement(_btnByRightArrow));
        }

        public void ViewAllImagesinAdvert()
        {
            while (_btnRightArrow.Displayed)
            {
                ClickElement(_btnRightArrow);
                Thread.Sleep(500);
            }
                
        }
    }
}
