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

        public List<RaderModel> ItemSource
        {
            get { return (List<RaderModel>)GetValue(ItemSourceProperty); }
            set { SetValue(ItemSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemSourceProperty =
            DependencyProperty.Register("ItemSource", typeof(int), typeof(List<RaderModel>), new PropertyMetadata(0));
        /// <summary>
        /// 画图方法
        /// </summary>
        public void Drag()
        {
            if (ItemSource!=null||ItemSource.Count==0)
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
            double step = 360.0/ItemSource.Count;//一个边对应角度
            for (int i = 0; i<ItemSource.Count; i++)
            {
                P1.Points.Add(new Point(raduis+(raduis-20)*Math.Cos((step*i-90)*Math.PI/180),raduis+(raduis-20)*Math.Sin((step*i-90)*Math.PI/180)));
                P2.Points.Add(new Point(raduis+(raduis-20)*Math.Cos((step*i-90)*Math.PI/180)*0.75, raduis+(raduis-20)*Math.Sin((step*i-90)*Math.PI/180)*0.75));
                P3.Points.Add(new Point(raduis+(raduis-20)*Math.Cos((step*i-90)*Math.PI/180)*0.5, raduis+(raduis-20)*Math.Sin((step*i-90)*Math.PI/180)*0.5));
                P4.Points.Add(new Point(raduis+(raduis-20)*Math.Cos((step*i-90)*Math.PI/180)*0.25, raduis+(raduis-20)*Math.Sin((step*i-90)*Math.PI/180)*0.25));
            }
        }
    }
}
