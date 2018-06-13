using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopMascot
{
    /// <summary>
    /// メインフォーム
    /// </summary>
    public partial class MainForm : Form
    {
        // アプリケーションの設定データ
        private ConfigurationData data;
        // マスコット用の表示
        private Image mascotImage;
        // マウス位置（FormBorderStyle=None時のウィンドウ移動処理用）
        private Point savedMousePosition;
        // ドラッグ操作中かどうかのフラグ
        // （FormBorderStyle=None時のウィンドウ移動処理用）
        private bool dragOperation;

        public MainForm()
        {
            InitializeComponent();
            Text = "DesktopMascot"; // ウィンドウの名前
            mascotImage = null;
            dragOperation = false;
            data = new ConfigurationData();
            data.LoadSetting();

            try
            {
                ApplyConfiguration();
            }
            catch (Exception) {
                // あまりよくないが、例外ムシ
            }
        }
        /// <summary>
        /// ConfigurationDataを元にUIを更新する。
        /// </summary>
        private void ApplyConfiguration()
        {
            try
            {
                TransparencyKey = BackColor;
                Visible = false;

                LoadImage();
                if (mascotImage != null)
                {
                    float ratio = data.DisplayRatio;
                    int width = (int)(mascotImage.Width * ratio / 100.0f);
                    int height = (int)(mascotImage.Height * ratio / 100.0f);

                    if ((width < 32) || (height < 32))
                    {
                        float xRatio = 32 / mascotImage.Width;
                        float yRatio = 32 / mascotImage.Height;
                        if (xRatio < yRatio)
                        {
                            width = (int)(mascotImage.Width * xRatio);
                            height = (int)(mascotImage.Height * xRatio);
                        } else
                        {
                            width = (int)(mascotImage.Width * yRatio);
                            height = (int)(mascotImage.Height * yRatio);
                        }
                    }
                    

                    try
                    {
                        // Note: ウィンドウをリサイズする時、BackgroundImageはnullにしておかないと
                        //       ArgumentExceptionが発生することがある。（サイズが大きくなる時に発生するようだ）
                        //       なかなか厄介。
                        BackgroundImage = null;
                        SetBounds(Left, Top, width, height);
                    }
                    catch (ArgumentException e)
                    {
                        String.Format("{0} : Top={1} Left={2} width={3} height={4}", e.Message, Left, Top, width, height);
                    }
                }
                BackgroundImage = mascotImage;
                double opacity = data.Opacity;
                Opacity = (opacity > 10.0f) ? (opacity / 100.0) : 0.1;
            }
            catch (Exception)
            {
                // Do nothing.
            }
            Visible = true;

            this.Invalidate(); // コンポーネントを再描画する。
        }

        /// <summary>
        /// 画像データを読み出す。
        /// mascotImageを有効なイメージデータまたはnullへ更新する。
        /// </summary>
        private void LoadImage()
        {
            string path = data.PicturePath;
            if ((path == null) || (path.Length == 0))
            {
                path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyPictures);
            }

            string image_path = null;

            if (!System.IO.File.Exists(path))
            {
                // これはディレクトリ
                string[] file_list = GetFileList(path);
                if (file_list.Length > 0)
                {
                    System.Random r = new System.Random(System.DateTime.Now.Millisecond);
                    image_path = file_list[r.Next(file_list.Length)];
                }
            }
            else
            {
                // これはファイル
                image_path = path;
            }

            if (image_path == null)
            {
                BackgroundImage = null;
                return;
            }

            if (mascotImage != null)
            {
                mascotImage.Dispose();
                mascotImage = null;
            }
            mascotImage = Image.FromFile(image_path);
        }
        /// <summary>
        /// dirで指定されたディレクトリの画像ファイルリストを取得する。
        /// </summary>
        /// <param name="dir">ディレクトリ</param>
        /// <returns>画像ファイルリストの配列が返る</returns>
        private string[] GetFileList(string dir)
        {
            List<string> ret = new List<string>();

            string[] suffixes = { "*.jpg", "*.png", "*.bmp" };

            foreach (string suffix in suffixes)
            {
                string[] file_list = System.IO.Directory.GetFiles(dir, suffix);
                foreach (string s in file_list)
                {
                    ret.Add(s);
                }
            }

            return ret.ToArray();
        }

        /// <summary>
        /// フォームがクローズされたとき、リソースの開放を行う。
        /// </summary>
        /// <param name="sender">送信元</param>
        /// <param name="e">イベントオブジェクト</param>
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (mascotImage != null)
            {
                mascotImage.Dispose();
                mascotImage = null;
            }
        }
        // 再描画処理を行う。
        // GDIでなんちゃらやる場合にはここで。
        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            /*
            if (mascotImage != null)
            {
                e.Graphics.DrawImage(mascotImage, 0, 0);
            }
            */
        }
        // Exitメニューアイテムがクリックされた
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        // マウス移動時のイベント処理
        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragOperation)
            {
                Left += (e.X - savedMousePosition.X);
                Top += (e.Y - savedMousePosition.Y);
            }
        }
        // マウスボタンが押された時のイベント処理
        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragOperation = true;
                savedMousePosition.X = e.X;
                savedMousePosition.Y = e.Y;
            }

        }
        // マウスボタンが離されたときのイベント処理
        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragOperation = false;
            }
        }

        // マウスが領域から離れたときの処理。
        private void MainForm_MouseLeave(object sender, EventArgs e)
        {
            dragOperation = false;
        }

        // Reloadメニューアイテムがクリックされた時のイベント処理。
        private void ReloadMenuItemReload_Click(object sender, EventArgs e)
        {
            ApplyConfiguration();
        }
        // 設定メニューアイテムがクリックされたときのイベント処理
        private void SettingMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurationEditor editor = new ConfigurationEditor();
            editor.ApplyConfigurationData(data);
            editor.ShowDialog(this);
            if (editor.GetResult() != DialogResult.OK)
            {
                return;
            }

            data = editor.GetConfigurationData();
            string file_path = System.IO.Path.Combine(
                System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments),
                ConfigurationData.ConfigurationFileName);
            data.SaveConfiguration(file_path);

            Visible = false;
            ApplyConfiguration();
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (!Visible)
            {
                //BackgroundImage = mascotImage;
                //Visible = true;
            }
        }
    }
}
