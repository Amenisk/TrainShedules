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
using TrainShedules.Classes;

namespace TrainShedules.Pages
{
    /// <summary>
    /// Логика взаимодействия для RoutePage.xaml
    /// </summary>
    public partial class RoutePage : Page
    {
        public RoutePage(RouteInformation route)
        {
            InitializeComponent();
            tbRouteName.Text = route.Name;
            tbDate.Text = route.Date;
            lvStops.ItemsSource = route.StopsList;
            iMap.Source = BytesToImage(route.Map);
        }

        private BitmapImage BytesToImage(byte[] bytes)
        {
            using (MemoryStream memoryStream = new MemoryStream(bytes))
            {
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = memoryStream;
                image.EndInit();
                return image;
            }
        }
    }
}
