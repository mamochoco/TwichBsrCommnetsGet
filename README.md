# TwichBsrCommnetsGet
Twitchのコメントから!bsrを検索しダウンロードするツール

[準備]
twitch APIを使用しているため事前にtwitchの登録とdevelopmentの登録が必要

https://dev.twitch.tv/

認証の設定が必要

下記サイトでクライアントIDとシークレットIDを取得

https://dev.twitch.tv/console/apps

権限の付与

コマンドプロンプトで柿コマンドを実行

        curl -X POST "https://id.twitch.tv/oauth2/token?client_id=クライアントID&client_secret=シークレットID&grant_type=client_credentials&scope=user:edit%20user:read:email%20user:read:broadcast%20chat:read%20chat:edit"

付与が終わればソースコードの変更

TwichCommentGet.csの""にそれぞれクライアントIDと権限を挿入してください

        // クライアントID
        const string TWITCH_CLIENT_ID = ""; // 自分のクライアントIDを使用してください
        const string TWITCH_V5CLiENT_ID = ""; // ←非推奨のため自分で検索してください。
        // 権限
        const string Author = "";// 自分の権限を使用してください

[アプリケーションの使い方]

上記設定を行い、ビルド＆実行を行うと下記画面が出てくる

![image](https://user-images.githubusercontent.com/101620250/158316970-6acd69df-e83e-447b-a308-43fd131d0642.png)

ユーザー名にtwitchのユーザー名を入力して検索ボタンを

押下するとアーカイブ情報を取得します。

![image](https://user-images.githubusercontent.com/101620250/158318172-d22c8171-ca89-4250-a1ae-3a263eb006a8.png)

アーカイブのリストからログを取得するアーカイブを選択し

ログ取得ボタンを押下するとコメントを取得します。

![image](https://user-images.githubusercontent.com/101620250/158318497-7081d460-ec3e-4175-aaba-00f469df43b4.png)

コメントから!bsr情報を取得しチェックボックスに表示します。

チェックを入れてダウンロードボタンを押下すると

保存先に書かれたファイルパスに曲を保存します。

![image](https://user-images.githubusercontent.com/101620250/158318872-a3189f4a-8017-4ed5-8969-f4c1a023d96e.png)


連絡先
Twitter : @sa_chocoed


