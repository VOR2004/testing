using System.Threading;
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

            Thread.Sleep(3000);

            app.Auth.Login(user);

            Thread.Sleep(3000);

            Assert.AreNotEqual("https://my-checklist.ru/login/", app.Driver.Url);
        }
    }
}