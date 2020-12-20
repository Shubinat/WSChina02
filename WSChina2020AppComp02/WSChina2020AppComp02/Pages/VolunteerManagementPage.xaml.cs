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

namespace WSChina2020AppComp02.Pages
{
    /// <summary>
    /// Логика взаимодействия для VolunteerManagementPage.xaml
    /// </summary>
    public partial class VolunteerManagementPage : Page
    {

         int currentPage = 0;
         static List<Entities.Volunteer> volunteers = AppData.Context.Volunteers.ToList().Where(p => 1 == p.CompetenceID).ToList();
         int countPages = (volunteers.Count / 10) + 1;
        public VolunteerManagementPage()
        {
            InitializeComponent(); 
            TxtBlockTotalValue.Text = "Total Volunteers: " + volunteers.Count.ToString();

            DataGrdVolunteers.ItemsSource = GetVolunteers(currentPage, volunteers);

            TxtBlockCurrPage.Text = (currentPage + 1) + " / " + countPages + " page";
            CBSortBy.Text = "ID Number";

            CBSkills.ItemsSource = AppData.Context.Competences.ToList();
            CBSkills.DisplayMemberPath = "SkillOfService";
            CBSkills.SelectedIndex = 0;

        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {

            volunteers = AppData.Context.Volunteers.ToList().Where(p => CBSkills.SelectedIndex + 1 == p.CompetenceID).ToList();
            volunteers.Sort(new VolunteerComparer() { SortBy = CBSortBy.SelectedIndex });
            DataGrdVolunteers.ItemsSource = GetVolunteers(currentPage, volunteers);
            TxtBlockTotalValue.Text = "Total Volunteers: " + volunteers.Count.ToString();
            countPages = (volunteers.Count / 10) + 1;
            TxtBlockCurrPage.Text = (currentPage + 1) + " / " + countPages + " page";
        }
        private void BtnFirstPage_Click(object sender, RoutedEventArgs e)
        {
            currentPage = 0;
            DataGrdVolunteers.ItemsSource = GetVolunteers(currentPage, volunteers);
            TxtBlockCurrPage.Text = (currentPage+1) + " / " + countPages + " page";
            BlockButtons();
        }

        private void BtnPreviousPage_Click(object sender, RoutedEventArgs e)
        {
            currentPage--;
            if (currentPage >= 0)
            {
                DataGrdVolunteers.ItemsSource = GetVolunteers(currentPage, volunteers);
                TxtBlockCurrPage.Text = (currentPage + 1) + " / " + countPages + " page";
                BlockButtons();
            }
            else
            {
                currentPage++;

            }
        }

        private void BtnNextPage_Click(object sender, RoutedEventArgs e)
        {
            currentPage++;
            if (currentPage < countPages)
            {
                DataGrdVolunteers.ItemsSource = GetVolunteers(currentPage, volunteers);
                TxtBlockCurrPage.Text = (currentPage + 1) + " / " + countPages + " page";
                BlockButtons();
            }
            else
            {
                currentPage--;
                
            }
            
        }

        private void BtnLastPage_Click(object sender, RoutedEventArgs e)
        {
            currentPage = countPages - 1;
            DataGrdVolunteers.ItemsSource = GetVolunteers(currentPage, volunteers);
            TxtBlockCurrPage.Text = (currentPage + 1) + " / " + countPages + " page";
            BlockButtons();
        }

        private void BtnGoToPage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                uint goTo = Convert.ToUInt32(TBGoToPage.Text) - 1;
                
                if(goTo < countPages)
                {
                    currentPage = (int)goTo;
                    DataGrdVolunteers.ItemsSource = GetVolunteers(currentPage, volunteers);
                    TxtBlockCurrPage.Text = (currentPage + 1) + " / " + countPages + " page";
                    BlockButtons();
                }
                else
                {
                    MessageBox.Show("Page cannot be found", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Page cannot be found", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        /// <summary>
        /// Функция разбивающая список на несколько частей и выводящая одну из частей
        /// </summary>
        /// <param name="currPage">Номер страницы списка</param>
        /// <param name="list">Список который нужно разбить</param>
        /// <returns>Страница списка</returns>
        private List<Entities.Volunteer> GetVolunteers(int currPage, List<Entities.Volunteer> list)
        {
            List<Entities.Volunteer> returnList = new List<Entities.Volunteer>();
            for (int i = 0; i < 10; i++)
            {
                string currIndex = currPage.ToString() + i.ToString();
                if (list.Count> Convert.ToInt32(currIndex))
                {
                    returnList.Add(list[Convert.ToInt32(currIndex)]);
                }
                else
                {
                    break;
                }       
            }
            return returnList;
        }

        void BlockButtons()
        {
            if(currentPage == 0 || currentPage == 1)         
                BtnFirstPage.IsEnabled = false;
            else
                BtnFirstPage.IsEnabled = true;

            if(currentPage == countPages-1 || currentPage == countPages - 2)
                BtnLastPage.IsEnabled = false;
            else
                BtnLastPage.IsEnabled = true;

            if(currentPage == countPages - 1)
                BtnNextPage.IsEnabled = false;
            else
                BtnNextPage.IsEnabled = true;

            if (currentPage == 0)
                BtnPreviousPage.IsEnabled = false;
            else
                BtnPreviousPage.IsEnabled = true;
  
        }

        private void BtnImportVolunteers_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAjustVolunteers_Click(object sender, RoutedEventArgs e)
        {

        }
    }
    /// <summary>
    /// Сортировщик волонтеров
    /// </summary>
    class VolunteerComparer : IComparer<Entities.Volunteer>
    {
        public int SortBy { get; set; }
        string charset = "abcdefghijklmnopqrstuvwxyz0123456789 ";
        int[] v1Indexes;
        int[] v2Indexes;
        public int Compare(Entities.Volunteer v1, Entities.Volunteer v2)
        {
            switch (SortBy)
            {
                //Сортировка по ID
                case 0:
                    if(v1.VolunteerID > v2.VolunteerID)
                        return 1;
                    else if(v1.VolunteerID < v2.VolunteerID)
                        return -1;
                    else
                        return 0;

                //Сортировка по Имени
                case 1:
                    v1Indexes = new int[v1.FullName.Length];
                    for (int i = 0; i < v1.FullName.Length; i++)
                    {
                        for (int j = 0; j < charset.Length; j++)
                        {
                            if (v1.FullName.ToLower()[i] == charset[j])
                                v1Indexes[i] = j;
                        }
                    }
                    v2Indexes = new int[v2.FullName.Length];
                    for (int i = 0; i < v2.FullName.Length; i++)
                    {
                        for (int j = 0; j < charset.Length; j++)
                        {
                            if (v2.FullName.ToLower()[i] == charset[j])
                                v2Indexes[i] = j;
                        }
                    }

                    
                    if(v1Indexes.Length > v2Indexes.Length)
                    {
                        for (int i = 0; i < v2Indexes.Length; i++)
                        {
                            if (v1Indexes[i] >v2Indexes[i])
                                return 1;
                            else if (v1Indexes[i] < v2Indexes[i])
                                return -1;
                        }
                        return 0;
                    }
                    else
                    {
                        for (int i = 0; i < v1Indexes.Length; i++)
                        {
                            if (v1Indexes[i] > v2Indexes[i])
                                return 1;
                            else if (v1Indexes[i] < v2Indexes[i])
                                return -1;
                        }
                        return 0;
                    }
                //Сортировка по полу
                case 2:
                    if (v1.GenderID > v2.GenderID)
                        return 1;
                    else if (v1.GenderID < v2.GenderID)
                        return -1;
                    else
                        return 0;
                //Сортировка по Городу 1
                case 3:
                    v1Indexes = new int[v1.City.Name.Length];
                    for (int i = 0; i < v1.City.Name.Length; i++)
                    {
                        for (int j = 0; j < charset.Length; j++)
                        {
                            if (v1.City.Name.ToLower()[i] == charset[j])
                                v1Indexes[i] = j;
                        }
                    }
                    v2Indexes = new int[v2.City.Name.Length];
                    for (int i = 0; i < v2.City.Name.Length; i++)
                    {
                        for (int j = 0; j < charset.Length; j++)
                        {
                            if (v2.City.Name.ToLower()[i] == charset[j])
                                v2Indexes[i] = j;
                        }
                    }


                    if (v1Indexes.Length > v2Indexes.Length)
                    {
                        for (int i = 0; i < v2Indexes.Length; i++)
                        {
                            if (v1Indexes[i] > v2Indexes[i])
                                return 1;
                            else if (v1Indexes[i] < v2Indexes[i])
                                return -1;
                        }
                        return 0;
                    }
                    else
                    {
                        for (int i = 0; i < v1Indexes.Length; i++)
                        {
                            if (v1Indexes[i] > v2Indexes[i])
                                return 1;
                            else if (v1Indexes[i] < v2Indexes[i])
                                return -1;
                        }
                        return 0;
                    }
                //Сортировка по Городу 2
                case 4:
                    v1Indexes = new int[v1.City1.Name.Length];
                    for (int i = 0; i < v1.City1.Name.Length; i++)
                    {
                        for (int j = 0; j < charset.Length; j++)
                        {
                            if (v1.City1.Name.ToLower()[i] == charset[j])
                                v1Indexes[i] = j;
                        }
                    }
                    v2Indexes = new int[v2.City1.Name.Length];
                    for (int i = 0; i < v2.City1.Name.Length; i++)
                    {
                        for (int j = 0; j < charset.Length; j++)
                        {
                            if (v2.City1.Name.ToLower()[i] == charset[j])
                                v2Indexes[i] = j;
                        }
                    }


                    if (v1Indexes.Length > v2Indexes.Length)
                    {
                        for (int i = 0; i < v2Indexes.Length; i++)
                        {
                            if (v1Indexes[i] > v2Indexes[i])
                                return 1;
                            else if (v1Indexes[i] < v2Indexes[i])
                                return -1;
                        }
                        return 0;
                    }
                    else
                    {
                        for (int i = 0; i < v1Indexes.Length; i++)
                        {
                            if (v1Indexes[i] > v2Indexes[i])
                                return 1;
                            else if (v1Indexes[i] < v2Indexes[i])
                                return -1;
                        }
                        return 0;
                    }
                //Сортировка по компетенции
                case 5:
                    if (v1.CompetenceID > v2.CompetenceID)
                        return 1;
                    else if (v1.CompetenceID < v2.CompetenceID)
                        return -1;
                    else
                        return 0;

                //Сортировка в противном случае.(Производится по ID)
                default:
                    if (v1.VolunteerID > v2.VolunteerID)
                        return 1;
                    else if (v1.VolunteerID < v2.VolunteerID)
                        return -1;
                    else
                        return 0;
                    
            }

        }
    }
}
