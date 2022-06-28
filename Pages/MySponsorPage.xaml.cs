using MaraphonSkills.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для MySponsorPage.xaml
    /// </summary>
    public partial class MySponsorPage : Page
    {
        public MarathonEntities marathon { get; set; }
        public ObservableCollection<Sponsor> sponsors { get; set; }

        public MySponsorPage()
        {
            marathon = new MarathonEntities();
            sponsors = new ObservableCollection<Sponsor>();
            InitializeComponent();
        }

        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            decimal a = 0;
            datagrid.ItemsSource = marathon.Sponsor.ToList();
            foreach (var item in marathon.Sponsor)
            {
                a += item.Amount;
            }
            total.Text = a.ToString();
        }
    }
}
