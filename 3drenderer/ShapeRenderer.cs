using System.Windows.Controls;
using System.Windows.Media.Media3D;

namespace _3drenderer
{
    public class ShapeRenderer
    {
        private Model3DGroup modelGroup = new Model3DGroup();
        private PerspectiveCamera camera = new PerspectiveCamera();
        private double angle = 0;
        private bool isRotating = true;
        private Grid containerGrid;

        public bool IsRotating
        {
            get { return isRotating; }
        }

        public ShapeRenderer(Grid containerGrid)
        {
            this.containerGrid = containerGrid;
        }

        public void InitializeScene(Shape shape)
        {
            modelGroup.Children.Add(shape.createModel());

            camera.Position = new Point3D(0, 0, 5);
            camera.LookDirection = new Vector3D(0, 0, -1);
            camera.UpDirection = new Vector3D(0, 1, 0);
            camera.FieldOfView = 45;

            Viewport3D viewport = new Viewport3D();
            viewport.Camera = camera;
            viewport.Children.Add(new ModelVisual3D { Content = modelGroup });

            containerGrid.Children.Add(viewport);
        }

        public void RenderFrame()
        {
            if (isRotating)
            {
                angle += 0.12;
                modelGroup.Transform = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(0, 1, 0), angle));
            }
        }

        public void ToggleRotation()
        {
            isRotating = !isRotating;
        }
    }
}
