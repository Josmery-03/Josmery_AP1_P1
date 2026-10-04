using Josmery_AP1_P1.Models;
using Microsoft.EntityFrameworkCore;

namespace Josmery_AP1_P1.Context
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }
        public DbSet<Modelo1> Modelo1 { get; set; }
    }
}