using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FintrakAcademy3._0.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("first name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("last name")]
        public string LastName { get; set; }
        [Required]
        [DisplayName("other name")]
        public string OtherName { get; set; }
        [Required]
        [DisplayName("address")]
        public string Address { get; set; }
        [Required]
        [Range(22,35, ErrorMessage = "age must be between 22 and 35 only!!")]
        [DisplayName("age")]
        public int Age { get; set; }
        [Required]
        [DisplayName("email")]
        public string Email { get; set; }
        [Required]
        [DisplayName("preferred sub-Unit")]
        public string PreferredSBU { get; set; }
        [Required]
       
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;





    }
}
