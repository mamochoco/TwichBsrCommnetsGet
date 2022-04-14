using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Xml.Linq;
using HtmlAgilityPack;
using ScrapySharp.Extensions;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;


namespace TwichComentGetAndDL
{
    public partial class Form1 : Form
    {
        private List<CommonClass> ArchiveInfo;
        private List<string> BsrInfos;
        static CommonClass u;

        public Form1()
        {
            InitializeComponent();
            u = new CommonClass();
            u.Setform(this);
        }

        void init()
        {
            ArchiveList.Text = "";
            textBox1.Text = "";
            if (ArchiveInfo == null)
            {
                ArchiveInfo = new List<CommonClass>();
            }
            else
            {
                ArchiveInfo.Clear();
                ArchiveList.Items.Clear();
            }
            if (BsrInfos == null)
            {
                BsrInfos = new List<string>();
            }
            else
            {
                BsrInfoCheckBox.Items.Clear();
                BsrInfos.Clear();
                BsrInfoCheckBox.Items.Clear();
            }
        }
        private void AccessButton_Click(object sender, EventArgs e)
        {
            // 初期化処理
            init();

            // 入力チェック
            if (BCNameTextBox.Text == "")
            {
                textBox1.Text = "空白以外の文字を入力してください。\r\n(Please enter non-white space characters)";
                return;
            }

            // ユーザが存在するか確認する
            TwichCommentGet userID = new TwichCommentGet();
            if (userID.AccessTwitchUser(BCNameTextBox.Text) == "")
            {
                return;
            }

            // Archive情報をリストにセットする
            ArchiveInfo = userID.TwitchArchiveList;
            foreach (var strtemp in ArchiveInfo)
            {
                ArchiveList.Items.Add(strtemp.ArchiveName);
            }
        }


        private void BSRGetButton_Click(object sender, EventArgs e)
        {
            // 初期化処理
            textBox1.Text = "";
            BsrInfoCheckBox.Items.Clear();
            BsrInfos.Clear();

            // 入力チェック
            if (ArchiveList.Text == "")
            {
                textBox1.Text = "アーカイブが選択されていません\r\n(Archive not selected)";
                return;
            }

            // Archiveからコメントを取得
            TwichCommentGet userID = new TwichCommentGet();
            userID.AccessTwitchUser(BCNameTextBox.Text);
            foreach (var strtemp in ArchiveInfo)
            {
                if (strtemp.ArchiveName == ArchiveList.Text)
                {
                    userID.GetTwitchStreamComment(strtemp.ArchiveID);
                }
            }

            // 取得したbsr情報から名前を取得する
            List<string> tempbsrinfo = userID.SearchResultBsrID;
            int commentcnt = 0;
            foreach (var strtemp in tempbsrinfo)
            {
                textBox1.Text = "ログから名前を取得中です:" + commentcnt.ToString() + " / " + tempbsrinfo.Count.ToString() + "" +
                    "\r\n(Getting the name from the log :" + commentcnt.ToString() + " / " + tempbsrinfo.Count.ToString() + ")";
                string tempBsrID = strtemp.Remove(0, 5);
                string BsrName = SongDownloader.GetNameDataCompleted(tempBsrID);
                if (BsrName != "")
                {
                    string strbsrid = CommonClass.BlankAdd(strtemp, 15);
                    BsrInfoCheckBox.Items.Add(strbsrid + BsrName);
                    BsrInfos.Add(tempBsrID);
                    commentcnt++;
                }
            }

            textBox1.Text = "ログを取得しました\r\n(Log retrieved)"; ;

        }

        private void DLButton_Click(object sender, EventArgs e)
        {
            CommonClass.DownloadCntInit();
            CommonClass.DownloadMaxCnt = BsrInfoCheckBox.CheckedItems.Count;
            
            // 入力チェック
            if(BsrInfoCheckBox.CheckedItems.Count == 0)
            {
                textBox1.Text = "曲が選択されていません。\r\n(Song not selected)";
                return;
            }

            // bsr情報から曲の取得
            textBox1.Text = "曲を取得しています : " + CommonClass.DownloadCnt.ToString() + " / " + CommonClass.DownloadMaxCnt.ToString() +
                        "\r\n(I'm getting a song : " + CommonClass.DownloadCnt.ToString() + " / " + CommonClass.DownloadMaxCnt.ToString() + ")";
            for (int i = 0; i != BsrInfoCheckBox.Items.Count; i++)
            {
                if (BsrInfoCheckBox.GetItemChecked(i))
                {
                    SongDownloader songDL = new SongDownloader();
                    songDL.DownloadSongCoroutine(FilePathtextBox.Text, BsrInfos[i]);
                }
            }
        }

    }
}


