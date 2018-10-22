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

namespace MiniGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Random random = new Random();
        private List<String> arrayImage;
        private List<String> arrayName;
        private int answer1, answer2, result, count = 0, point = 0;
        private List<int> checkDuplicate = new List<int>();

        public MainWindow()
        {
            InitializeComponent();
            create();
        }

        private void create()
        {
            arrayImage = new List<string>();
            arrayImage.Add("28_bull.jpg");
            arrayImage.Add("28_calf.jpg");
            arrayImage.Add("28_cock.jpg");
            arrayImage.Add("28_cow.jpg");
            arrayImage.Add("28_donkey.jpg");
            arrayImage.Add("28_goat.jpg");
            arrayImage.Add("28_lamb.jpg");
            arrayImage.Add("28_pig.jpg");
            arrayImage.Add("28_sheep.jpg");
            arrayImage.Add("28_turkey.jpg");

            arrayName = new List<string>();
            arrayName.Add("Bull");
            arrayName.Add("Calf");
            arrayName.Add("Cock");
            arrayName.Add("Cow");
            arrayName.Add("Donkey");
            arrayName.Add("Goat");
            arrayName.Add("Lamb");
            arrayName.Add("Pig");
            arrayName.Add("Sheep");
            arrayName.Add("Turkey");

            left.IsEnabled = false;
            right.IsEnabled = false;
        }

        private void let()
        {
            do
            {
                answer1 = random.Next(0, 10);
            } while (checkDupl(answer1) == 1);
            checkDuplicate.Add(answer1);

            do
            {
                answer2 = random.Next(0, 10);
            } while (answer2 == answer1);

            string pathImg = "";
            pathImg = arrayImage.ElementAt(answer1);
            question.Source = (ImageSource)new ImageSourceConverter().ConvertFrom("data/" + pathImg);

            int wrap = random.Next(1, 3);
            if (wrap == 1)
            {
                result = 1;
                left.Content = arrayName.ElementAt(answer1);
                right.Content = arrayName.ElementAt(answer2);
            }
            else
            {
                result = 2;
                left.Content = arrayName.ElementAt(answer2);
                right.Content = arrayName.ElementAt(answer1);
            }
        }

        private int checkDupl(int iRan) // fix rand lặp hình khi chơi
        {
            int flag = 0;
            for (int i = 0; i < checkDuplicate.Count(); i++)
            {
                if (iRan == checkDuplicate.ElementAt(i))
                {
                    flag = 1;
                }
            }
            return flag;
        }

        private void check(int iCheck)
        {
            if (result == iCheck)
            {
                point++;
                score.Content = "Score: " + point;
            }
            else
            {
            }
            count++;

            if (count < 10)
            { // fix trường hợp chơi xong 10 hình lại xuất hiện hình mới tiếp
                let();
            }

            if (count == 10)
            {
                count = 0;
                MessageBox.Show("Your score is: " + point + "/10!");
                point = 0;
                reset(); // quay lại từ đầu
            }
        }

        private void click_answer1(object sender, RoutedEventArgs e)
        {
            check(1);
        }

        private void click_answer2(object sender, RoutedEventArgs e)
        {
            check(2);
        }

        private void click_start(object sender, RoutedEventArgs e)
        {
            left.IsEnabled = true;
            right.IsEnabled = true;
            start.IsEnabled = false;
            let();
        }

        private void reset()
        {
            left.IsEnabled = false;
            right.IsEnabled = false;
            start.IsEnabled = true;
            score.Content = "Score: 0";
            left.Content = "Answer 1";
            right.Content = "Answer 2";
            question.Source = (ImageSource)new ImageSourceConverter().ConvertFrom("icons/logo_large.jpg");
            checkDuplicate = new List<int>();
        }
    }
}

