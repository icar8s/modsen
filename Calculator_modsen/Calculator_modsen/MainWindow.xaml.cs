﻿using System;
using System.Data;
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

namespace Calculator_modsen
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            foreach(UIElement el in MainRoot.Children)
            {
                if(el is Button)
                {
                    ((Button)el).Click += Button_Click;
                }
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string str = (string)((Button)e.OriginalSource).Content;
            
            if (str == "AC")
                textLabel.Text = "";
            else if (str.Contains("f"))
            {
                return;
            }
            else if(str == "=") {
                string value = new DataTable().Compute(textLabel.Text, null).ToString(); 
                textLabel.Text = value;
            }
           
            else
                textLabel.Text += str;
        }
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            double x = 0, y = 0;
            double.TryParse(xTextBox.Text, out x);
            double.TryParse(yTextBox.Text, out y);

            textLabel.Text += x + y;
        }
    }
}
