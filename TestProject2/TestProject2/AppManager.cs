using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TestProject2.Common;
using TestProject2.Helpers;

namespace TestProject2
{
    public class AppManager
    {
        private static ThreadLocal<AppManager?> app = new ThreadLocal<AppManager?>();

        private IWebDriver driver;
        private string baseUrl;

        private NavigationHelper navigation;
        private LoginHelper auth;
        private NoteHelper note;

        private AppManager()
        {
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();

            baseUrl = Settings.BaseURL;

            navigation = new NavigationHelper(this, baseUrl);
            auth = new LoginHelper(this);
            note = new NoteHelper(this);
        }

        public static AppManager GetInstance()
        {
            if (!app.IsValueCreated || app.Value == null)
            {
                app.Value = new AppManager();
            }
            return app.Value;
        }

        public static void RemoveInstance()
        {
            if (app.IsValueCreated && app.Value != null)
            {
                try
                {
                    app.Value.driver.Quit();
                }
                catch (Exception)
                {
                    // ignore
                }

                app.Value = null;
            }
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

        public void ClearCookies()
        {
            driver.Manage().Cookies.DeleteAllCookies();
        }

        ~AppManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // ignore
            }
        }
    }
}
