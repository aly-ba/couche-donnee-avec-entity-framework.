using ASPNET5Samurai.Models;
using Microsoft.Data.Entity;
using System;

namespace ASPNET5Samurai.DataModel
{
    public class SamuraiContext :DbContext
    {
        public DbSet<Samurai> Samurais { get; set; }

    }
}