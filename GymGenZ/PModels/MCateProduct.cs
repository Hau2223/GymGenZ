using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace GymGenZ.PModels
{
    internal class MCateProduct
    {
        public int id { get; set; }
        public string name { get; set; }

        public MCateProduct(int _id, string _name)
        {
            id = _id;
            name = _name;
        }
    }
}
