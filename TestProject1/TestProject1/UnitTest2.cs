using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class PruebaUnitaria1
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://www.google.com/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void ThePruebaUnitaria2Test()
        {
            driver.Navigate().GoToUrl("http://localhost/sis_inventario/");
            driver.FindElement(By.Name("ingUsuario")).Click();
            driver.FindElement(By.Name("ingUsuario")).Clear();
            driver.FindElement(By.Name("ingUsuario")).SendKeys("admin");
            driver.FindElement(By.Name("ingPassword")).Click();
            driver.FindElement(By.Name("ingPassword")).Clear();
            driver.FindElement(By.Name("ingPassword")).SendKeys("1234");
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            Assert.AreEqual("Error al ingresar, vuelve a intentarlo", driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Ingresar'])[1]/following::div[1]")).Text);
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}