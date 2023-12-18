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
        private Point startPoint;
        private Rectangle currentRectangle;

        public drawingPage()
        {
            InitializeComponent();
        }

        private void RectangleTool_Click(object sender, RoutedEventArgs e)
        {
            // Activate rectangle drawing mode
            isDrawingRectangle = true;
        }

        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (isDrawingRectangle)
            {
                // Start drawing a rectangle
                startPoint = e.GetPosition(drawingCanvas);

                // Remove existing rectangle if any
                RemoveCurrentRectangle();
            }
        }

        private void Canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (isDrawingRectangle)
            {
                // End drawing a rectangle
                Point endPoint = e.GetPosition(drawingCanvas);

                // Create and add the rectangle to the canvas
                currentRectangle = new Rectangle
                {
                    Width = Math.Abs(endPoint.X - startPoint.X),
                    Height = Math.Abs(endPoint.Y - startPoint.Y),
                    Stroke = Brushes.Black,
                    StrokeThickness = 2,
                };

                Canvas.SetLeft(currentRectangle, Math.Min(startPoint.X, endPoint.X));
                Canvas.SetTop(currentRectangle, Math.Min(startPoint.Y, endPoint.Y));

                drawingCanvas.Children.Add(currentRectangle);

                // Deactivate rectangle drawing mode
                isDrawingRectangle = false;
            }
        }

        private void ClearCanvas_Click(object sender, RoutedEventArgs e)
        {
            // Remove existing rectangle and clear the canvas
            RemoveCurrentRectangle();
            drawingCanvas.Children.Clear();
        }

        private void RemoveCurrentRectangle()
        {
            // Remove existing rectangle if any
            if (currentRectangle != null)
            {
                drawingCanvas.Children.Remove(currentRectangle);
                currentRectangle = null;
            }
        }

        private void RenderButton_Click(object sender, RoutedEventArgs e)
        {
            // Check if currentRectangle is null or its properties are not set
            if (currentRectangle != null && !double.IsNaN(currentRectangle.Width) && !double.IsNaN(currentRectangle.Height))
            {
                // Prompt the user for the depth value
                double depth = GetUserInput("Enter depth for rendering:");

                    // Navigate to the ShapeDisplayPage with width, height, and depth values

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
            double userInput;
            string input;

            do
            {
                input = Microsoft.VisualBasic.Interaction.InputBox(prompt, "User Input", "10.0");

                if (!double.TryParse(input, out userInput))
                {
                    MessageBox.Show("Invalid input. Please enter a valid number.");
                }

            } while (!double.TryParse(input, out userInput));

            return userInput;
        }
    }
}
