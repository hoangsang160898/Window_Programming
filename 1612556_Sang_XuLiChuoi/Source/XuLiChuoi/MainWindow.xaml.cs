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

namespace XuLiChuoi
{
    /// <summary>
    /// Màn hình lựa chọn xử lí chuỗi
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string ChuoiXuLi = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_Statistics(object sender, RoutedEventArgs e)
        {
            var window = new Normalize();
            window.ShowDialog();

        }

        private void btn_Normalize(object sender, RoutedEventArgs e)
        {
            var window = new Statistics();
            window.ShowDialog();
        }

        private void btn_PathInfor(object sender, RoutedEventArgs e)
        {
            var window = new PathInfo();
            window.ShowDialog();
        }
    }
}
