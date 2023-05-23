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
    public partial class AddAuthor_Page : Page
    {
        public AddAuthor_Page()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Regex fio = new Regex(@"([А-Я][а-я]+)(( [А-Я][а-я]+){1,2})");
            if (fio.IsMatch(tbxName.Text))
            {
                if (DB.ConnDB.connDb.Author.FirstOrDefault(x => x.FullName == tbxName.Text) == null)
                {
                    if (Convert.ToInt32(tbxYear.Text) <= 2005)
                    {
                        DB.Author author = new DB.Author();
                        author.FullName = tbxName.Text;
                        DB.ConnDB.connDb.Author.Add(author);
                        DB.ConnDB.connDb.SaveChanges();
                        FrameMain.frameMain.GoBack();
                    }
                    else
                    {
                        MessageBox.Show("Увы, но аввтору должно быть больше 18 лет");
                        FrameMain.frameMain.GoBack();
                    }
                }
                else
                {
                    MessageBox.Show("Такой автор уже существует");
                    FrameMain.frameMain.GoBack();
                }
            }    
        }
    }
}
