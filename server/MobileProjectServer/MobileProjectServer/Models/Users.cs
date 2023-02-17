using System.ComponentModel.DataAnnotations;

namespace MobileProjectServer.Models
{
    public class Users
    {
        public int Id { get; set; }
        [MaxLength(150)]
        public string? Login { get; set; }
        [MaxLength(150)]
        public string? Nickname { get; set; }
        [MaxLength(150)]

        public string? Password { get; set; }
        [MaxLength(11)]
        public string? Phone_Number { get; set; }
        public DateTime Birthdate { get; set; }
        public string Photo_Path { get; set; }

        public virtual ICollection<Coordinates> Coordinates { get; set; }
        public virtual ICollection<Enter_History> Enter_Histories { get; set; }
        public virtual ICollection<Friends> Friends { get; set; }
        public virtual ICollection<Friends> Friends1 { get; set; }
    }
}
