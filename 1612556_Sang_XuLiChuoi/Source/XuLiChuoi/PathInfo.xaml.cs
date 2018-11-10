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
using System.IO;

namespace XuLiChuoi
{
    /// <summary>
    /// Tách đường dẫn trả về tên file, đuôi file, và đường dẫn đến file
    /// Interaction logic for PathInfo.xaml
    /// </summary>
    public partial class PathInfo : Window
    {
        string path = @"";
        public PathInfo()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            path = txtBox_stringPath.Text;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            const string BackSlash = @"\";
            const string Dot = ".";
            var foundPos = path.LastIndexOf(BackSlash);
            var directory = path.Substring(0, foundPos);
            var filename = path.Substring(foundPos + 1, path.Length - foundPos - 1);

            foundPos = path.LastIndexOf(Dot);
            var extension = path.Substring(foundPos + 1, path.Length - foundPos - 1);
            Console.WriteLine($"{directory} - {filename} - {extension}");

            var info = new FileInfo(path);
            Console.WriteLine(info.DirectoryName);
            Console.WriteLine(info.Name);
            Console.WriteLine(info.Extension);
            string result_pathinfor = "";
            result_pathinfor = "DirectoryName: " + info.DirectoryName + "\nName: " + info.Name + "\nExtension: " + info.Extension;
            lbl_resultPathInfor.Content = result_pathinfor;
        }
    }
}
