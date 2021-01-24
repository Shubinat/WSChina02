using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;

namespace WSChina2020AppComp02.Pages
{
    /// <summary>
    /// Логика взаимодействия для ExportSponsorsListPage.xaml
    /// </summary>
    public partial class ExportSponsorsListPage : Page
    {
        List<Entities.SponsorClassName> ExportingList;
        public ExportSponsorsListPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Страница экспорта списка спонсоров
        /// </summary>
        /// <param name="ExportingList">Список для экспорта</param>
        public ExportSponsorsListPage(List<Entities.SponsorClassName> ExportingList)
        {
            InitializeComponent();
            this.ExportingList = ExportingList;
            TBFilePath.Text = null;
        }

        private void BtnBrowse_Click(object sender, RoutedEventArgs e)
        {
            var folderDialog = new FolderBrowserDialog();
            if(folderDialog.ShowDialog() == DialogResult.OK)
            {
                TBFilePath.Text = folderDialog.SelectedPath;
            }
        }

        private void BtnExport_Click(object sender, RoutedEventArgs e)
        {
            if(TBFilePath.Text + @"\SponsorshipDetal.xml" != @"\SponsorshipDetal.xml") // я хз почему не работает != null или != ""
            {
                if (RBXML.IsChecked.Value)
                {
                    
                    XDocument xDoc = new XDocument();
                    // Создание корневого элемента
                    XElement xRoot = new XElement("SponsorshipDetal");
                    // Добавление аттрибута к нему
                    XAttribute attrRoot = new XAttribute("Version", "1.0.0");
                    xRoot.Add(attrRoot);

                    // Добавление дочерних элементов в корневой элемент
                    foreach (var item in ExportingList)
                    {
                        // Создание элемента
                        XElement xElement = new XElement("SponsorshipDetal");
                        // Создание аттрибутов
                        XAttribute[] ElementAttr = { 
                            new XAttribute("Event", item.Competition.EventName),
                            new XAttribute("Skills", item.Competence.SkillOfService),
                            new XAttribute("Sponsor", item.Sponsor.Name),
                            new XAttribute("SponsorItem", item.Category.Name),
                            new XAttribute("Amount", item.Amount.ToString()),
                        };
                        // Добавление аттрибутов к элементу
                        xElement.Add(ElementAttr);
                        xRoot.Add(xElement);
                    }
                    // Сохранение
                    xDoc.Add(xRoot);
                    xDoc.Save(TBFilePath.Text + @"\SponsorshipDetal.xml");
                    System.Windows.MessageBox.Show($"File was saved from path {TBFilePath.Text + @"\SponsorshipDetal.xml"}.\nIt was exported {ExportingList.Count} records.", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                    TBFilePath.Text = null;
                }
                else
                {
                    Excel.Application application = new Excel.Application();
                    application.SheetsInNewWorkbook = 1;
                    Excel.Workbook workbook = application.Workbooks.Add(Type.Missing);
                    int startRowIndex = 1;
                    Excel.Worksheet worksheet = application.Worksheets.Item[1];

                    worksheet.Cells[1][startRowIndex] = "Event";
                    worksheet.Cells[2][startRowIndex] = "Skills";
                    worksheet.Cells[3][startRowIndex] = "Sponsor";
                    worksheet.Cells[4][startRowIndex] = "SponsorItem";
                    worksheet.Cells[5][startRowIndex] = "Amount";

                    startRowIndex++;

                    foreach (var item in ExportingList)
                    {
                        worksheet.Cells[1][startRowIndex] = item.Competition.EventName;
                        worksheet.Cells[2][startRowIndex] = item.Competence.SkillOfService;
                        worksheet.Cells[3][startRowIndex] = item.Sponsor.Name;
                        worksheet.Cells[4][startRowIndex] = item.Category.Name;
                        worksheet.Cells[5][startRowIndex] = item.Amount;
                        /// worksheet.Cells[5][startRowIndex].NumberFormat = "#,###.00";
                        startRowIndex++;
                    }

                    Excel.Range range = worksheet.Range[worksheet.Cells[1][1], worksheet.Cells[5][startRowIndex - 1]];
                    range.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle =
                    range.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle =
                    range.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle =
                    range.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle =
                    range.Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle =
                    range.Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;

                    worksheet.Columns.AutoFit();
                    System.Windows.MessageBox.Show($"File was saved from path {TBFilePath.Text + @"\SponsorshipDetal.xls"}.\nIt was exported {ExportingList.Count} records.", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                    // application.Visible = true;
                    workbook.SaveAs(TBFilePath.Text + @"\SponsorshipDetal.xls", Excel.XlFileFormat.xlExcel12);
                    TBFilePath.Text = null;
                }
            }
            else
            {
                System.Windows.MessageBox.Show("Filepath is empty!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e) => TBFilePath.Text = null;
    }
}
