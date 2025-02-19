using System.ComponentModel.DataAnnotations;

namespace Lab4_2.Domain.Models
{
    public class ClassEnrollment
    {
        [Key]
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int ClassId { get; set; }
        public Student Student { get; set; }
        public Class Class { get; set; }
    }

}
