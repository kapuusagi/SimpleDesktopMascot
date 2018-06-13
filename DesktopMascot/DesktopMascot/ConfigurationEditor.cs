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
    /// 設定を編集するフォーム。
    /// クラス関係のデザイン的にはViewにデータとコントローラを内包しているのでよろしくない。
    /// </summary>
    public partial class ConfigurationEditor : Form
    {
        private DialogResult dialogResult;

        public ConfigurationEditor()
        {
            InitializeComponent();
            dialogResult = DialogResult.Cancel;
        }

        public void ApplyConfigurationData(ConfigurationData data)
        {
            labelImagePath.Text = data.PicturePath;
            int displaySize = (int)(data.DisplayRatio);
            if (displaySize < trackBarDisplayRatio.Minimum)
            {
                displaySize = trackBarDisplayRatio.Minimum;
            }
            else if (displaySize > trackBarDisplayRatio.Maximum)
            {
                displaySize = trackBarDisplayRatio.Maximum;
            }

            trackBarDisplayRatio.Value = displaySize;
            labelDisplayRatio.Text = String.Format("{0}%", trackBarDisplayRatio.Value);

            float opacity = data.Opacity;
            if (opacity > 100.0f)
            {
                opacity = 100.0f;
            } else if (opacity < 10.0f)
            {
                opacity = 10.0f;
            }
            trackBarOpacity.Value = (int)(opacity / 10);
            labelOpacity.Text = String.Format("{0}%", trackBarOpacity.Value * 10);
        }

        /// <summary>
        /// 設定データを取得する。
        /// </summary>
        /// <returns>設定データ</returns>
        public ConfigurationData GetConfigurationData()
        {
            ConfigurationData ret = new ConfigurationData();
            ret.PicturePath = labelImagePath.Text;
            ret.DisplayRatio = trackBarDisplayRatio.Value;
            ret.Opacity = trackBarOpacity.Value * 10.0f;
            

            return ret;
        }

        /// <summary>
        /// 処理結果を取得する。
        /// </summary>
        /// <returns>適用ボタンが押された場合にはDialogResult.OKが返り、それ以外はDialogResult.Cancelが返る。</returns>
        public DialogResult GetResult()
        {
            return dialogResult;
        }

        private void ButtonApply_Click(object sender, EventArgs e)
        {
            dialogResult = DialogResult.OK;
            Close();

        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            dialogResult = DialogResult.Cancel;
            Close();
        }

        private void trackBarDisplayRatio_ValueChanged(object sender, EventArgs e)
        {
            labelDisplayRatio.Text = String.Format("{0}%", trackBarDisplayRatio.Value);
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            if ((labelImagePath.Text != null) && (labelImagePath.Text.Length != 0))
            {
                folderBrowserDialog.SelectedPath = labelImagePath.Text;
            } else
            {
                folderBrowserDialog.SelectedPath =System.Environment.GetFolderPath(
                    System.Environment.SpecialFolder.MyPictures);
            }

            DialogResult result = folderBrowserDialog.ShowDialog(this);
            if (result != DialogResult.OK)
            {
                return;
            }
            labelImagePath.Text = folderBrowserDialog.SelectedPath;
        }

        private void OpacityTrackbar_ValueChange(object sender, EventArgs e)
        {
            labelOpacity.Text = String.Format("{0}%", trackBarOpacity.Value * 10);
        }
    }
}
