using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_EF6_Example.Models
{
    public class ProductModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public DateTime ProductAddedDate { get; set; }
    }
}