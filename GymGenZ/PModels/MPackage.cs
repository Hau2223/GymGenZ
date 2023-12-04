using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymGenZ.PModels
{
    public class MPackage
    {
        public int id { get; set; }
        public string name { get; set; }
        public int time { get; set; }

        public MPackage(int _id, string _name, int _time)
        {
            id = _id;
            name = _name;
            time = _time;
        }
    }
}

