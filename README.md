# SimpleDesktopMascot
Sample of simple desktop mascot.

# 目的
画像ファイルのアルファチャンネルを透過させて画面上に表示させたくて作成したものです。

# 開発環境
Microsoft Visual Studio 2017 Community Edition

# 機能
- 指定した画像、または所定のディレクトリにある画像からランダムで1枚読み込み、アルファチャンネルを透過して表示します。
- 設定ファイルの保存先はMyDocument直下またはアプリケーションの実行ファイルと同じ場所。
- 右クリックでメニューを表示。
- 画像の表示倍率を割合で指定。

# その他
デスクトップとアルファチャンネル完全透過させるには至っていないです。Formの背景色（BackColor）に対してアルファチャンネルの処理が行われてます。
輪郭はFormのTransparencyKeyにBackColorを入れることで透過しています。
