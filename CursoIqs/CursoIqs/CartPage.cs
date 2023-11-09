using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIqs
{
    public class CartPage
    {

        public IWebDriver driver;

        public CartPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        public void RemoveItemCart()
        {
            driver.FindElement(By.Id("remove-sauce-labs-backpack")).Click();
        }

        public void RemoveItemCartReturnHome()
        {
            driver.FindElement(By.Id("remove-sauce-labs-backpack")).Click();
            driver.FindElement(By.Id("react-burger-menu-btn")).Click();
            driver.FindElement(By.Id("inventory_sidebar_link")).Click();
        }

        public void CompleteBuy()
        {
            driver.FindElement(By.Id("checkout")).Click();
            driver.FindElement(By.Id("first-name")).SendKeys("Calebe");
            driver.FindElement(By.Id("last-name")).SendKeys("Cleiton");
            driver.FindElement(By.Name("postalCode")).SendKeys("25640390");
            driver.FindElement(By.XPath("//input[@class='submit-button btn btn_primary cart_button btn_action']")).Click();
            driver.FindElement(By.XPath("//button[@class='btn btn_action btn_medium cart_button']")).Click();
            driver.FindElement(By.Id("back-to-products")).Click();
        }

 
        public void GoHome()
        { 
           driver.FindElement(By.Id("react-burger-menu-btn")).Click();
           driver.FindElement(By.Id("inventory_sidebar_link")).Click();
        }
    }
}
