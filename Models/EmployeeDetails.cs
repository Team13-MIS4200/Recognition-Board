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
        [Required(ErrorMessage = "Please include your @centricconsulting.com address.")]
        [EmailAddress]
        [Display(Name = "Employee Email")]
        public string email { get; set; }

        [Required(ErrorMessage = "Please include your first name.")]
        [Display(Name = "First Name")]
        public string firstName { get; set; }

        [Required(ErrorMessage = "Please include your last name.")]
        [Display(Name = "Last Name")]
        public string lastName { get; set; }

        //[Required(ErrorMessage = "Please include your office phone number.")]
        [Display(Name = "Office Phone")]
        [Phone]
        public string phoneNumber { get; set; }


        // location dd
        [Required]
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
            [Display(Name ="St. Louis")]
            StLouis,
            Tampa
        }

        // department dd
        [Required]
        [Display(Name = "Department")]
        public Department department{ get; set; }
        public enum Department
        {
            Accounting,
            [Display(Name = "Business Consulting")]
            BusinessConsulting,
            [Display(Name = "Digital Consulting")]
            DigitalConsulting,
            Finance,
            [Display(Name = "Human Resources")]
            HumanResources,
            [Display(Name = "Technology Services")]
            TechnologyServices
        }


        // Position Details
        //[Required(ErrorMessage = "Please include your current position title.")]
        [Display(Name = "Current Position")]
        public string position { get; set; }

        //[Required(ErrorMessage = "Please include your current manager.")]
        [Display(Name = "Manager")]
        public string manager { get; set; }

        [Required(ErrorMessage = "Please include your initial hire date.")]
        [Display(Name = "Hire Date")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime hireDate { get; set; }


        // Link to recognitions table
        public ICollection<Recognitions> Recognitions { get; set; }
    }
}
