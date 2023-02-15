using eShop.Data;
using eShop.Models;
using Microsoft.EntityFrameworkCore; //We need MEF to make this file as a trasnaltor between the models and the databases. Using older version of MEF for .net core 5, will migrate to 6.0 once complete
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Data
{
    public class AppDbContext: DbContext //We are inheriting from the base class "DbContext". //To make this file a sort of official translator between the models and the databases
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) //Default constructor. Takes AppDbContext as a parameter
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Actor_Movie>().HasKey(am => new
            {
                am.ActorId,
                am.MovieId
            });

            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Movie).WithMany(am => am.Actors_Movies).HasForeignKey(m => m.MovieId);
            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Actor).WithMany(am => am.Actors_Movies).HasForeignKey(m => m.ActorId);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor_Movie> Actors_Movies { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Director> Directors { get; set; }


        //Orders related tables
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
