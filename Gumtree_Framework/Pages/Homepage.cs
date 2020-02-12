using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Gumtree.Pages
{
    public class Homepage : BasePage
    {
        private IWebElement _inputSearchItem => FindElementByCssSelector("input#search-query");
        private IWebElement _inputSearchArea => FindElementByCssSelector("input#search-area");
        private IWebElement _spanSearchRange => FindElementByCssSelector(" span#srch-radius-input");
        private IWebElement _liSearchRange(string kmRange) => FindElementByXpath("//div[@id='srch-radius-wrpwrapper']//ul//li[.='"+kmRange+"']");
        private IWebElement _btnSearchItem => FindElementByCssSelector("button.header__search-button");
        private IList<IWebElement> _divSearchResults => FindElementsByCssSelector("div.search-results-page__main-ads-wrapper a.user-ad-row");
        private IWebElement _selectDisplayCount => FindElementByCssSelector("div.results-per-page-selector select");
        private IWebElement _linkPageNumber(string pageNumber) => FindElementByXpath("//a[contains(@class,'page-number') and .='"+ pageNumber +"']");

        public Homepage(IWebDriver driver) : base(driver)
        {
        }

        public void NavigateToGumtreeUrl()
        {
            var url = ConfigurationManager.AppSettings["GumtreeUrl"];
            driver.Navigate().GoToUrl(url);
            WaitForDocumentReady();
        }

        public void SearchItem(Table table)
        {
            dynamic credentials = table.CreateDynamicInstance();
            ClearAndSendKeys(_inputSearchItem, credentials.Item);
            ClearAndSendKeys(_inputSearchArea, credentials.Area);
            ClickElement(_spanSearchRange);
            ClickElement(_liSearchRange(credentials.Range));
            ClickElement(_btnSearchItem);
            WaitForDocumentReady();
        }

        public void ValidateCountForProductsDisplayed()
        {
            var searchResultsPerPage = new SelectElement(_selectDisplayCount);
            var displayedCountValue= searchResultsPerPage.SelectedOption.Text;
            var searchResultCount = _divSearchResults.Count;
            Assert.AreNotEqual(0, searchResultCount, "ERROR: Number of items displayed is 0, which means there are no items found in this page...");
            StringAssert.StartsWith(searchResultCount.ToString(), displayedCountValue,"Displayed item count DOES NOT match with search results count");
        }

        public void ClickThePageNumbers(Table pageNumbers)
        {
            foreach (var row in pageNumbers.Rows)
            {
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click(); ", _linkPageNumber(row["page number"]));
                Wait.Until(ExpectedConditions.UrlContains("page-"+row["page number"]));
            }
        }

        public void OpenRandomAdvert()
        {
            var random = (new Random()).Next(_divSearchResults.Count);
            ScrollTillElementVisible(_divSearchResults[random]);
            ClickElement(_divSearchResults[random]);
        }
    }   
}