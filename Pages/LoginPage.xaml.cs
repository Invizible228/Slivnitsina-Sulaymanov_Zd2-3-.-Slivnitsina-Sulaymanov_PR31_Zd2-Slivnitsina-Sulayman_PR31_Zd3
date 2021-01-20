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
using System.Windows.Threading;

namespace MaraphonSkills.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        DispatcherTimer newTimer;
        private int WrongTypes = 0;
        private int timeValue;
        Core.MarathonEntities context;
        public LoginPage()
        {
            InitializeComponent();
            newTimer = new DispatcherTimer();
            newTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            newTimer.Interval = new TimeSpan(0, 0, 1);
            timeValue = 60;
            TimerTextBox.Text = String.Format("До конца болокировки осталось {0} секунд", timeValue);
            context = new Core.MarathonEntities();
            CaptchaRenderer();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            CommandManager.InvalidateRequerySuggested();
            timeValue--;
            TimerTextBox.Text = String.Format("До конца блокировки осталось {0} секунд", timeValue);
            if (timeValue < 0)
            {
                EmailTextBox.IsEnabled = true;
                PasswordTextBox.IsEnabled = true;
                LoginButton.IsEnabled = true;
                CapchaTextBox.IsEnabled = true;

                TimerTextBox.Visibility = Visibility.Hidden;
                newTimer.Stop();
            }
        }


        /// <summary>
        /// Авторизация при нажатии на кнопку Login
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (CapchaTextBox.Text == CapchaTextBlock.Text)
            {
                Core.User currentUser = context.User.Where(x => x.Email == EmailTextBox.Text && x.Password == PasswordTextBox.Password).First();
                if (currentUser != null)
                {
                    WrongTypes = 0;
                    Properties.Settings.Default.currentUserEmail = currentUser.Email;
                    Properties.Settings.Default.Save();
                    switch (currentUser.RoleId)
                    {
                        case 1:
                            this.NavigationService.Navigate(new RunnerMenuPage());
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Неправильно введён логин и/или пароль.");
                    if (WrongTypes < 2)
                    {
                        WrongTypes++;
                        int remainingChances = 3 - WrongTypes;
                        CaptchaRenderer();
                    }
                    else
                    {
                        newTimer.Start();
                        TimerTextBox.Visibility = Visibility.Visible;
                        MessageBox.Show("Вы неверно ввели данные пользователя и исчерпали лимит.\nДоступ заблокирован на одну минуту");
                        EmailTextBox.IsEnabled = false;
                        PasswordTextBox.IsEnabled = false;
                        LoginButton.IsEnabled = false;
                        CapchaTextBox.IsEnabled = false;
                    }
                }
            }
            else
            {
                MessageBox.Show("Капча введена неверно");
                if (WrongTypes < 2)
                {
                    WrongTypes++;
                    int remainingChances = 3 - WrongTypes;
                    CaptchaRenderer();
                }
                else
                {
                    newTimer.Start();
                    TimerTextBox.Visibility = Visibility.Visible;
                    MessageBox.Show("Вы неверно ввели данные пользователя и исчерпали лимит.\nДоступ заблокирован на одну минуту");
                    EmailTextBox.IsEnabled = false;
                    PasswordTextBox.IsEnabled = false;
                    LoginButton.IsEnabled = false;
                    CapchaTextBox.IsEnabled = false;
                }
            }
        }

        /// <summary>
        /// Нажатие на кнопку Cancel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        /// <summary>
        /// Создание капчи
        /// </summary>
        void CaptchaRenderer()
        {
            Random rnd = new Random();
            string textCapcha = String.Empty;
            string ALF = "1234567890QWERTYUIOPASDFGHJKLZXCVBNM";
            for (int i = 0; i < 5; ++i)
                textCapcha += ALF[rnd.Next(ALF.Length)];
            CapchaTextBlock.Text = textCapcha;
        }

        /// <summary>
        /// Кнопка для разработчика чтобы войти под бегуном
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DebugButton_Click(object sender, RoutedEventArgs e)
        {
            CapchaTextBox.Text = CapchaTextBlock.Text;
            EmailTextBox.Text = "asd";
            PasswordTextBox.Password = "as";
        }
    }
}
