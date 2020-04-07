using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Recognition_Board.Models
{
    public class EmployeeDetails
    {
        [Key]
        [Required]
        public Guid employeeID { get; set; }

        [Display(Name = "Full Name")]
        public string fullName
        {
            get { return lastName + ", " + firstName; }
        }

        // Personal Info
        [EmailAddress]
        [Display(Name = "Employee Email")]
        public string email { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string firstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string lastName { get; set; }

        [Display(Name = "Primary Phone")]
        [Phone]
        public string phoneNumber { get; set; }


        // location dd
        [Display(Name = "Office Location")]
        public OfficeLocation officeLocation { get; set; }
        public enum OfficeLocation
        {
            Boston,
            Charlotte,
            Chicago,
            Cincinnati,
            Cleveland,
            Columbus,
            India,
            Indianapolis,
            Louisville,
            Miami,
            Seattle,
            StLouis,
            Tampa
        }

        // department dd
        [Display(Name = "Department")]
        public Department department{ get; set; }
        public enum Department
        {
            Accounting,
            BusinessConsulting,
            DigitalConsulting,
            Finance,
            HumanResources,
            TechnologyServices
        }


        // Position Details
        [Display(Name = "Current position")]
        public string position { get; set; }

        [Display(Name = "Manager")]
        public string manager { get; set; }

        [Display(Name = "Hire Date")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime hireDate { get; set; }


        // Link to recognitions table
        public ICollection<Recognitions> Recognitions { get; set; }
    }
}