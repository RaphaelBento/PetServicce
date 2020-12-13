using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetServicce.Model
{
    public class GravarUsuarioContext : DbContext
    {
        public GravarUsuarioContext(DbContextOptions<GravarUsuarioContext> options) : base(options)
        { }

        public GravarUsuarioContext()
        {
        }

        public DbSet<Cadastro> Cadastros { get; set; }
        public DbSet<CartaoDeVacinacao> CartaoDeVacinacaos { get; set; }


}
}
