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
using System.Windows.Threading;

namespace LogIn
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        string userAdmin = "admin";
        string passAdmin = "123";
        string userLogIn, passLogIn = "";
        private DispatcherTimer dispatcherTimer;
        private DispatcherTimer dispatcherTimerForTip;
        public MainWindow()
        {
            //Thời gian báo lỗi khi nhập user hoặc pass
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);

            //Thời gian của tip user và pass login
            dispatcherTimerForTip = new DispatcherTimer();
            dispatcherTimerForTip.Tick += new EventHandler(dispatcherTimerForTip_Tick);
            dispatcherTimerForTip.Interval = new TimeSpan(0, 0, 4);
            dispatcherTimerForTip.Start();

            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            userLogIn = txtbUsername.Text;
        }

        private void lblForgettenAccount_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Updating", "WARNING!!!");
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btnMini_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            passLogIn = passbPassword.Password;
            if (userLogIn == null || userLogIn != userAdmin)
            {
                lblErrorMessage_1.Content = "The username that you've entered" + "\n" + "doesn't match any account.";
                lblErrorMessage_1.Visibility = Visibility.Visible;
                uiErrorSp_1.Visibility = Visibility.Visible;
                dispatcherTimer.Start();
            }
            else if (passLogIn != passAdmin)
            {
                lblErrorMessage_2.Content = "The password that you've entered" + "\n" + "is incorrect.";
                lblErrorMessage_2.Visibility = Visibility.Visible;
                uiErrorSp_2.Visibility = Visibility.Visible;
                dispatcherTimer.Start();

            }
            else if (userLogIn == userAdmin & passLogIn == passAdmin)
            {
                var window = new Dashboard();
                this.Close();
                window.ShowDialog();
            }

        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            lblErrorMessage_1.Visibility = Visibility.Collapsed;
            uiErrorSp_1.Visibility = Visibility.Collapsed;
            lblErrorMessage_2.Visibility = Visibility.Collapsed;
            uiErrorSp_2.Visibility = Visibility.Collapsed;
            dispatcherTimer.IsEnabled = false;
        }

        private void dispatcherTimerForTip_Tick(object sender, EventArgs e)
        {
            lblTip.Visibility = Visibility.Collapsed;
            uiTipSp.Visibility = Visibility.Collapsed;
            borderTip.Visibility = Visibility.Collapsed;

        }
    }
}
