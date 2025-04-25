using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace tp5.Models
{
    public class Dance
    {
        [DisplayName("ID занятий")]
        public int CourseId { get; set; }

        [DisplayName("ID танцора")]
        public int DancerId { get; set; }

        [DisplayName("ФИО")]
        [Required(ErrorMessage = "Поле ФИО обязательно для заполнения")]
        public string FIO { get; set; }

        [DisplayName("Возраст")]
        public int Age { get; set; }

        [DisplayName("Стиль танца")]
        public string StyleDance { get; set; }

        [DisplayName("Время занятий")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}")]
        public DateTime StartDate { get; set; }

        [DisplayName("Денежные сборы")]
        public decimal Money { get; set; }

        [DisplayName("Телефон родителя")]
        [DataType(DataType.PhoneNumber)]
        public string ParentPhone { get; set; }
    }
}
