using Microsoft.EntityFrameworkCore;
using Pizzeria.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzeria.DAL
{
    public class PizzeriaContext : DbContext
    {
        public DbSet<Plat> Plats { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Commande> Commandes { get; set; }
        public DbSet<Plat_Commande> Plat_Commandes { get; set; }
        public PizzeriaContext(DbContextOptions options) : base(options){}
    }
}
