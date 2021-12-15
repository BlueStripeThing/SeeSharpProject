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
using Word = Microsoft.Office.Interop.Word;
using System.Runtime.InteropServices;

namespace SeeSharpProject
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        Encryptor enc = new Encryptor();
        private void StartBtn_Click(object sender, RoutedEventArgs e)
        {
            if (BeforeBlock.Text == "") MessageBox.Show("Укажите текст для обработки");
            else if (KeyBox.Text == "") MessageBox.Show("Укажите ключ для обработки");
            else
            {

                if (EncrBtn.IsChecked.Value == true)
                {
                    AfterBlock.Text=enc.Encrypt(BeforeBlock.Text, KeyBox.Text);
                }
                else if (DecrBtn.IsChecked.Value == true)
                {
                    AfterBlock.Text = enc.Decrypt(BeforeBlock.Text, KeyBox.Text);
                }
            }

        }

        private void LoadFile_Click(object sender, RoutedEventArgs e)
        {
            if (PathBox.Text != "" && PathBox.Text.Contains('\\'))
            {
                if (!new DirectoryInfo(PathBox.Text.Substring(0, PathBox.Text.LastIndexOf('\\'))).Exists)
                {
                    MessageBox.Show("Укажите корректный путь");
                }
                else
                {
                    BeforeBlock.Text=enc.LoadFile(PathBox.Text);
                }
            }
            else MessageBox.Show("Укажите корректный путь");

        }

        private void SaveFile_Click(object sender, RoutedEventArgs e)
        {
            if (PathBox.Text != "" && PathBox.Text.Contains('\\'))
            {
                if (!new DirectoryInfo(PathBox.Text.Substring(0, PathBox.Text.LastIndexOf('\\'))).Exists)
                {
                    MessageBox.Show("Укажите корректный путь");
                }
                else
                {
                    MessageBox.Show(enc.SaveFile(PathBox.Text, AfterBlock.Text));
                }
            }
            else MessageBox.Show("Укажите корректный путь");
        }
    }
}
