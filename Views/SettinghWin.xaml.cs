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
using System.Windows.Shapes;

namespace ProductMonitor.Views
{
    /// <summary>
    /// SettinghWin.xaml 的交互逻辑
    /// </summary>
    public partial class SettinghWin : Window
    {
        public SettinghWin()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 定位到配置页面相应位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            //程序集（授权）  路径  #为片段
            frame.Navigate(new Uri("pack://application:,,,/ProductMonitor;component/Views/SettingPage.xaml#"+(sender as RadioButton)?.Tag.ToString(), UriKind.RelativeOrAbsolute));

            ////程序集（授权）  路径  同一程序集时不用授权
            //frame.Navigate(new Uri("pack://application:,,,/Views/SettingPage.xaml", UriKind.RelativeOrAbsolute));


        }
    }
}
