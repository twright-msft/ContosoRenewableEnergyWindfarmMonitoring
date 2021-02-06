using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoRenewableEnergyWindfarmMonitoring.Models
{
    public class Windmill
    {
        public int ID { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public DateTime DateOfLastMaintenance { get; set; }

        public ICollection<Blade> Blades { get; set; }
        public ICollection<Turbine> Turbines { get; set; }
        public ICollection<Platform> Platforms { get; set; }
    }
}