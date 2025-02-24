﻿using System.ComponentModel.DataAnnotations;

namespace RestAPI.Models.DTOs.ProyectoDTO;

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

    [Required(ErrorMessage = "IdAlumno is required")]
    public int IdAlumno {get; set;}

    [Required(ErrorMessage = "IdProfesor is required")]
    public int IdProfesor {get; set;}

    [Required(ErrorMessage = "Estado is required")]
    public String Estado {get; set;}
}
