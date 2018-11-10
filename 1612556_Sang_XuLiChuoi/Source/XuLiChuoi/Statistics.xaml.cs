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

namespace XuLiChuoi
{
    /// <summary>
    /// Đếm số lần từ xuất hiện trong chuỗi
    /// Interaction logic for Normalize.xaml
    /// </summary>
    public partial class Normalize : Window
    {
        string stringStatistics = "";
        public Normalize()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            stringStatistics = txtBox_stringStatistics.Text;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            const string Space = " ";

            var tokens = stringStatistics.Split(new string[] { Space },
                StringSplitOptions.None)
                .Select(token => token.Trim().ToLower());

            var dictionary = new Dictionary<string, int>();

            foreach (var token in tokens)
            {
                if (dictionary.ContainsKey(token))
                {
                    dictionary[token]++;
                }
                else
                {
                    dictionary[token] = 1;
                }
            }
            string outResult_DemTu = "";
            foreach (var entry in dictionary)
            {
                outResult_DemTu += ($"{entry.Key}: {entry.Value}\n");
            }
            lbl_resultStatistics.Content = outResult_DemTu;
        }
    }
}
