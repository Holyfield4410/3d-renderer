using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System;

namespace _3drenderer
{
    public partial class drawingPage : Page
    {
        private bool isDrawingRectangle = false;
        // Change point out to own coordinate class
        private Point startPoint;
        private Rectangle currentRectangle;

        public drawingPage()
        {
            InitializeComponent();
        }

        private void RectangleTool_Click(object sender, RoutedEventArgs e)
        {
            isDrawingRectangle = true;
        }

        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (isDrawingRectangle)
            {
                startPoint = e.GetPosition(drawingCanvas);
                RemoveCurrentRectangle(); 
            }
        }

        private void Canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (isDrawingRectangle)
            {
                Point endPoint = e.GetPosition(drawingCanvas);
                // Maybe add own rectangle class instead
                currentRectangle = new Rectangle
                {
                    // Math.Abs = Modulus
                    Width = Math.Abs(endPoint.X - startPoint.X),
                    Height = Math.Abs(endPoint.Y - startPoint.Y),
                    Stroke = Brushes.Black,
                    StrokeThickness = 2,
                };

                // finds which side comes first (compares to find min), positions it
                Canvas.SetLeft(currentRectangle, Math.Min(startPoint.X, endPoint.X));
                Canvas.SetTop(currentRectangle, Math.Min(startPoint.Y, endPoint.Y));
                drawingCanvas.Children.Add(currentRectangle);
                isDrawingRectangle = false;
            }
        }

        private void ClearCanvas_Click(object sender, RoutedEventArgs e)
        {
            RemoveCurrentRectangle();
            drawingCanvas.Children.Clear();
        }

        private void RemoveCurrentRectangle()
        {
            if (currentRectangle != null)
            {
                drawingCanvas.Children.Remove(currentRectangle);
                currentRectangle = null;
            }
        }

        private void RenderButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentRectangle != null)
            {
                // prompt parameter = message to user asking for input
                double depth = GetUserInput("Enter depth for rendering:");

                MainWindow mainWindow = new MainWindow();
                mainWindow.Content = new shapeDisplayPage(currentRectangle.Width, currentRectangle.Height, depth);
                mainWindow.Show();
                Window.GetWindow(this).Close();
            }
            else
            {
                MessageBox.Show("Please draw a valid rectangle before rendering.");
            }
        }

        private double GetUserInput(string prompt)
        {
            double depthInput;
            string input;
            do
            {
                // https://stackoverflow.com/questions/97097/what-is-the-c-sharp-version-of-vb-nets-inputbox
                input = Microsoft.VisualBasic.Interaction.InputBox(prompt, "Input depth", "1.0");

                // out = store input in "depthInput" if parse correctly
                if (!double.TryParse(input, out depthInput))
                {
                    MessageBox.Show("Invalid input. Please enter a valid number.");
                }
            } while (!double.TryParse(input, out depthInput));
            return depthInput;
        }
    }
}
