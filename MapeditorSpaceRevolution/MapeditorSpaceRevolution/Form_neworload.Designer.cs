namespace MapeditorSpaceRevolution
{
    partial class Form_neworload
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
            this.button_newmap = new System.Windows.Forms.Button();
            this.label_neworload = new System.Windows.Forms.Label();
            this.button_loadmap = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_newmap
            // 
            this.button_newmap.Location = new System.Drawing.Point(17, 96);
            this.button_newmap.Name = "button_newmap";
            this.button_newmap.Size = new System.Drawing.Size(136, 23);
            this.button_newmap.TabIndex = 0;
            this.button_newmap.Text = "Create New...";
            this.button_newmap.UseVisualStyleBackColor = true;
            this.button_newmap.Click += new System.EventHandler(this.button_newmap_Click);
            // 
            // label_neworload
            // 
            this.label_neworload.AutoSize = true;
            this.label_neworload.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_neworload.Location = new System.Drawing.Point(13, 13);
            this.label_neworload.Name = "label_neworload";
            this.label_neworload.Size = new System.Drawing.Size(515, 24);
            this.label_neworload.TabIndex = 1;
            this.label_neworload.Text = "Would you like to create a new map or load an existing one?";
            // 
            // button_loadmap
            // 
            this.button_loadmap.Location = new System.Drawing.Point(391, 95);
            this.button_loadmap.Name = "button_loadmap";
            this.button_loadmap.Size = new System.Drawing.Size(136, 23);
            this.button_loadmap.TabIndex = 2;
            this.button_loadmap.Text = "Load...";
            this.button_loadmap.UseVisualStyleBackColor = true;
            this.button_loadmap.Click += new System.EventHandler(this.button_loadmap_Click);
            // 
            // Form_neworload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 133);
            this.Controls.Add(this.button_loadmap);
            this.Controls.Add(this.label_neworload);
            this.Controls.Add(this.button_newmap);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_neworload";
            this.Text = "Space Revolution map editor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_newmap;
        private System.Windows.Forms.Label label_neworload;
        private System.Windows.Forms.Button button_loadmap;
    }
}

