namespace V1EstimationTool
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.treeProjects = new System.Windows.Forms.TreeView();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.configureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuBuckets = new System.Windows.Forms.ToolStripMenuItem();
			this.menuBucketConfig = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.panel1 = new System.Windows.Forms.Panel();
			this.chkSingleLevel = new System.Windows.Forms.CheckBox();
			this.btnRefreshProjects = new System.Windows.Forms.Button();
			this.storyList = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
			this.iconList = new System.Windows.Forms.ImageList(this.components);
			this.btnRefreshStories = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.bucketPanel = new System.Windows.Forms.Panel();
			this.btnSaveAll = new System.Windows.Forms.Button();
			this.btnClearSort = new System.Windows.Forms.Button();
			this.menuStrip1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// treeProjects
			// 
			this.treeProjects.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			this.treeProjects.HideSelection = false;
			this.treeProjects.Location = new System.Drawing.Point(12, 47);
			this.treeProjects.Name = "treeProjects";
			this.treeProjects.Size = new System.Drawing.Size(188, 489);
			this.treeProjects.TabIndex = 0;
			this.treeProjects.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeProjects_AfterSelect);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.menuBuckets});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.menuStrip1.Size = new System.Drawing.Size(792, 24);
			this.menuStrip1.TabIndex = 2;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configureToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// configureToolStripMenuItem
			// 
			this.configureToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("configureToolStripMenuItem.Image")));
			this.configureToolStripMenuItem.Name = "configureToolStripMenuItem";
			this.configureToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
			this.configureToolStripMenuItem.Text = "&Configure";
			this.configureToolStripMenuItem.Click += new System.EventHandler(this.configureToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(129, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
			this.exitToolStripMenuItem.Text = "E&xit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// menuBuckets
			// 
			this.menuBuckets.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuBucketConfig,
            this.toolStripSeparator2});
			this.menuBuckets.Name = "menuBuckets";
			this.menuBuckets.Size = new System.Drawing.Size(56, 20);
			this.menuBuckets.Text = "&Buckets";
			// 
			// menuBucketConfig
			// 
			this.menuBucketConfig.Image = ((System.Drawing.Image)(resources.GetObject("menuBucketConfig.Image")));
			this.menuBucketConfig.Name = "menuBucketConfig";
			this.menuBucketConfig.Size = new System.Drawing.Size(132, 22);
			this.menuBucketConfig.Text = "Configure";
			this.menuBucketConfig.Click += new System.EventHandler(this.menuBucketConfig_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(129, 6);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.chkSingleLevel);
			this.panel1.Controls.Add(this.btnRefreshProjects);
			this.panel1.Controls.Add(this.treeProjects);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 24);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(212, 548);
			this.panel1.TabIndex = 3;
			// 
			// chkSingleLevel
			// 
			this.chkSingleLevel.AutoSize = true;
			this.chkSingleLevel.Location = new System.Drawing.Point(12, 18);
			this.chkSingleLevel.Name = "chkSingleLevel";
			this.chkSingleLevel.Size = new System.Drawing.Size(146, 17);
			this.chkSingleLevel.TabIndex = 4;
			this.chkSingleLevel.Text = "Single-Level Project View";
			this.chkSingleLevel.UseVisualStyleBackColor = true;
			this.chkSingleLevel.CheckedChanged += new System.EventHandler(this.chkSingleLevel_CheckedChanged);
			// 
			// btnRefreshProjects
			// 
			this.btnRefreshProjects.Image = ((System.Drawing.Image)(resources.GetObject("btnRefreshProjects.Image")));
			this.btnRefreshProjects.Location = new System.Drawing.Point(168, 9);
			this.btnRefreshProjects.Name = "btnRefreshProjects";
			this.btnRefreshProjects.Size = new System.Drawing.Size(32, 32);
			this.btnRefreshProjects.TabIndex = 4;
			this.btnRefreshProjects.UseVisualStyleBackColor = true;
			this.btnRefreshProjects.Click += new System.EventHandler(this.btnRefreshProjects_Click);
			// 
			// storyList
			// 
			this.storyList.AllowDrop = true;
			this.storyList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.storyList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
			this.storyList.Location = new System.Drawing.Point(3, 41);
			this.storyList.Name = "storyList";
			this.storyList.Size = new System.Drawing.Size(559, 219);
			this.storyList.SmallImageList = this.iconList;
			this.storyList.TabIndex = 4;
			this.storyList.UseCompatibleStateImageBehavior = false;
			this.storyList.View = System.Windows.Forms.View.Details;
			this.storyList.DoubleClick += new System.EventHandler(this.storyList_DoubleClick);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Name";
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "ID";
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Project";
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Iteration";
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Team";
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "Theme";
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "Estimate";
			// 
			// iconList
			// 
			this.iconList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iconList.ImageStream")));
			this.iconList.TransparentColor = System.Drawing.Color.Transparent;
			this.iconList.Images.SetKeyName(0, "Theme");
			this.iconList.Images.SetKeyName(1, "Changeset");
			this.iconList.Images.SetKeyName(2, "Defect");
			this.iconList.Images.SetKeyName(3, "DefectTemplate");
			this.iconList.Images.SetKeyName(4, "Epic");
			this.iconList.Images.SetKeyName(5, "Goal");
			this.iconList.Images.SetKeyName(6, "Issue");
			this.iconList.Images.SetKeyName(7, "Iteration");
			this.iconList.Images.SetKeyName(8, "Member");
			this.iconList.Images.SetKeyName(9, "Note");
			this.iconList.Images.SetKeyName(10, "Project");
			this.iconList.Images.SetKeyName(11, "Request");
			this.iconList.Images.SetKeyName(12, "Retrospective");
			this.iconList.Images.SetKeyName(13, "Story");
			this.iconList.Images.SetKeyName(14, "StoryTemplate");
			this.iconList.Images.SetKeyName(15, "Task");
			this.iconList.Images.SetKeyName(16, "Team");
			this.iconList.Images.SetKeyName(17, "Test");
			// 
			// btnRefreshStories
			// 
			this.btnRefreshStories.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRefreshStories.Image = ((System.Drawing.Image)(resources.GetObject("btnRefreshStories.Image")));
			this.btnRefreshStories.Location = new System.Drawing.Point(530, 3);
			this.btnRefreshStories.Name = "btnRefreshStories";
			this.btnRefreshStories.Size = new System.Drawing.Size(32, 32);
			this.btnRefreshStories.TabIndex = 5;
			this.btnRefreshStories.UseVisualStyleBackColor = true;
			this.btnRefreshStories.Click += new System.EventHandler(this.btnRefreshStories_Click);
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.Controls.Add(this.btnClearSort);
			this.panel2.Controls.Add(this.storyList);
			this.panel2.Controls.Add(this.btnRefreshStories);
			this.panel2.Location = new System.Drawing.Point(218, 300);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(574, 272);
			this.panel2.TabIndex = 11;
			// 
			// bucketPanel
			// 
			this.bucketPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.bucketPanel.AutoScroll = true;
			this.bucketPanel.Location = new System.Drawing.Point(218, 71);
			this.bucketPanel.Name = "bucketPanel";
			this.bucketPanel.Size = new System.Drawing.Size(574, 226);
			this.bucketPanel.TabIndex = 12;
			// 
			// btnSaveAll
			// 
			this.btnSaveAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSaveAll.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveAll.Image")));
			this.btnSaveAll.Location = new System.Drawing.Point(748, 33);
			this.btnSaveAll.Name = "btnSaveAll";
			this.btnSaveAll.Size = new System.Drawing.Size(32, 32);
			this.btnSaveAll.TabIndex = 6;
			this.btnSaveAll.UseVisualStyleBackColor = true;
			this.btnSaveAll.Click += new System.EventHandler(this.btnSaveStoryList_Click);
			// 
			// btnClearSort
			// 
			this.btnClearSort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClearSort.Image = ((System.Drawing.Image)(resources.GetObject("btnClearSort.Image")));
			this.btnClearSort.Location = new System.Drawing.Point(492, 3);
			this.btnClearSort.Name = "btnClearSort";
			this.btnClearSort.Size = new System.Drawing.Size(32, 32);
			this.btnClearSort.TabIndex = 6;
			this.btnClearSort.UseVisualStyleBackColor = true;
			this.btnClearSort.Click += new System.EventHandler(this.btnClearSort_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(792, 572);
			this.Controls.Add(this.btnSaveAll);
			this.Controls.Add(this.bucketPanel);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.Text = "VersionOne";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TreeView treeProjects;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem configureToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.Button btnRefreshProjects;
		private System.Windows.Forms.CheckBox chkSingleLevel;
		private System.Windows.Forms.ListView storyList;
		private System.Windows.Forms.Button btnRefreshStories;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel bucketPanel;
		private System.Windows.Forms.ImageList iconList;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ToolStripMenuItem menuBuckets;
		private System.Windows.Forms.Button btnSaveAll;
		private System.Windows.Forms.ToolStripMenuItem menuBucketConfig;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.Button btnClearSort;


	}
}

