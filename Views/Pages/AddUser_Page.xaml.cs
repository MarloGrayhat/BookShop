using BookShop.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для AddUser_Page.xaml
    /// </summary>
    public partial class AddUser_Page : Page
    {
        public AddUser_Page()
        {
            InitializeComponent();
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            DB.User user = new DB.User();
            string email = tbEmail.Text.ToLower();
            Regex emailReg = new Regex(@"^([a-z][a-z0-9]+)@([a-z]{3,20}?\.)([a-z]{2,6}$)");
            if (emailReg.IsMatch(email))
            {
                if(tbPassword.Text.Length >= 8)
                {
                    if (DB.ConnDB.connDb.User.FirstOrDefault(x => x.Email == tbEmail.Text.ToLower()) == null)
                    {
                        user.Email = email;
                        user.Password = tbPassword.Text;
                        DB.ConnDB.connDb.User.Add(user);
                        DB.ConnDB.connDb.SaveChanges();
                        Windows.ShopWindow shopWindow = new Windows.ShopWindow(false);
                        shopWindow.Show();
                        Window.GetWindow(this).Close();
                    }
                    else
                    {
                        MessageBox.Show("Почта занята");
                        FrameMain.frameMain.GoBack();
                    }
                } else
                {
                    MessageBox.Show("Слишком короткий пароль");
                    FrameMain.frameMain.GoBack();
                }

            } else
            {
                MessageBox.Show("Не правильно введена почта");
                FrameMain.frameMain.GoBack();
            }
        }
    }
}
