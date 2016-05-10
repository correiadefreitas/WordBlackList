using System;

namespace TTDWordBlackList
{
    internal class WordBlackList
    {
        private string[] blackList;
        private string[] blackListPartial;
        private string[] blackListExclusion;
        private string s;
        const string ReplaceChar = "*";

        public WordBlackList(string[] blackList)
        {
            this.blackList = blackList;
        }

        public WordBlackList(string s)
        {
            this.s = s;
        }

        public WordBlackList(string s, string[] blackList) : this(s)
        {
            this.blackList = blackList;
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

            if (blackList == null || blackList.GetLength(0) == 0)
            {
                if (blackListPartial == null || blackListPartial.GetLength(0) == 0)
                {
                    return string.Empty;
                }
                else
                {
                    if (blackListExclusion == null || blackListExclusion.GetLength(0) == 0)
                    {
                        //Just Partial
                    }
                    else
                    {
                        //Partial + Exclusions
                    }

                }
            }
            else
            {
                if (blackListPartial == null || blackListPartial.GetLength(0) == 0)
                {
                    // Just Full
                    foreach(var bl in blackList)
                    {
                        var size = bl.Length;
                        if(size > 1)
                        { 

                            char start = bl[0];
                            var startIndex = s.IndexOf(start);
                            var restIndex = 0;
                            do
                            {
                                restIndex = s.Length - start;
                                if (restIndex > bl.Length)
                                { 
                                    for (var l = startIndex + 1; l < restIndex; l++)
                                    {
                                        if (s.Substring(l,restIndex).TrimStart().Length != 0)
                                        {
                                            var rest = s.Substring(l, restIndex).TrimStart();
                                            var i = 1;

                                            if (s.Substring(l, restIndex).TrimStart().StartsWith(bl[i].ToString()))
                                            {
                                                i++;
                                            }
                                        }

                                    }
                                    ////if (i == size)
                                    ////{

                                    ////    startIndex[l] =
                                    ////        }
                                    ////else
                                    ////{
                                    ////    startIndex[l] = start + startIndex[l];
                                    ////}
                                }

                                startIndex = s.IndexOf(start);

                            } while (startIndex != -1);
                            s.IndexOf(bl);
                        }
                        else
                        { 
                            s.Replace(bl, ReplaceChar);
                        }
                    }
                    
                }
                else
                {
                    if (blackListExclusion == null || blackListExclusion.GetLength(0) == 0)
                    {
                        // Full + Partial
                    }
                    else
                    {
                        // Full + Partial + Exclusions
                    }
                }
            }



            return s;
        }
    }
}