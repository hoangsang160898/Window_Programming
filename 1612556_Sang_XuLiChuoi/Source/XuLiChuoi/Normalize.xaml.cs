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
    /// Chuẩn hóa chuỗi về đúng dạng yêu cầu
    /// Interaction logic for Statistics.xaml
    /// </summary>
    public partial class Statistics : Window
    {
        String stringNormalize = "";
        public Statistics()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            stringNormalize = txtBox_stringNormalize.Text;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            const string Space = " ";
            var tokens = stringNormalize.Split(new string[] { Space },
                StringSplitOptions.RemoveEmptyEntries)
                .Select(token =>
                {
                    token = token.Trim().ToLower();
                    var firstChar = token.Substring(0, 1).ToUpper();
                    var remaining = token.Substring(1, token.Length - 1);
                    return firstChar + remaining;
                });

            var builder = new StringBuilder();
            foreach (var token in tokens)
            {
                builder.Append(token);
                builder.Append(Space);
            }

            builder.Remove(builder.Length - 1, 1);

            lbl_resultNormalize.Content = builder.ToString();
        }
    }
}
