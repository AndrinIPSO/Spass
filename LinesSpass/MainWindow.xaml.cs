using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LinesSpass
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Point p1 = new Point(1, 1);
        Point p2;

        public MainWindow()
        {
            InitializeComponent();
            double val = sl_size.Value;
            lb_sizevalue.Content = $"Wert: {val.ToString("0.00")}";
            sl_size.Value = 1;
        }


        private void bt_draw_Click(object sender, RoutedEventArgs e)
        {
            method();
            gridi_Copy.Children.Clear();
            guidemethod();
        }

        private void sl_x_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            guidemethod();
        }

        private void sl_y_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            guidemethod();
        }

        private void bt_clear_Click(object sender, RoutedEventArgs e)
        {
            gridi.Children.Clear();
            gridi_Copy.Children.Clear();
        }

        private void bt_clearfull_Click(object sender, RoutedEventArgs e)
        {
            gridi.Children.Clear();
            gridi_Copy.Children.Clear();
            p1.X = 0;
            p1.Y = 0;
            p2.X = 0;
            p2.Y = 0;
        }

        private void sl_size_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            guidemethod();
            double val = sl_size.Value;
            lb_sizevalue.Content = $"Wert: {val.ToString("0.00")}";
        }

        public void method()
        {

            p2.X += sl_x.Value * sl_size.Value;
            p2.Y += sl_y.Value * sl_size.Value;
            AdvancedLines l1 = new AdvancedLines(p1, p2);
            p1.X = p2.X;
            p1.Y = p2.Y;

            gridi.Children.Add(l1.line);
        }

        public void guidemethod()
        {
            gridi_Copy.Children.Clear();
            Point p22 = new Point();
            p22.X = p2.X;
            p22.Y = p2.Y;

            Point p11 = new Point();
            p11.X = p1.X;
            p11.Y = p1.Y;


            p22.X += sl_x.Value * sl_size.Value;
            p22.Y += sl_y.Value * sl_size.Value;
            AdvancedLines l1 = new AdvancedLines(p11, p22);
            l1.line.Stroke = Brushes.Red;
            p11.X = p22.X;
            p11.Y = p22.Y;

            lb_x.Content = $"X: {p22.X}";
            lb_y.Content = $"Y: {p22.Y}";

            gridi_Copy.Children.Add(l1.line);
        }

        public void square()
        {
            Point e1 = p1;
            Point e2 = new Point(e1.X + sl_size.Value * 2, e1.Y);
            Point e3 = new Point(e2.X , e2.Y + sl_size.Value * 2);
            Point e4 = new Point(e3.X - sl_size.Value * 2, e3.Y);

            List<Point> edges = new List<Point>();
            edges.Add(e1);
            edges.Add(e2);
            edges.Add(e3);
            edges.Add(e4);

            List<AdvancedLines> lines = new List<AdvancedLines>();
            int i = 0;

            lines.Add(new AdvancedLines(edges[0], edges[1]));
            lines.Add(new AdvancedLines(edges[1], edges[2]));
            lines.Add(new AdvancedLines(edges[2], edges[3]));
            lines.Add(new AdvancedLines(edges[3], edges[0]));

            



            foreach (AdvancedLines line in lines)
            {
                gridi.Children.Add(line.line);
            }
            p1.X = e3.X;
            p1.Y = e3.Y;
        }

        public void guidesquare()
        {
            Point e1 = p1;
            Point e2 = new Point(e1.X + sl_size.Value * 2, e1.Y);
            Point e3 = new Point(e2.X, e2.Y + sl_size.Value * 2);
            Point e4 = new Point(e3.X - sl_size.Value * 2, e3.Y);

            List<Point> edges = new List<Point>();
            edges.Add(e1);
            edges.Add(e2);
            edges.Add(e3);
            edges.Add(e4);

            List<AdvancedLines> lines = new List<AdvancedLines>();
            int i = 0;

            lines.Add(new AdvancedLines(edges[0], edges[1]));
            lines.Add(new AdvancedLines(edges[1], edges[2]));
            lines.Add(new AdvancedLines(edges[2], edges[3]));
            lines.Add(new AdvancedLines(edges[3], edges[0]));





            foreach (AdvancedLines line in lines)
            {
                line.line.Stroke = Brushes.Red;
                gridi_Copy.Children.Add(line.line);
            }
            //p1.X = e3.X;
            //p1.Y = e3.Y;
        }

        private void bt_square_Click(object sender, RoutedEventArgs e)
        {
            square();
            gridi_Copy.Children.Clear();
            guidesquare();
        }

        private void bt_square_MouseEnter(object sender, MouseEventArgs e)
        {
            gridi_Copy.Children.Clear();
            guidesquare();
        }

        private void bt_square_MouseLeave(object sender, MouseEventArgs e)
        {
            gridi_Copy.Children.Clear();
            guidemethod();
        }
    }
}
