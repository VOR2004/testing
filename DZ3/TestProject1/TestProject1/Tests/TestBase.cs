using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;
using NUnit.Framework;

namespace TestProject1.Tests
{

    public class TestBase
    {
        protected AppManager app;

        [SetUp]
        public void SetupTest()
        {
            app = new AppManager();
        }

        [TearDown]
        public void TeardownTest()
        {
            app.Stop();
        }
    }
}