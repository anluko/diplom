using System.ComponentModel.DataAnnotations.Schema;

namespace MobileProjectServer.Models
{
    public class Coordinates
    {
        public int Id { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public int UsersId { get; set; }
        public virtual Users Users { get; set; }
    }
}
