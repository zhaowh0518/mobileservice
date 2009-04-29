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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Disappearwind.MobileService.MobileMainService
{
    /// <summary>
    /// Interaction logic for ucToDo.xaml
    /// </summary>
    public partial class ucToDo : UserControl
    {
        public ucToDo()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            txtDateTime.Text = DateTime.Now.ToString();
            BindToDoList();
        }

        private void btnDo_Click(object sender, RoutedEventArgs e)
        {
            if (CheckInput())
            {
                MainDispatcher.TODOList.Add(new ToDo(txtContent.Text, Convert.ToDateTime(txtDateTime.Text)));
                MainDispatcher.ShowInfoMessage("Have added in sequence!");
                BindToDoList();
            }
        }
        private bool CheckInput()
        {
            bool result = true;
            //content
            if (string.IsNullOrEmpty(txtContent.Text))
            {
                MainDispatcher.ShowInfoMessage("Content shouldn't be empty!");
                result = false;
            }
            else
            {
                var c = MainDispatcher.TODOList.Where(p => p.Content == txtContent.Text);
                if (c.Count() > 0)
                {
                    MessageBoxResult mbResult = MessageBox.Show("Sequence has same content,would you go on add the content?",
                        "Warning", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                    if (mbResult == MessageBoxResult.Cancel)
                    {
                        result = false;
                    }
                }
            }
            //checkout datetime
            DateTime dt;
            try
            {
                dt = Convert.ToDateTime(txtDateTime.Text);
            }
            catch
            {
                MainDispatcher.ShowInfoMessage("Invalid DateTime!");
                result = false;
            }
            return result;
        }
        private void BindToDoList()
        {
            if (MainDispatcher.TODOList.Count == 0)
            {
                lvToDoList.Visibility = Visibility.Hidden;
            }
            else
            {
                lvToDoList.Visibility = Visibility.Visible;
                lvToDoList.ItemsSource = MainDispatcher.TODOList.OrderBy(p => p.Time);
            }
        }
    }
}
