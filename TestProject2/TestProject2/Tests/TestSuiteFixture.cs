using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace TestProject2.Tests
{
    [SetUpFixture]
    public class TestSuiteFixture
    {
        [OneTimeTearDown]
        public void StopAll()
        {
            AppManager.RemoveInstance(); // на случай, если инстансы все-таки не удалятся, а браузер не закроется
        }
    }
}
