﻿using ProductMonitor.OpCommand;
using ProductMonitor.UserControls;
using ProductMonitor.ViewModels;
using ProductMonitor.Views;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProductMonitor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowVM mainWindowVM = new MainWindowVM();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext=mainWindowVM;
        }
        /// <summary>
        /// 显示车间详情页
        /// </summary>
        private void ShowDetailUC()
        {
            WorShopDetailUC worShopDetailUC = new WorShopDetailUC();
            mainWindowVM.MonitorUC= worShopDetailUC;

            #region 动画效果
            //上下，左右位移，时间
            ThicknessAnimation thicknessAnimation = new ThicknessAnimation(new Thickness(0,50,0,-50),new Thickness(0,0,0,0),new TimeSpan(0,0,0,0,500));
            //透明度,时间
            DoubleAnimation doubleAnimation = new DoubleAnimation(0, 1, new TimeSpan(0, 0, 0, 0, 500));

            Storyboard.SetTarget(thicknessAnimation, worShopDetailUC);
            Storyboard.SetTarget(doubleAnimation, worShopDetailUC);

            Storyboard.SetTargetProperty(thicknessAnimation, new PropertyPath("Margin"));
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("Opacity"));

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(thicknessAnimation);
            storyboard.Children.Add(doubleAnimation);
            storyboard.Begin();
            #endregion
        }
        /// <summary>
        /// 返回监控页
        /// </summary>
        private void GoBack()
        {
            MointorUC monitorUC = new MointorUC();

            mainWindowVM.MonitorUC = monitorUC;
        }
        /// <summary>
        /// 展示车间详情页
        /// </summary>
        public Command ShowDetailCmm
        {
            get
            {
                return new Command(ShowDetailUC);
            }
        }
        /// <summary>
        /// 返回监控也命令
        /// </summary>
        public Command GoBackCmm
        {
            get
            {
                return new Command(GoBack);
            }
        }
        /// <summary>
        /// 最小化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMin(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        /// <summary>
        /// 最大化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMax(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Maximized;
        }
        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClose(object sender, RoutedEventArgs e)
        {
            //this.Close();//关闭界面
            Environment.Exit(0);//关闭程序
        }
        #region 弹出配置窗口
        /// <summary>
        /// 显示配置窗口
        /// </summary>
        private void ShowSettingWin()
        {
            //创建父子关系

            SettinghWin settingWin = new SettinghWin() { Owner=this };
            settingWin.ShowDialog();
        }
        /// <summary>
        /// 创建弹出配置窗口命令
        /// </summary>
        public Command ShowSettingCmm
        {
            get
            {
                return new Command(ShowSettingWin);
            }
        }
        #endregion

    }
}