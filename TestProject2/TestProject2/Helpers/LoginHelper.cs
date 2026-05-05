using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TestProject2.Model;
using TestProject2.Helpers;

namespace TestProject2.Helpers
{

    public class LoginHelper : HelperBase
    {
        public LoginHelper(AppManager manager)
            : base(manager)
        {
        }

        public void Login(AccountData user)
        {
            driver.FindElement(By.Id("username-3908")).Click();
            driver.FindElement(By.Id("username-3908")).Clear();
            driver.FindElement(By.Id("username-3908")).SendKeys(user.Username);

            driver.FindElement(By.Id("user_password-3908")).Click();
            driver.FindElement(By.Id("user_password-3908")).Clear();
            driver.FindElement(By.Id("user_password-3908")).SendKeys(user.Password);

            driver.FindElement(By.Id("um-submit-btn")).Click();
        }
    }
}
