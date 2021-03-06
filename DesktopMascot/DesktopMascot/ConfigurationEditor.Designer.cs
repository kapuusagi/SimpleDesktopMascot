﻿namespace DesktopMascot
{
    partial class ConfigurationEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigurationEditor));
            this.buttonApply = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelImagePath = new System.Windows.Forms.Label();
            this.buttonSelectFolder = new System.Windows.Forms.Button();
            this.groupBoxImagePath = new System.Windows.Forms.GroupBox();
            this.trackBarDisplayRatio = new System.Windows.Forms.TrackBar();
            this.groupBoxDisplaySize = new System.Windows.Forms.GroupBox();
            this.labelDisplayRatio = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBoxOpacity = new System.Windows.Forms.GroupBox();
            this.trackBarOpacity = new System.Windows.Forms.TrackBar();
            this.labelOpacity = new System.Windows.Forms.Label();
            this.groupBoxImagePath.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDisplayRatio)).BeginInit();
            this.groupBoxDisplaySize.SuspendLayout();
            this.groupBoxOpacity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOpacity)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonApply
            // 
            this.buttonApply.Location = new System.Drawing.Point(202, 272);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(75, 23);
            this.buttonApply.TabIndex = 0;
            this.buttonApply.Text = "Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.ButtonApply_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(298, 272);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // labelImagePath
            // 
            this.labelImagePath.AutoSize = true;
            this.labelImagePath.Location = new System.Drawing.Point(15, 15);
            this.labelImagePath.Name = "labelImagePath";
            this.labelImagePath.Size = new System.Drawing.Size(0, 12);
            this.labelImagePath.TabIndex = 2;
            // 
            // buttonSelectFolder
            // 
            this.buttonSelectFolder.Location = new System.Drawing.Point(263, 18);
            this.buttonSelectFolder.Name = "buttonSelectFolder";
            this.buttonSelectFolder.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectFolder.TabIndex = 3;
            this.buttonSelectFolder.Text = "Select";
            this.buttonSelectFolder.UseVisualStyleBackColor = true;
            this.buttonSelectFolder.Click += new System.EventHandler(this.SelectButton_Click);
            // 
            // groupBoxImagePath
            // 
            this.groupBoxImagePath.Controls.Add(this.labelImagePath);
            this.groupBoxImagePath.Controls.Add(this.buttonSelectFolder);
            this.groupBoxImagePath.Location = new System.Drawing.Point(12, 12);
            this.groupBoxImagePath.Name = "groupBoxImagePath";
            this.groupBoxImagePath.Size = new System.Drawing.Size(353, 57);
            this.groupBoxImagePath.TabIndex = 4;
            this.groupBoxImagePath.TabStop = false;
            this.groupBoxImagePath.Text = "Image Path";
            // 
            // trackBarDisplayRatio
            // 
            this.trackBarDisplayRatio.LargeChange = 50;
            this.trackBarDisplayRatio.Location = new System.Drawing.Point(6, 18);
            this.trackBarDisplayRatio.Maximum = 400;
            this.trackBarDisplayRatio.Minimum = 10;
            this.trackBarDisplayRatio.Name = "trackBarDisplayRatio";
            this.trackBarDisplayRatio.Size = new System.Drawing.Size(332, 45);
            this.trackBarDisplayRatio.SmallChange = 10;
            this.trackBarDisplayRatio.TabIndex = 5;
            this.trackBarDisplayRatio.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarDisplayRatio.Value = 10;
            this.trackBarDisplayRatio.ValueChanged += new System.EventHandler(this.trackBarDisplayRatio_ValueChanged);
            // 
            // groupBoxDisplaySize
            // 
            this.groupBoxDisplaySize.Controls.Add(this.labelDisplayRatio);
            this.groupBoxDisplaySize.Controls.Add(this.label2);
            this.groupBoxDisplaySize.Controls.Add(this.label1);
            this.groupBoxDisplaySize.Controls.Add(this.trackBarDisplayRatio);
            this.groupBoxDisplaySize.Location = new System.Drawing.Point(12, 75);
            this.groupBoxDisplaySize.Name = "groupBoxDisplaySize";
            this.groupBoxDisplaySize.Size = new System.Drawing.Size(353, 95);
            this.groupBoxDisplaySize.TabIndex = 6;
            this.groupBoxDisplaySize.TabStop = false;
            this.groupBoxDisplaySize.Text = "Display Size";
            // 
            // labelDisplayRatio
            // 
            this.labelDisplayRatio.AutoSize = true;
            this.labelDisplayRatio.Location = new System.Drawing.Point(148, 62);
            this.labelDisplayRatio.Name = "labelDisplayRatio";
            this.labelDisplayRatio.Size = new System.Drawing.Size(23, 12);
            this.labelDisplayRatio.TabIndex = 8;
            this.labelDisplayRatio.Text = "xx%";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(309, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "400%";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "10%";
            // 
            // groupBoxOpacity
            // 
            this.groupBoxOpacity.Controls.Add(this.labelOpacity);
            this.groupBoxOpacity.Controls.Add(this.trackBarOpacity);
            this.groupBoxOpacity.Location = new System.Drawing.Point(13, 177);
            this.groupBoxOpacity.Name = "groupBoxOpacity";
            this.groupBoxOpacity.Size = new System.Drawing.Size(352, 80);
            this.groupBoxOpacity.TabIndex = 7;
            this.groupBoxOpacity.TabStop = false;
            this.groupBoxOpacity.Text = "Opacity";
            // 
            // trackBarOpacity
            // 
            this.trackBarOpacity.Location = new System.Drawing.Point(16, 19);
            this.trackBarOpacity.Minimum = 1;
            this.trackBarOpacity.Name = "trackBarOpacity";
            this.trackBarOpacity.Size = new System.Drawing.Size(321, 45);
            this.trackBarOpacity.TabIndex = 0;
            this.trackBarOpacity.Value = 10;
            this.trackBarOpacity.ValueChanged += new System.EventHandler(this.OpacityTrackbar_ValueChange);
            // 
            // labelOpacity
            // 
            this.labelOpacity.AutoSize = true;
            this.labelOpacity.Location = new System.Drawing.Point(147, 52);
            this.labelOpacity.Name = "labelOpacity";
            this.labelOpacity.Size = new System.Drawing.Size(23, 12);
            this.labelOpacity.TabIndex = 1;
            this.labelOpacity.Text = "xx%";
            // 
            // ConfigurationEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 315);
            this.Controls.Add(this.groupBoxOpacity);
            this.Controls.Add(this.groupBoxDisplaySize);
            this.Controls.Add(this.groupBoxImagePath);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonApply);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConfigurationEditor";
            this.Text = "ConfigurationEditor";
            this.groupBoxImagePath.ResumeLayout(false);
            this.groupBoxImagePath.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDisplayRatio)).EndInit();
            this.groupBoxDisplaySize.ResumeLayout(false);
            this.groupBoxDisplaySize.PerformLayout();
            this.groupBoxOpacity.ResumeLayout(false);
            this.groupBoxOpacity.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOpacity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelImagePath;
        private System.Windows.Forms.Button buttonSelectFolder;
        private System.Windows.Forms.GroupBox groupBoxImagePath;
        private System.Windows.Forms.TrackBar trackBarDisplayRatio;
        private System.Windows.Forms.GroupBox groupBoxDisplaySize;
        private System.Windows.Forms.Label labelDisplayRatio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.GroupBox groupBoxOpacity;
        private System.Windows.Forms.Label labelOpacity;
        private System.Windows.Forms.TrackBar trackBarOpacity;
    }
}