
namespace OoT_Link_Animation_Editor
{
    partial class Form1
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
            this.animationsGrid = new System.Windows.Forms.DataGridView();
            this.AnmID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FrameCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.Label();
            this.MenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.animationsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(800, 24);
            this.MenuStrip.TabIndex = 0;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openROMToolStripMenuItem,
            this.openZZRPToolStripMenuItem,
            this.openZZRPLToolStripMenuItem,
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
            this.openROMToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.openROMToolStripMenuItem.Text = "Open ROM";
            this.openROMToolStripMenuItem.Click += new System.EventHandler(this.openROMToolStripMenuItem_Click);
            // 
            // openZZRPToolStripMenuItem
            // 
            this.openZZRPToolStripMenuItem.Name = "openZZRPToolStripMenuItem";
            this.openZZRPToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.openZZRPToolStripMenuItem.Text = "Open ZZRP";
            // 
            // openZZRPLToolStripMenuItem
            // 
            this.openZZRPLToolStripMenuItem.Name = "openZZRPLToolStripMenuItem";
            this.openZZRPLToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.openZZRPLToolStripMenuItem.Text = "Open ZZRPL";
            // 
            // openIndividualToolStripMenuItem
            // 
            this.openIndividualToolStripMenuItem.Name = "openIndividualToolStripMenuItem";
            this.openIndividualToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.openIndividualToolStripMenuItem.Text = "Open individual";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // animationsGrid
            // 
            this.animationsGrid.AllowUserToAddRows = false;
            this.animationsGrid.AllowUserToDeleteRows = false;
            this.animationsGrid.AllowUserToResizeColumns = false;
            this.animationsGrid.AllowUserToResizeRows = false;
            this.animationsGrid.BackgroundColor = System.Drawing.Color.White;
            this.animationsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.animationsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AnmID,
            this.FrameCount});
            this.animationsGrid.Location = new System.Drawing.Point(12, 27);
            this.animationsGrid.MultiSelect = false;
            this.animationsGrid.Name = "animationsGrid";
            this.animationsGrid.RowHeadersVisible = false;
            this.animationsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.animationsGrid.Size = new System.Drawing.Size(213, 411);
            this.animationsGrid.TabIndex = 1;
            // 
            // AnmID
            // 
            this.AnmID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AnmID.HeaderText = "Animation ID";
            this.AnmID.Name = "AnmID";
            this.AnmID.ReadOnly = true;
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
            this.Status.AutoSize = true;
            this.Status.Location = new System.Drawing.Point(232, 424);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(24, 13);
            this.Status.TabIndex = 2;
            this.Status.Text = "Idle";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.animationsGrid);
            this.Controls.Add(this.MenuStrip);
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "Form1";
            this.Text = "Link Animation Editor";
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.animationsGrid)).EndInit();
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
        private System.Windows.Forms.DataGridView animationsGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn AnmID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FrameCount;
        private System.Windows.Forms.Label Status;
    }
}

