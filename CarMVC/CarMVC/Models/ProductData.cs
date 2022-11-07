using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarMVC.Models
{
    public class ProductData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

    }
}