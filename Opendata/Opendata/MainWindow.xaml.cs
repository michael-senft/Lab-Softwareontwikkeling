using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using MahApps.Metro.Controls;

namespace Opendata
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public ObservableCollection<Openwifidata> allopenwifidata;
        public RootObject wifi;

        public MainWindow()
        {
            InitializeComponent();
            allopenwifidata = new ObservableCollection<Openwifidata>() { };
        }

        private void idlistbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            infogrid.DataContext = idlistbox.SelectedItem;
            labelgrid.DataContext = idlistbox.SelectedItem;
        }

        private void infogrid_Loaded(object sender, RoutedEventArgs e)
        {
            string json = File.ReadAllText(@"c:\openwifiJSON.json");
            wifi = JsonConvert.DeserializeObject<RootObject>(json);
            idlistbox.ItemsSource = wifi.openwifidata;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (zoekbox.Text == "")
            {
                MessageBox.Show("geef een juiste zoekopdracht in, zoeken op gemeente");
            }
            else
            {
                try
                {
                    List<Openwifidata> catlist = (from wifilijst in wifi.openwifidata
                                                  where wifilijst.gemeente == zoekbox.Text
                                                  select wifilijst).ToList();
                    idlistbox.ItemsSource = catlist;
                    MessageBox.Show("Er zijn " + catlist.Count() + " overeenkomsten gevonden.");
                }
                catch (Exception)
                {
                    
                    MessageBox.Show("Geen overeenkomst gevonden");
                } 
                
            }
            
            
            
            
        }

        private void backbtn_Click(object sender, RoutedEventArgs e)
        {
            idlistbox.ItemsSource = wifi.openwifidata;
            zoekbox.Text = "";
            idlistbox.SelectedIndex = 0;
        }

        
    }
}
