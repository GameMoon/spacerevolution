namespace MapeditorSpaceRevolution
{
    partial class Form_editor
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
            this.toolStrip_editwindow = new System.Windows.Forms.ToolStrip();
            this.toolStrip_File = new System.Windows.Forms.ToolStripDropDownButton();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.loadMapFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadTilesetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.button_nextmap = new System.Windows.Forms.Button();
            this.label_lnamedontchangethis = new System.Windows.Forms.Label();
            this.button_prev = new System.Windows.Forms.Button();
            this.button_addlevel = new System.Windows.Forms.Button();
            this.textBox_levelname = new System.Windows.Forms.TextBox();
            this.label_levelcounter = new System.Windows.Forms.Label();
            this.pictureBox_selectedtiletransfer = new System.Windows.Forms.PictureBox();
            this.button_rotleft = new System.Windows.Forms.Button();
            this.button_rotright = new System.Windows.Forms.Button();
            this.button_vertinvert = new System.Windows.Forms.Button();
            this.button_horinvert = new System.Windows.Forms.Button();
            this.toolStrip_editwindow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_selectedtiletransfer)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip_editwindow
            // 
            this.toolStrip_editwindow.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip_File});
            this.toolStrip_editwindow.Location = new System.Drawing.Point(0, 0);
            this.toolStrip_editwindow.Name = "toolStrip_editwindow";
            this.toolStrip_editwindow.Size = new System.Drawing.Size(800, 25);
            this.toolStrip_editwindow.TabIndex = 0;
            this.toolStrip_editwindow.Text = "toolStrip_editor";
            // 
            // toolStrip_File
            // 
            this.toolStrip_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.loadMapFileToolStripMenuItem,
            this.loadTilesetToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.toolStrip_File.Name = "toolStrip_File";
            this.toolStrip_File.Size = new System.Drawing.Size(38, 22);
            this.toolStrip_File.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save...";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // loadMapFileToolStripMenuItem
            // 
            this.loadMapFileToolStripMenuItem.Name = "loadMapFileToolStripMenuItem";
            this.loadMapFileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadMapFileToolStripMenuItem.Text = "Load Map File...";
            this.loadMapFileToolStripMenuItem.Click += new System.EventHandler(this.loadMapFileToolStripMenuItem_Click);
            // 
            // loadTilesetToolStripMenuItem
            // 
            this.loadTilesetToolStripMenuItem.Name = "loadTilesetToolStripMenuItem";
            this.loadTilesetToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadTilesetToolStripMenuItem.Text = "Load Tileset...";
            this.loadTilesetToolStripMenuItem.Click += new System.EventHandler(this.loadTilesetToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel1.SizeChanged += new System.EventHandler(this.splitContainer1_Panel1_SizeChanged);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Size = new System.Drawing.Size(800, 425);
            this.splitContainer1.SplitterDistance = 148;
            this.splitContainer1.TabIndex = 1;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.splitContainer2.Panel1.Controls.Add(this.button_horinvert);
            this.splitContainer2.Panel1.Controls.Add(this.button_vertinvert);
            this.splitContainer2.Panel1.Controls.Add(this.button_rotright);
            this.splitContainer2.Panel1.Controls.Add(this.button_rotleft);
            this.splitContainer2.Panel1.Controls.Add(this.pictureBox_selectedtiletransfer);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.splitContainer2.Size = new System.Drawing.Size(148, 425);
            this.splitContainer2.SplitterDistance = 100;
            this.splitContainer2.TabIndex = 0;
            this.splitContainer2.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer2_SplitterMoved);
            // 
            // button_nextmap
            // 
            this.button_nextmap.Location = new System.Drawing.Point(725, 0);
            this.button_nextmap.Name = "button_nextmap";
            this.button_nextmap.Size = new System.Drawing.Size(75, 23);
            this.button_nextmap.TabIndex = 2;
            this.button_nextmap.Text = "Next Level >";
            this.button_nextmap.UseVisualStyleBackColor = true;
            this.button_nextmap.Click += new System.EventHandler(this.button_nextmap_Click);
            // 
            // label_lnamedontchangethis
            // 
            this.label_lnamedontchangethis.AutoSize = true;
            this.label_lnamedontchangethis.Location = new System.Drawing.Point(147, 6);
            this.label_lnamedontchangethis.Name = "label_lnamedontchangethis";
            this.label_lnamedontchangethis.Size = new System.Drawing.Size(36, 13);
            this.label_lnamedontchangethis.TabIndex = 3;
            this.label_lnamedontchangethis.Text = "Level:";
            // 
            // button_prev
            // 
            this.button_prev.Location = new System.Drawing.Point(641, 0);
            this.button_prev.Name = "button_prev";
            this.button_prev.Size = new System.Drawing.Size(78, 23);
            this.button_prev.TabIndex = 4;
            this.button_prev.Text = "< Prev. Level";
            this.button_prev.UseVisualStyleBackColor = true;
            this.button_prev.Click += new System.EventHandler(this.button_prev_Click);
            // 
            // button_addlevel
            // 
            this.button_addlevel.Location = new System.Drawing.Point(558, 0);
            this.button_addlevel.Name = "button_addlevel";
            this.button_addlevel.Size = new System.Drawing.Size(77, 23);
            this.button_addlevel.TabIndex = 6;
            this.button_addlevel.Text = "Add Level..";
            this.button_addlevel.UseVisualStyleBackColor = true;
            this.button_addlevel.Click += new System.EventHandler(this.button_addlevel_Click);
            // 
            // textBox_levelname
            // 
            this.textBox_levelname.Location = new System.Drawing.Point(204, 3);
            this.textBox_levelname.Name = "textBox_levelname";
            this.textBox_levelname.Size = new System.Drawing.Size(348, 20);
            this.textBox_levelname.TabIndex = 7;
            this.textBox_levelname.TextChanged += new System.EventHandler(this.textBox_levelname_TextChanged);
            // 
            // label_levelcounter
            // 
            this.label_levelcounter.AutoSize = true;
            this.label_levelcounter.Location = new System.Drawing.Point(189, 6);
            this.label_levelcounter.Name = "label_levelcounter";
            this.label_levelcounter.Size = new System.Drawing.Size(9, 13);
            this.label_levelcounter.TabIndex = 8;
            this.label_levelcounter.Text = "l";
            // 
            // pictureBox_selectedtiletransfer
            // 
            this.pictureBox_selectedtiletransfer.BackColor = System.Drawing.Color.Black;
            this.pictureBox_selectedtiletransfer.Location = new System.Drawing.Point(58, 34);
            this.pictureBox_selectedtiletransfer.Name = "pictureBox_selectedtiletransfer";
            this.pictureBox_selectedtiletransfer.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_selectedtiletransfer.TabIndex = 0;
            this.pictureBox_selectedtiletransfer.TabStop = false;
            // 
            // button_rotleft
            // 
            this.button_rotleft.Location = new System.Drawing.Point(3, 3);
            this.button_rotleft.Name = "button_rotleft";
            this.button_rotleft.Size = new System.Drawing.Size(59, 23);
            this.button_rotleft.TabIndex = 1;
            this.button_rotleft.Text = "<- Rotate";
            this.button_rotleft.UseVisualStyleBackColor = true;
            this.button_rotleft.Click += new System.EventHandler(this.button_rotleft_Click);
            // 
            // button_rotright
            // 
            this.button_rotright.Location = new System.Drawing.Point(88, 3);
            this.button_rotright.Name = "button_rotright";
            this.button_rotright.Size = new System.Drawing.Size(56, 23);
            this.button_rotright.TabIndex = 2;
            this.button_rotright.Text = "Rotate->";
            this.button_rotright.UseVisualStyleBackColor = true;
            this.button_rotright.Click += new System.EventHandler(this.button_rotright_Click);
            // 
            // button_vertinvert
            // 
            this.button_vertinvert.Location = new System.Drawing.Point(3, 33);
            this.button_vertinvert.Name = "button_vertinvert";
            this.button_vertinvert.Size = new System.Drawing.Size(49, 43);
            this.button_vertinvert.TabIndex = 3;
            this.button_vertinvert.Text = "Vert. Mirror";
            this.button_vertinvert.UseVisualStyleBackColor = true;
            this.button_vertinvert.Click += new System.EventHandler(this.button_vertinvert_Click);
            // 
            // button_horinvert
            // 
            this.button_horinvert.Location = new System.Drawing.Point(96, 32);
            this.button_horinvert.Name = "button_horinvert";
            this.button_horinvert.Size = new System.Drawing.Size(47, 44);
            this.button_horinvert.TabIndex = 4;
            this.button_horinvert.Text = "Horiz. Mirror";
            this.button_horinvert.UseVisualStyleBackColor = true;
            this.button_horinvert.Click += new System.EventHandler(this.button_horinvert_Click);
            // 
            // Form_editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label_levelcounter);
            this.Controls.Add(this.textBox_levelname);
            this.Controls.Add(this.button_addlevel);
            this.Controls.Add(this.button_prev);
            this.Controls.Add(this.label_lnamedontchangethis);
            this.Controls.Add(this.button_nextmap);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip_editwindow);
            this.Name = "Form_editor";
            this.Text = "Space Revolution - Map Editor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_editor_FormClosed);
            this.Resize += new System.EventHandler(this.Form_editor_Resize);
            this.toolStrip_editwindow.ResumeLayout(false);
            this.toolStrip_editwindow.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_selectedtiletransfer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip_editwindow;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripDropDownButton toolStrip_File;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem loadMapFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadTilesetToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button button_nextmap;
        private System.Windows.Forms.Label label_lnamedontchangethis;
        private System.Windows.Forms.Button button_prev;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button button_addlevel;
        private System.Windows.Forms.TextBox textBox_levelname;
        private System.Windows.Forms.Label label_levelcounter;
        private System.Windows.Forms.PictureBox pictureBox_selectedtiletransfer;
        private System.Windows.Forms.Button button_rotright;
        private System.Windows.Forms.Button button_rotleft;
        private System.Windows.Forms.Button button_horinvert;
        private System.Windows.Forms.Button button_vertinvert;
    }
}