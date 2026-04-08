namespace BaitapCodeFirst.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public int CourseId { get; set; }   // khóa ngoại

        public Course Course { get; set; }  // navigation
    }
}
