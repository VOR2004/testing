using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestProject2.Common;
using TestProject2.Model;

namespace TestProject2.Tests
{
    public class AuthBase : TestBase
    {
        [SetUp]
        public void SetupAuth()
        {
            AccountData user = new AccountData(Settings.Login, Settings.Password);
            app.Auth.Login(user);
        }
    }
}
