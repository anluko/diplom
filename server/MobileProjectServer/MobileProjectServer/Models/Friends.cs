using System.ComponentModel.DataAnnotations;

namespace MobileProjectServer.Models
{
    public class Friends
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string? Friendship_Type { get; set; }

        public int FirstUsersId { get; set; }
        public int SecondUsersId { get; set; }
        public virtual Users FirstUsers { get; set; }
        public virtual Users SecondUsers { get; set; }
    }
}
