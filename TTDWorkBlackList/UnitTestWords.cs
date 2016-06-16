using Microsoft.VisualStudio.TestTools.UnitTesting;
using WBL;

namespace WordBlackListTests
{
    [TestClass]
    public class UnitTestWords
    {
        // sorry about the bad language, but it's to make a point. I tryed with generic words and ppl didnt get it 
        const string text = "holyfuck you fucktard you s u c k ass and get fucked assimetric metric";

        readonly static string[] fullList = { "metric" };
        readonly static string[] partialList = { "fuck", "suck", "ass" };
        readonly static string[] excludedList = { "assimetric" };

        const string text_partial = "******** you ******** you ******* *** and get ****** ********** metric";
        const string text_fullList = "holyfuck you fucktard you s u c k ass and get fucked assimetric ******";
        const string text_all = "******** you ******** you ******* *** and get ****** assimetric ******";

        //const string text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque lacus urna, vestibulum quis risus hendrerit, venenatis volutpat quam. Donec iaculis facilisis nunc a imperdiet. In pretium felis in dictum mollis. Praesent facilisis imperdiet massa ac pretium. Mauris ante risus, accumsan vel facilisis non, porta ut lorem. Donec in nisi sap\nien. Nulla a vehicula mi, quis elementum sem. Nam est tortor, scelerisque at nisl nec, maximus accumsan mi. Proin tempus vestibulum justo sed volutpat. Nunc porta ligula a lacus laoreet volutpat. Donec lobortis nibh ac dui auctor interdum. Integer sed purus placerat, placerat ante at, accumsan massa. Phasellus semper magna eu pellentesque blandit.\nEtiam tempus faucibus facilisis.Integer diam urna, mattis nec neque sed, euismod lobortis mi.Phasellus et velit nunc. Vestibulum suscipit at lorem vitae ornare. Aenean in luctus elit. Integer eget est suscipit, suscipit felis id, sodales lacus. Etiam in laoreet mauris, id scelerisque libero.\nSed tellus orci, sodales scelerisque convallis et, fermentum ultrices tortor.Duis dignissim feugiat nisi ac fringilla. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.Maecenas et dolor et ligula volutpat aliquam nec sit amet velit.Quisque vel velit blandit risus rhoncus posuere eget sit amet orci.Nam eget mi at odio tempus egestas interdum eget nullas. Donec vitae maximus est. Mauris egestas fringilla metus semper pulvinar. Integer egestas ullamcorper pretium. In eleifend leo at eros pellentesque, vitae facilisis leo dictum. Sed tincidunt egestas aliquam. Maecenas eu leo at nisi feugiat sollicitudin vitae vel leo. Aliquam ac mollis est. Proin venenatis mollis magna, nec tincidunt eros ornare a.Nulla maximus imperdiet lorem non dapibus.\nEtiam cursus id nisl ultrices tempor. Praesent imperdiet, arcu in pulvinar varius, augue erat aliquet est, id vulputate ligula ligula eget tellus. Vivamus porttitor mi metus, vel auctor nisl aliquet ac.Integer cursus vitae dolor eu lobortis. Praesent nec facilisis elit, at interdum turpis.Morbi consequat efficitur malesuada. Phasellus tristique lacus magna, suscipit finibus orci mollis id.Duis vitae justo sed risus sollicitudin semper.Etiam imperdiet nisl metus, sed porta leo scelerisque et. Donec at augue at libero pellentesque lobortis fringilla a orci. Maecenas sit amet enim mollis, hendrerit diam in, pulvinar velit.\nFusce rutrum sit amet eros eget pharetra. Nulla eleifend congue mollis. Fusce tristique ultrices risus, id laoreet mi hendrerit id.Quisque congue aliquet mauris. Integer cursus mattis sapien a condimentum. In eu dapibus justo. Pellentesque porttitor pulvinar cursus.";

        //readonly static string[] fullList = { "sapien", "nulla" };
        //readonly static string[] partialList = { "nec", "met" };
        //readonly static string[] excludedList = { "donec" };

        //const string text_fullList = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque lacus urna, vestibulum quis risus hendrerit, venenatis volutpat quam. Donec iaculis facilisis nunc a imperdiet. In pretium felis in dictum mollis. Praesent facilisis imperdiet massa ac pretium. Mauris ante risus, accumsan vel facilisis non, porta ut lorem. Donec in nisi ***\n***. ***** a vehicula mi, quis elementum sem. Nam est tortor, scelerisque at nisl nec, maximus accumsan mi. Proin tempus vestibulum justo sed volutpat. Nunc porta ligula a lacus laoreet volutpat. Donec lobortis nibh ac dui auctor interdum. Integer sed purus placerat, placerat ante at, accumsan massa. Phasellus semper magna eu pellentesque blandit.\nEtiam tempus faucibus facilisis.Integer diam urna, mattis nec neque sed, euismod lobortis mi.Phasellus et velit nunc. Vestibulum suscipit at lorem vitae ornare. Aenean in luctus elit. Integer eget est suscipit, suscipit felis id, sodales lacus. Etiam in laoreet mauris, id scelerisque libero.\nSed tellus orci, sodales scelerisque convallis et, fermentum ultrices tortor.Duis dignissim feugiat nisi ac fringilla. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.Maecenas et dolor et ligula volutpat aliquam nec sit amet velit.Quisque vel velit blandit risus rhoncus posuere eget sit amet orci.Nam eget mi at odio tempus egestas interdum eget nullas. Donec vitae maximus est. Mauris egestas fringilla metus semper pulvinar. Integer egestas ullamcorper pretium. In eleifend leo at eros pellentesque, vitae facilisis leo dictum. Sed tincidunt egestas aliquam. Maecenas eu leo at nisi feugiat sollicitudin vitae vel leo. Aliquam ac mollis est. Proin venenatis mollis magna, nec tincidunt eros ornare a.***** maximus imperdiet lorem non dapibus.\nEtiam cursus id nisl ultrices tempor. Praesent imperdiet, arcu in pulvinar varius, augue erat aliquet est, id vulputate ligula ligula eget tellus. Vivamus porttitor mi metus, vel auctor nisl aliquet ac.Integer cursus vitae dolor eu lobortis. Praesent nec facilisis elit, at interdum turpis.Morbi consequat efficitur malesuada. Phasellus tristique lacus magna, suscipit finibus orci mollis id.Duis vitae justo sed risus sollicitudin semper.Etiam imperdiet nisl metus, sed porta leo scelerisque et. Donec at augue at libero pellentesque lobortis fringilla a orci. Maecenas sit amet enim mollis, hendrerit diam in, pulvinar velit.\nFusce rutrum sit amet eros eget pharetra. ***** eleifend congue mollis. Fusce tristique ultrices risus, id laoreet mi hendrerit id.Quisque congue aliquet mauris. Integer cursus mattis ****** a condimentum. In eu dapibus justo. Pellentesque porttitor pulvinar cursus.";

