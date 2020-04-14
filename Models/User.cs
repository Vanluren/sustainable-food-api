using System;
using System.Data.Spatial;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace sustainable_food_api.Models
{
    public class User
    {
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DbGeography Location { get; set; }
    }
}

