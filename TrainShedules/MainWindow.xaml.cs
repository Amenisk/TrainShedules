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
using TrainShedules.Pages;

namespace TrainShedules
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new MainPage()); 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if((MainFrame.Content as Page).Title == "RoutePage")
            {
                MainFrame.Navigate(new MainPage());
            }
        }
    }
}
