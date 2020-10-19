using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Логика взаимодействия для LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Page
    {

        public LoginScreen()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(TxtBoxLogin.Text) && !string.IsNullOrWhiteSpace(TxtBoxPassword.Text))
            {
                try
                {
                    var Users = AppData.Context.Users.ToList();
                    

                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            ImgCapcha.Source = CreateImage(1500, 500);
        }

        string capchaText ="";
        Random rnd = new Random();
        private DrawingImage CreateImage(int x, int y)
        {
            capchaText = "";
            string LowerCaseText = "qwertyuiopasdfghjklzxcvbnm";
            string UpperCaseText = "QWERTYUIOPASDFGHJKLZXCVBNM";
            string Numbers = "1234567890";

            for (int i = 0; i < 2; i++)
            {
                capchaText += LowerCaseText[rnd.Next(LowerCaseText.Length)];
            }

            for (int i = 0; i < 1; i++)
            {
                capchaText += UpperCaseText[rnd.Next(UpperCaseText.Length)];
            }

            for (int i = 0; i < 1; i++)
            {
                capchaText += Numbers[rnd.Next(Numbers.Length)];
            }
            string rndCapcha = new string(capchaText.ToList().OrderBy(p => (rnd.Next(2) % 2 == 0)).ToArray());

            byte[] bytes = new byte[x * y * 100];
            rnd.NextBytes(bytes);

            DrawingVisual drawingVisual = new DrawingVisual();

            using (DrawingContext drawingContext = drawingVisual.RenderOpen())
            {
                drawingContext.DrawImage(BitmapSource.Create(x, y, 300, 300, PixelFormats.BlackWhite, null, bytes, x*30), new Rect(0, 0, x, y));
                drawingContext.DrawText(new FormattedText(rndCapcha, CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial"), 300, Brushes.Black), new Point(x/5, y/5));
            }
            capchaText = rndCapcha;
            return new DrawingImage(drawingVisual.Drawing);
        }
    }
}
