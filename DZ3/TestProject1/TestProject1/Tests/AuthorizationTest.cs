using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium.BiDi.Input;
using NUnit.Framework;
using TestProject1.Model;

namespace TestProject1.Tests
{

    [TestFixture]
    public class AuthorizationTest : TestBase
    {
        [Test]
        public void Authorization()
        {
            AccountData user = new AccountData(
                "mr.vor2006@mail.ru",
                "qwerty1987"
            );

            app.Navigation.OpenLoginPage();
            app.Auth.Login(user);
        }
    }
}