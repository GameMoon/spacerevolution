using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace TileMapEditor
{
    class loadSavePopper
    {
        public static string mapFilePath;
        public static string tileFilePath;
        public static bool savedSinceLastedit = true;

        public static bool SaveFileAsDialog()
        {
            SaveFileDialog newMapFile = new SaveFileDialog();
            newMapFile.Filter = "SR Map|*.srm|All Files|*.*";
            newMapFile.Title = "Select SR mapfile...";
            if (newMapFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                mapFilePath = newMapFile.FileName;
                savedSinceLastedit = true;
                return true;
            }
            else return false;
        }

        public static bool LoadTilesetDialog()
        {
            {
                OpenFileDialog openTileFile = new OpenFileDialog();
                openTileFile.Filter = "PNG Image|*.png|All Files|*.*";
                openTileFile.Title = "Select a Tileset File";

                if (openTileFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    tileFilePath = openTileFile.FileName;
                    return true;
                }
                else return false;
            }
        }
        public static bool LoadMapFileDialog()
        {
            OpenFileDialog openMapFile = new OpenFileDialog();
            openMapFile.Filter = "SR Map|*.srm|All Files|*.*";
            openMapFile.Title = "Select a Map File";

            if (openMapFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                mapFilePath = openMapFile.FileName;
                return true;
            }
            else return false;
        }
        
        public static bool progEnd()
        {
            if(savedSinceLastedit)
            {
                Environment.Exit(0);
                return true;
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure?", "Exit without saving?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Environment.Exit(0);
                    return true;
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                    return false;
                }
                else return false;
            }
        }

        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }
    }
}
