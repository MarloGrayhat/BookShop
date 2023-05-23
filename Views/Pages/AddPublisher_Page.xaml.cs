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
    /// Логика взаимодействия для AddPublisher.xaml
    /// </summary>
    public partial class AddPublisher_Page : Page
    {
        public AddPublisher_Page()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (CheckName() && CheckINN() && CheckPhoneNumber())
            {
                DB.Publisher publisher = new DB.Publisher();

                if (tbxAddress.Text.Length != 0)
                {
                    publisher.Address = tbxAddress.Text;
                }
                publisher.Name = tbxName.Text;
                publisher.TelephoneNumber = tbxPhone.Text;
                publisher.INN = tbxINN.Text;
                DB.ConnDB.connDb.Publisher.Add(publisher);
                DB.ConnDB.connDb.SaveChanges();
                FrameMain.frameMain.GoBack();
            }
        }

        private bool CheckName()
        {
            if (DB.ConnDB.connDb.Publisher.FirstOrDefault(x => x.Name.ToLower() == tbxName.Text.ToLower()) == null)
            {
                return true;
            }
            else
            {
                FrameMain.Error("Издатель с таким названием уже есть");
                return false;
            }
        }
        private bool CheckINN()
        {
            if (DB.ConnDB.connDb.Publisher.FirstOrDefault(x => x.INN.ToLower() == tbxINN.Text.ToLower()) == null)
            {
                return true;
            }
            else
            {
                FrameMain.Error("Издатель с таким ИНН уже есть");
                return false;
            }
        }

        private bool CheckPhoneNumber()
        {
            Regex fio = new Regex(@"(\+7)([0-9]{10})");
            if (fio.IsMatch(tbxPhone.Text))
            {
                return true;
            }
            else
            {
                FrameMain.Error("Номер телефона начинается с +7 имеет вид +71234567890");
                return false;
            }
        }
    }
}
