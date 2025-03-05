using System.ComponentModel.DataAnnotations;

namespace RestAPI.Models.DTOs;

public class CreateProyectoDTO
{
    [Required(ErrorMessage = "Name is required")]
    [MaxLength(50, ErrorMessage = "Max char is 50")]
    public string Nombre {get; set;}

    [Required(ErrorMessage = "Descripcion is required")]
    [MaxLength(200, ErrorMessage = "Max char is 200")]
    public string Descripcion {get; set;}

    [Required(ErrorMessage = "Tipo is required")]
    [MaxLength(50, ErrorMessage = "Max char is 50")]
    public String Tipo {get; set;}


    [Required(ErrorMessage = "IdProfesor is required")]
    public string IdProfesor {get; set;}

    [Required(ErrorMessage = "Estado is required")]
    public String Estado {get; set;}
}
