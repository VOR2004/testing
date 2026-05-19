using NUnit.Framework;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestProject3;

namespace TestProject3.Tests
{
    public class TestBase
    {
        protected AppManager app;

        [SetUp]
        public void Setup()
        {
            app = new AppManager();
        }

        [TearDown]
        public void TearDown()
        {
            if (app != null)
            {
                app.Stop();
            }
        }
    }
}
