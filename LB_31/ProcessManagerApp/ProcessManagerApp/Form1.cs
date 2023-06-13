using System.Diagnostics;

namespace ProcessManagerApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            processListView.Items.Clear();
            Process[] processes = Process.GetProcesses();
            foreach (Process process in processes)
            {
                ListViewItem item = new ListViewItem(process.ProcessName);
                item.SubItems.Add(process.Id.ToString());
                processListView.Items.Add(item);
            }
        }

        private void RefreshProcessList()
        {
            processListView.Items.Clear();
            Process[] processes = Process.GetProcesses();
            foreach (Process process in processes)
            {
                ListViewItem item = new ListViewItem(process.ProcessName);
                item.SubItems.Add(process.Id.ToString());
                processListView.Items.Add(item);
            }
        }

        private void viewProcessInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (processListView.SelectedItems.Count > 0)
            {
                string processName = processListView.SelectedItems[0].Text;
                Process process = Process.GetProcessesByName(processName)[0];

                string processInfo = $"Process Name: {process.ProcessName}\n" +
                                     $"ID: {process.Id}\n" +
                                     $"Start Time: {process.StartTime}\n" +
                                     $"Responding: {process.Responding}\n" +
                                     $"Threads: {process.Threads.Count}\n" +
                                     $"Modules: {process.Modules.Count}\n\n";

                processInfo += "Threads:\n";
                foreach (ProcessThread thread in process.Threads)
                {
                    processInfo += $"Thread ID: {thread.Id}\tState: {thread.ThreadState}\n";
                }

                processInfo += "\nModules:\n";
                foreach (ProcessModule module in process.Modules)
                {
                    processInfo += $"Module Name: {module.ModuleName}\tFile Name: {module.FileName}\n";
                }

                MessageBox.Show(processInfo, "Process Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void stopProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (processListView.SelectedItems.Count > 0)
            {
                string processName = processListView.SelectedItems[0].Text;
                Process process = Process.GetProcessesByName(processName)[0];
                try
                {
                    process.Kill();
                    MessageBox.Show($"Process '{process.ProcessName}' has been stopped.",
                                    "Process Stopped", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to stop process.\nError: {ex.Message}",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            RefreshProcessList();
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text Files|*.txt";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        foreach (ListViewItem item in processListView.Items)
                        {
                            writer.WriteLine($"Process Name: {item.Text}\tID: {item.SubItems[1].Text}");
                        }
                    }
                    MessageBox.Show("Process list exported successfully.",
                                    "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}