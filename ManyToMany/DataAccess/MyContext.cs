using ManyToMany.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManyToMany.DataAccess
{
    public class MyContext:DbContext
    {
        public MyContext():base("MyManyDb")
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
                    
        }
    }
}
