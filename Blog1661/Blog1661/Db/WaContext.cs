using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Models
{
    public class WaContext : DbContext
    {
        public WaContext (DbContextOptions<WaContext> options)
            : base(options)
        {
        }

        public DbSet<Categoria> Categoria { get; set; }

        public DbSet<Comentario> Comentario { get; set; }

        public DbSet<Mensagem> Mensagem { get; set; }

    }
}
