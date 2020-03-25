using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Config
{
    public class ContextBase : DbContext
    {
        public DbSet<Anuncio> Anuncio { get; set; }

        public ContextBase(DbContextOptions<ContextBase> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConnectionString());
            }
        }

        private string GetConnectionString()
        {
            return @"Server=DESKTOP-JH6V1J8\SQLEXPRESS;Database=Gol;Trusted_Connection=True;";
        }
    }
}
