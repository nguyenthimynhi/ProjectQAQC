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

namespace QAQCDesktopApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(Object DataContext)
        {
            InitializeComponent();
            this.DataContext = DataContext;
            this.StateChanged += new EventHandler(MainWindow_StateChanged);
        }
        private void MainWindow_StateChanged(object sender, EventArgs e)
        {
            if (this.WindowState == WindowState.Minimized)
            {
                return;
            }
            if (this.WindowState == WindowState.Normal)
            {
                this.Width = SystemParameters.PrimaryScreenWidth * 0.22;
                this.Height = SystemParameters.PrimaryScreenHeight * 0.24;
                btnLogin.UpdateMinimizedUI();
                btnSetting.UpdateMinimizedUI();
                btnQA.UpdateMinimizedUI();
                btnQC.UpdateMinimizedUI();
                btnHelp.UpdateMinimizedUI();
                btnsupervise.UpdateMinimizedUI();
            }
            else if (this.WindowState == WindowState.Maximized)
            {
                btnLogin.UpdateNormalUI();
                btnQA.UpdateNormalUI();
                btnQC.UpdateNormalUI();
                btnSetting.UpdateNormalUI();
                btnHelp.UpdateNormalUI();
                btnsupervise.UpdateNormalUI();
            }
        }
    }
}
