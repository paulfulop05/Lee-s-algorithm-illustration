using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;


namespace Soarece
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(MainForm));
            panel = new Panel();
            lbl_nrsol = new Label();
            btnReset = new Button();
            btnStart = new Button();
            btnExit = new Button();
            SuspendLayout();
            // 
            // panel
            // 
            panel.Anchor = AnchorStyles.None;
            panel.Location = new Point(12, 12);
            panel.Name = "panel";
            panel.Size = new Size(1455, 762);
            panel.TabIndex = 0;
            // 
            // lbl_nrsol
            // 
            lbl_nrsol.Anchor = AnchorStyles.None;
            lbl_nrsol.Font = new Font("Arial Narrow", 24F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_nrsol.Location = new Point(882, 780);
            lbl_nrsol.Name = "lbl_nrsol";
            lbl_nrsol.Size = new Size(585, 45);
            lbl_nrsol.TabIndex = 1;
            lbl_nrsol.Text = "Jocul nu a inceput";
            lbl_nrsol.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnReset
            // 
            btnReset.Anchor = AnchorStyles.None;
            btnReset.BackgroundImageLayout = ImageLayout.None;
            btnReset.FlatStyle = FlatStyle.Popup;
            btnReset.Font = new Font("Arial Narrow", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnReset.ForeColor = SystemColors.ActiveCaptionText;
            btnReset.Location = new Point(12, 780);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(280, 45);
            btnReset.TabIndex = 2;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // btnStart
            // 
            btnStart.Anchor = AnchorStyles.None;
            btnStart.BackgroundImageLayout = ImageLayout.None;
            btnStart.FlatStyle = FlatStyle.Popup;
            btnStart.Font = new Font("Arial Narrow", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnStart.ForeColor = Color.Black;
            btnStart.Location = new Point(298, 780);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(278, 45);
            btnStart.TabIndex = 3;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnExit
            // 
            btnExit.Anchor = AnchorStyles.None;
            btnExit.BackgroundImageLayout = ImageLayout.None;
            btnExit.FlatStyle = FlatStyle.Popup;
            btnExit.Font = new Font("Arial Narrow", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnExit.ForeColor = Color.Black;
            btnExit.Location = new Point(582, 780);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(294, 45);
            btnExit.TabIndex = 4;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(1479, 837);
            Controls.Add(btnExit);
            Controls.Add(btnStart);
            Controls.Add(btnReset);
            Controls.Add(lbl_nrsol);
            Controls.Add(panel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Soarece";
            ResumeLayout(false);
        }

        #endregion

        private Panel panel;
        private Label lbl_nrsol;
        private Button btnReset;
        private Button btnStart;
        private Button btnExit;
    }
}