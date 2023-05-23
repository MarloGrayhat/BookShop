using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BookShop.Views.Pages
{
    internal class FrameMain
    {
        public static Frame frameMain;

        public static void Error(string errorMsg)
        {
            MessageBox.Show(errorMsg);
            frameMain.GoBack();
        }
    }
}
