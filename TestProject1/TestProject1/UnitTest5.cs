using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace TestProject1
{
    [TestFixture]
    public class PruebaUnitaria5
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
            driver.Navigate().GoToUrl("http://localhost/sis_inventario/ingreso");
            driver.FindElement(By.Name("ingUsuario")).Click();
            driver.FindElement(By.Name("ingUsuario")).Clear();
            driver.FindElement(By.Name("ingUsuario")).SendKeys("admin");
            driver.FindElement(By.Name("ingPassword")).Click();
            driver.FindElement(By.Name("ingPassword")).Clear();
            driver.FindElement(By.Name("ingPassword")).SendKeys("admin");
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            driver.FindElement(By.XPath("//li[6]/a/i")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Administrar ventas'])[1]/following::span[1]")).Click();
            Assert.AreEqual("Crear venta", driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Crear venta'])[2]/following::li[2]")).Text);
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
