using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Леготкин.Classes
{
    public class Movie
    {
        public int id { get; set; }
        public int idTeatr { get; set; }
        public string movie { get; set; }
        public DateTime time { get; set; }
        public int price { get; set; }
    }
}
