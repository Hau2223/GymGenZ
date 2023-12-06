using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymGenZ.PModels
{
    internal class MProduct
    {
        public int id { get; set; }
        public string nameProduct { get; set; }
        public int count {  get; set; }
        public int price { get; set; }
        public int idCateProduct { get; set; }
        public string image { get; set; }

        public string nameCate {  get; set; }
    }
}
