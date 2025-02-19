namespace Lab4_2.Domain.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Class> Classes { get; set; } = new List<Class>();
    }

}
