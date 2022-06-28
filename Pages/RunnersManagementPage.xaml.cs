﻿using MaraphonSkills.Core;
using Microsoft.Win32;
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
    /// Логика взаимодействия для RunnersManagementPage.xaml
    /// </summary>
    public partial class RunnersManagementPage : Page
    {
        List<RunnerMarathon> dataGridContent;
        MarathonEntities context;
        public RunnersManagementPage()
        {
            context = new Core.MarathonEntities();
            InitializeComponent();
            dataGridContent = context.RunnerMarathon.ToList();
            RunnersDataGrid.ItemsSource = dataGridContent;

            MarathonComboBox.ItemsSource = context.user3.ToList();
            MarathonComboBox.SelectedValuePath = "MarathonId";
            MarathonComboBox.DisplayMemberPath = "MarathonName";
            MarathonComboBox.SelectedIndex = 1;

            SortComboBox.ItemsSource = new List<string> {"Имя", "Фамилия", "Email"};

            TotalRunnersLabel.Content = String.Format("Всего бегунов {0}", context.RunnerMarathon.Count());
        }

        private void DataGridRefreshButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            dataGridContent = context.RunnerMarathon.ToList();
            Filter();
            Sort(SortComboBox.SelectedIndex);
        }

        private void Filter()
        {
            int selectedMarathon = Convert.ToInt32(MarathonComboBox.SelectedValue);
            dataGridContent = dataGridContent.Where(x => x.MarathonId == selectedMarathon).ToList();
            RunnersDataGrid.ItemsSource = dataGridContent;
            TotalRunnersLabel.Content = String.Format("Всего бегунов {0}", context.RunnerMarathon.Where(x => x.MarathonId == selectedMarathon).Count());
        }

        private void Sort(int sortIndex)
        {
            switch (sortIndex)
            {
                case 0:
                    dataGridContent = dataGridContent.OrderBy(x => x.Runner.User.FirstName).ToList();
                    RunnersDataGrid.ItemsSource = dataGridContent;
                    break;
                case 1:
                    dataGridContent = dataGridContent.OrderBy(x => x.Runner.User.LastName).ToList();
                    RunnersDataGrid.ItemsSource = dataGridContent;
                    break;
                case 2:
                    dataGridContent = dataGridContent.OrderBy(x => x.Runner.User.Email).ToList();
                    RunnersDataGrid.ItemsSource = dataGridContent;
                    break;
            }
        }
        //StreamWriter writer;
        private void FileExportButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Title = "Выгрузка в CSV файл";
                saveFile.Filter = "CSV file(*.csv)|*.csv|All files(*.*)|*.*";
                if (File.Exists(saveFile.FileName))
                {
                    File.Delete(saveFile.FileName);
                }
                if (saveFile.ShowDialog().HasValue)
                {
                    using (StreamWriter writer = new StreamWriter(saveFile.FileName, true, Encoding.GetEncoding(1251)))
                    {
                        Console.WriteLine("Вывод");
                        List<Runner> userList = context.Runner.ToList();
                        foreach (Runner item in userList)
                        {
                            List<string> lineList = new List<string>();

                            lineList.Add(item.User.FirstName.ToString());
                            lineList.Add(item.User.LastName.ToString());
                            lineList.Add(item.Email.ToString());

                            lineList.Add(item.Gender.ToString());
                            lineList.Add(item.DateOfBirth.ToString());
                            lineList.Add(item.Country.CountryName.ToString());

                            string list = String.Join(";", lineList);
                            Console.WriteLine(list);
                            writer.WriteLine(list);
                        }
                    }
                }

                MessageBox.Show("Файл с данными сохранён");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void EmailExportButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Title = "E-mail список";
                saveFile.Filter = "CSV file(*.csv)|*.csv|All files(*.*)|*.*";
                if (saveFile.ShowDialog().HasValue)
                {
                    using (StreamWriter writer = new StreamWriter(saveFile.FileName, true, Encoding.GetEncoding(1251)))
                    {
                        Console.WriteLine("Вывод");
                        List<Runner> userList = context.Runner.ToList();
                        foreach (Runner item in userList)
                        {
                            List<string> lineList = new List<string>();

                            lineList.Add(item.RunnerFIO);
                            lineList.Add(item.Email.ToString());

                            string list = String.Join(";", lineList);
                            Console.WriteLine(list);
                            writer.WriteLine(list);
                        }
                    }
                }

                MessageBox.Show("Файл с данными сохранён");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void EditButton_MouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
            //var currentEditButton = sender as Button;
            //var currentRunner = currentEditButton.DataContext as Runner;
            var ab = RunnersDataGrid.SelectedItem as RunnerMarathon;
            this.NavigationService.Navigate(new RunnerManagementPage(ab));
        }

        private void PageLoaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
