
using System;
// 引入System命名空間，包含了基本的C#類型和函數。

using System.Collections.Generic;
// 引入System.Collections.Generic命名空間，以使用泛型集合類別。

using System.Windows;
// 引入System.Windows命名空間，以使用WPF的視窗和控制元件。

using System.Windows.Media;
// 引入System.Windows.Media命名空間，以使用WPF的繪圖功能。



namespace WpfApp1
// 建立一個名為WpfApp1的命名空間。
{
    public partial class MainWindow : Window
    // 定義一個名為MainWindow的部分類別，繼承自Window類別，表示主應用程式視窗。
    {
        public MainWindow()
        // MainWindow類別的建構函數，用於初始化視窗。
        {
            InitializeComponent();
            // 方法，用於初始化視窗的元件和佈局。
        }

        private void CheckTriangle_Click(object sender, RoutedEventArgs e)
        //定義一個事件處理函數，當"CheckTriangle"按鈕被點擊時執行。
        {
            double side1, side2, side3;
            // 宣告三個double型態的變數side1、side2和side3，用於存儲輸入的三個邊長。


            // 檢查txtSide1.Text, txtSide2.Text, txtSide3.Text是否可以轉換為double型態的數值，
            // 同時確認這些數值是否為正數。如果任一條件不符，整個if條件會返回true。
            // 嘗試將txtSide1.Text轉換為double，結果存儲在side1變量中。
            // 嘗試將txtSide2.Text轉換為double，結果存儲在side2變量中
            // 嘗試將txtSide3.Text轉換為double，結果存儲在side3變量中。
            if (!Double.TryParse(txtSide1.Text, out side1) || !Double.TryParse(txtSide2.Text, out side2) || !Double.TryParse(txtSide3.Text, out side3) || side1 <= 0 || side2 <= 0 || side3 <= 0)
            //檢查輸入的邊長是否為有效的數字，並確保它們大於零。
            {
                MessageBox.Show("請輸入大於0的整數");
                //如果輸入無效，則顯示一個錯誤訊息對話框。
                return;
                // 並則提前結束事件處理函數。
            }

            Triangle triangle = new Triangle(side1, side2, side3);
            // 創建Triangle類的一個實例，使用輸入的邊長。
            triangles.Add(triangle);
            // 將新的三角形實例添加到triangles列表中。
            if (triangle.IsTriangle)
            // 檢查剛剛創建的三角形是否是有效的。

            {
                lblResult.Background = Brushes.Green;
                // 設置結果標籤(lblResult)的背景色為綠色。
                lblResult.Content = $"邊長 {triangle.Side1}, {triangle.Side2}, {triangle.Side3} 可以形成三角形。";
                // 設置結果標籤的內容，顯示三角形的邊長信息。
            }
            else
            // 如果三角形無效，則執行以下代碼。
            {
                lblResult.Background = Brushes.Red;
                // 設置結果標籤的背景色為紅色。

                lblResult.Content = $"邊長 {triangle.Side1}, {triangle.Side2}, {triangle.Side3} 不可以形成三角形。";
                // 設置結果標籤的內容，顯示三角形的邊長信息。

            }

            UpdateResultLabel();
            // 調用UpdateResultLabel函數，用於更新結果標籤中的文本。
        }


        private List<Triangle> triangles = new List<Triangle>();
        // 宣告一個泛型列表triangles，用於存儲已檢查的三角形。

        // 定義一個名為UpdateResultLabel的私有方法，此方法用於更新結果標籤。
        private void UpdateResultLabel()
        {
            // 將txtResultLog（一個文本框）的內容設置為空字串，以清空它。
            txtResultLog.Text = "";

            // 使用foreach迴圈遍歷名為triangles的列表，該列表包含Triangle類型的對象。
            foreach (Triangle triangle in triangles)
            {
                // 初始化一個名為resultMessage的字串變數，並使用字串內插格式將三角形的三個邊長添加到字串中。
                string resultMessage = $"邊長 {triangle.Side1}, {triangle.Side2}, {triangle.Side3} ";

                // 判斷當前三角形（triangle）是否為有效的三角形。
                if (triangle.IsTriangle)
                {
                    // 如果是有效的三角形，則在resultMessage字串的末尾添加 "可以形成三角形"。
                    resultMessage += "可以形成三角形";
                }
                else
                {
                    // 如果不是有效的三角形，則在resultMessage字串的末尾添加 "不可以形成三角形"。
                    resultMessage += "不可以形成三角形";
                }

                // 將帶有結果信息的resultMessage字串添加到txtResultLog文本框的內容中，並在其後添加一個新行字符。
                txtResultLog.Text += resultMessage + Environment.NewLine;
            }
        }



    }

    public class Triangle
    // 定義一個名為Triangle的公共類別。
    {
        public double Side1 { get; private set; }
        // 定義Side1屬性，用於存儲三角形的第一邊長。


        public double Side2 { get; private set; }
        // 定義Side2屬性，用於存儲三角形的第二邊長。

        public double Side3 { get; private set; }
        // 定義Side3屬性，用於存儲三角形的第三邊長。

        public bool IsTriangle { get; private set; }
        // 定義IsTriangle屬性，用於表示是否為有效的三角形。

        public Triangle(double side1, double side2, double side3)
        // Triangle類的建構函數，接受三個邊長作為參數，並初始化相關屬性。
        {
            Side1 = side1;
            // 將Side1函数的參數赋值给side1的属性
            Side2 = side2;
            // 將Side2函数的參數赋值给side2的属性
            Side3 = side3;
            // 將Side3函数的參數赋值给side3的属性
            IsTriangle = IsTrianglePossible(side1, side2, side3);
            // 使用 IsTrianglePossible 的方法来檢查輸入的三個邊長是否可以形成三角形
        }

        private bool IsTrianglePossible(double a, double b, double c)
   // IsTrianglePossible是一個私有方法，用於檢查給定的三個邊長是否可以形成三角形。它使用三角形不等式來進行檢查。如果可以形成三角形，則返回true，否則返回false。
        {
            return (a  +  b > c ) && (a  + c >  b) && (b  + c  >  a);
        }
    }


}




