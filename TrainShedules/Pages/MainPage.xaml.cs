using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Configuration;
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
using TrainShedules.Classes;

namespace TrainShedules.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        List<RouteInformation> routes = new List<RouteInformation>();
        List<RouteInformation> sortRoutes = new List<RouteInformation>(); 
        public MainPage()
        {
            InitializeComponent();
            var dateList = App.Connection.DateRoute;
            
            foreach (var r in dateList)
            {
                routes.Add(new RouteInformation(r.Route, r.DateTimeBeginning));
            }

            lvRoutes.ItemsSource = routes;
        }

        private void NavigateToRoutePage(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new RoutePage((RouteInformation) lvRoutes.SelectedItem));
        }

        private void SortRoutes()
        {
            StopInformation fromStop = null;
            var findRoutes = new List<RouteInformation>();  

            sortRoutes = routes.OrderBy(x => x.BeginningDateTime).ToList();
            if (cmbSort.SelectedIndex == 0)
            {
                lvRoutes.ItemsSource = sortRoutes;
            }
            else if (cmbSort.SelectedIndex == 1)
            {
                sortRoutes.Reverse();
                lvRoutes.ItemsSource = sortRoutes;
            }

            if (tbFrom.Text != "" && tbWhere.Text != "")
            {
                foreach(var r in sortRoutes)
                {
                    foreach(var s in r.StopsList)
                    {
                        if(fromStop == null && s.StationName.ToLower().Contains(tbFrom.Text.ToLower()))
                        {
                            fromStop = s;
                            continue;
                        }

                        if(fromStop != null && s.StationName.ToLower().Contains(tbWhere.Text.ToLower()))
                        {
                            fromStop.Highlighting = "Bold";
                            s.Highlighting = "Bold";
                            findRoutes.Add(r);
                            break;
                        }
                    }
                    fromStop = null;
                }
                sortRoutes = findRoutes;
                lvRoutes.ItemsSource = sortRoutes;
                return;
            }

            if (tbFrom.Text != "")
            {
                foreach (var r in sortRoutes)
                {
                    foreach (var s in r.StopsList)
                    {
                        if (fromStop == null && s.StationName.ToLower().Contains(tbFrom.Text.ToLower()))
                        {
                            s.Highlighting = "Bold";
                            findRoutes.Add(r);
                            break;
                        }
                    }
                }
                sortRoutes = findRoutes;
                lvRoutes.ItemsSource = sortRoutes;
                return;
            }

            if (tbWhere.Text != "")
            {
                foreach (var r in sortRoutes)
                {
                    foreach (var s in r.StopsList)
                    {
                        if (fromStop == null && s.StationName.ToLower().Contains(tbWhere.Text.ToLower()))
                        {
                            s.Highlighting = "Bold";
                            findRoutes.Add(r);
                            break;
                        }
                    }
                }
                sortRoutes = findRoutes;
                lvRoutes.ItemsSource = sortRoutes;
                return;
            }
        }

        private void cmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SortRoutes();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SortRoutes();
        }
    }
}
