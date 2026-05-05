using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TestProject2.Model;
using TestProject2.Helpers;

namespace TestProject2.Helpers
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
            driver.FindElement(By.CssSelector(".submit-btn > svg")).Click();
        }

        public void OpenFirstNote()
        {
            driver.FindElement(By.CssSelector(".todo-item:nth-child(1)")).Click();
        }

        public void EditOpenedNote(NoteData note)
        {
            driver.FindElement(By.CssSelector(".name-details")).Click();
            driver.FindElement(By.CssSelector(".name-details")).Clear();
            driver.FindElement(By.CssSelector(".name-details")).SendKeys(note.Text);
            driver.FindElement(By.CssSelector(".modal-mod-for-goal")).Click();
        }

        public bool IsNotePresent(string text)
        {
            return driver.PageSource.Contains(text);
        }

        public void DeleteFirstNote()
        {
            driver.FindElement(By.CssSelector(".todo-item:nth-child(1) svg")).Click();
            driver.FindElement(By.CssSelector(".confirm-btn")).Click();
        }

        public bool IsNoteNotPresent(string text)
        {
            var elements = driver.FindElements(By.CssSelector(".todo-item"));
            foreach (var el in elements)
            {
                if (el.Text.Contains(text))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
