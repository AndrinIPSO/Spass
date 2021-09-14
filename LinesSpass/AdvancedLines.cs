using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace LinesSpass
{
    public class AdvancedLines 
    {
        public Line line;
        
        public AdvancedLines(Point p1, Point p2)
        {
            line = new Line();
            line.X1 = p1.X;
            line.Y1 = p1.Y;

            line.X2 = p2.X;
            line.Y2 = p2.Y;

            line.Stroke = Brushes.Black;
            line.Fill = Brushes.Black;

            line.StrokeThickness = 1;
            
        }
    }
}
