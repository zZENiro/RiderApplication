using System;
using System.Collections.Generic;
using System.Text;

namespace RiderApplication.scenarios.ScenariosModels
{
    public class Organization
    {
        public int id { get; set; }
        public string name { get; set; }
    }


    public class RiderAccount
    {
        public string ID { get; set; }

        public string Name { get; set; }

        public Organization Organization { get; set; }

        public string CarNumber { get; set; }

        public string CarModel { get; set; }

        public string HashCode { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }
    }
}
