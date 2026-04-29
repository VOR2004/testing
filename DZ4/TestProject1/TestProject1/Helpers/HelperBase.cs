using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace TestProject1.Helpers
{

    public class HelperBase
    {
        protected AppManager manager;
        protected IWebDriver driver;

        public HelperBase(AppManager manager)
        {
            this.manager = manager;
            this.driver = manager.Driver;
        }
    }
}
