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
            shapeRenderer = new ShapeRenderer(ModelGrid);
            InitializeScene();
            StartRendering();
        }

        private void InitializeScene()
        {
            Cuboid cuboid = new Cuboid(Width, Height, Depth);
            shapeRenderer.InitializeScene(cuboid);
        }

        private void StartRendering()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(16); 
            timer.Tick += RenderFrame;
            timer.Start();
        }

        private void RenderFrame(object sender, EventArgs e)
        {
            shapeRenderer.RenderFrame();
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            shapeRenderer.ToggleRotation();
            ToggleButton.IsChecked = shapeRenderer.IsRotating;
        }

    }
}
