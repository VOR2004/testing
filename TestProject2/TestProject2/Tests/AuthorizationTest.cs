using NUnit.Framework;
using System.Threading;
using TestProject2.Model;

namespace TestProject2.Tests
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

            Assert.That("https://my-checklist.ru/login/", Is.Not.EqualTo(app.Driver.Url));
        }
    }
}