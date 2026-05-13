using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Xml.Serialization;
using TestProject2.Model;

namespace TestProject2.Tests
{
    [TestFixture]
    public class EditNoteTest : AuthBase
    {
        public static IEnumerable<EditNoteData> EditNoteDataFromXmlFile()
        {
            return (List<EditNoteData>)new XmlSerializer(typeof(List<EditNoteData>))
                .Deserialize(new StreamReader(@"TestData\editNotes.xml"));
        }

        [Test, TestCaseSource("EditNoteDataFromXmlFile")]
        public void EditNote(EditNoteData data)
        {
            NoteData originalNote = new NoteData(data.OriginalText);
            NoteData editedNote = new NoteData(data.EditedText);

            app.Navigation.OpenNotesPage();
            Thread.Sleep(3000);

            app.Note.SwitchMode();
            app.Note.OpenList();
            Thread.Sleep(3000);

            app.Note.AddNote(originalNote);
            Thread.Sleep(3000);

            Assert.That(app.Note.IsNotePresent(originalNote.Text), Is.True);

            app.Note.OpenFirstNote();
            Thread.Sleep(3000);

            app.Note.EditOpenedNote(editedNote);
            Thread.Sleep(3000);

            Assert.That(app.Note.IsNotePresent(editedNote.Text), Is.True);
        }
    }
}