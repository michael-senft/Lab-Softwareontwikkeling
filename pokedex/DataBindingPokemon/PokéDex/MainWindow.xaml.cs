﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
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
using Newtonsoft.Json;
using MahApps.Metro.Controls;
using System.Drawing;

namespace PokéDex
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public ObservableCollection<Pokemon> allPokemon;

        public Rootobject Pok;

        public MainWindow()
        {
            InitializeComponent();

            allPokemon = new ObservableCollection<Pokemon>() { };
            //NameStat.Visibility = Visibility.Collapsed;
            
        }


        private void BtnGetpokemon_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var res = PokemonDAL.DAL.GetAllPokemon();
                MessageBox.Show("Retrieved " + res.Count + " pokemons");
                //var s = PokemonDAL.DAL.GetPokemon(649);
                //MessageBox.Show("Retrieved pokemon " + s.name);
                ListPokemons.ItemsSource = res;
                /*for (int i = 1; i < 649; i++)
                {
                
                    var temppok = PokemonDAL.DAL.GetPokemon(i);
                    ListPokemons.Items.Add(temppok.name);
                }*/
            }
            catch (Exception)
            {

                MessageBox.Show("Kon pokemons niet downloaden");
            }
            
        }

        private void ListPokemons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            InfoGrid.DataContext = ListPokemons.SelectedItem;
            
            
            Pokemon pokemon = ListPokemons.SelectedItem as Pokemon;
            {
                
                //labelName.Text = pokemon.name;
                //BitmapImage bm = new BitmapImage(new Uri(pokemon.img, UriKind.RelativeOrAbsolute));
                //bm.MakeTransparent();
                //MainPokImage.Source = bm;
                //NameStat.Visibility = Visibility.Visible;
                //NameStat.Content = pokemon.name;
                //TypeStat.Content = pokemon.type.ToString();
            }
        }

        

        private void linqbtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Pokemon> linqlist = (from pokelijst in PokemonDAL.DAL.GetAllPokemon()
                                          where pokelijst.id == linqbox.Text
                                          select pokelijst).ToList();
                if (linqlist.Count() == 0)
                {
                    linqlist = (from pokelijst in PokemonDAL.DAL.GetAllPokemon()
                                where pokelijst.name == linqbox.Text
                                select pokelijst).ToList();
                    if (linqlist.Count() == 0)
                    {
                        MessageBox.Show("pokemon niet gevonden");
                    }
                    
                }
                ListPokemons.ItemsSource = linqlist;
            }
            catch (Exception)
            {

                MessageBox.Show("pokemon niet gevonden");
            }
        }

        private void terugbtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var res = PokemonDAL.DAL.GetAllPokemon();
                ListPokemons.ItemsSource = res;
            }
            catch (Exception)
            {
                
                throw;
            }
        }









    }

    public class StringToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string format = value as string;
            format = format.Replace(",", ".");
            if (!string.IsNullOrEmpty(format))
            {
                int snelheid = System.Convert.ToInt16(format);
                if (snelheid > 80)
                {
                    parameter = "https://cdnd.icons8.com/wp-content/uploads/2014/01/running_rabbit-128.png";
                }
                else if (snelheid <= 80)
                {
                    parameter = "https://cdnd.icons8.com/wp-content/uploads/2014/01/turtle-128.png";
                }
                return parameter;
            }
            else
            {
                return parameter.ToString();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }

}



