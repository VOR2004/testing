using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Xml.Serialization;
using TestProject2.Model;
using TestProject2.Tests;

namespace TestProject2.Tests
{
    [TestFixture]
    public class AddTest : TestBase
    {
        public static IEnumerable<NoteData> NoteDataFromXmlFile()
        {
            return (List<NoteData>)new XmlSerializer(typeof(List<NoteData>))
                .Deserialize(new StreamReader(@"TestData\notes.xml"));
        }

        [Test, TestCaseSource("NoteDataFromXmlFile")]
        public void Add(NoteData note)
        {
            AccountData user = new AccountData(
                "mr.vor2006@mail.ru",
                "qwerty1987"
            );

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

            Assert.That(app.Note.IsNotePresent(note.Text));
        }
    }
}