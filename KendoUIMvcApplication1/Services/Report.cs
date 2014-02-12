using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Word = Microsoft.Office.Interop.Word;

namespace ScheduleOfFaculty.Services
{
    public class Report
    {
        private static string PATH = String.Format(@"{0}Reports\Report.docx", AppDomain.CurrentDomain.BaseDirectory);
        private static string SAVE_AS = String.Format(@"{0}Reports\WordReport.docx", AppDomain.CurrentDomain.BaseDirectory);
        public byte[] GetDocument() {
            byte[] fileStream = null;
            try
            {
                MicrosoftWord();
                fileStream = File.ReadAllBytes(SAVE_AS);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
            return fileStream;
        }
        private void MicrosoftWord()
        {
            var wordApp = new Word.Application();
            wordApp.Visible = false;
            try
            {
                if (!File.Exists(@PATH))
                {
                    File.Create(@PATH);
                }
                var wordDocument = wordApp.Documents.Open(@PATH);
                Word.Table table;
                Word.Range range = wordDocument.Content;
                table = wordDocument.Tables.Add(range, 100, 10);
                table.Range.ParagraphFormat.SpaceAfter = 6;
                int r, c;
                string strText;
                for (r = 1; r <= 100; r++)
                    for (c = 1; c <= 10; c++)
                    {
                        strText = Guid.NewGuid().ToString();
                        table.Cell(r, c).Range.Text = strText;
                    }
                table.Rows[1].Range.Font.Bold = 1;
                table.Rows[1].Range.Font.Italic = 1;
                table.Borders.Enable = 1;
                wordDocument.SaveAs(@SAVE_AS);
                wordApp.Visible = false;
                wordDocument.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("System has found exception : " + ex);
            }
            finally
            {
                wordApp.Quit();
            }
        }

        private void RangeWordDocument(string marker, string text, Word.Document wordDocument)
        {
            var range = wordDocument.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: marker, ReplaceWith: text);
        }
    }
}