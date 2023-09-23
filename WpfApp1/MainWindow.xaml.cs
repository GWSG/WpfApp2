using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;



namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CheckTriangle_Click(object sender, RoutedEventArgs e)
        {
            double side1, side2, side3;

            if (!Double.TryParse(txtSide1.Text, out side1) || !Double.TryParse(txtSide2.Text, out side2) || !Double.TryParse(txtSide3.Text, out side3) || side1 <= 0 || side2 <= 0 || side3 <= 0)
            {
                MessageBox.Show("請輸入大於0的整數");
                return;
            }

            Triangle triangle = new Triangle(side1, side2, side3);
            triangles.Add(triangle);

            if (triangle.IsTriangle)
            {
                lblResult.Background = Brushes.Green;
                lblResult.Content = $"邊長 {triangle.Side1}, {triangle.Side2}, {triangle.Side3} 可以形成三角形。";
            }
            else
            {
                lblResult.Background = Brushes.Red;
                lblResult.Content = $"邊長 {triangle.Side1}, {triangle.Side2}, {triangle.Side3} 不可以形成三角形。";
            }

            UpdateResultLabel();
        }


        private List<Triangle> triangles = new List<Triangle>();

        private void UpdateResultLabel()
        {
            txtResultLog.Text = "";

            foreach (Triangle triangle in triangles)
            {
                string resultMessage = $"邊長 {triangle.Side1}, {triangle.Side2}, {triangle.Side3} ";
                if (triangle.IsTriangle)
                {
                    resultMessage += "可以形成三角形";
                }
                else
                {
                    resultMessage += "不可以形成三角形";
                }

                txtResultLog.Text += resultMessage + Environment.NewLine;
            }
        }


    }

    public class Triangle
    {
        public double Side1 { get; private set; }
        public double Side2 { get; private set; }
        public double Side3 { get; private set; }
        public bool IsTriangle { get; private set; }

        public Triangle(double side1, double side2, double side3)
        {
            Side1 = side1;
            Side2 = side2;
            Side3 = side3;
            IsTriangle = IsTrianglePossible(side1, side2, side3);
        }

        private bool IsTrianglePossible(double a, double b, double c)
        {
            return (a*a + b*b > c*c) && (a * a + c*c > b*b) && (b * b + c * c > a*a);
        }
    }


}
