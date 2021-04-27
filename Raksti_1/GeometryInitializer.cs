using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Raksti_1
{
    public class GeometryInitializer
    {
        private GeometryGroup GetGeometryGroup1_Elipses()
        {
            GeometryGroup geometryGroup = new GeometryGroup();

            for (int x = 20, y = 10; y >= 1; y -= 3, x -= 5)
            {
                geometryGroup.Children.Add(new EllipseGeometry(new Point(50, 50), x, y));
                geometryGroup.Children.Add(new EllipseGeometry(new Point(50, 50), y, x));
            }

            return geometryGroup;
        }

        private GeometryGroup GetGeometryGroup2()
        {
            GeometryGroup geometryGroup = new GeometryGroup();

            geometryGroup.Children.Add(new EllipseGeometry(new Point(110, 60), 50, 50));
            geometryGroup.Children.Add(new EllipseGeometry(new Point(80, 110), 50, 50));
            geometryGroup.Children.Add(new EllipseGeometry(new Point(140, 110), 50, 50));

            return geometryGroup;
        }

        private GeometryGroup GetGeometryGroup3()
        {
            GeometryGroup geometryGroup = new GeometryGroup();

            for (int x = 50; x >= 5; x -= 5)
                geometryGroup.Children.Add(new EllipseGeometry(new Point(110, 60), x, x));

            return geometryGroup;
        }

        private PathGeometry DogsBone()
        {
            var pathGeometry = new PathGeometry();
            var pathSegments = new List<PathSegment>();
            var pathFigure = new PathFigure();
            pathFigure.StartPoint = new Point(70, 60);
            pathFigure.IsClosed = true;

            pathSegments.Add(new ArcSegment(new Point(40, 80), new Size(20, 20), 0, true, new SweepDirection(), true));
            pathSegments.Add(new ArcSegment(new Point(70, 100), new Size(20, 20), 0, true, new SweepDirection(), true));
            pathSegments.Add(new LineSegment(new Point(160, 100), true));
            pathSegments.Add(new ArcSegment(new Point(190, 80), new Size(20, 20), 0, true, new SweepDirection(), true));
            pathSegments.Add(new ArcSegment(new Point(160, 60), new Size(20, 20), 0, true, new SweepDirection(), true));

            foreach (var pathSegment in pathSegments)
                pathFigure.Segments.Add(pathSegment);

            pathGeometry.Figures.Add(pathFigure);

            return pathGeometry;
        }

        private PathGeometry GetshurikenPathGeometry()
        {
            var pathGeometry = new PathGeometry();
            var polyLineSegments = new List<PolyLineSegment>();
            var pathFigure = new PathFigure();
            pathFigure.StartPoint = new Point(20, 80);
            pathFigure.IsClosed = true;

            var points = new List<Point>();
            points.Add(new Point(60, 60));
            points.Add(new Point(90, 75));
            points.Add(new Point(75, 45));
            points.Add(new Point(95, 5));
            points.Add(new Point(115, 45));
            points.Add(new Point(100, 75));
            points.Add(new Point(130, 60));
            points.Add(new Point(170, 80));
            points.Add(new Point(130, 100));
            points.Add(new Point(100, 85));
            points.Add(new Point(115, 115));
            points.Add(new Point(95, 155));
            points.Add(new Point(75, 115));
            points.Add(new Point(90, 85));
            points.Add(new Point(60, 100));

            polyLineSegments.Add(new PolyLineSegment(points, true));

            pathFigure.Segments.Add(polyLineSegments.First());

            pathGeometry.Figures.Add(pathFigure);

            return pathGeometry;
        }

        public Geometry GetSelectedGeometry(int _selectedRadioButtonTag)
        {
            switch (_selectedRadioButtonTag)
            {
                case 1:
                    return GetGeometryGroup1_Elipses();

                case 2:
                    return GetGeometryGroup2();

                case 3:
                    return GetGeometryGroup3();

                case 4:
                    return DogsBone();

                case 5:
                    return GetshurikenPathGeometry();
                default:
                    return GetGeometryGroup1_Elipses();
            }
        }
    }
}
