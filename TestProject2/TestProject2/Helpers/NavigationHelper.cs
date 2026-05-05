using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TestProject2.Helpers;

namespace TestProject2.Helpers
{
    public class NavigationHelper : HelperBase
    {
        private string baseUrl;

        public NavigationHelper(AppManager manager, string baseUrl)
            : base(manager)
        {
            this.baseUrl = baseUrl;
        }

        public void OpenLoginPage()
        {
            driver.Navigate().GoToUrl(baseUrl + "/login/");
        }

        public void OpenNotesPage()
        {
            driver.Navigate().GoToUrl(baseUrl + "/zametki-onlajn/");
        }
    }
}
