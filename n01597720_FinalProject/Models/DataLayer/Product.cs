using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace n01597720_FinalProject.Models.DataLayer
{
    public class Product
    {
        public int ProductID { get; set; }
        
        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public int ProductQty { get; set; }
    }
}
