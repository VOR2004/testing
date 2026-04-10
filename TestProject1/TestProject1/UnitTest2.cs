using NUnit.Framework;
using TestProject1;

namespace TestProject1
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

            NoteData note = new NoteData("56577888888");

            OpenLoginPage();
            Login(user);

            OpenNotesPage();
            SwitchMode();
            OpenList();
            AddNote(note);
            Pause();
        }
    }

}