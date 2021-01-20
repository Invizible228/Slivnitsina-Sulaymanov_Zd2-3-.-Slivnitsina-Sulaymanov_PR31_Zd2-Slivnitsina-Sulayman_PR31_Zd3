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
    /// Логика взаимодействия для ProfileEditPage.xaml
    /// </summary>
    public partial class ProfileEditPage : Page
    {
        Core.MarathonEntities context;
        public ProfileEditPage()
        {
            context = new Core.MarathonEntities();
            InitializeComponent();

            // Core.Runner currentRunner = context.Runner.Where(x=>x.Email = );

            EmailTextBox.Text = Properties.Settings.Default.currentUserEmail.ToString();


        }
    }
}
