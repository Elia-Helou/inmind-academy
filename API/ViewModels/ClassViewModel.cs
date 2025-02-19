namespace Lab4_2.API.ViewModels
{
    public class ClassViewModel
    {
        public int Id { get; set; }
        public string ClassName { get; set; }
        public DateTime Schedule { get; set; }
        public TeacherViewModel Teacher { get; set; }
        public CourseViewModel Course { get; set; }
    }
}
