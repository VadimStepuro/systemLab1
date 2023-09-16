﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace systemLab1
{
    /// <summary>
    /// Логика взаимодействия для ThreadsWindow.xaml
    /// </summary>
    public partial class ThreadsWindow : Window
    {
        public ThreadsWindow()
        {
            InitializeComponent();
        }

        public ThreadsWindow(ProcessThreadCollection threads) {
            InitializeComponent();
            this.threads.ItemsSource = threads;
            this.Show();
        }
    }
}
