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
//using System;: 引入System命名空間，包含了基本的C#類型和函數。

//using System.Collections.Generic;: 引入System.Collections.Generic命名空間，以使用泛型集合類別。

//using System.Windows;: 引入System.Windows命名空間，以使用WPF的視窗和控制元件。

//using System.Windows.Media;: 引入System.Windows.Media命名空間，以使用WPF的繪圖功能。

//namespace WpfApp1: 建立一個名為WpfApp1的命名空間。

//public partial class MainWindow : Window: 定義一個名為MainWindow的部分類別，繼承自Window類別，表示主應用程式視窗。

//public MainWindow(): MainWindow類別的建構函數，用於初始化視窗。

//InitializeComponent();: 呼叫InitializeComponent方法，用於初始化視窗的元件和佈局。

//private void CheckTriangle_Click(object sender, RoutedEventArgs e): 定義一個事件處理函數，當"CheckTriangle"按鈕被點擊時執行。

//double side1, side2, side3;: 宣告三個double型態的變數side1、side2和side3，用於存儲輸入的三個邊長。

//if (!Double.TryParse(txtSide1.Text, out side1) || !Double.TryParse(txtSide2.Text, out side2) || !Double.TryParse(txtSide3.Text, out side3) || side1 <= 0 || side2 <= 0 || side3 <= 0): 檢查輸入的邊長是否為有效的數字，並確保它們大於零。

//MessageBox.Show("請輸入大於0的整數");: 如果輸入無效，則顯示一個錯誤訊息對話框。

//return;: 如果輸入無效，則提前結束事件處理函數。

//Triangle triangle = new Triangle(side1, side2, side3);: 創建Triangle類的一個實例，使用輸入的邊長。

//triangles.Add(triangle);: 將新的三角形實例添加到triangles列表中。

//if (triangle.IsTriangle): 檢查剛剛創建的三角形是否是有效的。

//lblResult.Background = Brushes.Green;: 設置結果標籤(lblResult)的背景色為綠色。

//lblResult.Content = $"邊長 {triangle.Side1}, {triangle.Side2}, {triangle.Side3} 可以形成三角形。";: 設置結果標籤的內容，顯示三角形的邊長信息。

//else: 如果三角形無效，則執行以下代碼。

//lblResult.Background = Brushes.Red;: 設置結果標籤的背景色為紅色。

//lblResult.Content = $"邊長 {triangle.Side1}, {triangle.Side2}, {triangle.Side3} 不可以形成三角形。";: 設置結果標籤的內容，顯示三角形的邊長信息。

//UpdateResultLabel();: 調用UpdateResultLabel函數，用於更新結果標籤中的文本。

//private List<Triangle> triangles = new List<Triangle>();: 宣告一個泛型列表triangles，用於存儲已檢查的三角形。

//private void UpdateResultLabel(): 定義一個私有函數UpdateResultLabel，用於更新結果標籤中的文本。

//txtResultLog.Text = "";: 清空結果日誌文本框(txtResultLog)的內容。

//foreach (Triangle triangle in triangles): 遍歷triangles列表中的每個三角形。

//string resultMessage = $"邊長 {triangle.Side1}, {triangle.Side2}, {triangle.Side3} ";: 創建一個包含三角形邊長信息的字串。

//if (triangle.IsTriangle): 檢查當前三角形是否有效。

//resultMessage += "可以形成三角形";: 如果有效，將結果信息中添加"可以形成三角形"的文字。

//else: 如果無效，則執行以下代碼。

//resultMessage += "不可以形成三角形";: 如果無效，將結果信息中添加"不可以形成三角形"的文字。

//txtResultLog.Text += resultMessage + Environment.NewLine;: 向結果日誌文本框中添加當前三角形的結果信息，並換行。

//public class Triangle: 定義一個名為Triangle的公共類別。

//public double Side1 { get; private set; }: 定義Side1屬性，用於存儲三角形的第一邊長。

//public double Side2 { get; private set; }: 定義Side2屬性，用於存儲三角形的第二邊長。

//public double Side3 { get; private set; }: 定義Side3屬性，用於存儲三角形的第三邊長。

//public bool IsTriangle { get; private set; }: 定義IsTriangle屬性，用於表示是否為有效的三角形。

//public Triangle(double side1, double side2, double side3): Triangle類的建構函數，接受三個邊長作為參數，並初始化相關屬性。

//private bool IsTrianglePossible(double a, double b, double c): IsTrianglePossible是一個私有方法，用於檢查給定的三個邊長是否可以形成三角形。它使用三角形不等式來進行檢查。如果可以形成三角形，則返回true，否則返回false。




