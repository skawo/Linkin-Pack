
namespace OoT_Link_Animation_Editor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openROMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openZZRPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openZZRPLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openIndividualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AnimGrid = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AnmID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AnimationName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FrameCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.Label();
            this.ButtonImport = new System.Windows.Forms.Button();
            this.txSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.openZ64ROMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AnimGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(835, 24);
            this.MenuStrip.TabIndex = 0;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openROMToolStripMenuItem,
            this.openZZRPToolStripMenuItem,
            this.openZZRPLToolStripMenuItem,
            this.openZ64ROMToolStripMenuItem,
            this.openIndividualToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openROMToolStripMenuItem
            // 
            this.openROMToolStripMenuItem.Name = "openROMToolStripMenuItem";
            this.openROMToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.openROMToolStripMenuItem.Text = "Open ROM";
            this.openROMToolStripMenuItem.Click += new System.EventHandler(this.OpenROMToolStripMenuItem_Click);
            // 
            // openZZRPToolStripMenuItem
            // 
            this.openZZRPToolStripMenuItem.Name = "openZZRPToolStripMenuItem";
            this.openZZRPToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.openZZRPToolStripMenuItem.Text = "Open ZZRP Project";
            this.openZZRPToolStripMenuItem.Click += new System.EventHandler(this.OpenZZRPToolStripMenuItem_Click);
            // 
            // openZZRPLToolStripMenuItem
            // 
            this.openZZRPLToolStripMenuItem.Name = "openZZRPLToolStripMenuItem";
            this.openZZRPLToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.openZZRPLToolStripMenuItem.Text = "Open ZZRPL Project";
            this.openZZRPLToolStripMenuItem.Click += new System.EventHandler(this.OpenZZRPLToolStripMenuItem_Click);
            // 
            // openIndividualToolStripMenuItem
            // 
            this.openIndividualToolStripMenuItem.Name = "openIndividualToolStripMenuItem";
            this.openIndividualToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.openIndividualToolStripMenuItem.Text = "Open individual";
            this.openIndividualToolStripMenuItem.Click += new System.EventHandler(this.OpenIndividualToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // AnimGrid
            // 
            this.AnimGrid.AllowUserToAddRows = false;
            this.AnimGrid.AllowUserToDeleteRows = false;
            this.AnimGrid.AllowUserToResizeColumns = false;
            this.AnimGrid.AllowUserToResizeRows = false;
            this.AnimGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AnimGrid.BackgroundColor = System.Drawing.Color.White;
            this.AnimGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AnimGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.AnmID,
            this.AnimationName,
            this.FrameCount});
            this.AnimGrid.Location = new System.Drawing.Point(12, 27);
            this.AnimGrid.MultiSelect = false;
            this.AnimGrid.Name = "AnimGrid";
            this.AnimGrid.ReadOnly = true;
            this.AnimGrid.RowHeadersVisible = false;
            this.AnimGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AnimGrid.Size = new System.Drawing.Size(811, 402);
            this.AnimGrid.TabIndex = 1;
            this.AnimGrid.SelectionChanged += new System.EventHandler(this.AnimationsGrid_SelectionChanged);
            // 
            // ID
            // 
            this.ID.HeaderText = "ColumnID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // AnmID
            // 
            this.AnmID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AnmID.HeaderText = "Animation ID";
            this.AnmID.Name = "AnmID";
            this.AnmID.ReadOnly = true;
            // 
            // AnimationName
            // 
            this.AnimationName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AnimationName.FillWeight = 200F;
            this.AnimationName.HeaderText = "Animation Name";
            this.AnimationName.Name = "AnimationName";
            this.AnimationName.ReadOnly = true;
            // 
            // FrameCount
            // 
            this.FrameCount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FrameCount.HeaderText = "Frame Count";
            this.FrameCount.Name = "FrameCount";
            this.FrameCount.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Status.AutoSize = true;
            this.Status.Location = new System.Drawing.Point(365, 461);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(24, 13);
            this.Status.TabIndex = 2;
            this.Status.Text = "Idle";
            // 
            // ButtonImport
            // 
            this.ButtonImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonImport.Location = new System.Drawing.Point(12, 435);
            this.ButtonImport.Name = "ButtonImport";
            this.ButtonImport.Size = new System.Drawing.Size(347, 43);
            this.ButtonImport.TabIndex = 0;
            this.ButtonImport.Text = "Import BIN";
            this.ButtonImport.UseVisualStyleBackColor = true;
            this.ButtonImport.Click += new System.EventHandler(this.ButtonImport_Click);
            // 
            // txSearch
            // 
            this.txSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txSearch.Location = new System.Drawing.Point(621, 458);
            this.txSearch.Name = "txSearch";
            this.txSearch.Size = new System.Drawing.Size(202, 20);
            this.txSearch.TabIndex = 4;
            this.txSearch.TextChanged += new System.EventHandler(this.TxSearch_TextChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(571, 461);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(44, 13);
            this.lblSearch.TabIndex = 5;
            this.lblSearch.Text = "Search:";
            // 
            // openZ64ROMToolStripMenuItem
            // 
            this.openZ64ROMToolStripMenuItem.Name = "openZ64ROMToolStripMenuItem";
            this.openZ64ROMToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.openZ64ROMToolStripMenuItem.Text = "Open Z64ROM Project";
            this.openZ64ROMToolStripMenuItem.Click += new System.EventHandler(this.openZ64ROMToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 483);
            this.Controls.Add(this.ButtonImport);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txSearch);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.AnimGrid);
            this.Controls.Add(this.MenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "MainForm";
            this.Text = "Linkin Pack";
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AnimGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openROMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openZZRPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openZZRPLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openIndividualToolStripMenuItem;
        private System.Windows.Forms.DataGridView AnimGrid;
        private System.Windows.Forms.Label Status;
        private System.Windows.Forms.Button ButtonImport;
        private System.Windows.Forms.TextBox txSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn AnmID;
        private System.Windows.Forms.DataGridViewTextBoxColumn AnimationName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FrameCount;
        private System.Windows.Forms.ToolStripMenuItem openZ64ROMToolStripMenuItem;
    }
}

