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
    /// Логика взаимодействия для ViewerMenuPage.xaml
    /// </summary>
    public partial class ViewerMenuPage : Page
    {
        int picturePageNumber;
        int maxPicturePageNumber;
        Core.MarathonEntities context;
        public ViewerMenuPage()
        {
            context = new Core.MarathonEntities();

            InitializeComponent();

            picturePageNumber = 1;
            maxPicturePageNumber = context.Runner.ToList().Count/2;
            PictureListView.ItemsSource = context.Runner.OrderBy(x=>x.RunnerId).Take(2).ToList();

            PageCountTextBlock.Text = String.Format("{0} из {1}", picturePageNumber, maxPicturePageNumber);
        }

        public string PageCount { get
            {
                return String.Format("{0} из {1}", picturePageNumber, maxPicturePageNumber);
            }
        }

        private void PageDownButton_Click(object sender, RoutedEventArgs e)
        {
            if (picturePageNumber > 1)
            {
                picturePageNumber -= 1;
                PictureListView.ItemsSource = context.Runner.OrderBy(x => x.RunnerId).Skip((picturePageNumber-1)*2).Take(2).ToList();
                
                PageCountTextBlock.Text = String.Format("{0} из {1}", picturePageNumber, maxPicturePageNumber);
            }
        }

        private void PageUpButton_Click(object sender, RoutedEventArgs e)
        {
            if (picturePageNumber < maxPicturePageNumber)
            {
                picturePageNumber += 1;
                PictureListView.ItemsSource = context.Runner.OrderBy(x => x.RunnerId).Skip((picturePageNumber-1)*2).Take(2).ToList();
                PageCountTextBlock.Text = String.Format("{0} из {1}", picturePageNumber, maxPicturePageNumber);
            }
        }
    }
}
