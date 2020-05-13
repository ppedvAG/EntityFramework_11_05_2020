using Microsoft.EntityFrameworkCore;
using ppedv.LVS_Enterprise.Logic;
using ppedv.LVS_Enterprise.Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

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


            //DI per Hand
            //  var filePath = @"C:\Users\rulan\source\repos\ppedvAG\EntityFramework_11_05_2020\ppedv.LVS_Enterprise\ppedv.LVS_Enterprise.Data.EFCore\bin\Debug\netcoreapp2.0\ppedv.LVS_Enterprise.Data.EFCore.dll";
            //  var ass = Assembly.LoadFrom(filePath);
            //  var repo = ass.GetTypes().FirstOrDefault(x => x.Name.Contains("Repository"));
            //var repo = ass.GetTypes().FirstOrDefault(x => x.IsAssignableFrom(typeof(IRepository)));
            //var inst = Activator.CreateInstance(repo);
            //core = new LVSCore(inst as IRepository);
        }

        
        LVSCore core = null;
        ObservableCollection<Artikel> artikeListe = null;

        private void Laden(object sender, RoutedEventArgs e)
        {
            core = new LVSCore(new Data.EFCore.EfCoreRepository());
            artikeListe = new ObservableCollection<Artikel>(core.Repository.GetAll<Artikel>());
            myGrid.ItemsSource = artikeListe;
        }

        private void Speicher(object sender, RoutedEventArgs e)
        {

            try
            {
                core.Repository.Save();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var msg = MessageBox.Show("Die Daten wurden zwischenzeitlich geändert!\n Ja: Daten in DB überschreiben \n Nein: Daten aus DB laden", "",
                                            MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                if (msg == MessageBoxResult.Yes)
                {
                    //User wins
                    var entry = ex.Entries.Single();
                    entry.OriginalValues.SetValues(entry.GetDatabaseValues());
                    core.Repository.Save();
                }
                else if (msg == MessageBoxResult.No)
                {
                    //DB wins
                    ex.Entries.Single().Reload();
                    Laden(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler:{ex.Message}");
            }

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
