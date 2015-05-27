using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace Webscraper
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

        private void scrapebtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WebClient wc = new WebClient();
                wc.DownloadStringCompleted += wc_DownloadStringCompleted;
                wc.DownloadStringAsync(new Uri("http://leagueoflegends.wikia.com/wiki/League_of_Legends_Wiki"));
            }
            catch (Exception)
            {

                MessageBox.Show("site niet kunnen scrapen");
            }

        }

        private void wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                var scrape = new HtmlAgilityPack.HtmlDocument();
                scrape.LoadHtml(e.Result);
                HtmlNode docnode = scrape.DocumentNode;
                //Let's do it 


                HtmlNode[] divnodes = docnode.Descendants("div").ToArray(); //1 
                for (int i = 0; i < divnodes.Length; i++) //2 
                {
                    if (divnodes[i].Attributes["id"] != null) //3 
                    {
                        if (divnodes[i].Attributes["id"].Value == "roster") //4 
                        {
                            HtmlNode[] anodes = divnodes[i].Descendants("img").ToArray(); //5 
                            /*for (int x = 0; x < divnodes.Length; x++)
                            {
                                
                            }*/
                            foreach (var htmlNode in anodes)  //6 
                            {
                                string res = htmlNode.Attributes["src"].Value; //8 
                                listboxResults.Items.Add(res); //9 
                            }
                        }
                    }
                }

                /*HtmlNode imgnode = (from p in docnode.Descendants("div")
                                    where p.Attributes["id"] != null && p.Attributes["id"].Value == "comic"
                                    select p).FirstOrDefault(); */


                //Done 
                MessageBox.Show("Done");
            }
        }

        private void listboxResults_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string imgurl = listboxResults.SelectedItem.ToString();
            BitmapImage b = new BitmapImage(new Uri(imgurl));
            scrapeimg.Source = b;
            //listboxResults.SelectedItem = scrapeimg.Source;
        }
    }
}
