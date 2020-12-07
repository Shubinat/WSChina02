using System;
using System.Collections;
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
using WSChina2020AppComp02.Entities;

namespace WSChina2020AppComp02.Pages
{
    /// <summary>
    /// Логика взаимодействия для MyProfilePage.xaml
    /// </summary>
    public partial class MyProfilePage : Page
    {
        public MyProfilePage()
        {
            InitializeComponent();
        }
        User currUser;
        public MyProfilePage(User currUser)
        {
            InitializeComponent();
            this.DataContext = currUser;
            this.currUser = currUser;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (currUser.Password == PassBox.Password)
            {
                if((RePassBox.Password.Length <= 16 && RePassBox.Password.Length >= 6))
                {
                    bool ThereIsNumber = false;
                    foreach (var element in RePassBox.Password)
                    {
                        
                        char[] numbers = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
                        foreach(var number in numbers)
                        {
                            if (number == element)
                            {
                                ThereIsNumber = true;
                                break;
                            }
                        }
                        if (ThereIsNumber)
                            break;
                    }
                    if (ThereIsNumber)
                    {
                        bool Three = false;
                        LinkedList<LinkedListNode<char>> linked = new LinkedList<LinkedListNode<char>>();
                        for (int i = 0; i < RePassBox.Password.Length; i++)
                        {
                            linked.AddLast(new LinkedListNode<char>(RePassBox.Password[i]));
                        }
                        foreach (var element in linked)
                        {
                            if(element.Previous.Value == element.Value && element.Value == element.Next.Value)
                            {
                                Three = true;
                                break;
                            }
                        }
                        if (!Three)
                        {
                            bool ThereIsSpace = false;
                            for (int i = 0; i < RePassBox.Password.Length; i++)
                            {
                                if(RePassBox.Password[i] == ' ')
                                {
                                    ThereIsSpace = true;
                                    break;
                                }
                            }
                            if (!ThereIsSpace)
                            {
                                var Upper = "QWERTYUIOPASDFGHJKLZXCVBNM";
                                bool ThereIsUpper = false;
                                
                                foreach(var chr in Upper)
                                {
                                    foreach (var element in RePassBox.Password)
                                    {
                                        if(chr == element)
                                        {
                                            ThereIsUpper = true;
                                            break;
                                        }
                                    }
                                    if (ThereIsUpper)
                                        break;
                                }
                                if (ThereIsUpper)
                                {
                                    var Lower = Upper.ToLower();
                                    bool ThereIsLower = false;
                                    foreach (var chr in Lower)
                                    {
                                        foreach (var element in RePassBox.Password)
                                        {
                                            if (chr == element)
                                            {
                                                ThereIsLower = true;
                                                break;
                                            }
                                        }
                                        if (ThereIsLower)
                                            break;
                                    }
                                    if (ThereIsLower)
                                    {
                                        if(CheckBoxShowPass.IsChecked.Value)
                                            AppData.Context.Users.ToList().First(p => p.UserID == currUser.UserID).Password = TBRePassBox.Text;
                                        else
                                            AppData.Context.Users.ToList().First(p => p.UserID == currUser.UserID).Password = RePassBox.Password;

                                        AppData.Context.SaveChanges();
                                        PassBox.Password = "";
                                        RePassBox.Password = "";

                                        TBPassBox.Text = "";
                                        TBRePassBox.Text = "";
                                        MessageBox.Show("The changes are saved", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                                    }
                                    else
                                    {
                                        MessageBox.Show("The new password does not meet the condition: \"There must be at least one lowercase letter\"", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("The new password does not meet the condition: \"There must be at least one capital letter\"", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show("The new password does not meet the condition: \"There should be no spaces in the password\"", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                            }

                        }
                        else
                        {
                            MessageBox.Show("The new password does not meet the condition: \"There must be no repeated characters in a row\"", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                   }
                    else
                    {
                        MessageBox.Show("The new password does not meet the condition: \"There must be at least one digit\"", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    MessageBox.Show("The new password does not meet the condition: \"From 6 to 16 characters\"", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("The old password was entered incorrectly.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            PassBox.Password = "";
            RePassBox.Password = "";

            TBPassBox.Text = "";
            TBRePassBox.Text = "";
        }


        private void CheckBoxShowPass_Checked(object sender, RoutedEventArgs e)
        {
            
        }

        private void CheckBoxModifyPassword_Click(object sender, RoutedEventArgs e)
        {
            if (CheckBoxModifyPassword.IsChecked.Value)
            {
                BtnCancel.IsEnabled = true;
                BtnSave.IsEnabled = true;
                PasswordWindow.IsEnabled = true;
            }
            else
            {
                BtnCancel.IsEnabled = false;
                BtnSave.IsEnabled = false;
                PasswordWindow.IsEnabled = false;
            }
        }

        private void CheckBoxShowPass_Click(object sender, RoutedEventArgs e)
        {
            if (CheckBoxShowPass.IsChecked.Value)
            {
                TBPassBox.Text = PassBox.Password;
                TBPassBox.Visibility = Visibility.Visible;
                PassBox.Visibility = Visibility.Hidden;

                TBRePassBox.Text = RePassBox.Password;
                TBRePassBox.Visibility = Visibility.Visible;
                RePassBox.Visibility = Visibility.Hidden;
            }
            else
            {
                PassBox.Password = TBPassBox.Text;
                PassBox.Visibility = Visibility.Visible;
                TBPassBox.Visibility = Visibility.Hidden;

                RePassBox.Password = TBRePassBox.Text;
                RePassBox.Visibility = Visibility.Visible;
                TBRePassBox.Visibility = Visibility.Hidden;
            }
        }
    }
}
