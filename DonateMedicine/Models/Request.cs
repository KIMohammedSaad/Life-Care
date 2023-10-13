using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonateMedicine.Models
{
    public class Request
    {

        public int Id { get; set; }
        public string MedicineCategory { get; set; }
        public string MedicineName { get; set; }
        public int RequestedQuatity { get; set; }
        public string RequestorName { get; set; }
        public string  DeliveredAddress { get; set; }
        public DateTime RequestedDate { get; set; }
    }
}
