﻿namespace RestAPI.Models.DTOs.UserDto
{
    public class UserDto
    {
       public string Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public string Rol { get; set; }
        public int Telefono { get; set; }

    }
}
