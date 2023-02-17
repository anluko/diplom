using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileProjectServer.Models
{
    public class Enter_History
    {
        public int Id { get; set; }
        public DateTime Last_Entry { get; set; }
        [MaxLength(100)]
        public string? Status { get; set; }

        public int UsersId { get; set; }
        public virtual Users Users { get; set; }
    }
}
