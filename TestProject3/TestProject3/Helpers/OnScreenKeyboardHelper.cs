using FlaUI.Core.AutomationElements;
using FlaUI.Core.Input;
using FlaUI.Core.WindowsAPI;
using NUnit.Framework;
using System.Drawing;
using System.Windows.Forms;

namespace TestProject3.Helpers
{
    public class OnScreenKeyboardHelper
    {
        private AutomationElement desktop;

        public OnScreenKeyboardHelper(AutomationElement desktop)
        {
            this.desktop = desktop;
        }

        public void ClickButton(params string[] possibleNames)
        {
            AutomationElement? button = null;

            foreach (string name in possibleNames)
            {
                button = desktop.FindFirstDescendant(cf => cf.ByName(name));

                if (button != null)
                {
                    break;
                }
            }

            Assert.That(
                button,
                Is.Not.Null,
                "Не найдена кнопка экранной клавиатуры: " + string.Join(", ", possibleNames)
            );

            button.AsButton().Invoke();
        }

        public void ClickButtonByCoordinates(int x, int y)
        {
            var oskWindow = desktop.FindFirstDescendant(cf => cf.ByName("On-Screen Keyboard"))
                ?? desktop.FindFirstDescendant(cf => cf.ByName("Экранная клавиатура"));

            Assert.That(oskWindow, Is.Not.Null, "Не найдено окно экранной клавиатуры");

            var rectangle = oskWindow.BoundingRectangle;

            Mouse.Click(
                new Point(
                    (int)rectangle.Left + x,
                    (int)rectangle.Top + y
                )
            );
        }
        public void SwitchToEnglishIfNeeded()
        {
            string currentLayout = InputLanguage.CurrentInputLanguage.Culture.TwoLetterISOLanguageName;

            if (currentLayout != "en")
            {
                Keyboard.Press(VirtualKeyShort.LMENU); // Alt
                Keyboard.Press(VirtualKeyShort.SHIFT);

                Thread.Sleep(500);

                Keyboard.Release(VirtualKeyShort.SHIFT);
                Keyboard.Release(VirtualKeyShort.RMENU);

                Thread.Sleep(1000);
            }
        }
    }
}
