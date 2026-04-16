using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using TestProject1.Model;

namespace TestProject1.Helpers
{

    public class NoteHelper : HelperBase
    {
        public NoteHelper(AppManager manager)
            : base(manager)
        {
        }

        public void SwitchMode()
        {
            driver.FindElement(By.Id("ej-rejim")).Click();
        }

        public void OpenList()
        {
            driver.FindElement(By.CssSelector(".home-list")).Click();
        }

        public void AddNote(NoteData note)
        {
            driver.FindElement(By.Id("newTodo")).Click();
            driver.FindElement(By.Id("newTodo")).Clear();
            driver.FindElement(By.Id("newTodo")).SendKeys(note.Text);
            driver.FindElement(By.CssSelector(".submit-btn path")).Click();
        }
    }
}
