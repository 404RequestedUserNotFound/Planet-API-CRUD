using Planet_API_CRUD.EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Planet_API_CRUD.EF
{
    public class PlanetContext : DbContext
    {
        public DbSet<Planet> Planets { get; set; }
    }
}