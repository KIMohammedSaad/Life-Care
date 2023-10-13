using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonateMedicine.Models
{
    public class Donation
    {
        public int Id { get; set; }
        public string MedicineCategory { get; set; }
        public string MedicineName { get; set; }
        public int DonationQuantity { get; set; }
        public string DonorName { get; set; }
        public string PickupAddress { get; set; }
        public DateTime DonatedDate { get; set; }
    }
}
