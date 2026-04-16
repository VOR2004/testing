using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using TestProject1.Helpers;

namespace TestProject1
{

    public class AppManager
    {
        private IWebDriver driver;
        private string baseUrl;

        private NavigationHelper navigation;
        private LoginHelper auth;
        private NoteHelper note;

        public AppManager()
        {
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();

            baseUrl = "https://my-checklist.ru";

            navigation = new NavigationHelper(this, baseUrl);
            auth = new LoginHelper(this);
            note = new NoteHelper(this);
        }

        public IWebDriver Driver
        {
            get { return driver; }
        }

        public NavigationHelper Navigation
        {
            get { return navigation; }
        }

        public LoginHelper Auth
        {
            get { return auth; }
        }

        public NoteHelper Note
        {
            get { return note; }
        }

        public void Stop()
        {
            driver.Quit();
        }
    }
}
