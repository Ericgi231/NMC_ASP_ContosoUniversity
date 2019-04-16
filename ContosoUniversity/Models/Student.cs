using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    [Table("StudentInfo")]
    public class Student
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Please enter the student's last name.")]
        [StringLength(30, ErrorMessage = "The last name must be less than {1} characters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [StringLength(20, ErrorMessage = "The first name must be less than {1} characters")]
        [Column("FirstName")]
        [Display(Name = "First Name")]
        public string FirstMidName { get; set; }

        [RegularExpression(@"^\(?([0-9]{3})\)?[-.●]?([0-9]{3})[-.●]?([0-9]{4})$", ErrorMessage = "The PhoneNumber field is not a valid phone number")]
        public string Phone { get; set; }

        [Column("DateEnrolled")]
        [Display(Name = "Date Enrolled")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EnrollmentDate { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstMidName;
            }
        }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}