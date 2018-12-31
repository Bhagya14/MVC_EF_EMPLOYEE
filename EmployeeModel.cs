using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MVC_EF_employee.Models
{
    [Table("tbl_employees")]
    public class EmployeeModel
    {
       
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int employeeid { get; set; }
            [Required(ErrorMessage = "*")]
            [StringLength(100)]
            public string employeename { get; set; }

            [Required(ErrorMessage = "*")]
            [StringLength(100)]
            public string employeecity { get; set; }

            [Required(ErrorMessage = "*")]
            public int employeesalary { get; set; }

            [Required(ErrorMessage = "*")]
            [StringLength(100)]
            public string employeepassword { get; set; }

            [Required(ErrorMessage = "*")]
            [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
            public DateTime employeedoj { get; set; }

             public List<EmployeeLeaves> Leaves { get; set; }

    }
    }
