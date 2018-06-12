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
            labelImagePath.Text = data.ConfigurationPath;
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
        }

        public ConfigurationData GetConfigurationData()
        {
            ConfigurationData ret = new ConfigurationData();
            ret.PicturePath = labelImagePath.Text;
            ret.DisplayRatio = trackBarDisplayRatio.Value;
            labelDisplaySize.Text = String.Format("{0}%", trackBarDisplayRatio.Value);

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
            labelDisplaySize.Text = String.Format("{0}%", trackBarDisplayRatio.Value);
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            if ((labelImagePath.Text != null) && (labelImagePath.Text.Length != 0))
            {
                openFileDialog.FileName = labelImagePath.Text;
            } else
            {
                openFileDialog.FileName = System.Environment.GetFolderPath(
                    System.Environment.SpecialFolder.MyPictures);
            }

            DialogResult result = openFileDialog.ShowDialog(this);
            if (result != DialogResult.OK)
            {
                return;
            }
            labelImagePath.Text = openFileDialog.FileName;
        }
    }
}
