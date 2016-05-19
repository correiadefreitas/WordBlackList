using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TTDWordBlackList
{
    [TestClass]
    public class UnitTestWords
    {
        const string text = "fucksuckfuck";
        readonly static string[] fullList = { "fuck", "suck" };
        const string text_fullList = "************";

        readonly static string[] partialList = { "ass" };
        readonly static string[] excludedList = { "assimetric" };


        //const string text = "holyfuck you fucktard you s u c k and get fucked";
        //readonly static string[] fullList = { "fuck", "suck" };
        //const string text_fullList = "******** you ******** you ******* and get ******";

        //readonly static string[] partialList = { "ass" };
        //readonly static string[] excludedList = { "assimetric" };



        //const string text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque lacus urna, vestibulum quis risus hendrerit, venenatis volutpat quam. Donec iaculis facilisis nunc a imperdiet. In pretium felis in dictum mollis. Praesent facilisis imperdiet massa ac pretium. Mauris ante risus, accumsan vel facilisis non, porta ut lorem. Donec in nisi sap\nien. Nulla a vehicula mi, quis elementum sem. Nam est tortor, scelerisque at nisl nec, maximus accumsan mi. Proin tempus vestibulum justo sed volutpat. Nunc porta ligula a lacus laoreet volutpat. Donec lobortis nibh ac dui auctor interdum. Integer sed purus placerat, placerat ante at, accumsan massa. Phasellus semper magna eu pellentesque blandit.\nEtiam tempus faucibus facilisis.Integer diam urna, mattis nec neque sed, euismod lobortis mi.Phasellus et velit nunc. Vestibulum suscipit at lorem vitae ornare. Aenean in luctus elit. Integer eget est suscipit, suscipit felis id, sodales lacus. Etiam in laoreet mauris, id scelerisque libero.\nSed tellus orci, sodales scelerisque convallis et, fermentum ultrices tortor.Duis dignissim feugiat nisi ac fringilla. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.Maecenas et dolor et ligula volutpat aliquam nec sit amet velit.Quisque vel velit blandit risus rhoncus posuere eget sit amet orci.Nam eget mi at odio tempus egestas interdum eget nullas. Donec vitae maximus est. Mauris egestas fringilla metus semper pulvinar. Integer egestas ullamcorper pretium. In eleifend leo at eros pellentesque, vitae facilisis leo dictum. Sed tincidunt egestas aliquam. Maecenas eu leo at nisi feugiat sollicitudin vitae vel leo. Aliquam ac mollis est. Proin venenatis mollis magna, nec tincidunt eros ornare a.Nulla maximus imperdiet lorem non dapibus.\nEtiam cursus id nisl ultrices tempor. Praesent imperdiet, arcu in pulvinar varius, augue erat aliquet est, id vulputate ligula ligula eget tellus. Vivamus porttitor mi metus, vel auctor nisl aliquet ac.Integer cursus vitae dolor eu lobortis. Praesent nec facilisis elit, at interdum turpis.Morbi consequat efficitur malesuada. Phasellus tristique lacus magna, suscipit finibus orci mollis id.Duis vitae justo sed risus sollicitudin semper.Etiam imperdiet nisl metus, sed porta leo scelerisque et. Donec at augue at libero pellentesque lobortis fringilla a orci. Maecenas sit amet enim mollis, hendrerit diam in, pulvinar velit.\nFusce rutrum sit amet eros eget pharetra. Nulla eleifend congue mollis. Fusce tristique ultrices risus, id laoreet mi hendrerit id.Quisque congue aliquet mauris. Integer cursus mattis sapien a condimentum. In eu dapibus justo. Pellentesque porttitor pulvinar cursus.";

        //readonly static string[] fullList = { "sapien", "nulla" };
        //readonly static string[] partialList = { "nec", "met" };
        //readonly static string[] excludedList = { "donec" };

        //const string text_fullList = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque lacus urna, vestibulum quis risus hendrerit, venenatis volutpat quam. Donec iaculis facilisis nunc a imperdiet. In pretium felis in dictum mollis. Praesent facilisis imperdiet massa ac pretium. Mauris ante risus, accumsan vel facilisis non, porta ut lorem. Donec in nisi ***\n***. ***** a vehicula mi, quis elementum sem. Nam est tortor, scelerisque at nisl nec, maximus accumsan mi. Proin tempus vestibulum justo sed volutpat. Nunc porta ligula a lacus laoreet volutpat. Donec lobortis nibh ac dui auctor interdum. Integer sed purus placerat, placerat ante at, accumsan massa. Phasellus semper magna eu pellentesque blandit.\nEtiam tempus faucibus facilisis.Integer diam urna, mattis nec neque sed, euismod lobortis mi.Phasellus et velit nunc. Vestibulum suscipit at lorem vitae ornare. Aenean in luctus elit. Integer eget est suscipit, suscipit felis id, sodales lacus. Etiam in laoreet mauris, id scelerisque libero.\nSed tellus orci, sodales scelerisque convallis et, fermentum ultrices tortor.Duis dignissim feugiat nisi ac fringilla. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.Maecenas et dolor et ligula volutpat aliquam nec sit amet velit.Quisque vel velit blandit risus rhoncus posuere eget sit amet orci.Nam eget mi at odio tempus egestas interdum eget nullas. Donec vitae maximus est. Mauris egestas fringilla metus semper pulvinar. Integer egestas ullamcorper pretium. In eleifend leo at eros pellentesque, vitae facilisis leo dictum. Sed tincidunt egestas aliquam. Maecenas eu leo at nisi feugiat sollicitudin vitae vel leo. Aliquam ac mollis est. Proin venenatis mollis magna, nec tincidunt eros ornare a.***** maximus imperdiet lorem non dapibus.\nEtiam cursus id nisl ultrices tempor. Praesent imperdiet, arcu in pulvinar varius, augue erat aliquet est, id vulputate ligula ligula eget tellus. Vivamus porttitor mi metus, vel auctor nisl aliquet ac.Integer cursus vitae dolor eu lobortis. Praesent nec facilisis elit, at interdum turpis.Morbi consequat efficitur malesuada. Phasellus tristique lacus magna, suscipit finibus orci mollis id.Duis vitae justo sed risus sollicitudin semper.Etiam imperdiet nisl metus, sed porta leo scelerisque et. Donec at augue at libero pellentesque lobortis fringilla a orci. Maecenas sit amet enim mollis, hendrerit diam in, pulvinar velit.\nFusce rutrum sit amet eros eget pharetra. ***** eleifend congue mollis. Fusce tristique ultrices risus, id laoreet mi hendrerit id.Quisque congue aliquet mauris. Integer cursus mattis ****** a condimentum. In eu dapibus justo. Pellentesque porttitor pulvinar cursus.";

        [TestMethod]
        public void NoStringBlackList()
        {
            string[] BlackList = null;
            WordBlackList wbl = new WordBlackList(BlackList);
            string p = wbl.Process();
            Assert.AreEqual(p, string.Empty);
        }

        [TestMethod]
        public void NoStringAllLists()
        {
            string[] BlackList = fullList;
            string[] BlackListPartial = partialList;
            string[] BlackListExclusion = excludedList;
            WordBlackList wbl = new WordBlackList(BlackList, BlackListPartial, BlackListExclusion);
            string p = wbl.Process();
            Assert.AreEqual(p, string.Empty);
        }

        [TestMethod]
        public void NoBlackList()
        {
            string s = text;
            WordBlackList wbl = new WordBlackList(s);
            string p = wbl.Process();
            Assert.AreEqual(p, text);
        }

        [TestMethod]
        public void NullString()
        {
            string[] BlackList = fullList;
            string s = null;
            WordBlackList wbl = new WordBlackList(s, BlackList);
            string p = wbl.Process();
            Assert.AreEqual(p, string.Empty);
        }

        [TestMethod]
        public void EmptyString()
        {
            string[] BlackList = fullList;
            string s = string.Empty;
            WordBlackList wbl = new WordBlackList(s, BlackList);
            string p = wbl.Process();
            Assert.AreEqual(p, string.Empty);
        }

        [TestMethod]
        public void NullBlackList()
        {
            string[] BlackList = null;
            string s = text;
            WordBlackList wbl = new WordBlackList(s, BlackList);
            string p = wbl.Process();
            Assert.AreEqual(p, text);
        }

        [TestMethod]
        public void EmptyBlackList()
        {
            string[] BlackList = new string[] { };
            string s = text;
            WordBlackList wbl = new WordBlackList(s, BlackList);
            string p = wbl.Process();
            Assert.AreEqual(p, text);
        }


        [TestMethod]
        public void FullWords()
        {
            string[] BlackList = fullList;
            string s = text;
            WordBlackList wbl = new WordBlackList(s, BlackList);
            string p = wbl.Process();
            Assert.AreEqual(p, text_fullList);
        }

        [TestMethod]
        public void PartialWords()
        {
            string[] BlackList = new string[] { };
            string[] BlackListPartial = partialList;
            string[] BlackListExclusion = new string[] { };
            string s = text;
            WordBlackList wbl = new WordBlackList(s, BlackList, BlackListPartial, BlackListExclusion);
            string p = wbl.Process();
            Assert.AreEqual(p, "");
        }

        [TestMethod]
        public void Exclusions()
        {
            string[] BlackList = new string[] { };
            string[] BlackListPartial = partialList;
            string[] BlackListExclusion = excludedList;
            string s = text;
            WordBlackList wbl = new WordBlackList(s, BlackList, BlackListPartial, BlackListExclusion);
            string p = wbl.Process();
            Assert.AreEqual(p, "");
        }

        [TestMethod]
        public void AllLists()
        {
            string[] BlackList = fullList;
            string[] BlackListPartial = partialList;
            string[] BlackListExclusion = excludedList;
            string s = text;
            WordBlackList wbl = new WordBlackList(s, BlackList, BlackListPartial, BlackListExclusion);
            string p = wbl.Process();
            Assert.AreEqual(p, "");
        }
    }
}
