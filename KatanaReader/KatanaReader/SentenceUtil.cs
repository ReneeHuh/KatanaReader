using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KatanaReader
{
     static class SentenceUtil
    {

        static public int FindPreviousSentence(string iText, int CursorLocation)
        {
            int[] SentenceLocation = new int[4];

            SentenceLocation[0] = iText.LastIndexOf(". ", CursorLocation);
            SentenceLocation[1] = iText.LastIndexOf("? ", CursorLocation);
            SentenceLocation[2] = iText.LastIndexOf("! ", CursorLocation);
            SentenceLocation[3] = iText.LastIndexOf("\n", CursorLocation);

            Array.Sort(SentenceLocation);

            if (SentenceLocation[3] >= 0 && SentenceLocation[3] < CursorLocation)
            {
                return SentenceLocation[3];
            }
            else if (SentenceLocation[2] >= 0 && SentenceLocation[2] < CursorLocation)
            {
                return SentenceLocation[2];
            }
            else if (SentenceLocation[1] >= 0 && SentenceLocation[1] < CursorLocation)
            {
                return SentenceLocation[1];
            }
            else if (SentenceLocation[0] >= 0 && SentenceLocation[0] < CursorLocation)
            {
                return SentenceLocation[0];
            }
            else
            {
                return 0;
            }
        }

        static public int FindNextSentence(string iText, int CursorLocation)
        {
            int[] SentenceLocation = new int[4];

            SentenceLocation[0] = iText.IndexOf(". ", CursorLocation);
            SentenceLocation[1] = iText.IndexOf("? ", CursorLocation);
            SentenceLocation[2] = iText.IndexOf("! ", CursorLocation);
            SentenceLocation[3] = iText.IndexOf(System.Environment.NewLine, CursorLocation);


            Array.Sort(SentenceLocation);

            if (SentenceLocation[0] > 0 && SentenceLocation[0] > CursorLocation)
            {
                return SentenceLocation[0];
            }
            else if (SentenceLocation[1] > 0 && SentenceLocation[1] > CursorLocation)
            {
                return SentenceLocation[1];
            }
            else if (SentenceLocation[2] > 0 && SentenceLocation[2] > CursorLocation)
            {
                return SentenceLocation[2];
            }
            else if (SentenceLocation[3] > 0 && SentenceLocation[3] > CursorLocation)
            {
                return SentenceLocation[3];
            }
            else
            {
                return FindPreviousSentence(iText, CursorLocation);
            }

        }

        static public int FindPreviousWord(string iText, int CursorLocation)
        {
            if (CursorLocation < 0)
            {
                CursorLocation = 0;
            }
            else if (CursorLocation > iText.Length)
            {
                CursorLocation = iText.Length;
            }
            int startWordLocation = iText.LastIndexOf(' ', CursorLocation);
            return startWordLocation;
        }

        static public int FindNextWord(string iText, int CursorLocation)
        {
            if (CursorLocation < 0)
            {
                CursorLocation = 0;
            }
            else if (CursorLocation > iText.Length)
            {
                CursorLocation = iText.Length;
            }

            int endWordLocation = iText.IndexOf(' ', CursorLocation);
            if (endWordLocation < 0) { endWordLocation = iText.Length; }


            return endWordLocation;
        }
    }
}
