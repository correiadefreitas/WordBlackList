using System;
using QandA;

namespace PresentationLayer
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Click(object sender, EventArgs e)
        {
            var wbl = new WordBlackList();

            wbl.SetString(txt.Text);

            wbl.SetList(new string[] { "metric" }, WordBlackList.wordListType.Full);
            wbl.SetList(new string[] { "fuck", "suck", "ass" }, WordBlackList.wordListType.Partial);
            wbl.SetList(new string[] { "assimetric" }, WordBlackList.wordListType.Exclusion);

            lt.Text = wbl.Process();
        }
    }
}