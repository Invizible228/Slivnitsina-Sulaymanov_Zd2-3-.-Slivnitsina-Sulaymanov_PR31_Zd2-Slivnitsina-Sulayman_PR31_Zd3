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

namespace MaraphonSkills
{
    /// <summary>
    /// Логика взаимодействия для MarathonRegistrationPage.xaml
    /// </summary>
    public partial class MarathonRegistrationPage : Page
    {
        public MarathonRegistrationPage()
        {
            InitializeComponent();
        }

        private void GoToRegister(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Всё точно работает и вы точно зарегистрировались :)");
        }
    }
}
