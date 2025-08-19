using ProductMonitor.Models;
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

namespace ProductMonitor.UserControls
{
    /// <summary>
    /// ReaderUC.xaml 的交互逻辑
    /// </summary>
    public partial class ReaderUC : UserControl
    {
        public ReaderUC()
        {
            InitializeComponent();
            SizeChanged+=OnSizeChanged;//Alt+ENTER生成方法
        }
        /// <summary>
        /// 窗体大小改变，重绘控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            Drag();
        }

        /// <summary>
        /// 数据源。支持数据绑定 依赖属性
        /// </summary>
        public List<ReaderModel> ItemsSource
        {
            get { return (List<ReaderModel>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(List<ReaderModel>), typeof(ReaderUC), new PropertyMetadata(0));

        /// <summary>
        /// 画图方法
        /// </summary>
        public void Drag()
        {
            if (ItemsSource!=null||ItemsSource.Count==0)
            {
                return;
            }
            //清楚之前画的
            mainCanvas.Children.Clear();
            P1.Points.Clear();
            P2.Points.Clear();
            P3.Points.Clear();
            P4.Points.Clear();
            P5.Points.Clear();
            //调整大小，随界面改变而改变（正多边形）
            double size = Math.Min(RenderSize.Width, RenderSize.Height);//渲染器最小值
            LayGrid.Height = size;
            LayGrid.Width = size;
            //半径
            double raduis = size/2;

            //多边形边跨度
            double step = 360.0/ItemsSource.Count;//一个边对应角度
            for (int i = 0; i<ItemsSource.Count; i++)
            {
                double x = (raduis-20)*Math.Cos((step*i-90)*Math.PI/180);
                double y= (raduis-20)*Math.Sin((step*i-90)*Math.PI/180);
                P1.Points.Add(new Point(raduis+x,raduis+y));
                P2.Points.Add(new Point(raduis+x*0.75, raduis+y*0.75));
                P3.Points.Add(new Point(raduis+x*0.5, raduis+y*0.5));
                P4.Points.Add(new Point(raduis+x*0.25, raduis+y*0.25));
                ///数据多边形
                P5.Points.Add(new Point(raduis+x*ItemsSource[i].Value*0.01,raduis+y*ItemsSource[i].Value*0.01));

                //文字处理
                TextBlock txt = new TextBlock();
                txt.Width=60;
                txt.FontSize = 10;
                txt.TextAlignment=TextAlignment.Center;
                txt.Text=ItemsSource[i].ItemName;
                txt.Foreground=new SolidColorBrush(Color.FromArgb(100,255, 255, 255));
                txt.SetValue(Canvas.LeftProperty, raduis+(raduis-10)*Math.Cos((step*i-90)*Math.PI/180)-20);//文字离左边的间距
                txt.SetValue(Canvas.TopProperty, raduis+(raduis-10)*Math.Sin((step*i-90)*Math.PI/180)-7);//文字离左边的间距

                mainCanvas.Children.Add(txt);
            }
        }
    }
}
