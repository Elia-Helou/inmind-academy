namespace Lab4_2.Domain.Models
{
   public class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public int Credits { get; set; }
        
        public ICollection<Class> Classes { get; set; } = new List<Class>();
    }

}
