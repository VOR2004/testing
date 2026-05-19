using System.Threading;
using FlaUI.Core.AutomationElements;
using NUnit.Framework;
using TestProject3.Helpers;

namespace TestProject3.Tests
{
    [TestFixture]
    public class OnScreenKeyboardTests : TestBase
    {
        [Test]
        public void OpenCmdUsingOnScreenKeyboard()
        {
            app.StartOnScreenKeyboard();
            Thread.Sleep(3000);

            AutomationElement desktop = app.GetDesktop();
            OnScreenKeyboardHelper keyboard = new OnScreenKeyboardHelper(desktop);

            keyboard.ClickButton("Windows", "Win", "Пуск", "Start");
            Thread.Sleep(2000);

            keyboard.SwitchToEnglishIfNeeded();

            keyboard.ClickButton("c", "C", "с", "С");
            Thread.Sleep(500);

            keyboard.ClickButton("m", "M", "ь", "Ь");
            Thread.Sleep(500);

            keyboard.ClickButton("d", "D", "в", "В");
            Thread.Sleep(1000);

            keyboard.ClickButton("Enter", "Ввод");
            Thread.Sleep(4000);

            AutomationElement cmdWindow =
                desktop.FindFirstDescendant(cf => cf.ByName("Command Prompt"))
                ?? desktop.FindFirstDescendant(cf => cf.ByName("Командная строка"));

            Assert.That(cmdWindow, Is.Not.Null);

            cmdWindow.AsWindow().Focus();
            Thread.Sleep(1000);

            keyboard.ClickButtonByCoordinates(25, 345);
            Thread.Sleep(1000);

            keyboard.ClickButton("Alt");
            Thread.Sleep(1000);

            keyboard.ClickButton("F4");
            Thread.Sleep(4000);

            AutomationElement closedCmdWindow =
                desktop.FindFirstDescendant(cf => cf.ByName("Command Prompt"))
                ?? desktop.FindFirstDescendant(cf => cf.ByName("Командная строка"));

            Assert.That(closedCmdWindow, Is.Null);
        }
    }
}