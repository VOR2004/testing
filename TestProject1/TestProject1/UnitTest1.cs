using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium.BiDi.Input;

namespace TestProject1
{
    [TestFixture]
    public class AuthorizationTest : TestBase
    {
        [Test]
        public void Authorization()
        {
            AccountData user = new AccountData("mr.vor2006@mail.ru", "qwerty1987");
            OpenLoginPage();
            ResizeWindow();
            Login(user);
            //Pause();
        }
    }
}