using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class myForm : Form
    {
        SaveFileDialog saveFileDialog1 = new SaveFileDialog();
        FontDialog fontDialog1 = new FontDialog();

        static int i = 0;
                
        bool isTyping = false;
        bool isHihlight = false;
        bool languageIsSelected = false;

        string filePath = null;
        string BufferText = "";        
        string messageBoxSaveLine = "Want to save changes?";
        string messageBoxRtfWarningLine = "Save your file to .rft to print it!";
        string messageBoxAboutLine = "Valentyn has been creating this notepad for 7days in a row!";

        public myForm()
        {
            InitializeComponent();                        
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cutToolStripMenuItem.Enabled = false;
            copyToolStripMenuItem.Enabled = false;
            deleteToolStripMenuItem.Enabled = false;

            higlightStripMenuItem.Enabled = false;
            removeHStripMenuItem.Enabled = false;

            richTextBox1.SelectionFont = new Font("Consolas", 11, FontStyle.Regular);
        }

        private void richTextBox1_SelectionChanged_2(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText != "")
            {
                cutToolStripMenuItem.Enabled = true;
                copyToolStripMenuItem.Enabled = true;
                deleteToolStripMenuItem.Enabled = true;

                ghbToolStripMenuItem.Enabled = true;
                dfgToolStripMenuItem.Enabled = true;
                dfgToolStripMenuItem1.Enabled = true;
                
            }
            else
            {
                cutToolStripMenuItem.Enabled = false;
                copyToolStripMenuItem.Enabled = false;
                deleteToolStripMenuItem.Enabled = false;

                ghbToolStripMenuItem.Enabled = false;
                dfgToolStripMenuItem.Enabled = false;
                dfgToolStripMenuItem1.Enabled = false;
            }

            findHighlightSyntax(richTextBox1);

            if (!isHihlight)
            {
                higlightStripMenuItem.Enabled = false;
                removeHStripMenuItem.Enabled= false;
            }
            else
            {                
                isHihlight = false;
            }
        }       

        //******************************_File menu_*****************************************
        private void richTextBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            isTyping = true;
        }        

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //DialogResult dialogResult = MessageBox.Show("Текст", "Заголовок", MessageBoxButtons.YesNoCancel);
            if (richTextBox1.Text == "" || !isTyping)
            {
                richTextBox1.Text = "";
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show(messageBoxSaveLine, "notepadCSharp", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    if (filePath != null)
                    {
                        saveFileDialog1.FileName = Text;
                        richTextBox1.SaveFile(filePath, RichTextBoxStreamType.RichText);
                        isTyping = false;
                        richTextBox1.Text = "";
                    }
                    else
                    {
                        saveFileDialog1.FileName = Text;
                        saveFileDialog1.Filter = "txt files (*.txt)|*.txt|rtf files (*.rtf)|*.rtf|All files (*.*)|*.*";
                        saveFileDialog1.FilterIndex = 0;
                        saveFileDialog1.RestoreDirectory = true;

                        if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                            return;
                        filePath = saveFileDialog1.FileName;
                        richTextBox1.SaveFile(filePath, RichTextBoxStreamType.RichText);
                        isTyping = false;
                        richTextBox1.Text = "";
                    }
                    filePath = "";
                }
                else if (dialogResult == DialogResult.No)
                {
                    richTextBox1.Text = "";
                    filePath = "";
                }
            }
        }

        private void newBlankStripMenuItem_Click(object sender, EventArgs e)
        {            
            i++;
            myForm f = new myForm();
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
            }else if (darkIsSelected)
            {
                f.darkToolStripMenuItem_Click(sender, e);
            }else if (orangeIsSelected)
            {
                f.greenToolStripMenuItem_Click(sender, e);
            }
            f.Text = "notePadCSharp" + i;            
            int X = Location.X, Y = Location.Y;
            f.Location = new Point(X+=20, Y+=20);
            f.Show();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;           

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {                
                openFileDialog.Filter = "All Files(.txt;.rtf;)|*.txt;*.rtf;";                
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {

                    //if()
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
                    isTyping = false;
                }                
            }            
        }

        private void printStripMenuItem_Click(object sender, EventArgs e)
        {
            printDialog2.Document = printDocument1;
            if (richTextBox1.Rtf.Contains("{\\sv Image}"))
            {
                MessageBox.Show(messageBoxRtfWarningLine, "notepadCSharp", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (printDialog2.ShowDialog() == DialogResult.OK)
                {
                    printDocument1.Print();
                }
            }               
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(richTextBox1.Rtf, new Font("Arial", 40, FontStyle.Regular),
                System.Drawing.Brushes.Black, 10, 10);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(filePath != null)
            {
                saveFileDialog1.FileName = Text;
                richTextBox1.SaveFile(filePath, RichTextBoxStreamType.RichText);
                isTyping = false;
            }
            else
            {
                if (richTextBox1.Rtf.Contains("{\\sv Image}"))
                {
                    saveFileDialog1.Filter = "txt files (*.txt)|*.txt|rtf files (*.rtf)|*.rtf|All files (*.*)|*.*";
                    saveFileDialog1.FilterIndex = 2;// 2 required
                    saveFileDialog1.RestoreDirectory = true;

                    if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                        return;
                    filePath = saveFileDialog1.FileName;
                    richTextBox1.SaveFile(filePath, RichTextBoxStreamType.RichText);
                    isTyping = false;
                }
                else
                {                    
                    saveFileDialog1.Filter = "txt files (*.txt)|*.txt|rtf files (*.rtf)|*.rtf|All files (*.*)|*.*";
                    saveFileDialog1.FilterIndex = 1;// 1 required
                    saveFileDialog1.RestoreDirectory = true;

                    if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                        return;
                    filePath = saveFileDialog1.FileName;
                    File.WriteAllText(filePath, richTextBox1.Text);
                    isTyping = false;
                }                               
            }            
        }             
        
        private void txtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = Text;
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|rtf files (*.rtf)|*.rtf|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;// 1 required
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            filePath = saveFileDialog1.FileName;
            File.WriteAllText(filePath, richTextBox1.Text);
            isTyping = false;
        }

        private void rtxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = Text;
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|rtf files (*.rtf)|*.rtf|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;// 2 required
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            filePath = saveFileDialog1.FileName;
            richTextBox1.SaveFile(filePath, RichTextBoxStreamType.RichText);            
            isTyping = false;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = Text;
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|rtf files (*.rtf)|*.rtf|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 3;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            filePath = saveFileDialog1.FileName;
            richTextBox1.SaveFile(filePath, RichTextBoxStreamType.RichText);
            isTyping = false;
        }

        private void createImage(string name)
        {
            Clipboard.SetImage(System.Drawing.Image.FromFile(name));
            richTextBox1.Paste();
        }

        private void addPictureStripMenuItem_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(.jpg;.jpeg;.png;.gif;.tif)|*.jpg;*.jpeg;*.png;*.gif;*.tif";           

            if (open.ShowDialog() == DialogResult.OK)
            {
                createImage(open.FileName);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
            {
                Close();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show(messageBoxSaveLine, "notepadCSharp", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    if (filePath != null)
                    {
                        saveFileDialog1.FileName = Text;
                        richTextBox1.SaveFile(filePath, RichTextBoxStreamType.RichText);
                        isTyping = false;
                        richTextBox1.Text = "";
                    }
                    else
                    {
                        saveFileDialog1.FileName = Text;
                        saveFileDialog1.Filter = "txt files (*.txt)|*.txt|rtf files (*.rtf)|*.rtf|All files (*.*)|*.*";
                        saveFileDialog1.FilterIndex = 0;
                        saveFileDialog1.RestoreDirectory = true;

                        if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                            return;
                        filePath = saveFileDialog1.FileName;
                        richTextBox1.SaveFile(filePath, RichTextBoxStreamType.RichText);
                        isTyping = false;
                        richTextBox1.Text = "";
                    }
                    filePath = "";
                    Close();
                }
                else if (dialogResult == DialogResult.No)
                {
                    Close();
                }
            }           
        }

        //******************************_Edit menu_*****************************************                
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
            if(richTextBox1.SelectedText == "")
            {
                richTextBox1.Text = "";
            }else if(richTextBox1.SelectedText != "")
            {
                richTextBox1.SelectedText = "";
            }
            
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        //******************************_Format menu_*****************************************
        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // установка шрифта
            richTextBox1.SelectionFont = fontDialog1.Font;
            // установка цвета шрифта
            richTextBox1.ForeColor = fontDialog1.Color;
        }

        private void colorStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.ShowDialog();
            richTextBox1.ForeColor = dlg.Color;
        }

        //******************************Aligment menu*****************************************
        private void alignToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void alignCenterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void alignRightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }       

        //******************************Highlight menu*****************************************
        private void HighlightSyntax(RichTextBox rtb)
        {
            string[] keywords = new string[] { "auto", "break", "case", "char", "const", "continue", "default", "do", "double", "else", "enum", "extern", "float", "for", "goto", "if", "int", "long", "register", "return", "short", "signed", "sizeof", "static", "struct", "switch", "typedef", "union", "unsigned", "void", "volatile", "while" };
            string pattern = "\\b(" + string.Join("|", keywords) + ")\\b";
            Regex regex = new Regex(pattern);
            for (int i = 0; i < rtb.Lines.Length; i++)
            {
                string line = rtb.Lines[i];
                MatchCollection matches = regex.Matches(line);
                foreach (Match match in matches)
                {
                    rtb.Select(match.Index + i, match.Length);
                    rtb.SelectionColor = ColorTranslator.FromHtml("#00FF00");
                }
            }
        }

        private void findHighlightSyntax(RichTextBox rtb)
        {
            string[] keywords = new string[] { "auto", "break", "case", "char", "const", "continue", "default", "do", "double", "else", "enum", "extern", "float", "for", "goto", "if", "int", "long", "register", "return", "short", "signed", "sizeof", "static", "struct", "switch", "typedef", "union", "unsigned", "void", "volatile", "while" };
            string pattern = "\\b(" + string.Join("|", keywords) + ")\\b";
            Regex regex = new Regex(pattern);
            for (int i = 0; i < rtb.Lines.Length; i++)
            {
                string line = rtb.Lines[i];
                MatchCollection matches = regex.Matches(line);
                foreach (Match match in matches)
                {
                    higlightStripMenuItem.Enabled = true;
                    removeHStripMenuItem.Enabled = true;
                    isHihlight = true;
                }
            }
        }
        private void RemoveHighlightSyntax(RichTextBox rtb)
        {
            string[] keywords = new string[] { "auto", "break", "case", "char", "const", "continue", "default", "do", "double", "else", "enum", "extern", "float", "for", "goto", "if", "int", "long", "register", "return", "short", "signed", "sizeof", "static", "struct", "switch", "typedef", "union", "unsigned", "void", "volatile", "while" };
            string pattern = "\\b(" + string.Join("|", keywords) + ")\\b";
            Regex regex = new Regex(pattern);
            for (int i = 0; i < rtb.Lines.Length; i++)
            {
                string line = rtb.Lines[i];


                MatchCollection matches = regex.Matches(line);
                foreach (Match match in matches)
                {
                    rtb.Select(match.Index + i, match.Length);
                    rtb.SelectionColor = ColorTranslator.FromHtml("#000000");
                    if (whiteIsSelected)
                    {
                        rtb.SelectionColor = ColorTranslator.FromHtml("#000000");
                    }
                    else if (darkIsSelected)
                    {
                        rtb.SelectionColor = ColorTranslator.FromHtml("#B4B4B4");
                    }
                    else if (orangeIsSelected)
                    {
                        rtb.SelectionColor = ColorTranslator.FromHtml("#59EC30");
                    }

                }
            }
        }

        private void higlightStripMenuItem_Click(object sender, EventArgs e)
        {
            HighlightSyntax(richTextBox1);
        }

        private void removeHStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveHighlightSyntax(richTextBox1);
        }

        private void defaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Font = Font;
            richTextBox1.ForeColor = Color.Black;
        }

        //******************************_Language menu_*****************************************        
        private void ukranianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            languageIsSelected = true;
            messageBoxSaveLine = "Хочете зберегти зміни, внесені до файлу?";
            messageBoxAboutLine = "Валентин створюваав цей блокнот протягом 7ми днів поспіль!";

            fileToolStripMenuItem.Text = "Файл";
            newToolStripMenuItem.Text = "Новий файл";
            newBlankStripMenuItem.Text = "Нове вікно";
            openToolStripMenuItem.Text = "Відкрити";
            printStripMenuItem.Text = "Друкувати";
            messageBoxRtfWarningLine = "Збережіть файл у форматі .rft, щоб роздрукувати!";
            saveToolStripMenuItem.Text = "Зберегти";
            toolStripMenuItem2.Text = "Зберегти як";
            addPictureStripMenuItem.Text = "Додати фотокартку";
            exitToolStripMenuItem.Text = "Вихід";

            editToolStripMenuItem.Text = "Редагування";
            cutToolStripMenuItem.Text = "Вирізати";
            copyToolStripMenuItem.Text = "Копіювати";
            pasteToolStripMenuItem.Text = "Вставити";
            deleteToolStripMenuItem.Text = "Видалити";
            selectAllToolStripMenuItem.Text = "Виділити все";

            formatToolStripMenuItem.Text = "Форматування";
            fontToolStripMenuItem.Text = "Шрифт...";
            colorStripMenuItem.Text = "Колір...";
            alignmentStripMenuItem.Text = "Вирівнювання";
            alignToolStripMenuItem.Text = "Вирівнювання вліво";
            alignCenterToolStripMenuItem.Text = "Вирівнювання по центру";
            alignRightToolStripMenuItem.Text = "Вирівнювання вправо";
            higlightStripMenuItem.Text = "Виділити С-подібний синтаксис";
            removeHStripMenuItem.Text = "Зняти виділення";
            defaultToolStripMenuItem.Text = "За замовчуванням";

            windowToolStripMenuItem.Text = "Вікно";
            themeStripMenuItem.Text = "Тема";
            whiteToolStripMenuItem.Text = "Світла";
            darkToolStripMenuItem.Text = "Темна";
            greenToolStripMenuItem.Text = "Помаранчова";
            languageToolStripMenuItem.Text = "Мова";
            ukranianToolStripMenuItem.Text = "Українська";
            englishToolStripMenuItem.Text = "Англійська";

            aboutProgrammToolStripMenuItem.Text = "Про додаток...";
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            languageIsSelected = false;
            messageBoxSaveLine = "Want to save changes?";
            messageBoxAboutLine = "Valentyn has been creating this notepad for 7days in a row!";

            fileToolStripMenuItem.Text = "File";
            newToolStripMenuItem.Text = "New";
            newBlankStripMenuItem.Text = "New Window";
            openToolStripMenuItem.Text = "Open";
            printStripMenuItem.Text = "Print";
            messageBoxRtfWarningLine = "Save your file to .rft to print it!";
            saveToolStripMenuItem.Text = "Save";
            toolStripMenuItem2.Text = "Save As";
            addPictureStripMenuItem.Text = "Add Picture";
            exitToolStripMenuItem.Text = "Exit";

            editToolStripMenuItem.Text = "Edit";
            cutToolStripMenuItem.Text = "Cut";
            copyToolStripMenuItem.Text = "Copy";
            pasteToolStripMenuItem.Text = "Paste";
            deleteToolStripMenuItem.Text = "Delete";
            selectAllToolStripMenuItem.Text = "Select All";

            formatToolStripMenuItem.Text = "Format";
            fontToolStripMenuItem.Text = "Font...";
            colorStripMenuItem.Text = "Color...";
            alignmentStripMenuItem.Text = "Aligment";
            alignToolStripMenuItem.Text = "Align Left";
            alignCenterToolStripMenuItem.Text = "Align Center";
            alignRightToolStripMenuItem.Text = "Align Right";
            higlightStripMenuItem.Text = "Highlight C Syntax";
            removeHStripMenuItem.Text = "Remove Highlighting";
            deleteToolStripMenuItem.Text = "Delete";

            windowToolStripMenuItem.Text = "Window";
            themeStripMenuItem.Text = "Theme";
            whiteToolStripMenuItem.Text = "White";
            darkToolStripMenuItem.Text = "Dark";
            greenToolStripMenuItem.Text = "Orange";
            languageToolStripMenuItem.Text = "Language";
            ukranianToolStripMenuItem.Text = "Ukranian";
            englishToolStripMenuItem.Text = "English";

            aboutProgrammToolStripMenuItem.Text = "About Programm...";
            
        }

        //******************************_Theme control_*****************************************
        bool whiteIsSelected = false;
        bool darkIsSelected = false;
        bool orangeIsSelected = false;
        private void whiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            whiteIsSelected = true;
            whiteIsSelected = true;
            darkIsSelected = false;
            orangeIsSelected = false;

            BackColor = Color.WhiteSmoke;
            Color myColor = ColorTranslator.FromHtml("#FFFFFF");
            richTextBox1.BackColor = myColor;
            Color myColor2 = ColorTranslator.FromHtml("#000000");
            richTextBox1.ForeColor = myColor2;
            menuStrip1.BackColor = Color.White;
            menuStrip1.ForeColor = myColor2;
            Color myBackColor = Color.White;

            //****************ContextMenuStrip*****************
            ghbToolStripMenuItem.BackColor = myBackColor;
            dfgToolStripMenuItem.BackColor= myBackColor;
            dfgToolStripMenuItem1.BackColor= myBackColor;
            deleteToolStripMenuItem1.BackColor = myBackColor;
            selectAllToolStripMenuItem1.BackColor = myBackColor;
            ghbToolStripMenuItem.ForeColor = myColor2;
            dfgToolStripMenuItem.ForeColor = myColor2;
            dfgToolStripMenuItem1.ForeColor = myColor2;
            deleteToolStripMenuItem1.ForeColor = myColor2;
            selectAllToolStripMenuItem1.ForeColor = myColor2;

            //****************Aligment menu*****************
            alignmentStripMenuItem.ForeColor = myColor2;
            alignmentStripMenuItem.BackColor = myBackColor;
            alignToolStripMenuItem.BackColor = myBackColor;
            alignCenterToolStripMenuItem.BackColor = myBackColor;
            alignRightToolStripMenuItem.BackColor = myBackColor;
            alignToolStripMenuItem.ForeColor = myColor2;
            alignCenterToolStripMenuItem.ForeColor = myColor2;
            alignRightToolStripMenuItem.ForeColor = myColor2;

            //****************Color menu*****************
            colorStripMenuItem.ForeColor = myColor2;
            colorStripMenuItem.BackColor = myBackColor;

            //****************Image menu*****************
            addPictureStripMenuItem.BackColor= myBackColor;
            addPictureStripMenuItem.ForeColor= myColor2;

            //****************Highlight menu*****************
            higlightStripMenuItem.ForeColor = myColor2;
            higlightStripMenuItem.BackColor = myBackColor;
            removeHStripMenuItem.ForeColor = myColor2;
            removeHStripMenuItem.BackColor = myBackColor;

            //****************Print menu*****************
            printStripMenuItem.BackColor =myBackColor;
            printStripMenuItem.ForeColor =myColor2;

            //****************New blank menu*****************
            newBlankStripMenuItem.BackColor =(myBackColor);
            newBlankStripMenuItem.ForeColor =(myColor2);    

            newToolStripMenuItem.BackColor = myBackColor;
            openToolStripMenuItem.BackColor = myBackColor;
            saveToolStripMenuItem.BackColor = myBackColor;
            toolStripMenuItem2.BackColor = myBackColor;
            exitToolStripMenuItem.BackColor = myBackColor;
            
            newToolStripMenuItem.ForeColor = myColor2;
            openToolStripMenuItem.ForeColor = myColor2;
            saveToolStripMenuItem.ForeColor = myColor2;
            toolStripMenuItem2.ForeColor = myColor2;
            exitToolStripMenuItem.ForeColor = myColor2;
            

            cutToolStripMenuItem.BackColor = myBackColor;
            copyToolStripMenuItem.BackColor = myBackColor;
            pasteToolStripMenuItem.BackColor = myBackColor;
            deleteToolStripMenuItem.BackColor = myBackColor;
            selectAllToolStripMenuItem.BackColor = myBackColor;
            
            cutToolStripMenuItem.ForeColor = myColor2;
            copyToolStripMenuItem.ForeColor = myColor2;
            pasteToolStripMenuItem.ForeColor = myColor2;
            deleteToolStripMenuItem.ForeColor = myColor2;
            selectAllToolStripMenuItem.ForeColor = myColor2;
            

            fontToolStripMenuItem.BackColor = myBackColor;
            defaultToolStripMenuItem.BackColor = myBackColor;

            themeStripMenuItem.BackColor = myBackColor;
            languageToolStripMenuItem.BackColor = myBackColor;

            aboutProgrammToolStripMenuItem.BackColor = myBackColor;
            fontToolStripMenuItem.ForeColor = myColor2;
            defaultToolStripMenuItem.ForeColor = myColor2;

            themeStripMenuItem.ForeColor = myColor2;
            languageToolStripMenuItem.ForeColor = myColor2;

            aboutProgrammToolStripMenuItem.ForeColor = myColor2;
            toolStripMenuItem3.Visible = false;            
            toolStripMenuItem6.Visible = false;
            toolStripMenuItem4.Visible = false;

            txtToolStripMenuItem.BackColor = myBackColor; 
            txtToolStripMenuItem.ForeColor = myColor2;
            rtxToolStripMenuItem.BackColor = myBackColor;
            rtxToolStripMenuItem.ForeColor = myColor2;

            whiteToolStripMenuItem.BackColor = myBackColor;
            whiteToolStripMenuItem.ForeColor = myColor2;
            darkToolStripMenuItem.BackColor = myBackColor;
            darkToolStripMenuItem.ForeColor = myColor2; 
            greenToolStripMenuItem.BackColor = myBackColor;
            greenToolStripMenuItem.ForeColor = myColor2;

            ukranianToolStripMenuItem.BackColor = myBackColor;
            ukranianToolStripMenuItem.ForeColor = myColor2;
            englishToolStripMenuItem.BackColor = myBackColor;
            englishToolStripMenuItem.ForeColor = myColor2;
        }

        private void darkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            whiteIsSelected = false;
            darkIsSelected = true;
            orangeIsSelected = false;

            Color myColor2 = ColorTranslator.FromHtml("#B4B4B4");
            BackColor = myColor2;
            Color myColor = ColorTranslator.FromHtml("#1E1E1E");
            richTextBox1.BackColor = myColor;                        
            richTextBox1.ForeColor = myColor2;
            menuStrip1.BackColor = ColorTranslator.FromHtml("#2D2D30");            
            menuStrip1.ForeColor = myColor2;

            //****************ContextMenuStrip*****************
            Color myBackColor = ColorTranslator.FromHtml("#2D2D30");
            ghbToolStripMenuItem.BackColor = myBackColor;
            dfgToolStripMenuItem.BackColor = myBackColor;
            dfgToolStripMenuItem1.BackColor = myBackColor;
            deleteToolStripMenuItem1.BackColor = myBackColor;
            selectAllToolStripMenuItem1.BackColor = myBackColor;
            ghbToolStripMenuItem.ForeColor = myColor2;
            dfgToolStripMenuItem.ForeColor = myColor2;
            dfgToolStripMenuItem1.ForeColor = myColor2;
            deleteToolStripMenuItem1.ForeColor = myColor2;
            selectAllToolStripMenuItem1.ForeColor = myColor2;

            //****************Aligment menu*****************
            alignmentStripMenuItem.ForeColor = myColor2;
            alignmentStripMenuItem.BackColor = myBackColor;
            alignToolStripMenuItem.BackColor = myBackColor;
            alignCenterToolStripMenuItem.BackColor = myBackColor;
            alignRightToolStripMenuItem.BackColor = myBackColor;
            alignToolStripMenuItem.ForeColor = myColor2;
            alignCenterToolStripMenuItem.ForeColor = myColor2;
            alignRightToolStripMenuItem.ForeColor = myColor2;

            //****************Color menu*****************
            colorStripMenuItem.ForeColor = myColor2;
            colorStripMenuItem.BackColor = myBackColor;

            //****************Image menu*****************
            addPictureStripMenuItem.BackColor = myBackColor;
            addPictureStripMenuItem.ForeColor = myColor2;

            //****************Highlight menu*****************
            higlightStripMenuItem.ForeColor = myColor2;
            higlightStripMenuItem.BackColor = myBackColor;
            removeHStripMenuItem.ForeColor = myColor2;
            removeHStripMenuItem.BackColor = myBackColor;

            //****************Print menu*****************
            printStripMenuItem.BackColor = myBackColor;
            printStripMenuItem.ForeColor = myColor2;

            //****************New blank menu*****************
            newBlankStripMenuItem.BackColor = (myBackColor);
            newBlankStripMenuItem.ForeColor = (myColor2);

            txtToolStripMenuItem.BackColor = myBackColor;
            txtToolStripMenuItem.ForeColor = myColor2;
            rtxToolStripMenuItem.BackColor = myBackColor;
            rtxToolStripMenuItem.ForeColor = myColor2;

            whiteToolStripMenuItem.BackColor = myBackColor;
            whiteToolStripMenuItem.ForeColor = myColor2;
            darkToolStripMenuItem.BackColor = myBackColor;
            darkToolStripMenuItem.ForeColor = myColor2;
            greenToolStripMenuItem.BackColor = myBackColor;
            greenToolStripMenuItem.ForeColor = myColor2;

            ukranianToolStripMenuItem.BackColor = myBackColor;
            ukranianToolStripMenuItem.ForeColor = myColor2;
            englishToolStripMenuItem.BackColor = myBackColor;
            englishToolStripMenuItem.ForeColor = myColor2;

            newToolStripMenuItem.BackColor = myBackColor;
            openToolStripMenuItem.BackColor = myBackColor;
            saveToolStripMenuItem.BackColor = myBackColor;
            toolStripMenuItem2.BackColor = myBackColor;
            exitToolStripMenuItem.BackColor = myBackColor;
            
            newToolStripMenuItem.ForeColor = myColor2;
            openToolStripMenuItem.ForeColor = myColor2;
            saveToolStripMenuItem.ForeColor = myColor2;
            toolStripMenuItem2.ForeColor = myColor2;
            exitToolStripMenuItem.ForeColor = myColor2;
            

            cutToolStripMenuItem.BackColor = myBackColor;
            copyToolStripMenuItem.BackColor = myBackColor;
            pasteToolStripMenuItem.BackColor = myBackColor;
            deleteToolStripMenuItem.BackColor = myBackColor;
            selectAllToolStripMenuItem.BackColor = myBackColor;
            toolStripMenuItem3.BackColor = Color.Gray;
            cutToolStripMenuItem.ForeColor = myColor2;
            copyToolStripMenuItem.ForeColor = myColor2;
            pasteToolStripMenuItem.ForeColor = myColor2;
            deleteToolStripMenuItem.ForeColor = myColor2;
            selectAllToolStripMenuItem.ForeColor = myColor2;
            toolStripMenuItem3.ForeColor = myColor2;

            fontToolStripMenuItem.BackColor = myBackColor;
            defaultToolStripMenuItem.BackColor = myBackColor;
                        
            themeStripMenuItem.BackColor = myBackColor;
            languageToolStripMenuItem.BackColor = myBackColor;

            aboutProgrammToolStripMenuItem.BackColor = myBackColor;
            fontToolStripMenuItem.ForeColor = myColor2;
            defaultToolStripMenuItem.ForeColor = myColor2;

            themeStripMenuItem.ForeColor = myColor2;
            languageToolStripMenuItem.ForeColor = myColor2;

            aboutProgrammToolStripMenuItem.ForeColor = myColor2;
            toolStripMenuItem3.Visible = false;            
            toolStripMenuItem6.Visible = false;
            toolStripMenuItem4.Visible = false;
        }        

        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            whiteIsSelected = false;
            darkIsSelected = false;
            orangeIsSelected = true;

            Color myColor = ColorTranslator.FromHtml("#FFA07A");
            richTextBox1.BackColor = myColor;
            Color myColor2 = ColorTranslator.FromHtml("#8B00FF");            
            richTextBox1.ForeColor = myColor2;
            menuStrip1.BackColor = ColorTranslator.FromHtml("#FF6347");            
            menuStrip1.ForeColor = myColor2;
            BackColor = ColorTranslator.FromHtml("#FFA500");

            //****************ContextMenuStrip*****************
            Color myBackColor = ColorTranslator.FromHtml("#FF6347");
            ghbToolStripMenuItem.BackColor = myBackColor;
            dfgToolStripMenuItem.BackColor = myBackColor;
            dfgToolStripMenuItem1.BackColor = myBackColor;
            deleteToolStripMenuItem1.BackColor = myBackColor;
            selectAllToolStripMenuItem1.BackColor = myBackColor;
            ghbToolStripMenuItem.ForeColor = myColor2;
            dfgToolStripMenuItem.ForeColor = myColor2;
            dfgToolStripMenuItem1.ForeColor = myColor2;
            deleteToolStripMenuItem1.ForeColor = myColor2;
            selectAllToolStripMenuItem1.ForeColor = myColor2;

            //****************Aligment menu*****************
            alignmentStripMenuItem.ForeColor = myColor2;
            alignmentStripMenuItem.BackColor = myBackColor;
            alignToolStripMenuItem.BackColor = myBackColor;
            alignCenterToolStripMenuItem.BackColor = myBackColor;
            alignRightToolStripMenuItem.BackColor = myBackColor;
            alignToolStripMenuItem.ForeColor = myColor2;
            alignCenterToolStripMenuItem.ForeColor = myColor2;
            alignRightToolStripMenuItem.ForeColor = myColor2;

            //****************Color menu*****************
            colorStripMenuItem.ForeColor = myColor2;
            colorStripMenuItem.BackColor = myBackColor;

            //****************Image menu*****************
            addPictureStripMenuItem.BackColor = myBackColor;
            addPictureStripMenuItem.ForeColor = myColor2;

            //****************Highlight menu*****************
            higlightStripMenuItem.ForeColor= myColor2;
            higlightStripMenuItem.BackColor= myBackColor;
            removeHStripMenuItem.ForeColor= myColor2;
            removeHStripMenuItem.BackColor= myBackColor;

            //****************Print menu*****************
            printStripMenuItem.BackColor = myBackColor;
            printStripMenuItem.ForeColor = myColor2;

            //****************New blank menu*****************
            newBlankStripMenuItem.BackColor = (myBackColor);
            newBlankStripMenuItem.ForeColor = (myColor2);

            txtToolStripMenuItem.BackColor = myBackColor;
            txtToolStripMenuItem.ForeColor = myColor2;
            rtxToolStripMenuItem.BackColor = myBackColor;
            rtxToolStripMenuItem.ForeColor = myColor2;

            whiteToolStripMenuItem.BackColor = myBackColor;
            whiteToolStripMenuItem.ForeColor = myColor2;
            darkToolStripMenuItem.BackColor = myBackColor;
            darkToolStripMenuItem.ForeColor = myColor2;
            greenToolStripMenuItem.BackColor = myBackColor;
            greenToolStripMenuItem.ForeColor = myColor2;

            ukranianToolStripMenuItem.BackColor = myBackColor;
            ukranianToolStripMenuItem.ForeColor = myColor2;
            englishToolStripMenuItem.BackColor = myBackColor;
            englishToolStripMenuItem.ForeColor = myColor2;
        

            newToolStripMenuItem.BackColor = myBackColor;
            openToolStripMenuItem.BackColor = myBackColor;
            saveToolStripMenuItem.BackColor = myBackColor;
            toolStripMenuItem2.BackColor = myBackColor;
            exitToolStripMenuItem.BackColor = myBackColor;
            
            newToolStripMenuItem.ForeColor = myColor2;
            openToolStripMenuItem.ForeColor = myColor2;
            saveToolStripMenuItem.ForeColor = myColor2;
            toolStripMenuItem2.ForeColor = myColor2;
            exitToolStripMenuItem.ForeColor = myColor2;
           

            cutToolStripMenuItem.BackColor = myBackColor;
            copyToolStripMenuItem.BackColor = myBackColor;
            pasteToolStripMenuItem.BackColor = myBackColor;
            deleteToolStripMenuItem.BackColor = myBackColor;
            selectAllToolStripMenuItem.BackColor = myBackColor;
            toolStripMenuItem3.Visible = false;
            cutToolStripMenuItem.ForeColor = myColor2;
            copyToolStripMenuItem.ForeColor = myColor2;
            pasteToolStripMenuItem.ForeColor = myColor2;
            deleteToolStripMenuItem.ForeColor = myColor2;
            selectAllToolStripMenuItem.ForeColor = myColor2;
            toolStripMenuItem3.ForeColor = myColor2;

            fontToolStripMenuItem.BackColor = myBackColor;
            defaultToolStripMenuItem.BackColor = myBackColor;
            toolStripMenuItem6.Visible = false;

            themeStripMenuItem.BackColor = myBackColor;
            languageToolStripMenuItem.BackColor = myBackColor;
            toolStripMenuItem4.Visible = false;

            aboutProgrammToolStripMenuItem.BackColor = myBackColor;
            fontToolStripMenuItem.ForeColor = myColor2;
            defaultToolStripMenuItem.ForeColor = myColor2;

            themeStripMenuItem.ForeColor = myColor2;
            languageToolStripMenuItem.ForeColor = myColor2;

            aboutProgrammToolStripMenuItem.ForeColor = myColor2;
        }

        //******************************_Context menu_*****************************************
        private void ghbToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cutToolStripMenuItem_Click(sender, e);
        }

        private void dfgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            copyToolStripMenuItem_Click(sender, e);
        }

        private void dfgToolStripMenuItem1_Click(object sender, EventArgs e)
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

        private void aboutProgrammToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(messageBoxAboutLine, "Pontak corp.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }        
    }
}