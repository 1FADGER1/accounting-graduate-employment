﻿using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class SelfEmploymentViewModel
    {
        public int ID { get; set; }
        public int IDStatus { get; set; }
        public string? TypeActivity { get; set; }
    }
}
