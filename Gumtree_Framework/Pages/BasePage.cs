using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using ExpectedConditions = OpenQA.Selenium.Support.UI.ExpectedConditions;

namespace Gumtree.Pages
{
    public class BasePage
    {
        protected WebDriverWait Wait;
        protected IWebDriver driver;

        public BasePage(IWebDriver webDriver)
        {
            driver = webDriver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(double.Parse(ConfigurationManager.AppSettings["ExplicitWaitTimeout"])));
        }

        public void WaitForDocumentReady()
        {
            var javascript = driver as IJavaScriptExecutor;
            Wait.Until((d) =>
            {
                try
                {
                    string readyState = javascript.ExecuteScript(
                        "if (document.readyState) return document.readyState;").ToString();
                    return readyState.ToLower() == "complete";
                }
                catch (InvalidOperationException e)
                {
                    //Window is no longer available
                    return e.Message.ToLower().Contains("unable to get browser");
                }
                catch (WebDriverException e)
                {
                    //Browser is no longer available
                    return e.Message.ToLower().Contains("unable to connect");
                }
                catch (Exception)
                {
                    return false;
                }
            });
        }

        public void ClearAndSendKeys(IWebElement element, string text)
        {
            try
            {
                Wait.Until(driver => element.Displayed);
                if(element.GetAttribute("value") != null)
                {
                    element.Clear();
                }
                element.SendKeys(text);
            }
            catch (NoSuchElementException)
            {
                var errorMessage = $"{element} not found";
                throw new Exception(errorMessage);
            }
        }

        
        public void ClickElement(IWebElement element)
        {
            try
            {
                Wait.Until(driver => element.Enabled);
                Wait.Until(ExpectedConditions.ElementToBeClickable(element));
                element.Click();
            }
            catch (StaleElementReferenceException)
            {
                Wait.Until(ExpectedConditions.StalenessOf(element));
                Wait.Until(driver => element.Displayed);
                Wait.Until(ExpectedConditions.ElementToBeClickable(element));
                element.Click();
            }
            catch (NoSuchElementException e)
            {
                throw e;
            }
            catch (WebDriverTimeoutException e)
            {
                throw new WebDriverException(e.InnerException.Message);
            }
        }

        public void WaitTillElementVisible(By findMethod)
        {
            Wait.Until(ExpectedConditions.ElementExists(findMethod));
            Wait.Until(ExpectedConditions.ElementIsVisible(findMethod));
        }

        public void ScrollTillElementVisible(IWebElement element)
        {
            var scrolledElement = (ILocatable)element;
            try{ 
                var point = scrolledElement.LocationOnScreenOnceScrolledIntoView;
                ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollBy(" + point.X + ", " + point.Y + ");");
            }catch(Exception e) { }
        }

        protected virtual IList<IWebElement> FindElementsByCssSelector(string path)
        {
            return driver.FindElements(By.CssSelector(path));
        }

        protected virtual IWebElement FindElementByXpath(string path)
        {
            return driver.FindElement(By.XPath(path));
        }

        protected virtual IWebElement FindElementByCssSelector(string path)
        {
            return driver.FindElement(By.CssSelector(path));
        }
    }
}
