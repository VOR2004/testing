using NUnit.Framework;
using NUnit.Framework;
using TestProject1.Model;

namespace TestProject1.Tests
{

    [TestFixture]
    public class AddTest : TestBase
    {
        [Test]
        public void Add()
        {
            AccountData user = new AccountData(
                "mr.vor2006@mail.ru",
                "qwerty1987"
            );

            NoteData note = new NoteData("875875687568");

            app.Navigation.OpenLoginPage();
            app.Auth.Login(user);

            Thread.Sleep(3000);

            app.Navigation.OpenNotesPage();

            Thread.Sleep(3000);

            app.Note.SwitchMode();
            app.Note.OpenList();

            Thread.Sleep(3000);

            app.Note.AddNote(note);

            Thread.Sleep(3000);
        }
    }
}