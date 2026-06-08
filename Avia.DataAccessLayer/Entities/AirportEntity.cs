using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Avia.DataAccessLayer.Entities
{
    [Table("Airports", Schema = "dbo")]
    public record AirportEntity
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
    }
}
