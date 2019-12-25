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
using System.IO;

namespace String_Checker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string file1Text = String.Empty;
        private string file2Text = String.Empty;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void File1_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();
            openFileDlg.DefaultExt = ".po";
            openFileDlg.Filter = "PO files (.po)|*.po"; 

            var result = openFileDlg.ShowDialog();
            if (result == true)
            {
                File1Path.Text = openFileDlg.FileName;
                file1Text = File.ReadAllText(openFileDlg.FileName);
            }
        }

        private void File2_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();
            openFileDlg.DefaultExt = ".po";
            openFileDlg.Filter = "PO files (.po)|*.po";

            var result = openFileDlg.ShowDialog();
            if (result == true)
            {
                File2Path.Text = openFileDlg.FileName;
                file2Text = System.IO.File.ReadAllText(openFileDlg.FileName);
            }
        }

        private void ButtonCompare_Click(object sender, RoutedEventArgs e)
        {
            using (StringReader reader = new StringReader(file1Text))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.StartsWith("msgid"))
                    {
                        int i = 0, j = 0;
                        char[] key = new char[200];
                        while(i < line.Length && line[i] != '\"')
                        {
                            i++;
                        }
                        i++;
                        while (i < line.Length && line[i] != '\"')
                        {
                            key[j++] = line[i];
                            i++;
                        }
                        key[j] = '\0';

                        string keyString = new string(key, 0, j);
                        if (j > 0 && !file2Text.Contains(keyString))
                        {
                            OutputText.Text += keyString + "\n";
                        }
                    }
                }
            }
            if (String.IsNullOrEmpty(OutputText.Text))
            {
                OutputText.Text = "All texts found";
            }
        }
    }
}
