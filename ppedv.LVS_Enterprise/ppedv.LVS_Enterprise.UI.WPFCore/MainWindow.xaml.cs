using ppedv.LVS_Enterprise.Logic;
using ppedv.LVS_Enterprise.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        ObservableCollection<Artikel> artikeListe = null;

        private void Laden(object sender, RoutedEventArgs e)
        {
            artikeListe = new ObservableCollection<Artikel>(core.Repository.GetAll<Artikel>());
            myGrid.ItemsSource = artikeListe;
        }

        private void Speicher(object sender, RoutedEventArgs e)
        {
            core.Repository.Save();
        }

        private void Neu(object sender, RoutedEventArgs e)
        {
            var a = new Artikel() { Bezeichnung = "NEU" };
            artikeListe.Add(a);
            core.Repository.Add(a);
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            if (myGrid.SelectedItem is Artikel a)
            {
                if (MessageBox.Show($"Soll der Artikel {a.Bezeichnung} wirklich gelöscht werden?", "", MessageBoxButton.YesNo, MessageBoxImage.Warning)
                    == MessageBoxResult.Yes)
                {
                    core.Repository.Delete(a);
                    artikeListe.Remove(a);
                }
            }
        }
    }
}
