using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Леготкин.Classes
{
    public class Teatr
    {
        public int id { get; set; }
        public string name { get; set; }
        public int countZal { get; set; }
        public int countMest { get; set; }
        public Teatr() { }
        public Teatr(int id, string name, int countZal, int countMest)
        {
            this.id = id;
            this.name = name;
            this.countZal = countZal;
            this.countMest = countMest;
        }
    }
}
