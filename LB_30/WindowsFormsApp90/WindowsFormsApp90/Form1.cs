using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace WindowsFormsApp90
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void connect_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(tbHost.Text);
            request.Credentials = new NetworkCredential(tbUser.Text, tbPass.Text);
            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (line != null)
                {
                    string[] details = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    string permissions = details[0];
                    string fileType = details[0].Substring(0, 1) == "d" ? "Directory" : "File";
                    string name = details[details.Length - 1];

                    TreeNode node = new TreeNode(name);
                    node.Tag = fileType;

                    if (fileType == "Directory")
                    {
                        node.Nodes.Add("*"); 
                    }

                    treeView1.Nodes.Add(node);
                }
            }

            reader.Close();
            response.Close();
        }
        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes.Count == 1 && e.Node.Nodes[0].Text == "*")
            {
                e.Node.Nodes.Clear();

                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(tbHost.Text + e.Node.FullPath);
                request.Credentials = new NetworkCredential(tbUser.Text, tbPass.Text);
                request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (line != null)
                    {
                        string[] details = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        string permissions = details[0];
                        string fileType = details[0].Substring(0, 1) == "d" ? "Directory" : "File";
                        string name = details[details.Length - 1];

                        TreeNode node = new TreeNode(name);
                        node.Tag = fileType;

                        if (fileType == "Directory")
                        {
                            node.Nodes.Add("*");
                        }

                        e.Node.Nodes.Add(node);
                    }
                }

                reader.Close();
                response.Close();
            }
        }
        private void upload_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string targetDirectory = tbUpload.Text.Trim();

                foreach (string fileName in openFileDialog1.FileNames)
                {
                    string targetFilePath = tbHost.Text + targetDirectory + Path.GetFileName(fileName);

                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(targetFilePath);
                    request.Credentials = new NetworkCredential(tbUser.Text, tbPass.Text);
                    request.Method = WebRequestMethods.Ftp.UploadFile;
                    byte[] file = File.ReadAllBytes(fileName);
                    Stream strz = request.GetRequestStream();
                    strz.Write(file, 0, file.Length);
                    strz.Close();
                    strz.Dispose();

                    MessageBox.Show(Path.GetFileName(fileName) + " uploaded");
                }
            }
        }

        private void create_Click(object sender, EventArgs e)
        {
            string newDirectoryName = tbNewDir.Text.Trim();
            if (!string.IsNullOrEmpty(newDirectoryName))
            {
                TreeNode selectedNode = treeView1.SelectedNode;
                if (selectedNode != null)
                {
                    string directoryPath = tbHost.Text + selectedNode.FullPath + "/" + newDirectoryName;

                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(directoryPath);
                    request.Credentials = new NetworkCredential(tbUser.Text, tbPass.Text);
                    request.Method = WebRequestMethods.Ftp.MakeDirectory;
                    FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                    MessageBox.Show("Directory " + newDirectoryName + " created");

                    response.Close();

                    selectedNode.Nodes.Add(newDirectoryName);
                }
            }
        }

        private void appe_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(tbHost.Text + openFileDialog1.SafeFileName);
                request.Credentials = new NetworkCredential(tbUser.Text, tbPass.Text);
                request.Method = WebRequestMethods.Ftp.AppendFile;

                using (Stream fileStream = openFileDialog1.OpenFile())
                using (Stream ftpStream = request.GetRequestStream())
                {
                    fileStream.CopyTo(ftpStream);
                }

                MessageBox.Show(openFileDialog1.SafeFileName + " appended");
            }
        }

        private void dele_Click(object sender, EventArgs e)
        {
            string fileName = FadList.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(fileName))
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(tbHost.Text + fileName);
                request.Credentials = new NetworkCredential(tbUser.Text, tbPass.Text);
                request.Method = WebRequestMethods.Ftp.DeleteFile;

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                MessageBox.Show(fileName + " deleted");

                response.Close();
            }
        }

        private void retr_Click(object sender, EventArgs e)
        {
            string fileName = FadList.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(fileName))
            {
                saveFileDialog1.Filter = "All files (*.*)|*.*";
                saveFileDialog1.FileName = fileName;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(tbHost.Text + fileName);
                    request.Credentials = new NetworkCredential(tbUser.Text, tbPass.Text);
                    request.Method = WebRequestMethods.Ftp.DownloadFile;

                    using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                    using (Stream ftpStream = response.GetResponseStream())
                    using (Stream fileStream = File.Create(saveFileDialog1.FileName))
                    {
                        ftpStream.CopyTo(fileStream);
                    }

                    MessageBox.Show(fileName + " downloaded");
                }
            }
        }

        private void mdt_Click(object sender, EventArgs e)
        {
            string fileName = FadList.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(fileName))
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(tbHost.Text + fileName);
                request.Credentials = new NetworkCredential(tbUser.Text, tbPass.Text);
                request.Method = WebRequestMethods.Ftp.GetDateTimestamp;

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                MessageBox.Show("Modification Time of " + fileName + ": " + response.LastModified);

                response.Close();
            }
        }

        private void size_Click(object sender, EventArgs e)
        {
            string fileName = FadList.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(fileName))
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(tbHost.Text + fileName);
                request.Credentials = new NetworkCredential(tbUser.Text, tbPass.Text);
                request.Method = WebRequestMethods.Ftp.GetFileSize;

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                MessageBox.Show("Size of " + fileName + ": " + response.ContentLength + " bytes");

                response.Close();
            }
        }

        private void nlist_Click(object sender, EventArgs e)
        {
            FadList.Items.Clear();

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(tbHost.Text);
            request.Credentials = new NetworkCredential(tbUser.Text, tbPass.Text);
            request.Method = WebRequestMethods.Ftp.ListDirectory;

            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            using (Stream responseStream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(responseStream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    FadList.Items.Add(line);
                }
            }

            MessageBox.Show("NLIST completed");
        }

        private void list_Click(object sender, EventArgs e)
        {
            FadList.Items.Clear();

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(tbHost.Text);
            request.Credentials = new NetworkCredential(tbUser.Text, tbPass.Text);
            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            using (Stream responseStream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(responseStream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    FadList.Items.Add(line);
                }
            }

            MessageBox.Show("LIST completed");
        }

        private void mkd_Click(object sender, EventArgs e)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(tbHost.Text + tbNewDir.Text);
            request.Credentials = new NetworkCredential(tbUser.Text, tbPass.Text);
            request.Method = WebRequestMethods.Ftp.MakeDirectory;

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            MessageBox.Show("Directory " + tbNewDir.Text + " created");

            response.Close();
        }

        private void rmd_Click(object sender, EventArgs e)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(tbHost.Text + tbRemoveDir.Text);
            request.Credentials = new NetworkCredential(tbUser.Text, tbPass.Text);
            request.Method = WebRequestMethods.Ftp.RemoveDirectory;

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            MessageBox.Show("Directory " + tbRemoveDir.Text + " removed");

            response.Close();
        }

        private void rename_Click(object sender, EventArgs e)
        {
            string oldFileName = FadList.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(oldFileName) && !string.IsNullOrEmpty(tbNewName.Text))
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(tbHost.Text + oldFileName);
                request.Credentials = new NetworkCredential(tbUser.Text, tbPass.Text);
                request.Method = WebRequestMethods.Ftp.Rename;
                request.RenameTo = tbNewName.Text;

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                MessageBox.Show(oldFileName + " renamed to " + tbNewName.Text);

                response.Close();
            }
        }

        private void stor_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(tbHost.Text + openFileDialog1.SafeFileName);
                request.Credentials = new NetworkCredential(tbUser.Text, tbPass.Text);
                request.Method = WebRequestMethods.Ftp.UploadFile;

                using (Stream fileStream = openFileDialog1.OpenFile())
                using (Stream ftpStream = request.GetRequestStream())
                {
                    fileStream.CopyTo(ftpStream);
                }

                MessageBox.Show(openFileDialog1.SafeFileName + " uploaded");
            }
        }

        private void stou_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(tbHost.Text);
                request.Credentials = new NetworkCredential(tbUser.Text, tbPass.Text);
                request.Method = WebRequestMethods.Ftp.UploadFileWithUniqueName;

                using (Stream fileStream = openFileDialog1.OpenFile())
                using (Stream ftpStream = request.GetRequestStream())
                {
                    fileStream.CopyTo(ftpStream);
                }

                MessageBox.Show("File uploaded with a unique name");
            }

        }
        private void LoadSettings()
        {
            string settingsFilePath = "settings.txt";

            if (File.Exists(settingsFilePath))
            {
                using (StreamReader reader = new StreamReader(settingsFilePath))
                {
                    hostTextBox.Text = reader.ReadLine();
                    usernameTextBox.Text = reader.ReadLine();
                    passwordTextBox.Text = reader.ReadLine();
                }
            }
        }

        private void settings_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            if (settingsForm.ShowDialog() == DialogResult.OK)
            {
                LoadSettings();
            }
        }
    }
}
