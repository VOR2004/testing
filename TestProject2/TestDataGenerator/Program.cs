using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using TestProject2.Model;

namespace TestDataGenerator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length < 4)
            {
                Console.WriteLine("Usage: TestDataGenerator.exe type count filename format");
                Console.WriteLine("Types: add, delete, edit");
                return;
            }

            string type = args[0];
            int count = Convert.ToInt32(args[1]);
            string filename = args[2];
            string format = args[3];

            if (format != "xml")
            {
                Console.WriteLine("Only xml format is supported");
                return;
            }

            if (type == "add")
            {
                List<NoteData> notes = GenerateNotes(count, "Add note ");
                WriteToXmlFile(notes, filename);
            }
            else if (type == "delete")
            {
                List<NoteData> notes = GenerateNotes(count, "Delete note ");
                WriteToXmlFile(notes, filename);
            }
            else if (type == "edit")
            {
                List<EditNoteData> notes = GenerateEditNotes(count);
                WriteToXmlFile(notes, filename);
            }
            else
            {
                Console.WriteLine("Unknown type: " + type);
            }
        }

        private static List<NoteData> GenerateNotes(int count, string prefix)
        {
            List<NoteData> notes = new List<NoteData>();

            for (int i = 0; i < count; i++)
            {
                notes.Add(new NoteData(prefix + i));
            }

            return notes;
        }

        private static List<EditNoteData> GenerateEditNotes(int count)
        {
            List<EditNoteData> notes = new List<EditNoteData>();

            for (int i = 0; i < count; i++)
            {
                notes.Add(new EditNoteData(
                    "Original note " + i,
                    "Edited note " + i
                ));
            }

            return notes;
        }

        private static void WriteToXmlFile<T>(List<T> data, string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));

            using (StreamWriter writer = new StreamWriter(filename))
            {
                serializer.Serialize(writer, data);
            }
        }
    }
}