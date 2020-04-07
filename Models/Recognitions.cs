using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Recognition_Board.Models
{
    public class Recognitions
    {
        [Key]
        public int recognitionID { get; set; }

        [Display(Name = "From")]
        public Guid From { get; set; }
        public virtual EmployeeDetails EmployeeRecognizer { get; set; }


        // Employee being recognized for their core values

        [Display(Name = "Employee Recognized")]
        public Guid employeeID { get; set; }
        public virtual EmployeeDetails EmployeeRecognized { get; set; }


        //Core Values ddl
        [Display(Name = "Core Value")]
        public CoreValue award { get; set; }
        public enum CoreValue
        {
            Excellence = 1,
            Integrity = 2,
            Stewardship = 3,
            Culture = 4,
            Passion = 5,
            Innovate = 6,
            Lifestyle = 7
        }

        [Display(Name = "Description")]
        public string description { get; set; }

        [Display(Name = "Recognition Data")]
        public DateTime recognizationDate { get; set; }




    }
}