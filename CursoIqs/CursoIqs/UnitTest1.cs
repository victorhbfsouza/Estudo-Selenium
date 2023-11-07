using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CursoIqs
{
    public class UnitTest1
    {
        public string user = "standard_user";
        public string password = "secret_sauce";

        [Fact]
        public void Test1()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");

            #region LOGIN COM SUCESSO
            driver.FindElement(By.XPath("//input[@id='user-name']")).SendKeys(user);
            driver.FindElement(By.Id("password")).SendKeys(password);
            driver.FindElement(By.Id("login-button")).Click();
            #endregion

            #region VALIDAÇÃO DE LOGIN POR ITEM NA TELA
            string msgSucsses = driver.FindElement(By.XPath("//span[@class='title']")).Text;
            Assert.Equal("Products", msgSucsses);
            #endregion

            #region LOGOUT
            driver.FindElement(By.XPath("//button[@id='react-burger-menu-btn']")).Click();
            driver.FindElement(By.Id("logout_sidebar_link")).Click();
            #endregion

            driver.Quit();
        }

        [Fact]
        public void Test2()
        {
            IWebDriver driver = new ChromeDriver();
            // A linha abaixo faz com que o programa aguarde o tempo informado para que caso não apareça dar erro
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");

            #region VERIFICAÇÃO DE LOGIN COM ERRO E VERIFICAÇÃO DE MENSAGEM
            driver.FindElement(By.XPath("//input[@id='user-name']")).SendKeys(user);
            driver.FindElement(By.Id("password")).SendKeys("senha errada");
            driver.FindElement(By.Id("login-button")).Click();

            // Neste caso, para o teste passar deve ser informado o username ou password errados
            string msgError = driver.FindElement(By.XPath("//h3[@data-test='error']")).Text;
            Assert.Equal("Epic sadface: Username and password do not match any user in this service", msgError);
            #endregion

            driver.Quit();
        }

        [Fact]
        public void Test3()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");

            #region LOGIN COM SUCESSO
            driver.FindElement(By.XPath("//input[@id='user-name']")).SendKeys(user);
            driver.FindElement(By.Id("password")).SendKeys(password);
            driver.FindElement(By.Id("login-button")).Click();
            #endregion

            #region VALIDAÇÃO DE LOGIN POR ITEM NA TELA
            string msgSucsses = driver.FindElement(By.XPath("//span[@class='title']")).Text;
            Assert.Equal("Products", msgSucsses);
            #endregion

            #region ADICIONA ITEM NO CARRINHO E FINALIZA A COMPRA RETORNANDO PARA HOME
            driver.FindElement(By.Id("add-to-cart-sauce-labs-fleece-jacket")).Click();
            driver.FindElement(By.XPath("//a[@class='shopping_cart_link']")).Click();
            driver.FindElement(By.Id("checkout")).Click();
            driver.FindElement(By.Id("first-name")).SendKeys("Calebe");
            driver.FindElement(By.Id("last-name")).SendKeys("Cleiton");
            driver.FindElement(By.Name("postalCode")).SendKeys("25640390");
            driver.FindElement(By.XPath("//input[@class='submit-button btn btn_primary cart_button btn_action']")).Click();
            driver.FindElement(By.XPath("//button[@class='btn btn_action btn_medium cart_button']")).Click();
            driver.FindElement(By.XPath("//button[@class='btn btn_primary btn_small']")).Click();
            #endregion

            #region LOGOUT
            driver.FindElement(By.XPath("//button[@id='react-burger-menu-btn']")).Click();
            driver.FindElement(By.Id("logout_sidebar_link")).Click();
            #endregion

            driver.Quit();
        }
    }
}