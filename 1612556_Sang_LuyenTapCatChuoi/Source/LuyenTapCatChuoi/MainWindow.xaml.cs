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
using System.Text.RegularExpressions;

namespace LuyenTapCatChuoi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public class Fraction
    {
        private int numerator;
        private int denominator;

        public Fraction()
        {
            this.numerator = 0;
            this.denominator = 1;
        }

        public Fraction(int numer, int denomi)
        {
            this.numerator = numer;
            this.denominator = denomi;
        }

        public Fraction(string sfraction)
        {
            string[] temp = sfraction.Split('/');
            this.numerator = Int32.Parse(temp[0]);
            this.denominator = Int32.Parse(temp[1]);
        }

        public string getFraction()
        {
            return this.numerator + "/" + this.denominator;
        }

        public Fraction plusTwoFraction(Fraction f)
        {
            int numer = this.numerator * f.denominator + this.denominator * f.numerator;
            int denomi = this.denominator * f.denominator;
            Fraction result = new Fraction(numer, denomi);
            return result;
        }

        public Fraction compactFraction() //Rút gọn phân số
        {
            int tmp = uCLN(this.numerator, this.denominator);
            Fraction result = new Fraction(this.numerator / tmp, this.denominator / tmp);
            return result;
        }

        int uCLN(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            if (a == 0 && b != 0)
            {
                return b;
            }
            else if (a != 0 && b == 0)
            {
                return a;
            }
            while (a != b)
            {
                if (a > b)
                {
                    a -= b;
                }
                else
                {
                    b -= a;
                }
            }
            return a;
        }
    }

    public partial class MainWindow : Window
    {
        private string expresstions = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void btn_sumPS_Click(object sender, RoutedEventArgs e)
        {
            string expresstions = txtBox_PS.Text;
            if (isFractionExpresstions(expresstions) == true)
            {
                lbl_result.Content = progressFractionExpresstions(expresstions).compactFraction().getFraction();
            }
            else
            {
                lbl_result.Content = "Error";
            }
        }

        private bool isFractionExpresstions(string express)
        {
            bool result = true;
            Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$"); // Dấu trừ xét trường hợp phân số âm
            string[] temp = express.Split(new string[] { "+" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < temp.Length; i++)
            {
                string[] tokens = temp[i].Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length != 2)
                {
                    result = false; // Kiểm tra đủ 2 thành phần tử và mẫu 
                }
                else
                {
                    if (regex.IsMatch(tokens[0].Trim()) && regex.IsMatch(tokens[1].Trim()))
                    {
                        int denomi = int.Parse(tokens[1]);
                        if (denomi == 0) // Kiểm tra mẫu = 0
                        {
                            result = false;
                        }
                        else
                        {
                            result = true;
                        }
                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            return result;
        }

        private Fraction progressFractionExpresstions(string express)
        {
            string progressExpress = express.Trim(); // Xóa khoảng trắng
            string[] temp = progressExpress.Split(new string[] { "+" }, StringSplitOptions.RemoveEmptyEntries);
            Fraction result = new Fraction();
            for (int i = 0; i < temp.Length; i++)
            {
                Fraction tmpf1 = new Fraction(temp[i]);
                result = result.plusTwoFraction(tmpf1);
            }
            return result;
        }

        private void btn_sumSN_Click(object sender, RoutedEventArgs e)
        {
            expresstions = txtBox_SN.Text;
            if (checkIntegerExpresstions(expresstions) == true)
            {
                lbl_result.Content = progressIntegerExpresstions(expresstions);
            }
            else
            {
                lbl_result.Content = "Error";

            }
        }

        private bool checkIntegerExpresstions(string express)
        {
            bool result = true;
            if (express[express.Length - 1] == '+') // Kiểm tra trường hợp dấu + ở cuối chuỗi, còn dấu + ở đầu chuỗi vẫn ok nên không kiểm tra
            {
                result = false;
            }
            else
            {
                Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$"); // có dầu trừ vì tính cả số âm
                string[] tokens = express.Split(new string[] { "+" }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < tokens.Length; i++)
                {
                    if (!regex.IsMatch(tokens[i].Trim()))
                    {
                        result = false;
                        break;
                    }
                }
            }
            return result;
        }

        private int progressIntegerExpresstions(string express)
        {
            int result = 0;
            string progressExpress = "";
            progressExpress = express.Trim();
            string[] arrNumber = progressExpress.Split(new string[] { "+" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < arrNumber.Length; i++)
            {
                result += Int32.Parse(arrNumber[i]);
            }
            return result;
        }
    }
}
