using ManyToMany.DataAccess;
using ManyToMany.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ManyToMany
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            LoadData();
        }

        public async void LoadData()
        {
            List<Student> students = null;
            List<Course> courses = null;

            using (var context=new MyContext())
            {
                context.Database.CreateIfNotExists();

                students = await context.Students.ToListAsync();
                if (students.Count == 0)
                {
                    context.Students.Add(new Student
                    {
                        Firstname="John",
                        Lastname="Johnlu"
                    });

                    context.Students.Add(new Student
                    {
                        Firstname="Aysel",
                        Lastname="Mammadova"
                    });

                    context.Students.Add(new Student
                    {
                        Firstname = "Rafiq",
                        Lastname = "Rafiqli"
                    });

                    context.Students.Add(new Student
                    {
                        Firstname = "Mike",
                        Lastname = "Novruzlu"
                    });

                    context.Courses.Add(new Course
                    {
                        CourseName="Step IT Academy",
                        Address="Koroglu Rehimov"
                    });

                    context.Courses.Add(new Course
                    {
                        CourseName="Elvin Academy",
                        Address="Port Baku Mall 2F"
                    });

                    await context.SaveChangesAsync();

                    var s1=await context.Students.SingleOrDefaultAsync(s=>s.Id==1);
                    var s2=await context.Students.SingleOrDefaultAsync(s=>s.Id==2);
                    var s3=await context.Students.SingleOrDefaultAsync(s=>s.Id==3);
                    var s4=await context.Students.SingleOrDefaultAsync(s=>s.Id==4);

                    var c1 = await context.Courses.SingleOrDefaultAsync(c => c.Id == 1);
                    var c2 = await context.Courses.SingleOrDefaultAsync(c => c.Id == 2);

                    s1.Courses.Add(c1);

                    s2.Courses.Add(c1);
                    s2.Courses.Add(c2);

                    s3.Courses.Add(c1);
                    s3.Courses.Add(c2);

                    s4.Courses.Add(c2);


                    await context.SaveChangesAsync();

                }

                students = await context.Students.ToListAsync();
                courses = await context.Courses.ToListAsync();

                studentsGrid.ItemsSource = students;
                coursesGrid.ItemsSource = courses;
            }
        }

        private async void coursesGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = coursesGrid.SelectedItem as Course;
            if (item != null)
            {
                using (var context=new MyContext())
                {
                    try
                    {
                        var course=await context
                            .Courses
                            .FirstOrDefaultAsync(c => c.Id == item.Id);

                        if (course != null)
                        {
                            var students = course.Students;
                            studentsGrid.ItemsSource = students;
                        }
                    }
                    catch(Exception ex)
                    {

                    }
                }
            }
        }

        private void studentsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
