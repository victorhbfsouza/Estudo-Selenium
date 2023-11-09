using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIqs
{

    public class Test : IDisposable
    {
        public IWebDriver driver;


        public Test()
        {
            driver = new ChromeDriver();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            driver.Manage().Window.Maximize();
        }

        public void Dispose()
        {
            driver.Quit();
        }

        [Fact]
        public void TestDemo()
        {
            LoginPage loginPage = new LoginPage(driver);
            HomePage homePage = new HomePage(driver);
            CartPage cartPage = new CartPage(driver);

            loginPage.LoginSucsses();
            homePage.AddItemCart();
            cartPage.RemoveItemCartReturnHome();
            homePage.Cart();
            cartPage.GoHome();
            homePage.Buy();
            homePage.AddItemCart();
            homePage.Cart();
            cartPage.CompleteBuy();
            homePage.AddItemCart();
            homePage.Cart();
            cartPage.RemoveItemCart();
            cartPage.GoHome();
            homePage.Logout();
            loginPage.LoginFailPassword();
        }
    }
}
