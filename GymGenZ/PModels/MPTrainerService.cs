using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymGenZ.PModels
{
    internal class MPTrainerService
    {
        public int id { get; set; }
        public string name { get; set; }
        public int time {  get; set; }
        public int price { get; set; }

        public MPTrainerService(int _id, string _name, int _time, int _price )
        {
            id = _id;
            name = _name;
            time = _time;
            price = _price;
        }

    }
}
