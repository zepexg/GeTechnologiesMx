using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entity.Model
{
    public class FacturaModel: Entity<Guid>
    {
        [Required]
        [DataType(DataType.DateTime)]
        public required DateTime Fecha { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public required decimal Monto { get; set; }
        [Required]
        public required Guid PersonaId { get; set; }
        [JsonIgnore]
        public PersonaModel? Persona { get; set; }
    }
}
