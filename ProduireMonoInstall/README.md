# プロデルをLinuxで使う

日本語プログラミング言語「プロデル」は，メインの実装が .NET Framework ベースであり Windows 向けの機能が充実していますが，[mono版も提供されている](https://rdr.utopiat.net/files/mono.html)ため，他のシステムでも利用できます．
基本的に公式ページの説明通りにやれば導入すれば問題ないですが，若干いじったところもあるため初心者の方でも利用しやすいよう，導入からアンインストールまでの流れをまとめておきます．

**2023/01/28 現在**の情報です．
動作確認は WSL2 の Ubuntu 22.04.1 LTS で行っています．
環境によって（特にmonoのインストールについて）ちょいちょいコマンドが変わるので公式ページを確認して該当部分をすげ替えてください．

## インストール

monoをインストールし，プロデルの実行ファイルを展開します．

※注：

* 最初の4行は[mono公式のダウンロードページ](https://www.mono-project.com/download/stable/#download-lin)の記載に従う．以下は Ubuntu 20.04 用．バージョンが上な分には問題ないはず．
現在のmono版プロデルは Mono6.12 向けなのでバージョンを指定しておく[^ver]
* GUI関係の機能のため？[^gtk] libgtk2.0-dev のモジュールがないと警告が出るため一緒にインストールしておく．
* 以下ではプロデルが "`./produire-mono/`" に展開されるがお好みで変更可．

```sh
# install mono
## Add the Mono repository to your system
sudo apt-get install -y gnupg ca-certificates
sudo apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 3FA7E0328081BFF6A14DA29AA6A19B38D3D831EF
echo deb "https://download.mono-project.com/repo/ubuntu stable-focal main" | sudo tee /etc/apt/sources.list.d/mono-official-stable.list
sudo apt-get update
## Install Mono
sudo apt-get install -y mono-devel=6.12* libgtk2.0-dev

# expand produire
wget -O produire-mono.tar.gz https://rdr.utopiat.net/files/mono/latest.php?type=tar
tar zxvf produire-mono.tar.gz
rm produire-mono.tar.gz
```

ファイルに保存して "`bash install_produire.sh > /dev/null`" [^null] のようにバッチ実行すればノータッチで最後まで終わるはず．
[GitHub](https://github.com/Y-Saki26/memorandum/tree/main/ProduireMonoInstall) にファイルを置いておくので参考にされたい．（そのまんま上記のコマンドが書いてあるだけ）

### バージョン指定

プロデルのバージョンを指定したい場合は以下のように配布ファイルを指定します．

```sh
wget https://rdr.utopiat.net/files/mono//produire-mono-1.8.1150.tar.gz
tar zxvf produire-mono-1.8.1150.tar.gz
rm produire-mono-1.8.1150.tar.gz
```

### monoの動作確認

monoのインストールページに「[このページ](https://www.mono-project.com/docs/getting-started/mono-basics/)に従って動作確認することをおすすめします」と書いてあるので一応やっておきます．

```sh
# テスト用コード生成
echo 'using System;
public class HelloWorld
{
    public static void Main(string[] args)
    {
        Console.WriteLine ("Hello Mono World");
    }
}
' > hello.cs
# コンパイル
csc hello.cs
# 実行
mono hello.exe
# => "Hello Mono World" が出力されれば成功．
```

## 実行

実行時に DLL ファイルが必要なためコンパイラなどと同じディレクトリに実行ファイルを置きます．
上記通りだとコマンドを実行したディレクトリの下の "`produire-mono/`" の中．

コンソールアプリをコンパイルして実行する例（[プロデル公式](https://rdr.utopiat.net/files/mono.html)より）．

```sh
# テスト用コード生成
echo 「こんにちは！プロデルへようこそ」を出力して改行する > produire-mono/Main.rdr
# インタプリタ実行
mono produire-mono/pconsole.exe produire-mono/Main.rdr
# => "こんにちは！プロデルへようこそ" が出力
# コンパイル
mono produire-mono/rdrc.exe /mono /console produire-mono/Main.rdr
# "produire-mono/Main.exe" が生成
# 実行
mono produire-mono/Main.exe
# => "こんにちは！プロデルへようこそ" が出力
```

`Main.rdr` の部分を好きに変えて，プロデルのソースコードを書いて実行すれば完成です．

## アンインストール

mono関連のパッケージをアンインストールする．（参考：[How to Completely remove mono?](https://askubuntu.com/questions/644938/how-to-completely-remove-mono)）

```sh
sudo apt-get purge -y mono-runtime mono-devel libgtk2.0-dev
sudo apt-get autoremove -y
```

消えたか確認：

```sh
apt list --installed | grep -E "^mono"
```

何も出てこなければOK．

プロデルの削除はフォルダを消すだけ．

```sh
rm -r produire-mono/
```

[^ver]: 現時点では 6.12 が最新なので何も指定しなくても 6.12 がインストールされる

[^gtk]: "Gtk not found (missing LD_LIBRARY_PATH to libgtk-x11-2.0.so.0?)" という警告が実行時に出る．一応動くが邪魔なので対応しておく．（参考：[Ubuntuでlibgtk-x11-2.0.so.0を追加するには](https://ja.stackoverflow.com/questions/44290/ubuntu%E3%81%A7libgtk-x11-2-0-so-0%E3%82%92%E8%BF%BD%E5%8A%A0%E3%81%99%E3%82%8B%E3%81%AB%E3%81%AF)）

[^null]: "`> /dev/null`" の部分は標準出力を握り潰してエラー出力だけにするためのもの．不要なら無くてよい．
