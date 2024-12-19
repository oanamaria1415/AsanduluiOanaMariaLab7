
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;




using SQLite;

namespace AsanduluiOanaMariaLab7.Models
{
    public class Shop
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string ShopName { get; set; }

        public string Adress { get; set; }

        [Ignore] // Ignorăm lista pentru SQLite
        public List<ShopList> ShopLists { get; set; }

        public string ShopDetails
        {
            get { return $"{ShopName} {Adress}"; }
        }
    }
}

