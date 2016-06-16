using System;

namespace WBL
{
    public class WordBlackList
    {
        private string[] blackListFull;
        private string[] blackListPartial;
        private string[] blackListExclusion;
        private string s;

        public readonly char[] WordBreakChars = { ' ', '\n', '\r', '\t', '\v', '\f' };

        const string ReplaceChar = "*";
        const string NotImplementedExceptionMsg = "List type not implemented.";

        public enum wordListType
        {
            Partial,
            Full,
            Exclusion
        }

        public WordBlackList()
        {
        }

        public void SetString(string s)
        {
            this.s = s;
        }

        public void SetList(string[] wordList, wordListType type)
        {
            switch (type)
            {
                case wordListType.Partial:
                    {
                        blackListPartial = wordList;
                        break;
                    }
                case wordListType.Full:
                    {
                        blackListFull = wordList;
                        break;
                    }
                case wordListType.Exclusion:
                    {
                        blackListExclusion = wordList;
                        break;
                    }
                default:
                    {
                        throw new NotImplementedException(this.GetType().ToString() + ": SetList: " + NotImplementedExceptionMsg);
                    }
            }
        }

        public string Process()
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return "";
            }

            if (blackListPartial != null && blackListPartial.GetLength(0) > 0)
            {
                ProcessBlackList(wordListType.Partial);
            }

            if (blackListFull != null && blackListFull.GetLength(0) > 0)
            {
                ProcessBlackList(wordListType.Full);
            }

            return s;
        }

        private void ProcessBlackList(wordListType type)
        {
            string[] blackList = { };
            switch(type)
            {
                case wordListType.Partial:
                    blackList = blackListPartial;
                    break;
                case wordListType.Full:
                    blackList = blackListFull;
                    break;
                default:
                    throw new NotImplementedException(this.GetType().ToString() + ": SetList: " + NotImplementedExceptionMsg);
            }

            foreach (var bl in blackList)
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

                            if (CheckSize(type, size, startIndex, LetterIndex))
                            {
                                int startOfString = startIndex;
                                int endOfString = LetterIndex;

                                string PartialWord = bl;

                                PartialWord = GetComposedWord(startIndex, LetterIndex, type, ref startOfString, ref endOfString);

                                if (IsToRemove(PartialWord))
                                {
                                    s = s.Remove(startOfString, endOfString).Insert(startOfString, new string(ReplaceChar[0], endOfString));
                                }
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

        private bool IsToRemove(string PartialWord)
        {
            var Remove = true;
            if (blackListExclusion != null && blackListExclusion.Length > 0)
            {
                foreach (var exclusion in blackListExclusion)
                {
                    if (exclusion == PartialWord)
                    {
                        Remove = false;
                        break;
                    }
                }
            }

            return Remove;
        }

        private bool CheckSize(wordListType type, int size, int startIndex, int LetterIndex)
        {
            bool checkSize = LetterIndex >= size;
            if (type == wordListType.Full)
            {
                checkSize = checkSize &&
                    (startIndex + LetterIndex == s.Length || s.Substring(startIndex + LetterIndex).StartsWith(" ")) &&
                    (startIndex == 0 || s.Substring(startIndex - 1).StartsWith(" "));
            }

            return checkSize;
        }

        private string GetComposedWord(int startIndex, int LetterIndex, wordListType type, ref int startOfString, ref int endOfString)
        {
            int startOfPartialString = startOfString;
            int endOfPartialString = endOfString;

            for (int WordBreakCharsCounter = 0; WordBreakCharsCounter < WordBreakChars.Length - 1; WordBreakCharsCounter++)
            {
                startOfPartialString = s.Substring(0, startIndex).LastIndexOf(WordBreakChars[WordBreakCharsCounter]);
                if (startOfPartialString != -1)
                {
                    startOfPartialString++;
                    break;
                }
            }

            for (int WordBreakCharsCounter = 0; WordBreakCharsCounter < WordBreakChars.Length - 1; WordBreakCharsCounter++)
            {
                endOfPartialString = s.Substring(startIndex + LetterIndex).IndexOf(WordBreakChars[WordBreakCharsCounter]);
                if (endOfPartialString != -1)
                {
                    //EndOfString--;
                    break;
                }
            }

            //For start and end of string
            startOfPartialString = startOfPartialString == -1 ? 0 : startOfPartialString;
            endOfPartialString = endOfPartialString == -1 ? s.Length - startIndex : endOfPartialString + startIndex + LetterIndex - startOfPartialString;

            if (type == wordListType.Partial)
            {
                startOfString = startOfPartialString;
                endOfString = endOfPartialString;
                return s.Substring(startOfString, endOfString);
            }

            if (type == wordListType.Full)
            {
                var PartialWord = s.Substring(startOfPartialString, endOfPartialString);
                foreach(var word in WordBreakChars)
                {
                    return PartialWord.Replace(word.ToString(), "");
                }
            }

            throw new NotImplementedException(this.GetType().ToString() + ": SetList: " + NotImplementedExceptionMsg);
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