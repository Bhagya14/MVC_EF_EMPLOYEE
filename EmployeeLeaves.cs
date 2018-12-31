using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_EF_employee.Models
{
    [Table("tbl_employeeleaves")]
    public class EmployeeLeaves
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Leaveid { get; set; }

        [Required(ErrorMessage = "*")]
        public int employeeid { get; set; }
        [Required(ErrorMessage = "*")]
        public string leavetype { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime leaveapplydate { get; set; }
        [Required(ErrorMessage = "*")]
        public DateTime leavestartdate { get; set; }
        [Required(ErrorMessage = "*")]
        public int noofdays { get; set; }

        [ForeignKey("employeeid")]
        public EmployeeModel employee { get; set; }
    }
}