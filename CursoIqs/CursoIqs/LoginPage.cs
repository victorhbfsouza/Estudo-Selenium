using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoIqs
{
    public class LoginPage
    {
        public string user = "standard_user";
        public string password = "secret_sauce";

        public IWebDriver driver;

        public By UserNameInput => By.XPath("//input[@id='user-name']");
        public By PasswordInput => By.XPath("//input[@id='password']");

        public LoginPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        public void LoginSucsses()
        {
            #region LOGIN COM SUCESSO
            driver.FindElement(UserNameInput).SendKeys(user);
            driver.FindElement(PasswordInput).SendKeys(password);
            driver.FindElement(By.Id("login-button")).Click();
            #endregion

            #region VALIDAÇÃO DE LOGIN POR ITEM NA TELA
            string msgSucsses = driver.FindElement(By.XPath("//span[@class='title']")).Text;
            Assert.Equal("Products", msgSucsses);
            #endregion
        }

        public void LoginFailPassword()
        {
            #region VERIFICAÇÃO DE LOGIN COM ERRO E VERIFICAÇÃO DE MENSAGEM
            driver.FindElement(UserNameInput).SendKeys(user);
            // Neste caso, para o teste passar deve ser informado o username ou password errados
            driver.FindElement(PasswordInput).SendKeys("senha errada");
            driver.FindElement(By.Id("login-button")).Click();
            string msgError = driver.FindElement(By.XPath("//h3[@data-test='error']")).Text;
            Assert.Equal("Epic sadface: Username and password do not match any user in this service", msgError);
            #endregion
        }
    }
}
