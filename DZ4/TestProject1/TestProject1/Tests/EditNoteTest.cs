using System.Threading;
using NUnit.Framework;
using TestProject1.Model;

namespace TestProject1.Tests
{
    [TestFixture]
    public class EditNoteTest : TestBase
    {
        [Test]
        public void EditNote()
        {
            AccountData user = new AccountData(
                "mr.vor2006@mail.ru",
                "qwerty1987"
            );

            NoteData originalNote = new NoteData("Первая версия заметки");
            NoteData editedNote = new NoteData("Измененная версия заметки");

            app.Navigation.OpenLoginPage();

            Thread.Sleep(3000);

            app.Auth.Login(user);

            Thread.Sleep(3000);

            app.Navigation.OpenNotesPage();

            Thread.Sleep(3000);

            app.Note.SwitchMode();
            app.Note.OpenList();

            Thread.Sleep(3000);

            app.Note.AddNote(originalNote);

            Thread.Sleep(3000);

            Assert.IsTrue(app.Note.IsNotePresent(originalNote.Text));

            app.Note.OpenFirstNote();

            Thread.Sleep(3000);

            app.Note.EditOpenedNote(editedNote);

            Thread.Sleep(3000);

            Assert.IsTrue(app.Note.IsNotePresent(editedNote.Text));
        }
    }
}