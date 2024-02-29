using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Entity.Model
{
    public class PersonaModel : Entity<Guid>
    {

        [Required]
        [MaxLength(200)]
        public required string Nombre { get; set; }

        [Required]
        [MaxLength(200)]
        public required string ApellidoPaterno { get; set; }

        [AllowNull]
        [MaxLength(200)]
        public string? ApellidoMaterno { get; set; }

        [Required]
        [MaxLength(20)]
        public required string Identificacion { get; set; }
        [JsonIgnore]
        public List<FacturaModel>? Facturas { get; set; }
    }
}
