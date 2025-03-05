using System.Text.Json.Serialization;


namespace InfoManager.Models
{
    public class ProyectoDTO
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("tipo")]
        public string Tipo { get; set; }

        [JsonPropertyName("id_alumno")]
        public int Id_alumno { get; set; }

        [JsonPropertyName("id_profesor")]
        public int Id_profesor { get; set; }

        [JsonPropertyName("estado")]
        public string Estado { get; set; }

    }
    }

  
  





