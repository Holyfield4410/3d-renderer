using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace _3drenderer
{
    /// <summary>
    /// Interaction logic for shapeDisplayPage.xaml
    /// </summary>
    public partial class shapeDisplayPage : Page
    {
        private ShapeRenderer shapeRenderer;
        double Width;
        double Height;
        double Depth;

        public shapeDisplayPage(double width, double height, double depth)
        {
            InitializeComponent();
            Width = width;
            Height = height;
            Depth = depth;
            shapeRenderer = new ShapeRenderer(MainGrid);
            InitializeScene();
            StartRendering();
            CreateToggleButton();
        }

        private void InitializeScene()
        {
            // Prompt the user for input (you can use TextBoxes, sliders, or any other UI controls)

            Cuboid cuboid = new Cuboid(Width, Height, Depth);
            shapeRenderer.InitializeScene(cuboid);
        }

        private void StartRendering()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(16); // 60 fps
            timer.Tick += RenderFrame;
            timer.Start();
        }

        private void RenderFrame(object sender, EventArgs e)
        {
            shapeRenderer.RenderFrame();
        }

        private void CreateToggleButton()
        {
            ToggleButton toggleButton = new ToggleButton();
            toggleButton.Content = "Toggle Rotation";
            toggleButton.IsChecked = shapeRenderer.IsRotating;
            toggleButton.Click += ToggleButton_Click;

            StackPanel buttonPanel = new StackPanel();
            buttonPanel.Orientation = Orientation.Horizontal;
            buttonPanel.Margin = new Thickness(10);
            buttonPanel.Children.Add(toggleButton);

            MainGrid.Children.Add(buttonPanel);
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            shapeRenderer.ToggleRotation();
        }
    }
}
