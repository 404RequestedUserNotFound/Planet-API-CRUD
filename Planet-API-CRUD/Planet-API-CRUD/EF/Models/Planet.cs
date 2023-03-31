using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Planet_API_CRUD.EF.Models
{
    public class Planet
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public string Type { get; set; }
        public int Moons { get; set; }
        public int DistanceFromSun { get; set; }
    }
}