using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject2.Model
{
    public class NoteData
    {
        public NoteData()
        {
        }

        public NoteData(string text)
        {
            Text = text;
        }

        public string Text { get; set; }
    }
}
