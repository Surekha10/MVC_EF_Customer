using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_EF6_Example.Models
{
    [Table("tbl_employees")]
    public class EmployeeModel
    {
        [Key]
        public string EmployeeEmailID { get; set; }
        [Required(ErrorMessage ="*")]
        public string EmployeeName { get; set; }
        [Required(ErrorMessage ="*")]
        public int EmployeeSalary { get; set; }
    }
}