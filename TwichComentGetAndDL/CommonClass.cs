using System;
using System.Collections.Generic;
using System.Text;

namespace TwichComentGetAndDL
{
    class CommonClass
    {
        public static Form1 form1;
        public string ArchiveName { get; set; }
        public string ArchiveID { get; set; }
        public static int DownloadCnt{ get; set; }
        public static int DownloadMaxCnt { get; set; }

        public void Setform(Form1 parents)
        {
            form1 = parents;
        }

        public void UISendTextMessage(string message)
        {
            form1.textBox1.Text = message;
        }

        public static void DownloadCntInit()
        {
            DownloadCnt = 0;
            DownloadMaxCnt = 0;
        }

        public static string BlankAdd(string srcstr, int addblank)
        {
            string straddtemp = srcstr;
            for (int i = 0; addblank - srcstr.Length - i > 0; i++)
            {
                straddtemp += " ";
            }
            return straddtemp;
        }

    }

}
