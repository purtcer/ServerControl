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

namespace ServerControl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private System.Windows.Forms.NotifyIcon appIcon;
        public MainWindow()
        {
            InitializeComponent();

            appIcon = new System.Windows.Forms.NotifyIcon();
            appIcon.BalloonTipTitle = "Зоголовок сообщения";
            appIcon.BalloonTipText = "Появляется когда мы помещаем иконку в трэй";

            appIcon.Text = "Это у нас пишется если мы наведем мышку на нашу иконку в трэее";
            appIcon.Icon = new System.Drawing.Icon(@"Resources.Images.Circle_Red.png");
            appIcon.Click += new EventHandler(appIcon_Click);
        }

        private WindowState windowState = WindowState.Normal;
        void OnStateChanged(object sender, EventArgs args)
        {
            if (WindowState == WindowState.Minimized)
            {
                Hide();
                if (appIcon != null)
                    appIcon.ShowBalloonTip(2000);
            }
            else
                windowState = WindowState;
        }
        void OnIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs args)
        {
            CheckTrayIcon();
        }
        void appIcon_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = windowState;
        }
        void CheckTrayIcon()
        {
            ShowTrayIcon(!IsVisible);
        }
        void ShowTrayIcon(bool show)
        {
            if (appIcon != null)
                appIcon.Visible = show;
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            appIcon.Dispose();
            appIcon = null;
        }

    }
}
