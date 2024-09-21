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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WordPadCopyCat
{
    public partial class Form1 : Form
    {
        string path = "./Saved Files";
        
        bool bold;
        bool italic;
        bool underLine;
        string copyboard;


        public Form1()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            List<string> fonts = new List<string>();

            foreach (FontFamily font in System.Drawing.FontFamily.Families)
            {
                cb_fonts.Items.Add(font.Name);
            }

            for (int i = 1; i < 72; i++)
            {
                cb_fontsize.Items.Add(i);
            }
            cb_fonts.SelectedItem = "Calibri";
            cb_fontsize.SelectedIndex = 11;
            saveFileDialog1.Filter = "Rich Text Files (*.rtf)|*.rtf|Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            saveFileDialog1.Title = "Save File";
            saveFileDialog2.Filter = "Rich Text Files (*.rtf)|*.rtf|All Files (*.*)|*.*";
            saveFileDialog2.Title = "Save File";
            saveFileDialog3.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            saveFileDialog3.Title = "Save File";
            tssl_saved.Text ="Data unsaved";
        }

        private void rtb_textBox_TextChanged(object sender, EventArgs e)
        {

            if (float.TryParse(cb_fontsize.SelectedItem.ToString(), out float newsize))
            {
                if (rtb_textBox.SelectedText == null)
                {
                    rtb_textBox.Font = new Font(cb_fonts.SelectedItem.ToString(), newsize);
                }
            }

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            rtb_textBox.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            rtb_textBox.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            rtb_textBox.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void cb_fonts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rtb_textBox.SelectedText.Length > 0)
            {
                rtb_textBox.Select(rtb_textBox.SelectionStart, rtb_textBox.SelectionLength);
                rtb_textBox.SelectionFont = new Font(cb_fonts.SelectedItem.ToString(), rtb_textBox.SelectionFont.Size);
            }
            else if (rtb_textBox.SelectedText == "")
            {
                rtb_textBox.Font = new Font(cb_fonts.SelectedItem.ToString(), rtb_textBox.SelectionFont.Size);
            }

        }

        private void cb_fontsize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (float.TryParse(cb_fontsize.SelectedItem.ToString(), out float newsize))
            {
                Font oldFont = rtb_textBox.Font;
                rtb_textBox.Font = new Font(oldFont.FontFamily, newsize, oldFont.Style);
            }
        }

        private void btn_fontsizeUp_Click(object sender, EventArgs e)
        {
            Font currentFont = rtb_textBox.SelectionFont;

            FontStyle currentStyle = new FontStyle();
            currentStyle = rtb_textBox.SelectionFont.Style;
            rtb_textBox.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size + 1, currentStyle);

            cb_fontsize.SelectedIndex++;



        }

        private void btn_fontsizeDown_Click(object sender, EventArgs e)
        {

            Font currentFont = rtb_textBox.SelectionFont;

            FontStyle currentStyle = new FontStyle();
            currentStyle = rtb_textBox.SelectionFont.Style;
            rtb_textBox.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size - 1, currentStyle);

            cb_fontsize.SelectedIndex--;




        }

        private void btn_bold_Click(object sender, EventArgs e)
        {
            if (rtb_textBox.SelectionFont != null)
            {
                Font currentFont = rtb_textBox.SelectionFont;
                FontStyle newFontStyle = rtb_textBox.SelectionFont.Style ^ FontStyle.Bold;
                rtb_textBox.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
            }
        }

        private void btn_italic_Click(object sender, EventArgs e)
        {
            if (rtb_textBox.SelectionFont != null)
            {
                Font currentFont = rtb_textBox.SelectionFont;
                FontStyle newFontStyle = rtb_textBox.SelectionFont.Style ^ FontStyle.Italic;
                rtb_textBox.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
            }
        }

        private void btn_underline_Click(object sender, EventArgs e)
        {
            if (rtb_textBox.SelectionFont != null)
            {
                Font currentFont = rtb_textBox.SelectionFont;
                FontStyle newFontStyle = rtb_textBox.SelectionFont.Style ^ FontStyle.Underline;
                rtb_textBox.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
            }
        }

        private void btn_colors_Click(object sender, EventArgs e)
        {
            ColoursForm colorss = new ColoursForm();

            colorss.ColorSelected += ColoursForm_ColorSelected;
            colorss.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("You are exiting the program, all the unsaved data will be lost!!!", "Warning", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                this.Close();

            }
        }
        private void ColoursForm_ColorSelected(Color color)
        {
            rtb_textBox.SelectionColor = color;
        }

        private void tsbtn_copy_Click(object sender, EventArgs e)
        {
            if (rtb_textBox.SelectedText != string.Empty)
            {
                copyboard = rtb_textBox.SelectedRtf;
                Clipboard.SetText(rtb_textBox.SelectedText);
            }

        }

        private void tsbtn_cut_Click(object sender, EventArgs e)
        {
            if (rtb_textBox.SelectedText != string.Empty)
            {
                copyboard = rtb_textBox.SelectedRtf;
                Clipboard.SetText(rtb_textBox.SelectedText);
                rtb_textBox.SelectedText = string.Empty;
            }
        }

        private void tsbtn_paste_Click(object sender, EventArgs e)
        {
            rtb_textBox.SelectedText = Clipboard.GetText();
        }

       
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName;
                string rtfText = File.ReadAllText(fileName);
                rtb_textBox.Rtf = rtfText;
               
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rtb_textBox.Text != null)
            {
                if (saveFileDialog1.ShowDialog()==DialogResult.OK)
                {
                    
                    if (saveFileDialog1.FileName != null)
                    {
                        string fileName = saveFileDialog1.FileName;
                        FileStream fs = new FileStream(fileName, FileMode.CreateNew);
                        fs.Close();
                        File.WriteAllText(fileName, rtb_textBox.Text);
                        tssl_saved.Text = fileName + " saved successfully";
                    }
                    else
                    {
                        MessageBox.Show("Please define a file name!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                
            }
        }

        private void richTextFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rtb_textBox.Text != null)
            {
                if (saveFileDialog2.ShowDialog() == DialogResult.OK)
                {

                    if (saveFileDialog2.FileName != null)
                    {
                        string fileName = saveFileDialog2.FileName;
                        FileStream fs = new FileStream(fileName, FileMode.CreateNew);
                        fs.Close();
                        rtb_textBox.SaveFile(fileName,RichTextBoxStreamType.RichNoOleObjs);
                        tssl_saved.Text = fileName + " saved successfully";


                    }
                    else
                    {
                        MessageBox.Show("Please define a file name!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            }
        }

        private void textFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rtb_textBox.Text != null)
            {
                if (saveFileDialog3.ShowDialog() == DialogResult.OK)
                {

                    if (saveFileDialog3.FileName != null)
                    {
                        string fileName = saveFileDialog3.FileName;
                        FileStream fs = new FileStream(fileName, FileMode.CreateNew);
                        fs.Close();
                        rtb_textBox.SaveFile(fileName, RichTextBoxStreamType.PlainText);
                        tssl_saved.Text = fileName + " saved successfully";


                    }
                    else
                    {
                        MessageBox.Show("Please define a file name!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutWordPadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("I created this copycat of wordpad for my Keyf Kahya xp","About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("You are exiting the program, all the unsaved data will be lost!!!", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                Environment.Exit(0);

            }
            if (dr==DialogResult.Cancel)
            {
                e.Cancel = true;
            }

        }
    }
}
