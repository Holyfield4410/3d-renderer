using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;

namespace _3drenderer
{
    /// <summary>
    /// Interaction logic for introPage.xaml
    /// </summary>
    public partial class introPage : Page
    {
        public introPage()
        {
            InitializeComponent();
        }

        private void intro_start_button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Content = new drawingPage();
            mainWindow.Show();
            Window.GetWindow(this).Close();
        }
    }
}
