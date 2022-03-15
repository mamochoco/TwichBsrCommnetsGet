using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Net;
using Microsoft.Extensions.Configuration;
using System.IO;


namespace TwichComentGetAndDL
{
    class TwichCommentGet
    {
        // アクセスURL
        private const string RequestChannelURL = "https://api.twitch.tv/helix/search/channels?";
        private const string RequestStreamMakerURL = "https://api.twitch.tv/helix/";
        private const string RequestVideoURL = "https://api.twitch.tv/v5/videos/";
        // クライアントID
        const string TWITCH_CLIENT_ID = ""; // 自分のクライアントIDを使用してください
        const string TWITCH_V5CLiENT_ID = ""; // 非推奨のやり方のためそのうち変更が必要。もしくは出来なくなる可能性がある。
        // 権限
        const string Author = "";// 自分の権限を使用してください

        public List<CommonClass> TwitchArchiveList;
        private const string SearchWord = "!bsr";
        public List<string> SearchResultBsrID;

        public string AccessTwitchUser(string userID)
        {
            // 初期化処理
            string twitchid = "";
            TwitchArchiveList = new List<CommonClass>();

            //入力チェック
            if (userID == "")
            {
                TwichCommentGetSendMessage("空白以外の文字を入力してください。" +
                    "\r\n(Please enter non-white space characters)");
                return "";
            }

            //Twitchのユーザー検索を行いユーザーが存在する場合は、アーカイブを取得する
            var webResponse = SendHttpMessage(RequestChannelURL + "query=" + userID, TWITCH_CLIENT_ID);
            using (var reader = new StreamReader(webResponse))
            {
                dynamic tempData = JObject.Parse(reader.ReadToEnd());
                JObject UserSearchtemp;
                UserSearchtemp = tempData;
                JArray jArray = (JArray)UserSearchtemp["data"];
                foreach(JObject item in jArray)
                {
                    string strtemp = item["broadcaster_login"].ToString();
                    
                    //ユーザーが存在するかチェックする
                    if (strtemp == userID)
                    {
                        twitchid = item["id"].ToString();
                        GetTwitchStreamArchiveData(twitchid);
                        TwichCommentGetSendMessage("リストに最近のアーカイブ情報を表示しました。" +
                            "\r\n(Recently archived information was displayed in the list.)");
                    }
                }
            }
            if(twitchid == "")
            {
                TwichCommentGetSendMessage("ユーザーが存在しません。\r\n(User does not exist)");
            }
            return twitchid;
        }

        public void GetTwitchStreamArchiveData(string twitchid)
        {
            // 初期化処理
            TwitchArchiveList.Clear();

            // 入力チェック
            if (twitchid == "")
            {
                return;
            }

            //ダウンロード基のURL
            string urlquary = "videos?user_id=" + twitchid + "&first=10&type=archive";
            var webResponse = SendHttpMessage(RequestStreamMakerURL + urlquary, TWITCH_CLIENT_ID);

            //ArchiveからビデオIDとタイトルを取得する
            using (var reader = new StreamReader(webResponse))
            {
                dynamic tempData = JObject.Parse(reader.ReadToEnd());
                //JObject UserSearchtemp = tempData;
                JArray jArray = (JArray)tempData["data"];
                foreach (JObject item in jArray)
                {
                    string strtemp = item["type"].ToString();
                    if (strtemp == "archive")
                    {
                        CommonClass Listtemp = new CommonClass();
                        Listtemp.ArchiveID = item["id"].ToString();
                        Listtemp.ArchiveName = "[" + item["created_at"].ToString() + "] " + item["title"].ToString();
                        TwitchArchiveList.Add(Listtemp);
                    }
                    else
                    {
                        Console.WriteLine(strtemp);
                    }
                }
            }
        }

        public void GetTwitchStreamComment(string videoID)
        {
            // 初期化処理
            SearchResultBsrID = new List<string>();

            // ダウンロード基のURL
            string urlquary = RequestVideoURL + videoID + "/comments?content_offset_seconds=0";
            var webResponse = SendHttpMessage(urlquary, TWITCH_V5CLiENT_ID);

            // ビデオID先のコメントを取得する
            using (var reader = new StreamReader(webResponse))
            {
                JObject UserSearchtemp = JObject.Parse(reader.ReadToEnd());
                //dynamic tempData = JObject.Parse(reader.ReadToEnd());
                //JObject UserSearchtemp = tempData;
                JArray jArray = (JArray)UserSearchtemp["comments"];
                foreach (JObject item in jArray)
                {
                    string strtemp = item["message"]["body"].ToString();
                    if (strtemp.StartsWith(SearchWord))
                    {
                        SearchResultBsrID.Add(strtemp);
                    }
                    else
                    {
                        Console.WriteLine(strtemp);
                    }
                }
                //commentが多い場合はnextに次のコメント情報が入るため、再度取得する
                bool IsNextComment;
                IsNextComment = UserSearchtemp.ContainsKey("_next");
                while(IsNextComment)
                {
                    
                    urlquary = RequestVideoURL + videoID + "/comments?cursor=" +UserSearchtemp["_next"].ToString();
                    
                    webResponse = SendHttpMessage(urlquary, TWITCH_V5CLiENT_ID);
                    using (var rereader = new StreamReader(webResponse))
                    {
                        UserSearchtemp = JObject.Parse(rereader.ReadToEnd());
                        //tempData = JObject.Parse(rereader.ReadToEnd());
                        //UserSearchtemp = tempData;
                        jArray = (JArray)UserSearchtemp["comments"];
                        foreach (JObject item in jArray)
                        {
                            string strtemp = item["message"]["body"].ToString();
                            if (strtemp.StartsWith(SearchWord))
                            {
                                SearchResultBsrID.Add(strtemp);
                            }
                            else
                            {
                            }
                        }
                    }
                    IsNextComment = UserSearchtemp.ContainsKey("_next");
                }
            }
        }
        public Stream SendHttpMessage(string URL, string client_id)
        {
            //ダウンロード基のURL
            var apiEndpoint = URL;
            var request = (HttpWebRequest)WebRequest.Create(apiEndpoint);

            // 使用する API のバージョン
            request.Headers.Add("Accept", @"application/json");
            request.Accept = $@"application/vnd.twitchtv.v5+json";

            // クライアントIDと権限を指定する
            request.Headers.Add("Client-ID", client_id);
            request.Headers.Add("Authorization", Author);
            var webResponse = request.GetResponse();

            return webResponse.GetResponseStream();
        }

        public void TwichCommentGetSendMessage(string message)
        {
            CommonClass sendmessage = new CommonClass();
            sendmessage.UISendTextMessage(message);
        }

    }
    
}
