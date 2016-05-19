using System;

namespace TTDWordBlackList
{
    internal class WordBlackList
    {
        private string[] blackListFull;
        private string[] blackListPartial;
        private string[] blackListExclusion;
        private string s;
        const string ReplaceChar = "*";
        public readonly char[] WordBreakChars = { ' ', '\n', '\r', '\t', '\v', '\f' };

        public WordBlackList(string[] blackList)
        {
            this.blackListFull = blackList;
        }

        public WordBlackList(string s)
        {
            this.s = s;
        }

        public WordBlackList(string s, string[] blackList) : this(s)
        {
            this.blackListFull = blackList;
        }

        public WordBlackList(string[] blackList, string[] blackListPartial, string[] blackListExclusion) : this(blackList)
        {
            this.blackListPartial = blackListPartial;
            this.blackListExclusion = blackListExclusion;
        }

        public WordBlackList(string s, string[] blackList, string[] blackListPartial, string[] blackListExclusion) : this(s, blackList)
        {
            this.blackListPartial = blackListPartial;
            this.blackListExclusion = blackListExclusion;
        }

        public string Process()
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return string.Empty;
            }


            if (blackListPartial == null || blackListPartial.GetLength(0) == 0)
            {
                ProcessBlackListFull();
            }


            if (blackListFull == null || blackListFull.GetLength(0) == 0)
            {

            }

            return s;
        }

        private void ProcessBlackListFull()
        {
            // Just Full
            foreach (var bl in blackListFull)
            {
                var size = bl.Length;
                if (size > 1)
                {

                    char start = bl[0];
                    var startIndex = s.IndexOf(start);
                    var restIndex = 0;
                    int LetterIndex = 0;
                    while (startIndex != -1)
                    {
                        restIndex = s.Length - startIndex;
                        
                        if (restIndex >= bl.Length)
                        {
                            LetterIndex = FindWord(bl, startIndex, restIndex);

                            if (LetterIndex >= size)
                            {
                                int startOfString = startIndex;
                                int EndOfString = LetterIndex;

                                GetComposedWord(startIndex, LetterIndex, ref startOfString, ref EndOfString);

                                //For start and end of string
                                startOfString = startOfString == -1 ? 0 : startOfString;
                                EndOfString = EndOfString == -1 ? restIndex : EndOfString + startIndex + LetterIndex - startOfString;

                                s = s.Remove(startOfString, EndOfString).Insert(startOfString, new string(ReplaceChar[0], EndOfString));
                            }
                        }

                        startIndex = s.IndexOf(start, startIndex + LetterIndex);

                    }
                    s.IndexOf(bl);
                }
                else
                {
                    s.Replace(bl, ReplaceChar);
                }
            }
        }

        private void GetComposedWord(int startIndex, int LetterIndex, ref int startOfString, ref int EndOfString)
        {
            for (int WordBreakCharsCounter = 0; WordBreakCharsCounter < WordBreakChars.Length - 1; WordBreakCharsCounter++)
            {
                startOfString = s.Substring(0, startIndex).LastIndexOf(WordBreakChars[WordBreakCharsCounter]);
                if (startOfString != -1)
                {
                    startOfString++;
                    break;
                }
            }

            for (int WordBreakCharsCounter = 0; WordBreakCharsCounter < WordBreakChars.Length - 1; WordBreakCharsCounter++)
            {
                EndOfString = s.Substring(startIndex + LetterIndex).IndexOf(WordBreakChars[WordBreakCharsCounter]);
                if (EndOfString != -1)
                {
                    //EndOfString--;
                    break;
                }
            }
        }

        private int FindWord(string bl, int startIndex, int restIndex)
        {
            var NextLetterIndexInString = 1;
            var NextLetterIndexInBlackList = 1;
            for (var l = startIndex + 1; l < s.Length + 1; l++)
            {
                if (NextLetterIndexInBlackList < bl.Length)
                {
                    var sub = s.Substring(l + NextLetterIndexInString - NextLetterIndexInBlackList, restIndex - NextLetterIndexInString);
                    if (sub.TrimStart().Length != 0)
                    {
                        if (sub.TrimStart().StartsWith(bl[NextLetterIndexInBlackList].ToString()))
                        {
                            NextLetterIndexInString += sub.IndexOf(bl[NextLetterIndexInBlackList].ToString()) + 1;
                            NextLetterIndexInBlackList++;
                        }
                        else
                        {
                            break;
                        }
                    }
                }

            }

            return NextLetterIndexInString;
        }
    }
}