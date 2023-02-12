using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ManyToMany.Entities
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public Student()
        {
            Courses=new List<Course>();
        }

    }
}
