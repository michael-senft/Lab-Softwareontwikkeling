using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opendata
{

    public class RootObject
    {
        public Openwifidata[] openwifidata { get; set; }
    }
    public class Openwifidata
    {
        public string id { get; set; }
        public string objectid { get; set; }
        public string point_lat { get; set; }
        public string point_lng { get; set; }
        public string id_wifi { get; set; }
        public string klant { get; set; }
        public string locatie { get; set; }
        public string straat { get; set; }
        public string huisnr { get; set; }
        public string postcode { get; set; }
        public string gemeente { get; set; }
        public string huidige_dekking { get; set; }
        public string @private { get; set; }
        public string private_mobile { get; set; }
        public string wifi_balie { get; set; }
        public string lokale_wifi { get; set; }
        public string museumtracker { get; set; }
        public object wireless_scholen { get; set; }
        public object zb_alarm { get; set; }
        public object bewoner { get; set; }
        public string stad_gratis_wifi { get; set; }
        public string stad_gratis_wifi_citymesh { get; set; }
        public string aanvraag_uitbreiding { get; set; }
        public string geraamd_budget { get; set; }
        public string timing { get; set; }
        public object opmerking { get; set; }
        public string publ { get; set; }
    }

    
}
