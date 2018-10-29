using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minotaur
{
    public partial class Minotaur : Form
    {
        public Minotaur()
        {
            InitializeComponent();
            richTextBox1.Text = "<h1> Minautor is French ! </h1>";
            richTextBox1.SelectAll();
        }


        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            String[] azure = { "{", "}", ">", "<"};
            for (int i = 0; i < azure.Length; i++)
            {
                this.CheckKeyword(azure[i], Color.DarkSalmon, 0);
            }

            String[] gold = { "+", "-", "(", ")" };
            for (int i = 0; i < gold.Length; i++)
            {
                this.CheckKeyword(gold[i], Color.Gold, 0);
            }

            String[] khaki = { "public", "static", "return", "break" };
            for (int i = 0; i < khaki.Length; i++)
            {
                this.CheckKeyword(khaki[i], Color.DarkKhaki, 0);
            }

            String[] blue = { "int", "String", "float", "Array" };
            for (int i = 0; i < blue.Length; i++)
            {
                this.CheckKeyword(blue[i], Color.CornflowerBlue, 0);
            }

            String[] lavender = { "\"", ";", "'" };
            for (int i = 0; i < khaki.Length; i++)
            {
                this.CheckKeyword(khaki[i], Color.Khaki, 0);
            }
        }

        private void CheckKeyword(string word, Color color, int startIndex)
        {

            if (this.richTextBox1.Text.Contains(word))
            {
                int index = -1;
                int selectStart = this.richTextBox1.SelectionStart;

                while ((index = this.richTextBox1.Text.IndexOf(word, (index + 1))) != -1)
                {
                    this.richTextBox1.Select((index + startIndex), word.Length);
                    this.richTextBox1.SelectionColor = color;
                    this.richTextBox1.Select(selectStart, 0);
                    this.richTextBox1.SelectionColor = Color.AntiqueWhite;
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();

            save.FileName = "EditMe.minautor";
            save.Filter = "All files (*.*)|*.*";

            if (save.ShowDialog() == DialogResult.OK)

            {

                StreamWriter writer = new StreamWriter(save.OpenFile());
                writer.Write(richTextBox1.Text);
                writer.Dispose();
                writer.Close();

            }
        }

        public void newWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Minotaur f2 = new Minotaur())
            {
                f2.ShowDialog(this);
            }
        }

        private void resetToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Reset you code ?", "Confirm", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                richTextBox1.Clear();
            }   
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
