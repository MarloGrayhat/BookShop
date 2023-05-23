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

namespace BookShop.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для ShopMenu_Page.xaml
    /// </summary>
    public partial class ShopMenu_Page : Page
    {
        public ShopMenu_Page(bool admin)
        {
            InitializeComponent();
            spAdminWindow.Visibility = admin ? Visibility.Visible : Visibility.Collapsed;
        }

        private void btnAddStyle_Click(object sender, RoutedEventArgs e)
        {
            FrameMain.frameMain.Navigate(new AddStyle_Page());
        }

        private void btnAddAuther_Click(object sender, RoutedEventArgs e)
        {
            FrameMain.frameMain.Navigate(new AddAuthor_Page());
        }

        private void btnAddPublisher_Click(object sender, RoutedEventArgs e)
        {
            FrameMain.frameMain.Navigate(new AddPublisher_Page());

        }
    }
}
