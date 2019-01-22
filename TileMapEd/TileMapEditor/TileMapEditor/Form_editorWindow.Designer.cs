namespace TileMapEditor
{
    partial class Form_editorWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_editorWindow));
            this.toolStrip_MenuStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton_FileMenu = new System.Windows.Forms.ToolStripDropDownButton();
            this.newMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.saveMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMapAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.loadMapFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadTilesetFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer_Main = new System.Windows.Forms.SplitContainer();
            this.splitContainer_TileSelector = new System.Windows.Forms.SplitContainer();
            this.label_rotateLabel = new System.Windows.Forms.Label();
            this.button_horizontalMirror = new System.Windows.Forms.Button();
            this.button_verticalMirror = new System.Windows.Forms.Button();
            this.button_rotateRight = new System.Windows.Forms.Button();
            this.button_rotateLeft = new System.Windows.Forms.Button();
            this.pictureBox_previewTile = new System.Windows.Forms.PictureBox();
            this.label_LevelCountLabel = new System.Windows.Forms.Label();
            this.label_levelCountNumber = new System.Windows.Forms.Label();
            this.textBox_LevelName = new System.Windows.Forms.TextBox();
            this.button_prevLevel = new System.Windows.Forms.Button();
            this.button_nextLevel = new System.Windows.Forms.Button();
            this.button_deleteLevel = new System.Windows.Forms.Button();
            this.button_addLevel = new System.Windows.Forms.Button();
            this.button_addEntity = new System.Windows.Forms.Button();
            this.button_removeentity = new System.Windows.Forms.Button();
            this.toolStrip_MenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Main)).BeginInit();
            this.splitContainer_Main.Panel1.SuspendLayout();
            this.splitContainer_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_TileSelector)).BeginInit();
            this.splitContainer_TileSelector.Panel1.SuspendLayout();
            this.splitContainer_TileSelector.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_previewTile)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip_MenuStrip
            // 
            this.toolStrip_MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton_FileMenu});
            this.toolStrip_MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip_MenuStrip.Name = "toolStrip_MenuStrip";
            this.toolStrip_MenuStrip.Size = new System.Drawing.Size(800, 25);
            this.toolStrip_MenuStrip.TabIndex = 0;
            this.toolStrip_MenuStrip.Text = "toolStrip_MenuStrip";
            // 
            // toolStripDropDownButton_FileMenu
            // 
            this.toolStripDropDownButton_FileMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton_FileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newMapToolStripMenuItem,
            this.toolStripSeparator2,
            this.saveMapToolStripMenuItem,
            this.saveMapAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.loadMapFileToolStripMenuItem,
            this.loadTilesetFileToolStripMenuItem,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem});
            this.toolStripDropDownButton_FileMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton_FileMenu.Name = "toolStripDropDownButton_FileMenu";
            this.toolStripDropDownButton_FileMenu.Size = new System.Drawing.Size(38, 22);
            this.toolStripDropDownButton_FileMenu.Text = "File";
            this.toolStripDropDownButton_FileMenu.ToolTipText = "File...";
            // 
            // newMapToolStripMenuItem
            // 
            this.newMapToolStripMenuItem.Name = "newMapToolStripMenuItem";
            this.newMapToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.newMapToolStripMenuItem.Text = "New Map..";
            this.newMapToolStripMenuItem.Click += new System.EventHandler(this.newMapToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(161, 6);
            // 
            // saveMapToolStripMenuItem
            // 
            this.saveMapToolStripMenuItem.Name = "saveMapToolStripMenuItem";
            this.saveMapToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.saveMapToolStripMenuItem.Text = "Save Map..";
            this.saveMapToolStripMenuItem.Click += new System.EventHandler(this.saveMapToolStripMenuItem_Click);
            // 
            // saveMapAsToolStripMenuItem
            // 
            this.saveMapAsToolStripMenuItem.Name = "saveMapAsToolStripMenuItem";
            this.saveMapAsToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.saveMapAsToolStripMenuItem.Text = "Save Map As..";
            this.saveMapAsToolStripMenuItem.Click += new System.EventHandler(this.saveMapAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(161, 6);
            // 
            // loadMapFileToolStripMenuItem
            // 
            this.loadMapFileToolStripMenuItem.Name = "loadMapFileToolStripMenuItem";
            this.loadMapFileToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.loadMapFileToolStripMenuItem.Text = "Load Map File..";
            this.loadMapFileToolStripMenuItem.Click += new System.EventHandler(this.loadMapFileToolStripMenuItem_Click);
            // 
            // loadTilesetFileToolStripMenuItem
            // 
            this.loadTilesetFileToolStripMenuItem.Name = "loadTilesetFileToolStripMenuItem";
            this.loadTilesetFileToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.loadTilesetFileToolStripMenuItem.Text = "Load Tileset File..";
            this.loadTilesetFileToolStripMenuItem.Click += new System.EventHandler(this.loadTilesetFileToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(161, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // splitContainer_Main
            // 
            this.splitContainer_Main.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_Main.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer_Main.IsSplitterFixed = true;
            this.splitContainer_Main.Location = new System.Drawing.Point(0, 25);
            this.splitContainer_Main.Name = "splitContainer_Main";
            // 
            // splitContainer_Main.Panel1
            // 
            this.splitContainer_Main.Panel1.Controls.Add(this.splitContainer_TileSelector);
            // 
            // splitContainer_Main.Panel2
            // 
            this.splitContainer_Main.Panel2.AutoScroll = true;
            this.splitContainer_Main.Panel2.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.splitContainer_Main.Size = new System.Drawing.Size(800, 425);
            this.splitContainer_Main.SplitterDistance = 151;
            this.splitContainer_Main.TabIndex = 1;
            // 
            // splitContainer_TileSelector
            // 
            this.splitContainer_TileSelector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer_TileSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_TileSelector.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer_TileSelector.IsSplitterFixed = true;
            this.splitContainer_TileSelector.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_TileSelector.Name = "splitContainer_TileSelector";
            this.splitContainer_TileSelector.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_TileSelector.Panel1
            // 
            this.splitContainer_TileSelector.Panel1.Controls.Add(this.label_rotateLabel);
            this.splitContainer_TileSelector.Panel1.Controls.Add(this.button_horizontalMirror);
            this.splitContainer_TileSelector.Panel1.Controls.Add(this.button_verticalMirror);
            this.splitContainer_TileSelector.Panel1.Controls.Add(this.button_rotateRight);
            this.splitContainer_TileSelector.Panel1.Controls.Add(this.button_rotateLeft);
            this.splitContainer_TileSelector.Panel1.Controls.Add(this.pictureBox_previewTile);
            // 
            // splitContainer_TileSelector.Panel2
            // 
            this.splitContainer_TileSelector.Panel2.AutoScroll = true;
            this.splitContainer_TileSelector.Panel2.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.splitContainer_TileSelector.Size = new System.Drawing.Size(151, 425);
            this.splitContainer_TileSelector.SplitterDistance = 100;
            this.splitContainer_TileSelector.TabIndex = 0;
            // 
            // label_rotateLabel
            // 
            this.label_rotateLabel.AutoSize = true;
            this.label_rotateLabel.Location = new System.Drawing.Point(55, 12);
            this.label_rotateLabel.Name = "label_rotateLabel";
            this.label_rotateLabel.Size = new System.Drawing.Size(39, 13);
            this.label_rotateLabel.TabIndex = 5;
            this.label_rotateLabel.Text = "Rotate";
            // 
            // button_horizontalMirror
            // 
            this.button_horizontalMirror.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_horizontalMirror.Location = new System.Drawing.Point(94, 54);
            this.button_horizontalMirror.Name = "button_horizontalMirror";
            this.button_horizontalMirror.Size = new System.Drawing.Size(55, 40);
            this.button_horizontalMirror.TabIndex = 4;
            this.button_horizontalMirror.Text = "Horizon. Mirror";
            this.button_horizontalMirror.UseVisualStyleBackColor = true;
            this.button_horizontalMirror.Click += new System.EventHandler(this.button_horizontalMirror_Click);
            // 
            // button_verticalMirror
            // 
            this.button_verticalMirror.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_verticalMirror.Location = new System.Drawing.Point(0, 55);
            this.button_verticalMirror.Name = "button_verticalMirror";
            this.button_verticalMirror.Size = new System.Drawing.Size(55, 40);
            this.button_verticalMirror.TabIndex = 3;
            this.button_verticalMirror.Text = "Vertical Mirror";
            this.button_verticalMirror.UseVisualStyleBackColor = true;
            this.button_verticalMirror.Click += new System.EventHandler(this.button_verticalMirror_Click);
            // 
            // button_rotateRight
            // 
            this.button_rotateRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_rotateRight.Location = new System.Drawing.Point(116, 3);
            this.button_rotateRight.Name = "button_rotateRight";
            this.button_rotateRight.Size = new System.Drawing.Size(30, 30);
            this.button_rotateRight.TabIndex = 2;
            this.button_rotateRight.Text = "->";
            this.button_rotateRight.UseVisualStyleBackColor = true;
            this.button_rotateRight.Click += new System.EventHandler(this.button_rotateRight_Click);
            // 
            // button_rotateLeft
            // 
            this.button_rotateLeft.Location = new System.Drawing.Point(3, 3);
            this.button_rotateLeft.Name = "button_rotateLeft";
            this.button_rotateLeft.Size = new System.Drawing.Size(30, 30);
            this.button_rotateLeft.TabIndex = 1;
            this.button_rotateLeft.Text = "<-";
            this.button_rotateLeft.UseVisualStyleBackColor = true;
            this.button_rotateLeft.Click += new System.EventHandler(this.button_rotateLeft_Click);
            // 
            // pictureBox_previewTile
            // 
            this.pictureBox_previewTile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_previewTile.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox_previewTile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_previewTile.Location = new System.Drawing.Point(57, 34);
            this.pictureBox_previewTile.Name = "pictureBox_previewTile";
            this.pictureBox_previewTile.Size = new System.Drawing.Size(35, 32);
            this.pictureBox_previewTile.TabIndex = 0;
            this.pictureBox_previewTile.TabStop = false;
            // 
            // label_LevelCountLabel
            // 
            this.label_LevelCountLabel.AutoSize = true;
            this.label_LevelCountLabel.Location = new System.Drawing.Point(59, 6);
            this.label_LevelCountLabel.Name = "label_LevelCountLabel";
            this.label_LevelCountLabel.Size = new System.Drawing.Size(39, 13);
            this.label_LevelCountLabel.TabIndex = 2;
            this.label_LevelCountLabel.Text = "Level: ";
            // 
            // label_levelCountNumber
            // 
            this.label_levelCountNumber.AutoSize = true;
            this.label_levelCountNumber.Location = new System.Drawing.Point(104, 6);
            this.label_levelCountNumber.Name = "label_levelCountNumber";
            this.label_levelCountNumber.Size = new System.Drawing.Size(31, 13);
            this.label_levelCountNumber.TabIndex = 3;
            this.label_levelCountNumber.Text = "1234";
            // 
            // textBox_LevelName
            // 
            this.textBox_LevelName.Location = new System.Drawing.Point(141, 3);
            this.textBox_LevelName.Name = "textBox_LevelName";
            this.textBox_LevelName.Size = new System.Drawing.Size(140, 20);
            this.textBox_LevelName.TabIndex = 4;
            this.textBox_LevelName.TextChanged += new System.EventHandler(this.textBox_LevelName_TextChanged);
            // 
            // button_prevLevel
            // 
            this.button_prevLevel.Location = new System.Drawing.Point(287, 1);
            this.button_prevLevel.Name = "button_prevLevel";
            this.button_prevLevel.Size = new System.Drawing.Size(80, 23);
            this.button_prevLevel.TabIndex = 5;
            this.button_prevLevel.Text = "< Prev. Level";
            this.button_prevLevel.UseVisualStyleBackColor = true;
            this.button_prevLevel.Click += new System.EventHandler(this.button_prevLevel_Click);
            // 
            // button_nextLevel
            // 
            this.button_nextLevel.Location = new System.Drawing.Point(373, 1);
            this.button_nextLevel.Name = "button_nextLevel";
            this.button_nextLevel.Size = new System.Drawing.Size(75, 23);
            this.button_nextLevel.TabIndex = 6;
            this.button_nextLevel.Text = "Next Level >";
            this.button_nextLevel.UseVisualStyleBackColor = true;
            this.button_nextLevel.Click += new System.EventHandler(this.button_nextLevel_Click);
            // 
            // button_deleteLevel
            // 
            this.button_deleteLevel.Location = new System.Drawing.Point(713, 1);
            this.button_deleteLevel.Name = "button_deleteLevel";
            this.button_deleteLevel.Size = new System.Drawing.Size(75, 23);
            this.button_deleteLevel.TabIndex = 7;
            this.button_deleteLevel.Text = "Delete Level";
            this.button_deleteLevel.UseVisualStyleBackColor = true;
            this.button_deleteLevel.Click += new System.EventHandler(this.button_deleteLevel_Click);
            // 
            // button_addLevel
            // 
            this.button_addLevel.Location = new System.Drawing.Point(632, 1);
            this.button_addLevel.Name = "button_addLevel";
            this.button_addLevel.Size = new System.Drawing.Size(75, 23);
            this.button_addLevel.TabIndex = 8;
            this.button_addLevel.Text = "Add Level";
            this.button_addLevel.UseVisualStyleBackColor = true;
            this.button_addLevel.Click += new System.EventHandler(this.button_addLevel_Click);
            // 
            // button_addEntity
            // 
            this.button_addEntity.Location = new System.Drawing.Point(454, 1);
            this.button_addEntity.Name = "button_addEntity";
            this.button_addEntity.Size = new System.Drawing.Size(75, 23);
            this.button_addEntity.TabIndex = 9;
            this.button_addEntity.Text = "Add Entity..";
            this.button_addEntity.UseVisualStyleBackColor = true;
            this.button_addEntity.Click += new System.EventHandler(this.button_addEntity_Click);
            // 
            // button_removeentity
            // 
            this.button_removeentity.Location = new System.Drawing.Point(535, 1);
            this.button_removeentity.Name = "button_removeentity";
            this.button_removeentity.Size = new System.Drawing.Size(91, 23);
            this.button_removeentity.TabIndex = 10;
            this.button_removeentity.Text = "Remove Entity..";
            this.button_removeentity.UseVisualStyleBackColor = true;
            this.button_removeentity.Click += new System.EventHandler(this.button_removeentity_Click);
            // 
            // Form_editorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_removeentity);
            this.Controls.Add(this.button_addEntity);
            this.Controls.Add(this.button_addLevel);
            this.Controls.Add(this.button_deleteLevel);
            this.Controls.Add(this.button_nextLevel);
            this.Controls.Add(this.button_prevLevel);
            this.Controls.Add(this.textBox_LevelName);
            this.Controls.Add(this.label_levelCountNumber);
            this.Controls.Add(this.label_LevelCountLabel);
            this.Controls.Add(this.splitContainer_Main);
            this.Controls.Add(this.toolStrip_MenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_editorWindow";
            this.Text = "TileMapEditor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_editorWindow_FormClosing);
            this.Load += new System.EventHandler(this.Form_editorWindow_Load);
            this.toolStrip_MenuStrip.ResumeLayout(false);
            this.toolStrip_MenuStrip.PerformLayout();
            this.splitContainer_Main.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Main)).EndInit();
            this.splitContainer_Main.ResumeLayout(false);
            this.splitContainer_TileSelector.Panel1.ResumeLayout(false);
            this.splitContainer_TileSelector.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_TileSelector)).EndInit();
            this.splitContainer_TileSelector.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_previewTile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip_MenuStrip;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton_FileMenu;
        private System.Windows.Forms.ToolStripMenuItem newMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem saveMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveMapAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem loadMapFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadTilesetFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer_Main;
        private System.Windows.Forms.SplitContainer splitContainer_TileSelector;
        private System.Windows.Forms.PictureBox pictureBox_previewTile;
        private System.Windows.Forms.Button button_rotateRight;
        private System.Windows.Forms.Button button_rotateLeft;
        private System.Windows.Forms.Button button_verticalMirror;
        private System.Windows.Forms.Button button_horizontalMirror;
        private System.Windows.Forms.Label label_LevelCountLabel;
        private System.Windows.Forms.Label label_levelCountNumber;
        private System.Windows.Forms.TextBox textBox_LevelName;
        private System.Windows.Forms.Button button_prevLevel;
        private System.Windows.Forms.Button button_nextLevel;
        private System.Windows.Forms.Button button_deleteLevel;
        private System.Windows.Forms.Button button_addLevel;
        private System.Windows.Forms.Label label_rotateLabel;
        private System.Windows.Forms.Button button_addEntity;
        private System.Windows.Forms.Button button_removeentity;
    }
}

