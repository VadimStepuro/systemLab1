using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace systemLab1
{
    public class CustomProcess
    {
        public CustomProcess() { }

        public Process Process { get; set; }
        public string Name { get; set; }

        public CustomProcess(Process process, string name)
        {
            Process = process;
            Name = name;
        }
    }
}
