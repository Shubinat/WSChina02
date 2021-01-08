using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace WSChina2020AppComp02.Pages
{
    /// <summary>
    /// Логика взаимодействия для ImportVolunteers.xaml
    /// </summary>
    public partial class ImportVolunteers : Page
    {
        public ImportVolunteers()
        {
            InitializeComponent();
            BtnImport.Visibility = Visibility.Hidden;
            BtnCancel.Visibility = Visibility.Hidden;
        }

        private void BtnBrowse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Microsoft Excel Table Files (*.xls;*xlsx)|*.xls;*.xlsx|All files (*.*)|*.*";
            if(ofd.ShowDialog() == true)
            {
                TBFilePath.Text = ofd.FileName;
                BtnImport.Visibility = Visibility.Visible;
                BtnCancel.Visibility = Visibility.Visible;
            }
        }

        private void BtnImport_Click(object sender, RoutedEventArgs e)
        {
            if(TBFilePath.Text != null)
            {

                try
                {
                    string str = "";
                    for (int i = 0; i < File.ReadAllLines(TBFilePath.Text, System.Text.Encoding.Default).Length; i++)
                    {
                        for (int j = 0; j < File.ReadAllLines(TBFilePath.Text, System.Text.Encoding.Default)[i].Split(',').Length; j++)
                        {
                            str += File.ReadAllLines(TBFilePath.Text, System.Text.Encoding.Default)[i].Split(',')[j] + " ";
                        }
                        str += "\n";
                    }
                        
                        
                    MessageBox.Show(str);
                }
                catch (Exception)
                {

                    throw;
                }
                
            }
            
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            TBFilePath.Text = null;
            BtnImport.Visibility = Visibility.Hidden;
            BtnCancel.Visibility = Visibility.Hidden;
        }
    }
}
