using EcommerceMVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceMVC
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set;}
        public DbSet<ItemPedido> ItemPedido { get; set; }
        public DbSet<Cadastro> Cadastro { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Server=(localdb)\mssqllocaldb;Database=E-CommerceMVC; Integrated Security=True");
        }

        // Relacionamento das Classes

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // relacionando que o pedido vai com muitos itens(HasMany) e os itens retornam um pedido (WithOne) 
            modelBuilder.Entity<Pedido>().HasMany(t => t.Itens).WithOne(t => t.Pedido);

            // relacionando(assegurando) que o itens do pedido vão paenas para pedido (HasOne)
            modelBuilder.Entity<ItemPedido>().HasOne(t => t.Pedido);

            // relacionando(assegurando) que itens do pedido vão apenas com produtos (HasOne)
            modelBuilder.Entity<ItemPedido>().HasOne(t => t.Produto);

            // relacionando que cada pedido vai para cadastro (HasOne) e que cada pedido vai apenas para um cadastro(WithOne)
            modelBuilder.Entity<Pedido>().HasOne(t => t.Cadastro).WithOne(t => t.Pedido).IsRequired();

            // relacionando (assegurando) que o cadastro vai com pedido (HasOne) 
            modelBuilder.Entity<Cadastro>().HasOne(t => t.Pedido);
        }


    }

}
