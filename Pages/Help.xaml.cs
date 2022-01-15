﻿using System.Windows;
using System.Windows.Controls;
using WpfTetris.Interfaces;

namespace WpfTetris.Pages
{
    public partial class Help : UserControl, ICloseControl
    {
        public Help()
        {
            InitializeComponent();
        }

        public event CloseControl CloseEvent;

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            CloseEvent?.Invoke();
        }
    }
}