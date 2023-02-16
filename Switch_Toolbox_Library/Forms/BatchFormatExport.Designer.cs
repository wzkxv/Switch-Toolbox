﻿namespace Toolbox.Library
{
    partial class BatchFormatExport
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
            this.chkChannelComponents = new Toolbox.Library.Forms.STCheckBox();
            this.chkSeperateArchives = new Toolbox.Library.Forms.STCheckBox();
            this.chkSeperateTextureContainers = new Toolbox.Library.Forms.STCheckBox();
            this.OkButton = new Toolbox.Library.Forms.STButton();
            this.button1 = new Toolbox.Library.Forms.STButton();
            this.comboBox1 = new Toolbox.Library.Forms.STComboBox();
            this.chkExportTextures = new Toolbox.Library.Forms.STCheckBox();
            this.SuspendLayout();
            // 
            // chkChannelComponents
            // 
            this.chkChannelComponents.AutoSize = true;
            this.chkChannelComponents.Checked = true;
            this.chkChannelComponents.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkChannelComponents.Location = new System.Drawing.Point(12, 85);
            this.chkChannelComponents.Name = "chkChannelComponents";
            this.chkChannelComponents.Size = new System.Drawing.Size(161, 17);
            this.chkChannelComponents.TabIndex = 5;
            this.chkChannelComponents.Text = "使用纹理通道交换";
            this.chkChannelComponents.UseVisualStyleBackColor = true;
            // 
            // chkSeperateArchives
            // 
            this.chkSeperateArchives.AutoSize = true;
            this.chkSeperateArchives.Checked = true;
            this.chkSeperateArchives.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSeperateArchives.Location = new System.Drawing.Point(12, 62);
            this.chkSeperateArchives.Name = "chkSeperateArchives";
            this.chkSeperateArchives.Size = new System.Drawing.Size(160, 17);
            this.chkSeperateArchives.TabIndex = 4;
            this.chkSeperateArchives.Text = "使用文件夹保存文件";
            this.chkSeperateArchives.UseVisualStyleBackColor = true;
            // 
            // chkSeperateTextureContainers
            // 
            this.chkSeperateTextureContainers.AutoSize = true;
            this.chkSeperateTextureContainers.Checked = true;
            this.chkSeperateTextureContainers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSeperateTextureContainers.Location = new System.Drawing.Point(12, 39);
            this.chkSeperateTextureContainers.Name = "chkSeperateTextureContainers";
            this.chkSeperateTextureContainers.Size = new System.Drawing.Size(219, 17);
            this.chkSeperateTextureContainers.TabIndex = 3;
            this.chkSeperateTextureContainers.Text = "使用文件夹保存模型/纹理";
            this.chkSeperateTextureContainers.UseVisualStyleBackColor = true;
            // 
            // OkButton
            // 
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OkButton.Location = new System.Drawing.Point(83, 138);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(63, 23);
            this.OkButton.TabIndex = 2;
            this.OkButton.Text = "Ok";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(168, 138);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(63, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "取消";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.BorderColor = System.Drawing.Color.Empty;
            this.comboBox1.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.comboBox1.ButtonColor = System.Drawing.Color.Empty;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.IsReadOnly = false;
            this.comboBox1.Location = new System.Drawing.Point(12, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(222, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // chkExportTextures
            // 
            this.chkExportTextures.AutoSize = true;
            this.chkExportTextures.Checked = true;
            this.chkExportTextures.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExportTextures.Location = new System.Drawing.Point(11, 108);
            this.chkExportTextures.Name = "chkExportTextures";
            this.chkExportTextures.Size = new System.Drawing.Size(100, 17);
            this.chkExportTextures.TabIndex = 6;
            this.chkExportTextures.Text = "导出纹理";
            this.chkExportTextures.UseVisualStyleBackColor = true;
            // 
            // BatchFormatExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(246, 173);
            this.Controls.Add(this.chkExportTextures);
            this.Controls.Add(this.chkChannelComponents);
            this.Controls.Add(this.chkSeperateArchives);
            this.Controls.Add(this.chkSeperateTextureContainers);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Name = "BatchFormatExport";
            this.Text = "TextureFormatExport";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Toolbox.Library.Forms.STComboBox comboBox1;
        private Toolbox.Library.Forms.STButton button1;
        private Toolbox.Library.Forms.STButton OkButton;
        private Forms.STCheckBox chkSeperateTextureContainers;
        private Forms.STCheckBox chkSeperateArchives;
        private Forms.STCheckBox chkChannelComponents;
        private Forms.STCheckBox chkExportTextures;
    }
}