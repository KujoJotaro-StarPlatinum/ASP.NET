
namespace ASPNETProdactAndCategory.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public int Credits { get; set; }

        internal double Count()
        {
            throw new NotImplementedException();
        }
    }
}