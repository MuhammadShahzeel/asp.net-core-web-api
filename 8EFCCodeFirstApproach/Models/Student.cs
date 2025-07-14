using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCCodeFirstApproach.Models
{
    public class Student
    {
        [Key] //to make id primary key
        public int Id { get; set; }


        [Column("StudentName",TypeName ="varchar(100)")] //to display name in db
        public string Name { get; set; }
        [Column("StudentGender", TypeName = "varchar(20)")] //to display name in db
        public string Gender { get; set; }
        public int Age { get; set; }
        public int Standard { get; set; } 

    }
}
