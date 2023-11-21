﻿using System.ComponentModel.DataAnnotations;

namespace SkiServiceDatenbank.models
{
    public class SkiService
    {
        [Key]
        public int Id { get; set; }

        
        public string? Kundenname { get; set; }

        
        public string? Email { get; set; }

        
        public string? Telefon { get; set; }

      
        public string? Priorität { get; set; }

       
        public string? Dienstleistung { get; set; }

    }
}
