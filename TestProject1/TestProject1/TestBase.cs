using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace TestProject1
{
    public class TestBase
    {
        protected IWebDriver driver;
        public IDictionary<string, object> vars { get; private set; }
        protected IJavaScriptExecutor js;

        [SetUp]
        public void SetUp()
        {
            driver = new FirefoxDriver();
            js = (IJavaScriptExecutor)driver;
            vars = new Dictionary<string, object>();
        }

        [TearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }
        }

        public static void Pause()
        {
            Thread.Sleep(20000); // additional just for showcase
        }

        public void OpenLoginPage()
        {
            driver.Navigate().GoToUrl("https://my-checklist.ru/login/");
        }

        public void ResizeWindow()
        {
            driver.Manage().Window.Size = new System.Drawing.Size(1503, 778);
        }

        public void Login(AccountData user)
        {
            driver.FindElement(By.Id("username-3908")).Click();
            driver.FindElement(By.Id("username-3908")).SendKeys(user.Username);
            driver.FindElement(By.Id("user_password-3908")).Click();
            driver.FindElement(By.Id("user_password-3908")).SendKeys(user.Password);
            driver.FindElement(By.Id("um-submit-btn")).Click();
        }

        public void OpenNotesPage()
        {
            driver.Navigate().GoToUrl("https://my-checklist.ru/zametki-onlajn/");
        }

        public void SwitchMode()
        {
            driver.FindElement(By.Id("ej-rejim")).Click();
        }

        public void OpenList()
        {
            driver.FindElement(By.CssSelector(".home-list")).Click();
        }

        public void AddNote(NoteData note)
        {
            driver.FindElement(By.Id("newTodo")).Click();
            driver.FindElement(By.Id("newTodo")).SendKeys(note.Text);
            driver.FindElement(By.CssSelector(".submit-btn path")).Click();
        }
    }
}