        [TestMethod]
        public void NoStringNoLists()
        {
            WordBlackList wbl = new WordBlackList();
            string p = wbl.Process();
            Assert.AreEqual(p, "");
        }


        [TestMethod]
        public void NoStringBlackList()
        {
            WordBlackList wbl = new WordBlackList();

            string[] BlackList = null;
            wbl.SetList(BlackList, WordBlackList.wordListType.Full);
            string p = wbl.Process();

            Assert.AreEqual(p, string.Empty);
        }

        [TestMethod]
        public void NoStringAllLists()
        {
            WordBlackList wbl = new WordBlackList();

            string[] BlackList = fullList;
            string[] BlackListPartial = partialList;
            string[] BlackListExclusion = excludedList;
            wbl.SetList(BlackList, WordBlackList.wordListType.Full);
            wbl.SetList(BlackListPartial, WordBlackList.wordListType.Partial);
            wbl.SetList(BlackListExclusion, WordBlackList.wordListType.Exclusion);

            string p = wbl.Process();
            Assert.AreEqual(p, string.Empty);
        }

        [TestMethod]
        public void NoBlackList()
        {
            WordBlackList wbl = new WordBlackList();
            string s = text;
            wbl.SetString(s);
            string p = wbl.Process();
            Assert.AreEqual(p, text);
        }

        [TestMethod]
        public void NullString()
        {
            WordBlackList wbl = new WordBlackList();
            string s = null;
            wbl.SetString(s);
            string[] BlackList = fullList;
            wbl.SetList(BlackList, WordBlackList.wordListType.Full);
            string p = wbl.Process();
            Assert.AreEqual(p, string.Empty);
        }

        [TestMethod]
        public void EmptyString()
        {
            WordBlackList wbl = new WordBlackList();
            string s = string.Empty;
            wbl.SetString(s);
            string[] BlackList = fullList;
            wbl.SetList(BlackList, WordBlackList.wordListType.Full);
            string p = wbl.Process();
            Assert.AreEqual(p, string.Empty);
        }

        [TestMethod]
        public void NullBlackList()
        {
            WordBlackList wbl = new WordBlackList();
            string s = text;
            wbl.SetString(s);
            string[] BlackList = null;
            wbl.SetList(BlackList, WordBlackList.wordListType.Full);
            string p = wbl.Process();
            Assert.AreEqual(p, text);
        }

        [TestMethod]
        public void EmptyBlackList()
        {
            WordBlackList wbl = new WordBlackList();
            string s = text;
            wbl.SetString(s);
            string[] BlackList = new string[] { };
            wbl.SetList(BlackList, WordBlackList.wordListType.Full);
            string p = wbl.Process();
            Assert.AreEqual(p, text);
        }


        [TestMethod]
        public void FullWords()
        {
            WordBlackList wbl = new WordBlackList();
            string s = text;
            wbl.SetString(s);
            string[] BlackList = fullList;
            wbl.SetList(BlackList, WordBlackList.wordListType.Full);
            string p = wbl.Process();
            Assert.AreEqual(p, text_fullList);
        }

        [TestMethod]
        public void PartialWords()
        {
            WordBlackList wbl = new WordBlackList();
            string s = text;
            wbl.SetString(s);
            string[] BlackList = partialList;
            wbl.SetList(BlackList, WordBlackList.wordListType.Partial);
            string p = wbl.Process();
            Assert.AreEqual(p, text_partial);
        }

        [TestMethod]
        public void Exclusions()
        {
            WordBlackList wbl = new WordBlackList();
            string s = text;
            wbl.SetString(s);
            string[] BlackList = fullList;
            wbl.SetList(BlackList, WordBlackList.wordListType.Full);
            string[] BlackListExlusinons = excludedList;
            wbl.SetList(excludedList, WordBlackList.wordListType.Exclusion);
            string p = wbl.Process();
            Assert.AreEqual(p, text_fullList);
        }

        [TestMethod]
        public void AllLists()
        {
            WordBlackList wbl = new WordBlackList();
            string s = text;
            wbl.SetString(s);
            string[] BlackList = fullList;
            wbl.SetList(BlackList, WordBlackList.wordListType.Full);
            string[] BlackListPartial = partialList;
            wbl.SetList(BlackListPartial, WordBlackList.wordListType.Partial);
            string[] BlackListExlusinons = excludedList;
            wbl.SetList(excludedList, WordBlackList.wordListType.Exclusion);
            string p = wbl.Process();
            Assert.AreEqual(p, text_all);
        }
    }
}
