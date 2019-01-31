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
        public static string enMnemoFilePath;
        public static bool savedSinceLastedit = true;

        public static bool SaveFileAsDialog()
        {
            SaveFileDialog newMapFile = new SaveFileDialog();
            newMapFile.Filter = "Text File|*.txt|All Files|*.*";
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
            openMapFile.Filter = "Text File|*.txt|All Files|*.*";
            openMapFile.Title = "Select a Map File";

            if (openMapFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                mapFilePath = openMapFile.FileName;
                return true;
            }
            else return false;
        }

        public static bool LoadEntityMnemo()
        {
            OpenFileDialog openMapFile = new OpenFileDialog();
            openMapFile.Filter = "Text File|*.txt|All Files|*.*";
            openMapFile.Title = "Select an Entity Mnemonic File";

            if (openMapFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                enMnemoFilePath = openMapFile.FileName;
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

        public static DialogResult enMnemoSelectorWindow(ref int entid)
        {
            Form form = new Form();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();
            ListBox listBox = new ListBox();

            form.Text = "Select an Entity";

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            buttonOk.SetBounds(10, 367, 75, 23);
            buttonCancel.SetBounds(115, 367, 75, 23);
            listBox.Location = new Point(5,5);
            listBox.SetBounds(5, 5, 190, 357);
            listBox.Size = new Size(190,357);

            form.ClientSize = new Size(200, 400);
            form.Controls.AddRange(new Control[] {listBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(form.ClientSize.Width, form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;
            for (int i = 0; i < EntityMenmonics.EnMenmoList.Count(); i++)
            {
                listBox.Items.Add("Id: "+EntityMenmonics.EnMenmoList[i].id.ToString()+" "+ EntityMenmonics.EnMenmoList[i].name+ " "+ EntityMenmonics.EnMenmoList[i].defaultText);
            }
            listBox.SelectedIndex = 0;
            DialogResult dialogResult = form.ShowDialog();
            entid = listBox.SelectedIndex;
            return dialogResult;
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
