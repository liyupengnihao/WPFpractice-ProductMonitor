using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// RingUC.xaml 的交互逻辑
    /// </summary>
    public partial class RingUC : UserControl
    {
        public RingUC()
        {
            InitializeComponent();
            SizeChanged += OnSizeChanged;//界面大小改变时触发事件
        }

        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            Drug();
        }

        public double PrecentValue
        {
            get { return (double)GetValue(PrecentValueProperty); }
            set { SetValue(PrecentValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PrecentValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PrecentValueProperty =
            DependencyProperty.Register("PrecentValue", typeof(double), typeof(RingUC));

        /// <summary>
        /// 画圆环方法
        /// </summary>
        private void Drug()
        {
            LayOutGrid.Width=Math.Min(RenderSize.Width,RenderSize.Height);//取渲染器最小值
            double raduis = LayOutGrid.Width / 2;
            double x=raduis+(raduis-3)*Math.Cos((PrecentValue%100*3.6-90)*Math.PI/180);
            double y=raduis+(raduis-3)*Math.Sin((PrecentValue%100*3.6-90)*Math.PI/180);

            int Is50 = PrecentValue<50 ? 0 : 1;
            string pathStr = $"M{raduis+0.01} 3A{raduis-3} {raduis-3} 0 {Is50} 1 {x} {y}";

            var converter=TypeDescriptor.GetConverter(typeof(Geometry));
            Path.Data=(Geometry)converter.ConvertFrom(pathStr);
        }
    }
}
