using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Avia.DataAccessLayer.Entities
{
    [Table("Cities", Schema = "dbo")]
    public record CityEntity
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
