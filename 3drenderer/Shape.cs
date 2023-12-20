using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace _3drenderer
{
    public abstract class Shape
    {
        public double width { get; set; }
        public double height { get; set; }
        public double depth { get; set; }
        public abstract Model3D createModel();
    }

    public class Cuboid : Shape
    {
        public Cuboid(double width, double height, double depth)
        {
            base.width = width * 0.01;
            base.height = height * 0.01;
            base.depth = depth;
        }

        public override Model3D createModel()
        {
            MeshGeometry3D cuboidMesh = new MeshGeometry3D();
            cuboidMesh.Positions.Add(new Point3D(-width / 2, -height / 2, -depth / 2));
            cuboidMesh.Positions.Add(new Point3D(-width / 2, -height / 2, depth / 2));
            cuboidMesh.Positions.Add(new Point3D(-width / 2, height / 2, -depth / 2));
            cuboidMesh.Positions.Add(new Point3D(-width / 2, height / 2, depth / 2));
            cuboidMesh.Positions.Add(new Point3D(width / 2, -height / 2, -depth / 2));
            cuboidMesh.Positions.Add(new Point3D(width / 2, -height / 2, depth / 2));
            cuboidMesh.Positions.Add(new Point3D(width / 2, height / 2, -depth / 2));
            cuboidMesh.Positions.Add(new Point3D(width / 2, height / 2, depth / 2));
            Int32Collection indices = new Int32Collection
        {
            // front
            0, 2, 1,
            1, 2, 3,

            // back
            4, 5, 6,
            5, 7, 6,

            // left
            0, 1, 5,
            0, 5, 4,

            // right
            2, 6, 3,
            3, 6, 7,

            // top
            2, 0, 4,
            2, 4, 6,

            // bottom
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
