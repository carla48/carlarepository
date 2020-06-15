using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AcaiAPI.Model;

namespace AcaiAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pedido>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Pedido>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<Personalizacao>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<PedidoPersonalizacao>()
                .HasKey(x => new { x.PedidoId, x.PersonalizacaoId });

            modelBuilder.Entity<PedidoPersonalizacao>()
                .HasOne(x => x.Pedido)
                .WithMany(m => m.Personalizacoes)
                .HasForeignKey(x => x.PedidoId);

            modelBuilder.Entity<PedidoPersonalizacao>()
                .HasOne(x => x.Personalizacao)
                .WithMany(m => m.Pedidos)
                .HasForeignKey(x => x.PersonalizacaoId);

            var config = modelBuilder.Entity<PedidoPersonalizacao>();
            config.ToTable("pedidospersonalizacoes");

            base.OnModelCreating(modelBuilder);
        }                  
        public DbSet<Pedido> Pedidos { get; set; }

        public DbSet<Sabor> Sabores { get; set; }

        public DbSet<Tamanho> Tamanhos { get; set; }

        public DbSet<Personalizacao> Personalizacoes { get; set; }

        public DbSet<PedidoPersonalizacao> PedidoPersonalizacoes { get; set; }
    }
}
