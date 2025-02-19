namespace Lab4_2.Domain.Models
{
    public class Class
    {
        public int Id { get; set; }
        public string ClassName { get; set; }
        public DateTime Schedule { get; set; }

        public int? TeacherId { get; set; } 
        public int CourseId { get; set; } 
        public Teacher Teacher { get; set; }
        public Course Course { get; set; }
        public ICollection<ClassEnrollment> ClassEnrollments { get; set; } = new List<ClassEnrollment>();
    }

}
