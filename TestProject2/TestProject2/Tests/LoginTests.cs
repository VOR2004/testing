using NUnit.Framework;
using System.Threading;
using TestProject2.Common;
using TestProject2.Model;

namespace TestProject2.Tests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidData()
        {
            app.Auth.Logout();

            Thread.Sleep(5000);

            app.Navigation.OpenLoginPage();

            Thread.Sleep(5000);

            AccountData user = new AccountData(
                Settings.Login,
                Settings.Password
            );

            app.Auth.Login(user);

            Thread.Sleep(5000);

            Assert.That(app.Auth.IsLoggedIn(), Is.True);
        }

        [Test]
        public void LoginWithInvalidData()
        {
            app.Auth.Logout();

            Thread.Sleep(5000);

            app.Navigation.OpenLoginPage();

            Thread.Sleep(5000);

            AccountData user = new AccountData(
                Settings.Login,
                "wrong-password"
            );

            app.Auth.Login(user);

            Thread.Sleep(5000);

            Assert.That(app.Auth.IsLoggedIn(), Is.False);
        }
    }
}