using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace tp5.Models
{
    public class Predmet
    {
        [DisplayName("ID курса")]
        public int CourseId { get; set; }

        [DisplayName("Название курса")]
        public string CourseName { get; set; }

        [DisplayName("Описание курса")]
        public string Description { get; set; }

        [DisplayName("Дата начала")]  
        public DateTime StartDate { get; set; }

        [DisplayName("Дата окончания")]
        public string EndDate { get; set; }

        [DisplayName("Преподаватель")]
        public string Instructor { get; set; }

        [DisplayName("Телефон преподавателя")]
        [DataType(DataType.PhoneNumber)]
        public string InstructorPhone { get; set; }
    }
}
