using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace AircraftDomain.Models
{
    public class Aircraft
    {
        public long Id { get; set; }
        public string? ModelName { get; set; }
        public long SerialNumber { get; set; }
        public long RegistrationNumber { get; set; }
        public string? RegistrationStatus { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
