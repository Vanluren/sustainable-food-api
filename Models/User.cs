using System;
using System.ComponentModel.DataAnnotations;

namespace sustainable_food_api.Models
{
    public class User
    {
        public User() { }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

