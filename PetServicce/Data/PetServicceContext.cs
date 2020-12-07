using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PetServicce.Model;

namespace PetServicce.Data
{
    public class PetServicceContext : DbContext
    {
        public PetServicceContext (DbContextOptions<PetServicceContext> options)
            : base(options)
        {
        }
        public DbSet<CartaoDeVacinacao> CartaoDeVacinacaos { get; set; }
        public DbSet<PetServicce.Model.Cadastro> Cadastro { get; set; }
    }
}
