using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymGenZ.PModels
{
    internal class MPaymentPackage
    {
        public int id { get; set; }
        public int customerID { get; set; }
        public string paymentDate { get; set; }
        public string paymentMethod { get; set; }
        public string serviceID { get; set; }
        public string packageID { get; set; }
        public int amount { get; set; }

    }
}
