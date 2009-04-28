using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using System.Windows.Forms; // NotifyIcon control
using System.Drawing; // Icon

namespace Disappearwind.MobileService.MobileMainService
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NotifyIcon notifyIcon;
        System.Windows.Forms.ContextMenu notifyMenu;
        bool IsRealExit = false;
        /// <summary>
        /// Dispatch all things
        /// </summary>
        public static MainDispatcher MainDispatcher = new MainDispatcher();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ShowInTaskbar = false;
            WindowStyle = WindowStyle.ToolWindow;
            Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!IsRealExit)
            {
                e.Cancel = true;
                WindowState = WindowState.Minimized;
                if (notifyIcon == null)
                {
                    // Configure and show a notification icon in the system tray
                    notifyIcon = new NotifyIcon();
                    notifyIcon.BalloonTipText = "Mobile Service!";
                    notifyIcon.Text = "Mobile Service!";
                    notifyIcon.Icon = new System.Drawing.Icon("mymobile.ico");
                    notifyIcon.Visible = true;
                    notifyIcon.ShowBalloonTip(10);
                    notifyIcon.Click += new EventHandler(notifyIcon_Click);
                    BuildNotifyMenu();
                }
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (notifyIcon != null)
            {
                notifyIcon.Visible = false;
                notifyIcon = null;
            }
        }

        void notifyIcon_Click(object sender, EventArgs e)
        {
            if (WindowState == WindowState.Minimized)
            {
                WindowState = WindowState.Normal;
            }
            else
            {
                WindowState = WindowState.Minimized;
            }
        }
        private void BuildNotifyMenu()
        {
            if (notifyMenu == null)
            {
                notifyMenu = new System.Windows.Forms.ContextMenu();

                System.Windows.Forms.MenuItem miOpen = new System.Windows.Forms.MenuItem();
                miOpen.Text = "Open";
                miOpen.Click += new EventHandler(miOpen_Click);
                notifyMenu.MenuItems.Add(miOpen);

                System.Windows.Forms.MenuItem miExit = new System.Windows.Forms.MenuItem();
                miExit.Text = "Exit";
                miExit.Click += new EventHandler(miExit_Click);
                notifyMenu.MenuItems.Add(miExit);
            }
            notifyIcon.ContextMenu = notifyMenu;
        }

        void miOpen_Click(object sender, EventArgs e)
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            WindowState = WindowState.Normal;
        }

        void miExit_Click(object sender, EventArgs e)
        {
            notifyIcon.Visible = false;
            notifyIcon = null;
            notifyMenu = null;
            IsRealExit = true;
            Close();
        }

        private void miScheduleToDO_Click(object sender, RoutedEventArgs e)
        {
            spContent.Children.Clear();
            ucToDo uc = new ucToDo();
            spContent.Children.Add(uc);
            spContent.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            spContent.VerticalAlignment = VerticalAlignment.Center;
        }
    }
}
