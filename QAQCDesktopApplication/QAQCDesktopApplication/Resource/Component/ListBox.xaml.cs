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

namespace QAQCDesktopApplication.Resource.Component
{
    /// <summary>
    /// Interaction logic for ListBox.xaml
    /// </summary>
    public partial class ListBox : UserControl
    {
        public ListBox()
        {
            InitializeComponent();
        }
        public static readonly RoutedEvent ClickEvent =
        EventManager.RegisterRoutedEvent(nameof(MouseDoubleClick), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ListBox));

        public event RoutedEventHandler MouseDoubleClick
        {
            add { AddHandler(ClickEvent, value); }
            remove { RemoveHandler(ClickEvent, value); }
        }
        private void OnClick(object sender, RoutedEventArgs e)
        {
            MyListView.IsEnabled = true;
            RaiseEvent(new RoutedEventArgs(ClickEvent));
        }
    }
}
