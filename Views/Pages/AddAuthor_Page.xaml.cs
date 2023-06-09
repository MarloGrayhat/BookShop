﻿using System;
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
using System.Xml.Linq;

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
            if (CheckFullName() && CheckYearOfBirth())
            {
                DB.Author author = new DB.Author();
                author.FullName= tbxName.Text;
                author.YearOfBirth = Convert.ToInt32(tbxYear.Text);
                DB.ConnDB.connDb.Author.Add(author);
                DB.ConnDB.connDb.SaveChanges();
                FrameMain.frameMain.GoBack();
            }
        }    
        

        private bool CheckFullName()
        {
            Regex fio = new Regex(@"([А-Я][а-я]+)(( [А-Я][а-я]+){1,2})");
            if (fio.IsMatch(tbxName.Text))
            {
                if (DB.ConnDB.connDb.Author.FirstOrDefault(x => x.FullName == tbxName.Text) == null)
                {
                    return true;
                }
                else
                {
                    FrameMain.Error("Такой автор уже существует");
                    return false;
                }
            }
            else
            {
                FrameMain.Error("Имя автора введено не корректно");
                return false;
            }
        }

        private bool CheckYearOfBirth()
        {
            if (Convert.ToInt32(tbxYear.Text) <= 2005)
            {
                return true;
            }
            else
            {
                FrameMain.Error("Увы, но аввтору должно быть больше 18 лет");
                return false;
            }
        }
    }
}
