using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProiectPapetarie.Models;

namespace ProiectPapetarie.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //adaugare structura tabele
        public DbSet<Categorie> Categorii { get; set; }
        public DbSet<Comanda> Comenzi { get; set; }
        public DbSet<DetaliiComanda> DetaliiComenzi { get; set; }
        public DbSet<CosCumparaturi> CosuriCumparaturi { get; set; }
        public DbSet<DetaliiCosCump> DetaliiCosCump { get; set; }
        public DbSet<Produs> Produse { get; set; }
        public DbSet<StatusComanda> StatusuriComenzi { get; set; }
    }
}