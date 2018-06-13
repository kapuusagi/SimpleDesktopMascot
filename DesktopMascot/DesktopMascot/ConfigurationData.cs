using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopMascot
{
    /// <summary>
    /// ソフトウェアの設定を保持するクラス
    /// </summary>
    public class ConfigurationData
    {
        public static readonly string ConfigurationFileName = ".desktop-mascot.ini";

        private string picturePath;
        private string configurationPath = "";
        private float displayRatio = 100.0f;
        private float opacity;


        public ConfigurationData()
        {
            // 初期化
            InitSetting();
        }

        private void InitSetting()
        {
            picturePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyPictures);
            configurationPath = "";
            displayRatio = 100.0f;
            opacity = 100.0f;
        }

        /// <summary>
        /// 設定ファイルパスを取得する。
        /// </summary>
        public string ConfigurationPath
        {
            get { return configurationPath; }
        }

        /// <summary>
        /// 画像ディレクトリ/パスを取得する。
        /// </summary>
        public string PicturePath
        {
            get { return picturePath; }
            set { picturePath = value; }
        }
        /// <summary>
        /// 表示倍率(%)を取得または設定する。
        /// 割合(%)であることに注意。100の時に等倍。
        /// </summary>
        public float DisplayRatio
        {
            get { return displayRatio; }
            set { displayRatio = value; }
        }

        /// <summary>
        /// 不透明度の設定
        /// 割合(%)で扱うことに注意。
        /// </summary>
        public float Opacity
        {
            get { return opacity; }
            set { opacity = value; }
        }

        /// <summary>
        /// 設定ファイルを読み込む。
        /// </summary>
        /// <returns>ファイルを読み込んだ場合にはtrue, 失敗した場合にはfalse。エラー発生時は例外を投げる。</returns>
        public bool LoadSetting()
        {
            string file_path = System.IO.Path.Combine(
                System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments),
                ConfigurationFileName);
            if (ReadConfiguration(file_path))
            {
                configurationPath = file_path;
                return true;
            }

            file_path = System.IO.Path.Combine(
                System.Reflection.Assembly.GetExecutingAssembly().Location, ConfigurationFileName);
            if (ReadConfiguration(file_path))
            {
                configurationPath = file_path;
                return true;
            }
            return false;
        }

        /// <summary>
        /// pathで指定されたパスから設定を読み出す。
        /// </summary>
        /// <param name="path">ファイルパス</param>
        /// <returns>設定ファイルが読み出せた場合にはtrue,設定ファイルが存在しない場合にはfalse。</returns>
        private bool ReadConfiguration(string path)
        {
            if (!System.IO.File.Exists(path))
            {
                return false;
            }
            char[] delimters = { ' ', '\t', '\r', '\n' };

            // TODO: 
            using (System.IO.StreamReader sr = System.IO.File.OpenText(path))
            {
                InitSetting();
                while (true)
                {
                    string line = sr.ReadLine();
                    if (line == null)
                    {
                        break;
                    }

                    string[] tokens = line.Split(delimters);
                    if (tokens.Length < 2)
                    {
                        continue;
                    }
                    SetValue(tokens[0], tokens[1]);
                    System.Console.Write(line);
                }
            }

            return true;
        }

        /// <summary>
        /// 設定をキーと価の組として設定する。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        private void SetValue(string key, string value)
        {
            switch(key)
            {
                case "picture-path":
                    picturePath = value;
                    break;
                case "display-ratio":
                    displayRatio = float.Parse(value);
                    break;
                case "opacity":
                    opacity = float.Parse(value);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 設定ファイルを保存する。
        /// </summary>
        /// <param name="file_path">ファイルパス</param>
        public void SaveConfiguration(string file_path)
        {
            using (System.IO.TextWriter tw = System.IO.File.CreateText(file_path))
            {
                tw.WriteLine("picture-path {0}", picturePath);
                tw.WriteLine("display-ratio {0}", displayRatio);
                tw.WriteLine("opacity {0}", opacity);
            }
        }


    }
}
