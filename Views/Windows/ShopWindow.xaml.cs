using BookShop.Views.Pages;
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
using System.Windows.Shapes;

namespace BookShop.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для ShopWindow.xaml
    /// </summary>
    public partial class ShopWindow : Window
    {
        private bool adminUser;
        public ShopWindow(bool admin)
        {
            adminUser =  admin;
            InitializeComponent();
            FrameMain.frameMain = frmShopWindow;
            FrameMain.frameMain.Navigate(new ShopMenu_Page(admin));
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            if (FrameMain.frameMain.CanGoBack) FrameMain.frameMain.GoBack();
        }
    }
}
