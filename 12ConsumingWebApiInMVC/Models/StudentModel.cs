﻿using System.ComponentModel.DataAnnotations;

namespace _12ConsumingWebApiInMVC.Models
{
    public class StudentModel
    {
        public int id { get; set; }

        [Required]
        public string studentName { get; set; }

        [Required]
        public string studentGender { get; set; }

        [Required]
        public int age { get; set; }

        [Required]
        public int standard { get; set; }

        [Required]
        public string fatherName { get; set; }
    }
}
