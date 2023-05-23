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
    /// Логика взаимодействия для UserLogIn.xaml
    /// </summary>
    public partial class UserLogIn_Page : Page
    {
        public UserLogIn_Page()
        {
            InitializeComponent();
        }
        private void btnAuth_Click(object sender, RoutedEventArgs e)
        {
            var user = GetUser();
            if (user != null)
            {
                Windows.ShopWindow shopWindow = new Windows.ShopWindow(user.Admin);
                shopWindow.Show();
                Window.GetWindow(this).Close();
            }
            else
            {
                tbEmail.Text = string.Empty;
                tbPassword.Text = string.Empty;
            }
        }

        private DB.User GetUser()
        {
            string email = tbEmail.Text.ToLower();
            string pass = tbPassword.Text;
            var user = DB.ConnDB.connDb.User.FirstOrDefault(x => x.Email == email && x.Password == pass);
            if (user == null)
            {
                MessageBox.Show("Пользователь не найден");
                return null;
            }
            else
            {
                return user;
            }
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            FrameMain.frameMain.Navigate(new AddUser_Page());
        }
    }
}
