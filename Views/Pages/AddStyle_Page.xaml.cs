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
    /// Логика взаимодействия для AddStyle.xaml
    /// </summary>
    public partial class AddStyle_Page : Page
    {
        public AddStyle_Page()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (DB.ConnDB.connDb.Style.FirstOrDefault(x => x.Name.ToLower() == tbxName.Text.ToLower()) == null)
            {     
                DB.Style style = new DB.Style();
                style.Name = tbxName.Text;
                DB.ConnDB.connDb.Style.Add(style);
                DB.ConnDB.connDb.SaveChanges();
                FrameMain.frameMain.GoBack();
            }
            else
            {
                MessageBox.Show("Такой жанр уже существует");
                FrameMain.frameMain.GoBack();
            }
        }
    }
}
