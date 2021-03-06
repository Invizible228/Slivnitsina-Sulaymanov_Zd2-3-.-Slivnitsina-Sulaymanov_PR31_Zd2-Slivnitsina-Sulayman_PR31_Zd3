using MaraphonSkills.Core;
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

namespace MaraphonSkills.Pages
{
    /// <summary>
    /// Логика взаимодействия для MyResultsPage.xaml
    /// </summary>
    public partial class MyResultsPage : Page
    {
        public MarathonEntities marathon { get; set; }

        public MyResultsPage()
        {
            marathon = new MarathonEntities();
            InitializeComponent();
        }

        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            datagr.ItemsSource = marathon.RunnerMarathon.ToList();

        }
    }
}
