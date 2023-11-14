using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIqs
{
    public class HomePage
    {

        public IWebDriver driver;

        public HomePage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        public void AddItemCart()
        {
            driver.FindElement(By.XPath("//button[@id='add-to-cart-sauce-labs-backpack']")).Click();
            driver.FindElement(By.XPath("//a[@class='shopping_cart_link']")).Click();
        }

        public void Cart()
        {
            driver.FindElement(By.XPath("//a[@class='shopping_cart_link']")).Click();
        }
        
        public void Buy()
        {
            #region ADICIONA ITEM AO CARRINHO E VAI ATE ELE
            driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack")).Click();
            driver.FindElement(By.XPath("//a[@class='shopping_cart_link']")).Click();
            #endregion
            #region FINALIZA A COMPRA
            driver.FindElement(By.Id("checkout")).Click();
            driver.FindElement(By.Id("first-name")).SendKeys("Calebe");
            driver.FindElement(By.Id("last-name")).SendKeys("Cleiton");
            driver.FindElement(By.Name("postalCode")).SendKeys("25640390");
            driver.FindElement(By.XPath("//input[@class='submit-button btn btn_primary cart_button btn_action']")).Click();
            driver.FindElement(By.XPath("//button[@class='btn btn_action btn_medium cart_button']")).Click();
            driver.FindElement(By.Id("back-to-products")).Click();
            #endregion
        }

        public void Logout()
        {
            driver.FindElement(By.XPath("//button[@id='react-burger-menu-btn']")).Click();
            driver.FindElement(By.Id("logout_sidebar_link")).Click();
        }


    }
}
