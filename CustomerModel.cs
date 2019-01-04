using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_EF6_Example.Models
{
    [Table("tbl_customers")]
    public class CustomerModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerID { get; set; }
        [Required(ErrorMessage = "*")]
        [StringLength(100)]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "*")]
        [StringLength(100)]
        public string CustomerPassword { get; set; }
        [Required(ErrorMessage = "*")]
        [StringLength(100)]
        public string CustomerCity { get; set; }
        [Required(ErrorMessage = "*")]
        [StringLength(100)]
        [Column("CustomerEmailAddress")]
        public string CustomerEmailID { get; set; }
        [NotMapped]
        public string CustomerDetails { get; set; }
        public List<OrderModel> Orders { get; set; }
    }
}