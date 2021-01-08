using ExcelDataReader;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        BackgroundWorker worker = new BackgroundWorker();
        public ImportVolunteers()
        {
            InitializeComponent();
            BtnImport.Visibility = Visibility.Hidden;
            BtnCancel.Visibility = Visibility.Hidden;
            InitializeBackgroundWorker();
        }
        private void InitializeBackgroundWorker()
        {
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerCompleted +=new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            worker.ProgressChanged +=new ProgressChangedEventHandler(worker_ProgressChanged);
        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressBarImporting.Value = e.ProgressPercentage;
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("The import was finish.", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            
            try
            {
            FileStream stream = File.Open(e.Argument.ToString(), FileMode.Open, FileAccess.Read);
            IExcelDataReader excelReader;
            if (System.IO.Path.GetExtension(e.Argument.ToString()).ToUpper() == ".XLS")
            {
                excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
            }
            else
            {

                excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            }
            DataSet result = excelReader.AsDataSet(new ExcelDataSetConfiguration() { UseColumnDataType = false });
            int iterationNumber = 0;
            for (int i = 1; i < result.Tables[0].Rows.Count; i++)
            {
                string[] str = new string[result.Tables[0].Columns.Count];
                for (int j = 0; j < result.Tables[0].Columns.Count; j++)
                {
                    var data = result.Tables[0].Rows[i][j];
                    str[j] = data.ToString();
                        
                        iterationNumber++;
                    double progress = ((double)iterationNumber / (double)((result.Tables[0].Rows.Count-1) * (result.Tables[0].Columns.Count))) * 100;
                    worker.ReportProgress((int)Math.Floor(progress));

                }
                var tableVolunteer = VolunteerConverter(str);
                var currVolunteer = AppData.Context.Volunteers.ToList().FirstOrDefault(p => p.VolunteerID == tableVolunteer.VolunteerID);
                    if (currVolunteer != null)
                    {
                        currVolunteer.Name = tableVolunteer.Name;
                        currVolunteer.Surname = tableVolunteer.Surname;
                        currVolunteer.GenderID = tableVolunteer.GenderID;
                        currVolunteer.OccupationCityID = tableVolunteer.OccupationCityID;
                        currVolunteer.ProvinceCityID = tableVolunteer.ProvinceCityID;
                        currVolunteer.CompetenceID = tableVolunteer.CompetenceID;
                        currVolunteer.DateOfBirth = tableVolunteer.DateOfBirth;
                    }
                    else
                    {
                        AppData.Context.Volunteers.Add(tableVolunteer);
                    }
            }
            excelReader.Close();
            AppData.Context.SaveChanges();    
            
            }
            catch (Exception)
            {
                e.Cancel = true;
                MessageBox.Show("An error occurred while importing.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
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
                    worker.RunWorkerAsync(TBFilePath.Text);             
            }
            
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            TBFilePath.Text = null;
            BtnImport.Visibility = Visibility.Hidden;
            BtnCancel.Visibility = Visibility.Hidden;
        }
        
        private Entities.Volunteer VolunteerConverter(string[] data)
        {
            Entities.Volunteer currVolunteer = new Entities.Volunteer();
            for (int i = 0; i < data.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        currVolunteer.VolunteerID = Convert.ToInt32(data[i]);
                        break;
                    case 1:
                        currVolunteer.Name = data[i];
                        break;
                    case 2:
                        currVolunteer.Surname = data[i];
                        break;
                    case 3:
                        currVolunteer.GenderID = Convert.ToInt32(data[i]);
                        break;
                    case 4:
                        currVolunteer.OccupationCityID = Convert.ToInt32(data[i]);
                        break;
                    case 5:
                        currVolunteer.ProvinceCityID = Convert.ToInt32(data[i]);
                        break;
                    case 6:
                        currVolunteer.CompetenceID = Convert.ToInt32(data[i]);
                        break;
                    case 7:
                        DateTime dateTime = DateTime.Parse(data[i]);
                       currVolunteer.DateOfBirth = dateTime;
                        break;
                    default:
                        break;
                }
            }
            return currVolunteer;
        }
    }
}
