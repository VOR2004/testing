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
            if (IsLoggedIn())
            {
                if (IsLoggedIn(user.Username))
                {
                    return;
                }

                Logout();
            }

            manager.Navigation.OpenLoginPage();

            IWebElement username = driver.FindElement(By.Id("username-3908"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", username);
            username.Clear();
            username.SendKeys(user.Username);

            IWebElement password = driver.FindElement(By.Id("user_password-3908"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", password);
            password.Clear();
            password.SendKeys(user.Password);

            driver.FindElement(By.Id("um-submit-btn")).Click();
        }

        public void Logout()
        {
            driver.Manage().Cookies.DeleteAllCookies();
            manager.Navigation.OpenHomePage();
        }

        public bool IsLoggedIn()
        {
            return driver.Manage().Cookies.AllCookies
                .Any(cookie => cookie.Name.Contains("wordpress_logged_in"));
        }

        public bool IsLoggedIn(string username)
        {
            return IsLoggedIn();
        }
    }
}
