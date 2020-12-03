using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetServicce.Model
{
    public class GravarUsuario : DbContext
    {
        public GravarUsuario(DbContextOptions<GravarUsuario> options) : base(options)
        { }

        public DbSet<Cadastro> Cadastros { get; set; }

    }
}
