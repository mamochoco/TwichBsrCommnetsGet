using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Net;

namespace TwichComentGetAndDL
{
    class SongDownloader
    {
        // WebClientフィールド
        System.Net.WebClient DownloadClient = null;
        //ダウンロードしたファイルの保存先
        string SaveFilePath = "";
        // APIに接続するURL
        private const string RequestBeatSaverURL = "https://api.beatsaver.com/maps/id/";

        static public  string GetNameDataCompleted(string mapid)
        {
            string mapname = "";
            //ダウンロード基のURL
            string urlquary = RequestBeatSaverURL + mapid;
            var apiEndpoint = urlquary;

            try
            {
                var request = (HttpWebRequest)WebRequest.Create(apiEndpoint);
                var webResponse = request.GetResponse();

                using (var reader = new StreamReader(webResponse.GetResponseStream()))
                {
                    dynamic tempData = JObject.Parse(reader.ReadToEnd());
                    JObject UserSearchtemp = tempData;
                    mapname = tempData.GetValue("name").ToString();
                }
            }
            catch
            {
            }
            return mapname;
        }

        public void DownloadSongCoroutine(string FilePath, string BSkeys)
        {
            // 保存先
            SaveFilePath = FilePath;
            //ダウンロード基のURL
            string urlquary = RequestBeatSaverURL + BSkeys;
            var apiEndpoint = urlquary;

            try
            {
                var request = (HttpWebRequest)WebRequest.Create(apiEndpoint);
                var webResponse = request.GetResponse();

                using (var reader = new StreamReader(webResponse.GetResponseStream()))
                {
                    // ダウンロードURLの取得
                    dynamic tempData = JObject.Parse(reader.ReadToEnd());
                    JObject UserSearchtemp = tempData;
                    var aclist = UserSearchtemp.GetValue("versions").ToString();
                    aclist = aclist.TrimStart('[');
                    aclist = aclist.TrimEnd(']');
                    UserSearchtemp = JObject.Parse(aclist);
                    string DownloadURL = UserSearchtemp.GetValue("downloadURL").ToString();

                    
                    // WebClientの作成
                    if (DownloadClient == null)
                    {
                        DownloadClient = new System.Net.WebClient();
                        //イベントハンドラの作成
                        DownloadClient.DownloadDataCompleted += new System.Net.DownloadDataCompletedEventHandler(downloadClient_DownloadDataCompleted);
                    }

                    // BeatSaverにアクセスを開始する
                    // 妥協案:ParameterにmapIDを挿入する
                    Uri u = new Uri(DownloadURL);
                    DownloadClient.DownloadDataAsync(u, BSkeys);
                }
            }
            catch
            {
            }
        }

        private void downloadClient_DownloadDataCompleted(object sender, System.Net.DownloadDataCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                SongDownLoaderSendMessage("処理がタイムアウトしました。\r\n(Processing timed out)");
            }
            else if (e.Error != null)
            {
                Console.WriteLine("エラー:{0}", e.Error.Message);
                SongDownLoaderSendMessage("エラーが発生しました。\r\n(An error has occurred)");
            }
            else
            {
                byte[] sourceData = e.Result;

                
                try
                {
                    string dstZIP = SaveFilePath +"\\"+ e.UserState;
                    string tempZIP = SaveFilePath + "\\" + e.UserState + ".zip";
                    if (!Directory.Exists(dstZIP))
                    {
                        Directory.CreateDirectory(dstZIP);
                    }

                    // Zip展開した結果を取り出すストリーム
                    System.IO.MemoryStream zipStream = null;
                    zipStream = new System.IO.MemoryStream(sourceData);
                    zipStream.Seek(0, SeekOrigin.Begin);

                    //ZipInputStreamオブジェクトの作成
                    System.IO.FileStream fs = new System.IO.FileStream(tempZIP, FileMode.Create, FileAccess.ReadWrite);
                    zipStream.WriteTo(fs);
                    fs.Seek(0, SeekOrigin.Begin);

                    //妥協案:zipファイルを一時保存し、展開する
                    fs.Write(sourceData, 0, sourceData.Length);
                    fs.Close();

                    //zipファイルの展開
                    using (var z = System.IO.Compression.ZipFile.OpenRead(tempZIP))
                    {
                        foreach (var entry in z.Entries)
                        {
                            using (var r = new StreamReader(entry.Open()))
                            {
                                string uncompressedFile = Path.Combine(dstZIP, entry.Name);
                                File.WriteAllText(uncompressedFile, r.ReadToEnd());
                            }
                        }
                    }

                    // 終了処理
                    zipStream.Close();
                    File.Delete(tempZIP);
                    SongDownLoaderFinishSendMessage();
                }
                catch (Exception)
                {
                }
                
            }
        }

        public void SongDownLoaderSendMessage(string message)
        {
            CommonClass sendmessage = new CommonClass();
            sendmessage.UISendTextMessage(message);
        }

        public void SongDownLoaderFinishSendMessage()
        {
            CommonClass.DownloadCnt++;
            if(CommonClass.DownloadCnt == CommonClass.DownloadMaxCnt)
            {
                SongDownLoaderSendMessage("曲の取得が終了しました : " + CommonClass.DownloadCnt.ToString() + " / " + CommonClass.DownloadMaxCnt.ToString() +
                    "\r\nThe acquisition of the song is finished : " + CommonClass.DownloadCnt.ToString() + " / " + CommonClass.DownloadMaxCnt.ToString() + ")");
            }
            else
            {
                SongDownLoaderSendMessage("曲を取得しています : " + CommonClass.DownloadCnt.ToString() + " / " + CommonClass.DownloadMaxCnt.ToString() +
                    "\r\n(I'm getting a song : " + CommonClass.DownloadCnt.ToString() + " / " + CommonClass.DownloadMaxCnt.ToString() + ")");
            }
        }
    }
}
