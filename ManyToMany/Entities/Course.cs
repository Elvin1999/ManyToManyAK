using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManyToMany.Entities
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CourseName { get; set; }
        [Required]
        public string Address { get; set; }

        public virtual ICollection<Student> Students { get; set; }
        public Course()
        {
            Students = new List<Student>();
        }
    }
}
