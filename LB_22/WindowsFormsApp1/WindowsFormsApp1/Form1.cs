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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        SaveFileDialog saveFileDialog1 = new SaveFileDialog();
        FontDialog fontDialog1 = new FontDialog();

        static int i = 0;

        string BufferText = "";

        bool isTyping = false;
        bool languageIsSelected = false;

        string messageBoxSaveLine = "Want to save changes?";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            englishToolStripMenuItem_Click(sender, e);

            cutToolStripMenuItem.Enabled = false;
            copyToolStripMenuItem.Enabled = false;
            deleteToolStripMenuItem.Enabled = false;
            cutToolStripMenuItem1.Enabled = false;
            pasteToolStripMenuItem1.Enabled = false;
            deleteToolStripMenuItem1.Enabled = false;

            toolStripComboBox1.SelectedText = "Consolas";
            toolStripComboBox2.SelectedText = "11";

            Graphics gr = richTextBox1.CreateGraphics();
            foreach (FontFamily F_family in FontFamily.GetFamilies(gr))
            {
                toolStripComboBox1.Items.Add(F_family.Name);
            }
            for (int fsize = 7; fsize < 73; fsize++)
            {
                if (fsize > 48)
                {
                    fsize = 72;
                }
                else if (fsize > 36)
                {
                    fsize = 48;
                }
                else if (fsize > 28)
                {
                    fsize = 36;
                }
                else if (fsize > 12)
                {
                    fsize++;
                }
                toolStripComboBox2.Items.Add(fsize);
            }            
        }

        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText != "")
            {
                cutToolStripMenuItem.Enabled = true;
                copyToolStripMenuItem.Enabled = true;
                deleteToolStripMenuItem.Enabled = true;

                cutToolStripMenuItem1.Enabled = true;
                copyToolStripMenuItem1.Enabled = true;
                pasteToolStripMenuItem1.Enabled = true;

            }
            else
            {
                cutToolStripMenuItem.Enabled = false;
                copyToolStripMenuItem.Enabled = false;
                deleteToolStripMenuItem.Enabled = false;

                cutToolStripMenuItem1.Enabled = false;
                pasteToolStripMenuItem1.Enabled = false;
                deleteToolStripMenuItem1.Enabled = false;
            }
        }

        //---------------------Open------------------------------------
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "All Files(.txt;.rtf;)|*.txt;*.rtf;";
                openFileDialog.InitialDirectory = "D:\\!Валик\\Универ\\ООП\\c#\\LB_22\\files";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();

                    }
                    if (openFileDialog.FileName.Contains(".txt"))
                    {
                        richTextBox1.Text = fileContent;
                    }
                    else
                    {
                        richTextBox1.LoadFile(filePath, RichTextBoxStreamType.RichText);
                    }
                }
            }
        }

        //---------------------Save------------------------------------
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDlg = new SaveFileDialog();
            string filename = Text;
            saveDlg.Filter = "txt files (*.txt)|*.txt|rtf files (*.rtf)|*.rtf|All files (*.*)|*.*";
            saveDlg.Title = "Save the contents";
            DialogResult retval = saveDlg.ShowDialog();
            if (retval == DialogResult.OK)
                filename = saveDlg.FileName;
            else
                return;
            RichTextBoxStreamType stream_type;
            if (saveDlg.FileName.Contains(".txt"))
                stream_type = RichTextBoxStreamType.PlainText;
            else
                stream_type = RichTextBoxStreamType.RichText;
            richTextBox1.SaveFile(filename, stream_type);
        }

        //---------------------Close------------------------------------
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            toolStripButton7_Click(sender, e);
        }
        //******************************_Edit menu_************************
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BufferText = richTextBox1.SelectedText;
            Clipboard.SetText(BufferText.ToString());
            richTextBox1.SelectedText = "";
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BufferText = richTextBox1.SelectedText;
            Clipboard.SetText(BufferText.ToString());
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = Clipboard.GetText();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText == "")
            {
                richTextBox1.Text = "";
            }
            else if (richTextBox1.SelectedText != "")
            {
                richTextBox1.SelectedText = "";
            }
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }               

        private void cutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cutToolStripMenuItem_Click(sender, e);
        }

        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            copyToolStripMenuItem_Click(sender, e);
        }

        private void pasteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            pasteToolStripMenuItem_Click(sender, e);
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            deleteToolStripMenuItem_Click(sender, e);
        }

        private void selectAllToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            selectAllToolStripMenuItem_Click(sender, e);
        }

        //******************************_Text style_************************
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Font SelectedText_Font = richTextBox1.SelectionFont;
            if (SelectedText_Font != null)
                richTextBox1.SelectionFont = new Font(SelectedText_Font, SelectedText_Font.Style ^ FontStyle.Bold);
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Font SelectedText_Font = richTextBox1.SelectionFont;
            if (SelectedText_Font != null)
                richTextBox1.SelectionFont = new Font(SelectedText_Font, SelectedText_Font.Style ^ FontStyle.Italic);
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            Font SelectedText_Font = richTextBox1.SelectionFont;
            if (SelectedText_Font != null)
                richTextBox1.SelectionFont = new Font(SelectedText_Font, SelectedText_Font.Style ^ FontStyle.Underline);
        }

        private void SetNewFont()
        {
            Font old_font;
            Font new_font;
            String FName;
            float FSize = 8;
            FontStyle style = 0;
            byte charset = 0;

            FName = toolStripComboBox1.Text;
            if (string.IsNullOrEmpty(toolStripComboBox2.Text))
                FSize = 8;
            else
                FSize = float.Parse(toolStripComboBox2.Text);
            old_font = richTextBox1.SelectionFont;

            if (old_font == null)
            {
                style = FontStyle.Regular;
            }
            else
            {
                style = old_font.Style;
                charset = old_font.GdiCharSet;
            }


            new_font = new Font(FName, FSize, style, GraphicsUnit.Point, charset);
            richTextBox1.SelectionFont = new_font;
        }
        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetNewFont();
        }

        private void toolStripComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetNewFont();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            richTextBox1.Font = Font;
            richTextBox1.ForeColor = Color.Black;
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.ShowDialog();
            richTextBox1.ForeColor = dlg.Color;
        }

        private void ukranianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            languageIsSelected = true;
            //------------edit menu----------
            cutToolStripMenuItem.Text = "Вирізати";
            copyToolStripMenuItem.Text = "Копіювати";
            pasteToolStripMenuItem.Text = "Вставити";
            deleteToolStripMenuItem.Text = "Видалити";
            selectAllToolStripMenuItem.Text = "Виділити все";

            cutToolStripMenuItem1.Text = "Вирізати";
            copyToolStripMenuItem1.Text = "Копіювати";
            pasteToolStripMenuItem1.Text = "Вставити";
            deleteToolStripMenuItem1.Text = "Видалити";
            selectAllToolStripMenuItem1.Text = "Виділити все";

            languageToolStripMenuItem.Text = "Мова";
            ukranianToolStripMenuItem.Text = "Українська";
            englishToolStripMenuItem.Text = "Англійська";

            themeToolStripMenuItem.Text = "Тема";
            whiteToolStripMenuItem.Text = "Світла";
            darkToolStripMenuItem.Text = "Темна";

            //------------Hints----------
            toolStripButton1.Text = "Відкрити";
            toolStripButton10.Text = "Нове вікно";
            toolStripButton2.Text = "Зберегти";
            toolStripDropDownButton2.Text = "Редагувати";
            toolStripButton9.Text = "Додати зображення";
            toolStripButton3.Text = "Закрити";
            toolStripButton4.Text = "Жирний";
            toolStripButton5.Text = "Курсив";
            toolStripButton6.Text = "Підкреслений";
            toolStripButton8.Text = "Колір";
            toolStripButton7.Text = "За замовчуванням";
            toolStripDropDownButton1.Text = "Налаштування";
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            languageIsSelected = false;
            //------------edit menu----------
            cutToolStripMenuItem.Text = "Cut";
            copyToolStripMenuItem.Text = "Copy";
            pasteToolStripMenuItem.Text = "Paste";
            deleteToolStripMenuItem.Text = "Delete";
            selectAllToolStripMenuItem.Text = "Select All";
            
            selectAllToolStripMenuItem1.Text = "Select All";
            deleteToolStripMenuItem1.Text = "Delete";            
            pasteToolStripMenuItem1.Text = "Paste";            
            copyToolStripMenuItem1.Text = "Copy";
            cutToolStripMenuItem1.Text = "Cut";

            languageToolStripMenuItem.Text = "Language";
            ukranianToolStripMenuItem.Text = "Ukranian";
            englishToolStripMenuItem.Text = "English";

            themeToolStripMenuItem.Text = "Theme";
            whiteToolStripMenuItem.Text = "White";
            darkToolStripMenuItem.Text = "Dark";

            //------------Hints----------
            toolStripButton1.Text = "Open";
            toolStripButton10.Text = "New Window";
            toolStripButton2.Text = "Save";
            toolStripDropDownButton2.Text = "Edit";
            toolStripButton9.Text = "Add Picture";
            toolStripButton3.Text = "Close";
            toolStripButton4.Text = "Bold";
            toolStripButton5.Text = "Italic";
            toolStripButton6.Text = "Underlined";
            toolStripButton8.Text = "Color";
            toolStripButton7.Text = "Default";
            toolStripDropDownButton1.Text = "Options";
        }

        private void createImage(string name)
        {
            Clipboard.SetImage(System.Drawing.Image.FromFile(name));
            richTextBox1.Paste();
        }
        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(.jpg;.jpeg;.png;.gif;.tif)|*.jpg;*.jpeg;*.png;*.gif;*.tif";

            if (open.ShowDialog() == DialogResult.OK)
            {
                createImage(open.FileName);
            }
        }
        
        private void coloring(Color backColor, Color foreColore)
        {
            toolStrip1.BackColor = backColor;

            richTextBox1.BackColor = backColor;
            richTextBox1.ForeColor = foreColore;

            toolStripComboBox1.BackColor = backColor;
            toolStripComboBox1.ForeColor = foreColore;
            toolStripComboBox2.BackColor = backColor;
            toolStripComboBox2.ForeColor = foreColore;

            cutToolStripMenuItem.BackColor = backColor;
            copyToolStripMenuItem.BackColor = backColor;
            pasteToolStripMenuItem.BackColor = backColor;
            deleteToolStripMenuItem.BackColor = backColor;
            selectAllToolStripMenuItem.BackColor = backColor;            
            cutToolStripMenuItem.ForeColor = foreColore;
            copyToolStripMenuItem.ForeColor = foreColore;
            pasteToolStripMenuItem.ForeColor = foreColore;
            deleteToolStripMenuItem.ForeColor = foreColore;
            selectAllToolStripMenuItem.ForeColor = foreColore;            

            cutToolStripMenuItem1.BackColor = backColor;
            copyToolStripMenuItem1.BackColor = backColor;
            pasteToolStripMenuItem1.BackColor = backColor;
            deleteToolStripMenuItem1.BackColor = backColor;
            selectAllToolStripMenuItem1.BackColor = backColor;
            cutToolStripMenuItem1.ForeColor = foreColore;
            copyToolStripMenuItem1.ForeColor = foreColore;
            pasteToolStripMenuItem1.ForeColor = foreColore;
            deleteToolStripMenuItem1.ForeColor = foreColore;
            selectAllToolStripMenuItem1.ForeColor = foreColore;

            languageToolStripMenuItem.ForeColor = foreColore;
            languageToolStripMenuItem.BackColor = backColor;
            ukranianToolStripMenuItem.BackColor = backColor;
            ukranianToolStripMenuItem.ForeColor = foreColore;
            englishToolStripMenuItem.BackColor = backColor;
            englishToolStripMenuItem.ForeColor = foreColore;    

            themeToolStripMenuItem.ForeColor = foreColore;           
            themeToolStripMenuItem.BackColor = backColor;
            whiteToolStripMenuItem.BackColor = backColor;
            whiteToolStripMenuItem.ForeColor = foreColore;
            darkToolStripMenuItem.BackColor = backColor;
            darkToolStripMenuItem.ForeColor= foreColore;
        }

        bool whiteIsSelected = false;
        bool darkIsSelected = false;
        private void darkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            darkIsSelected = true;
            Color backColor = ColorTranslator.FromHtml("#1E1E1E");
            Color foreColor = ColorTranslator.FromHtml("#B4B4B4");
            coloring(backColor, foreColor);
        }

        private void whiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            whiteIsSelected = true;
            Color backColor = Color.White;
            Color foreColor = ColorTranslator.FromHtml("#000000");
            coloring(backColor, foreColor);
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            i++;
            Form1 f = new Form1();
            if (!languageIsSelected)
            {
                f.englishToolStripMenuItem_Click(sender, e);
            }
            else
            {
                f.ukranianToolStripMenuItem_Click(sender, e);
            }
            if (whiteIsSelected)
            {
                f.whiteToolStripMenuItem_Click(sender, e);
            }
            else if (darkIsSelected)
            {
                f.darkToolStripMenuItem_Click(sender, e);
            }            
            f.Text = "wordCSharp" + i;
            int X = Location.X, Y = Location.Y;
            f.Location = new Point(X += 20, Y += 20);
            f.Show();
        }
    }
}
