using MaraphonSkills.Core;
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

namespace MaraphonSkills.Pages
{
    /// <summary>
    /// Логика взаимодействия для RunnerManagementPage.xaml
    /// </summary>
    public partial class RunnerManagementPage : Page
    {
        public MarathonEntities context { get; set; }
        public Runner runner { get; set; }
        public RunnerManagementPage(RunnerMarathon Runner)
        {
            context = new MarathonEntities();
            var a = context.Runner.Find(Runner.RunnerId);
            runner = a;

            //MemoryStream ms = new MemoryStream(runner.RunnerPicture);
            //BitmapImage image = new BitmapImage();
            //image.BeginInit();
            //image.StreamSource = ms;
            //image.EndInit();
            //RunnerImg.Source = image;

            InitializeComponent();
        }

        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void GoToCertificate(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CertificatePage());
        }

        private void EfitProfile(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new EditPage());
        }
    }
}
