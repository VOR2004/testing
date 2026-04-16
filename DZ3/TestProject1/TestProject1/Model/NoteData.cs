using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject1.Model
{
    public class NoteData
    {
        public NoteData(string text)
        {
            Text = text;
        }

        public string Text { get; set; }
    }
}
