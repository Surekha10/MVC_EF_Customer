using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_EF6_Example.Models
{
    [Table("tbl_orders")]
    public class OrderModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderID { get; set; }
        [Required(ErrorMessage ="*")]
        public int CustomerID { get; set; }
        [Required(ErrorMessage ="*")]
        public string ItemName { get; set; }
        [Required(ErrorMessage ="*")]
        public int ItemPrice { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime OrderDate { get; set; }
        [ForeignKey("CustomerID")]
        public CustomerModel Customer { get; set; }
        [Required(ErrorMessage ="*")]
        public string OrderCity { get; set; }
    }
}