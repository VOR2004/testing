using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject2.Model
{
    public class EditNoteData
    {
        public EditNoteData()
        {
        }

        public EditNoteData(string originalText, string editedText)
        {
            OriginalText = originalText;
            EditedText = editedText;
        }

        public string OriginalText { get; set; }
        public string EditedText { get; set; }
    }
}
