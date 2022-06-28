﻿using System;
using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;
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
    /// Логика взаимодействия для ReviewsPage.xaml
    /// </summary>
    public partial class ReviewsPage : Page
    {
        Core.MarathonEntities context;
        public ReviewsPage()
        {
            context = new Core.MarathonEntities();
            InitializeComponent();

            ReviewItemsControl.ItemsSource = context.Review.OrderByDescending(x => x.ReviewDateTime).Take(6).ToList();
            ManCountTextBlock.Text = context.Review.Where(x => x.Volunteer.Gender == "M").Count().ToString();
            WomanCountTextBlock.Text = context.Review.Where(x => x.Volunteer.Gender == "W").Count().ToString();
            RussiaCountTextBlock.Text = context.Review.Where(x => x.user3.CountryCode == "RU").Count().ToString();
            AnotherCountriesCountTextBlock.Text = context.Review.Where(x => x.user3.CountryCode != "RU").Count().ToString();

            ReviewChart.ChartAreas.Add(new ChartArea("Main"));
            var curentSeries = new Series("Rating")
            {
                IsValueShownAsLabel = true
            };
            ReviewChart.Series.Add(curentSeries);
            curentSeries.ChartType = SeriesChartType.Column;

            ReviewChart.BorderlineColor = System.Drawing.Color.White ;

            var reviewMarks = context.Review.ToList();
            for (int i = 1; i <= 5; i++)
            {
                curentSeries.Points.AddXY(i, reviewMarks.Where(x => x.ReviewMark == i).Count()) ;
            }

        }

        private void ManFilterButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ReviewItemsControl.ItemsSource = context.Review.Where(x => x.Volunteer.Gender == "M").ToList();
        }

        private void WomenFilterButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ReviewItemsControl.ItemsSource = context.Review.Where(x => x.Volunteer.Gender == "W").ToList();
        }

        private void RussiaFilterButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ReviewItemsControl.ItemsSource = context.Review.Where(x => x.user3.CountryCode == "RU").ToList();
        }

        private void AnotherCountriesButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ReviewItemsControl.ItemsSource = context.Review.Where(x => x.user3.CountryCode != "RU").ToList();
        }
    }
}
