using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymGenZ.PModels
{
    internal class MSchedule
    {
        public int Id { get; set; }
        public int trainerId { get; set; }
        public int  customerId { get; set; }
        public string date { get; set; }
        public string shiftCode { get; set; }
        public int idTrainerService { get; set; }
        public string dateStart { get; set;}
        public string dateEnd { get; set;}
    }
}
