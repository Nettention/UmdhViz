// UMDH Diff Viewer
// Copyright Nettention Co., Ltd.

namespace UmdhViz
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_openUmdhFile = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.m_allocBlockListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.m_callStackView = new System.Windows.Forms.ListView();
            this.Column1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.m_openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.m_proudNetLink = new System.Windows.Forms.LinkLabel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(719, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_openUmdhFile});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // m_openUmdhFile
            // 
            this.m_openUmdhFile.Name = "m_openUmdhFile";
            this.m_openUmdhFile.Size = new System.Drawing.Size(190, 22);
            this.m_openUmdhFile.Text = "Open UMDH Diff File";
            this.m_openUmdhFile.Click += new System.EventHandler(this.OpenUmdhFile_OnSelect);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.m_allocBlockListView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.m_callStackView);
            this.splitContainer1.Size = new System.Drawing.Size(719, 492);
            this.splitContainer1.SplitterDistance = 239;
            this.splitContainer1.TabIndex = 1;
            // 
            // m_allocBlockListView
            // 
            this.m_allocBlockListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_allocBlockListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.m_allocBlockListView.Location = new System.Drawing.Point(4, 4);
            this.m_allocBlockListView.Name = "m_allocBlockListView";
            this.m_allocBlockListView.Size = new System.Drawing.Size(232, 485);
            this.m_allocBlockListView.TabIndex = 0;
            this.m_allocBlockListView.UseCompatibleStateImageBehavior = false;
            this.m_allocBlockListView.View = System.Windows.Forms.View.Details;
            this.m_allocBlockListView.SelectedIndexChanged += new System.EventHandler(this.AllocBlock_OnSelected);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Amount";
            this.columnHeader1.Width = 200;
            // 
            // m_callStackView
            // 
            this.m_callStackView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_callStackView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Column1});
            this.m_callStackView.Location = new System.Drawing.Point(3, 4);
            this.m_callStackView.Name = "m_callStackView";
            this.m_callStackView.Size = new System.Drawing.Size(470, 485);
            this.m_callStackView.TabIndex = 0;
            this.m_callStackView.UseCompatibleStateImageBehavior = false;
            this.m_callStackView.View = System.Windows.Forms.View.Details;
            // 
            // Column1
            // 
            this.Column1.Text = "Function";
            this.Column1.Width = 300;
            // 
            // m_openFileDialog
            // 
            this.m_openFileDialog.FileName = "*.txt";
            this.m_openFileDialog.Filter = "Text files|*.txt|All files|*.*";
            // 
            // m_proudNetLink
            // 
            this.m_proudNetLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_proudNetLink.AutoSize = true;
            this.m_proudNetLink.Location = new System.Drawing.Point(547, 6);
            this.m_proudNetLink.Name = "m_proudNetLink";
            this.m_proudNetLink.Size = new System.Drawing.Size(141, 12);
            this.m_proudNetLink.TabIndex = 1;
            this.m_proudNetLink.TabStop = true;
            this.m_proudNetLink.Text = "Do you know ProudNet?";
            this.m_proudNetLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ProudNetLink_Open);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 516);
            this.Controls.Add(this.m_proudNetLink);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "UMDH Diff Viz";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_openUmdhFile;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView m_allocBlockListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ListView m_callStackView;
        private System.Windows.Forms.ColumnHeader Column1;
        private System.Windows.Forms.OpenFileDialog m_openFileDialog;
        private System.Windows.Forms.LinkLabel m_proudNetLink;
    }
}

