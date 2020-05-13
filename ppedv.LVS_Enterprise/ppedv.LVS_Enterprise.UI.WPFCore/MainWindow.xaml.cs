using ppedv.LVS_Enterprise.Logic;
using ppedv.LVS_Enterprise.Model;
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

namespace ppedv.LVS_Enterprise.UI.WPFCore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        LVSCore core = new LVSCore();

        private void Laden(object sender, RoutedEventArgs e)
        {
            myGrid.ItemsSource = core.Repository.GetAll<Artikel>();
        }
    }
}
