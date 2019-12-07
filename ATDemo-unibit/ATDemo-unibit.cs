using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace ATDemo_unibit
{
    [TestClass]
    public class ATDemo
    {
        private IWebDriver driver;
        [TestInitialize]
        public void SetUp()
        {
            driver = new ChromeDriver();
        }
        [TestCleanup]
        public void TearDown()
        {
            driver.Quit();
        }
        [TestMethod]
        public void invalidmailorPass()
        {
            driver.Navigate().GoToUrl("https://www2.hm.com/bg_bg/index.html");
            driver.Manage().Window.Size = new System.Drawing.Size(1366, 728);
            driver.FindElement(By.LinkText("Вход")).Click();
            {
                var element = driver.FindElement(By.LinkText("Вход"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(element).Perform();
            }
            {
                var element = driver.FindElement(By.TagName("body"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(element, 0, 0).Perform();
            }
            driver.FindElement(By.Id("modal-txt-signin-email")).Click();
            driver.FindElement(By.Id("modal-txt-signin-email")).SendKeys("invalid_mail@gmail.com");
            driver.FindElement(By.Id("modal-txt-signin-password")).Click();
            driver.FindElement(By.Id("modal-txt-signin-password")).SendKeys("123456");
            driver.FindElement(By.CssSelector(".js-set-session-storage")).Click();
            System.Threading.Thread.Sleep(3000);
            Assert.AreEqual(driver.FindElement(By.Id("modal-txt-signin-password-unknown-error-type-error")).Text,"Грешен имейл или парола, моля, опитайте отново.");
        }
        
        }
    }

