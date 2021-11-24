using IVVUO.INTEGRACIONES.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MARESA.INTEGRACIONES.Infraestructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public virtual DbSet<OrdenesEntity> Ordenes { get; set; } //Reconoce una tabla
        public virtual DbSet<InventoryEntity> Inventory { get; set; } //Reconoce una tabla
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrdenesEntity>().HasNoKey(); //Por si no tiene llave primaria, no genere error al ejecutar
            modelBuilder.Entity<InventoryEntity>().HasNoKey(); //Por si no tiene llave primaria, no genere error al ejecutar
        }
    }
}
