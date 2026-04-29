using System;
using System.Collections.Generic;
using System.Text;

using System.Threading;
using NUnit.Framework;
using TestProject1.Model;

namespace TestProject1.Tests
{
    [TestFixture]
    public class DeleteNoteTest : TestBase
    {
        [Test]
        public void DeleteNote()
        {
            AccountData user = new AccountData(
                "mr.vor2006@mail.ru",
                "qwerty1987"
            );

            NoteData note = new NoteData("Тест заметка для удаления");

            app.Navigation.OpenLoginPage();
            Thread.Sleep(3000);

            app.Auth.Login(user);
            Thread.Sleep(3000);

            app.Navigation.OpenNotesPage();
            Thread.Sleep(3000);

            app.Note.SwitchMode();
            app.Note.OpenList();
            Thread.Sleep(3000);

            app.Note.AddNote(note);
            Thread.Sleep(3000);

            Assert.IsTrue(app.Note.IsNotePresent(note.Text));

            app.Note.DeleteFirstNote();
            Thread.Sleep(3000);

            Assert.IsTrue(app.Note.IsNoteNotPresent(note.Text));
        }
    }
}
