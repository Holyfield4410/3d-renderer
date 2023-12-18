// Shape.cs
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace _3drenderer
{
    public abstract class Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public double Depth { get; set; }

        public abstract Model3D CreateModel();
    }

    // Modify the Cuboid class to accept width, height, and depth in the constructor
    public class Cuboid : Shape
    {
        public Cuboid(double width, double height, double depth)
        {
            Width = width * 0.01;
            Height = height * 0.01;
            Depth = depth;
        }

        public override Model3D CreateModel()
        {
            MeshGeometry3D cuboidMesh = new MeshGeometry3D();

            // Vertices of the cuboid
            cuboidMesh.Positions.Add(new Point3D(-Width / 2, -Height / 2, -Depth / 2));
            cuboidMesh.Positions.Add(new Point3D(-Width / 2, -Height / 2, Depth / 2));
            cuboidMesh.Positions.Add(new Point3D(-Width / 2, Height / 2, -Depth / 2));
            cuboidMesh.Positions.Add(new Point3D(-Width / 2, Height / 2, Depth / 2));
            cuboidMesh.Positions.Add(new Point3D(Width / 2, -Height / 2, -Depth / 2));
            cuboidMesh.Positions.Add(new Point3D(Width / 2, -Height / 2, Depth / 2));
            cuboidMesh.Positions.Add(new Point3D(Width / 2, Height / 2, -Depth / 2));
            cuboidMesh.Positions.Add(new Point3D(Width / 2, Height / 2, Depth / 2));

            // Indices for the cuboid's triangles
            Int32Collection indices = new Int32Collection
        {
            // Front face
            0, 2, 1,
            1, 2, 3,

            // Back face
            4, 5, 6,
            5, 7, 6,

            // Left face
            0, 1, 5,
            0, 5, 4,

            // Right face
            2, 6, 3,
            3, 6, 7,

            // Top face
            2, 0, 4,
            2, 4, 6,

            // Bottom face
            1, 3, 5,
            3, 7, 5
        };

            cuboidMesh.TriangleIndices = indices;
            SolidColorBrush blueBrush = new SolidColorBrush(Colors.Blue);
            DiffuseMaterial material = new DiffuseMaterial(blueBrush);

            return new GeometryModel3D(cuboidMesh, material);
        }
    }
}
