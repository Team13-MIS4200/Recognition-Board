using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Recognition_Board.Models
{
    public class Recognitions
    {
        [Key]
        public int recognitionID { get; set; }

        //This is to get the logged in employee as the one who is recognizing another coworker
        [Display(Name = "ID of Person giving the recognition")]
        public Guid recognizer { get; set; }
        public virtual EmployeeDetails EmployeeRecognizing { get; set; }


        // Employee being recognized for their core values
        [Display(Name = "ID of Person receiving the recognition")]
        public Guid employeeID { get; set; }
        public Guid Recognized { get; set; }
        public virtual EmployeeDetails EmployeeRecognized { get; set; }


        //Core Values ddl
        [Display(Name = "Core value recognized")]
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





        public string Description { get; set; }

        [Display(Name = "Date recognition given")]
        public DateTime recognizationDate { get; set; }




    }
}