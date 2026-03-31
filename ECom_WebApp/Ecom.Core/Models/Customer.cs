using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceConsoleApp.Models
{

        public class Customer
        {
            public int CustomerID { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public long Phone_number { get; set; }
            public string Address { get; set; }
        }
}

