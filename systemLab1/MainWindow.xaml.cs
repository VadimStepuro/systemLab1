using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Management;

namespace systemLab1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            Process[] processes = Process.GetProcesses();
            string processName;
            CustomProcess[] customProcesses= new CustomProcess[processes.Length];
            for (int i = 0; i < processes.Length; i++)
            {
                processName = GetProcessOwner(processes[i].Id);
                customProcesses[i] = new CustomProcess(processes[i], processName);
            }
            listOfProcesses.ItemsSource = customProcesses;
            
        }

        public string GetProcessOwner(int processId)
        {
            string query = "Select * From Win32_Process Where ProcessID = " + processId;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            ManagementObjectCollection processList = searcher.Get();

            foreach (ManagementObject obj in processList)
            {
                string[] argList = new string[] { string.Empty, string.Empty };
                int returnVal = Convert.ToInt32(obj.InvokeMethod("GetOwner", argList));
                if (returnVal == 0)
                {
                    // return DOMAIN\user
                    return argList[1] + "\\" + argList[0];
                }
            }

            return "NO OWNER";
        }

        private void OpenTreadsWindow(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                ProcessThreadCollection? processThreadCollection = (ProcessThreadCollection)button.CommandParameter;
                ThreadsWindow threadsWindow = new ThreadsWindow(processThreadCollection);
            }
            else
            {
                throw new Exception();
            }

        }
    }
}
